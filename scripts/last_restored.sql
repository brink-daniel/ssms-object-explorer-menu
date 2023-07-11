-- Category:	EXPERIMENTAL
-- Name:		last_restored.sql
-- Description:	Get last restore date for all databases
-- Project:		https://github.com/brink-daniel/ssms-object-explorer-menu
--				Tags; {SERVER}, {DATABASE}, {SCHEMA}, {TABLE} & {STORED_PROCEDURE} are replaced by the SSMSObjectExplorerMenu extension.

select
	a.name
	, a.restore_date as last_restored
	
from 
	(
		select
			*
			, row_number() over (partition by d.Name order by r.restore_date desc) as RowNumber
						
		from 
			sys.databases as d
	
			left join msdb.dbo.restorehistory as r
			on d.Name = r.destination_database_name
	) as a

where a.RowNumber = 1;