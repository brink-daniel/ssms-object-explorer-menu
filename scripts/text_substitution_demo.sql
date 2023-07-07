--This script is designed to be executed using SQLMedic's SSMSObjectExplorerMenu extension.
--The extension will replace the DATABASE, SCHEMA & TABLE tags with valid values before executing the script

--Demo of text substitution feature

use {DATABASE}
go

set nocount on;
go

select
    '{SERVER}' as [server]
    , '{DATABASE}' as [database]
    , '{SCHEMA}' as [schema]
    , '{TABLE}' as [table]
    , '{STORED_PROCEDURE}' as [stored_procedure]
