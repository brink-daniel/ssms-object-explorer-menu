-- Category:	EXPERIMENTAL
-- Name:		last_restored.sql
-- Description:	Get last restore date for all databases
-- Project:		https://github.com/brink-daniel/ssms-object-explorer-menu
--				Tags; {SERVER}, {DATABASE}, {SCHEMA}, {TABLE}, {VIEW}, {STORED_PROCEDURE}, {FUNCTION} & {JOB} are replaced by the SSMSObjectExplorerMenu extension.

select 
	d.[name] as [database]
	, d.state_desc
	, x.restore_date
	, b.server_name as [source_server]
	, b.[user_name] as [source_user]
	, b.[name] as [backup_name]
	
from
	sys.databases as d
	
	left join (
		select
			h.destination_database_name as db
			, max(h.restore_date) as restore_date
			, max(h.backup_set_id) as backup_set_id
		from msdb.dbo.restorehistory as h
		group by h.destination_database_name
	
	) as x
	on d.[name] = x.db
	
	left join msdb.dbo.backupset as b 
	on x.backup_set_id = b.backup_set_id
	
order by x.restore_date desc;
