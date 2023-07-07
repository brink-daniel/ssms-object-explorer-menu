--This script is designed to be executed using SQLMedic's SSMSObjectExplorerMenu extension.
--The extension will replace the DATABASE, SCHEMA & TABLE tags with valid values before executing the script

--Run tSQLt unit test for stored procedure.

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

--create unit text if not exists
if object_id('test.[test {SCHEMA}.{STORED_PROCEDURE}]') is null
begin
	exec ('
		create procedure test.[test {SCHEMA}.{STORED_PROCEDURE}]
		as
		begin
			exec tSQLt.Fail ''No test defined'';
		end
	');
end
go

--run unit test
exec tSQLt.Run @TestName = 'test.[test {SCHEMA}.{STORED_PROCEDURE}]';
go