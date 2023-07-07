--This script is designed to be executed using SQLMedic's SSMSObjectExplorerMenu extension.
--The extension will replace the DATABASE, SCHEMA & TABLE tags with valid values before executing the script

--Run all tSQLt unit tests

use {DATABASE}
go

set nocount on;
go

--create unit test class if not exists
if not exists (
	select * from sys.extended_properties 
	where 
		name = 'tSQLt.TestClass' 
		and class_desc = 'SCHEMA' and [value] = 1
		and major_id = (select top 1 schema_id from sys.schemas where name = 'test')
)
begin
	exec tSQLt.NewTestClass 'test';
end
go

--ensure unit tests exist for all stored procedures
select 
	s.name + '.' + p.name as StoredProc
into #StoredProcs
from 
	sys.procedures as p

	inner join sys.schemas as s
	on p.schema_id = s.schema_id

where s.name not in ('tSQLt', 'test');

while exists (select * from #StoredProcs)
begin
	declare @StoredProc nvarchar(800) = null;
	
	select top 1
		@StoredProc = StoredProc
	from #StoredProcs;

	delete from #StoredProcs
	where StoredProc = @StoredProc;

	--create unit text if not exists
	if object_id(N'test.[test ' + @StoredProc + N']') is null
	begin
		exec (N'
			create procedure test.[test ' + @StoredProc + N']
			as
			begin
				exec tSQLt.Fail ''No test defined'';
			end
		');
	end
end --while

drop table if exists #StoredProcs;
go

--run all unit tests
exec tSQLt.RunAll;
go