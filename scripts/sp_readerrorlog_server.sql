-- Category:	EXPERIMENTAL
-- Name:		sp_readerrorlog_server.sql
-- Description:	Read the SQL Server error log
-- Project:		https://github.com/brink-daniel/ssms-object-explorer-menu
--				Tags; {SERVER}, {DATABASE}, {SCHEMA}, {TABLE} & {STORED_PROCEDURE} are replaced by the SSMSObjectExplorerMenu extension.

exec sp_readerrorlog
	@p1 = 0 --0=current, 1=previous, 2, 3, ...
	, @p2 = 1 --1=Server, 2=Agent
	, @p3 = null --first search string
	, @p4 = null; --second search string