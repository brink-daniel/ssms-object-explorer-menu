--EXPERIMENTAL

--This script is designed to be executed using SQLMedic's SSMSObjectExplorerMenu extension.
--The extension will replace the DATABASE, SCHEMA & TABLE tags with valid values before executing the script

--Script table data as an insert statement. 

declare 
	@Database varchar(250) = '{DATABASE}'
	, @Schema varchar(250) = '{SCHEMA}'
	, @Table varchar(250) = '{TABLE}'
	, @Top int = 10
	, @IncludeIdentity bit = 0

/*
select
	@Database = 'AdventureWorks2022'
	, @Schema = 'HumanResources'
	, @Table = 'Department'
*/

begin
	set nocount on;
	
	declare @table_qualified_name varchar(250) = '[' + @Database + '].[' + @Schema + '].[' + @Table + ']';

	if object_id(@table_qualified_name) is null
	begin
		declare @err1 varchar(8000) = 'Error: Table ' + @table_qualified_name + ' not found';
		raiserror(@err1, 16, 1);
		return; 
	end
	

	if @Top > 1000
	begin
		set @Top = 1000;
		print 'Warning: The Table Value Constructor used in this script only supports up to 1000 rows. @Top parameter changed to 1000;';
	end
	
	
	create table #columns (
		column_id int
		, column_name varchar(250)
		, column_type varchar(250)
		, quote_value bit
		, is_identity bit	
	);
	
	declare @columns_query nvarchar(max) = '	
	
	select 
		c.column_id
		, c.name as column_name
		, t.name as column_type
		, case when (select top 1 x.name from sys.types as x where x.system_type_id = t.system_type_id) in (
				''bigint'', ''binary'', ''bit''
				, ''decimal'', ''float'', ''int''
				, ''numeric'', ''real'', ''smallint''
				, ''tinyint'', ''binary'', ''money''
				, ''smallmoney'', ''varbinary'') then 0 else 1 end as quote_value
		, is_identity

	from 
		[' + @Database + '].sys.columns as c 

		inner join [' + @Database + '].sys.types as t
		on c.user_type_id = t.user_type_id
			and t.name != ''timestamp''

	where 
		c.object_id = object_id(@table_qualified_name)
		and (c.is_identity = 0 or (@IncludeIdentity = 1 and c.is_identity = 1))
		and c.is_computed = 0

	order by c.column_id;
	
	';
	
	insert into #columns (column_id, column_name, column_type, quote_value, is_identity)	
	exec sp_executesql 
		@columns_query
		, N'@table_qualified_name varchar(250), @IncludeIdentity bit'
		, @table_qualified_name = @table_qualified_name
		, @IncludeIdentity=@IncludeIdentity;
	
		
	declare @out nvarchar(max) = '';

	if exists (select * from #columns where is_identity = 1)
	begin
		set @out += 'set identity_insert ' + @table_qualified_name + ' on;' + char(10)
	end
	
	
	set @out += 'insert into ' + @table_qualified_name +' (';
	
	select 
		@out += '[' + column_name + '], ' 
	from #columns
	order by column_id;

	set @out = substring(@out, 1, len(@out) - 1);
	set @out += ')' + char(10)
	set @out += 'values '

	
	
	declare @sql nvarchar(max) = '';	
	set @sql += 'select top (' + cast(@Top as varchar(50)) + ') ';
	set @sql += ' char(10) + char(9) + '', (';
	select 
		@sql +=
			case
				when column_type = 'smalldatetime' then
					''' + isnull('''''''' + convert(nvarchar(max), [' + column_name + '], 20) + '''''''', ''null'') + ''' + ', '			

				when column_type = 'datetime' then
					''' + isnull('''''''' + convert(nvarchar(max), [' + column_name + '], 21) + '''''''', ''null'') + ''' + ', '

				when column_type = 'money' or column_type = 'smallmoney' then
					''' + isnull(convert(nvarchar(max), [' + column_name + '], 2), ''null'') + ''' + ', '
					
				else 		
					case 
						when quote_value = 1 then 
							''' + isnull('''''''' + replace(cast([' + column_name + '] as nvarchar(max)), '''''''', '''''''''''') + '''''''', ''null'') + ''' + ', '
						else 
							''' + isnull(cast([' + column_name + '] as nvarchar(max)), ''null'') + ''' + ', '
					end					
			end
	from #columns
	order by column_id;

	set @sql = substring(@sql, 1, len(@sql) - 1);
	set @sql += ')'' as table_row ';
	set @sql += 'from ' + @table_qualified_name + ';'; 


	create table #data (
		table_row nvarchar(max)	
	);

	insert into #data (table_row)
	exec (@sql);

	select 
		@out += table_row
	from #data

	set @out = @out + ';'  + char(10);

	set @out = replace(@out,'values ' + char(10) + char(9) + ',', 'values ' + char(10) + char(9) + ' ');

	if exists (select * from #columns where is_identity = 1)
	begin
		set @out += 'set identity_insert ' + @table_qualified_name + ' off;' + char(10)
	end

	print @out;
	select @out as [Insert_Statement];

	drop table if exists #columns, #data;
end
go


