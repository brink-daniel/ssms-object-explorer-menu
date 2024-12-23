-- Category:	EXPERIMENTAL
-- Name:		text_substitution_demo.sql
-- Description:	Demo of SSMSObjectExplorerMenu extension.
-- Project:		https://github.com/brink-daniel/ssms-object-explorer-menu
--				Tags; {SERVER}, {DATABASE}, {SCHEMA}, {TABLE}, {VIEW}, {STORED_PROCEDURE}, {FUNCTION} & {JOB} are replaced by the SSMSObjectExplorerMenu extension.

use {DATABASE}
go

set nocount on;
go

select
	'{SERVER}' as [server]
	, '{DATABASE}' as [database]
	, '{SCHEMA}' as [schema]
	, '{TABLE}' as [table]
	, '{VIEW}' as [view]
	, '{STORED_PROCEDURE}' as [stored_procedure]
	, '{FUNCTION}' as [function]
	, '{JOB}' as [job]
	, '{YYYY-MM-DD}' as [date]
	, '{HH:mm:ss}' as [time]
	, '{YYYY-MM-DD HH:mm:ss}' as [datetime]
