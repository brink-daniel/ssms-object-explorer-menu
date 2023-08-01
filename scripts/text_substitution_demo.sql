-- Category:	EXPERIMENTAL
-- Name:		text_substitution_demo.sql
-- Description:	Demo of SSMSObjectExplorerMenu extension.
-- Project:		https://github.com/brink-daniel/ssms-object-explorer-menu
--				Tags; {SERVER}, {DATABASE}, {SCHEMA}, {TABLE}, {STORED_PROCEDURE}, {FUNCTION} & {JOB} are replaced by the SSMSObjectExplorerMenu extension.

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
    , '{FUNCTION}' as [function]
    , '{JOB}' as [job]
