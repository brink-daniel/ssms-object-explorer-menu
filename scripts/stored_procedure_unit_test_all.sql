--Category:		EXPERIMENTAL
--Name:			stored_procedure_unit_test_all.sql
--Description:	Run all tSQLt unit tests. If a stored procedure does not have a unit test, a unit test is created for it. 
--Project:		https://github.com/brink-daniel/ssms-object-explorer-menu
--				Tags; {SERVER}, {DATABASE}, {SCHEMA}, {TABLE} & {STORED_PROCEDURE} are replaced by the SSMSObjectExplorerMenu extension.

use {DATABASE}
go

set nocount on;
go

--create unit test "test" class if not exists
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

--ensure unit tests exist for all stored procedures in the "test" class
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

	--create unit test if not exists
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