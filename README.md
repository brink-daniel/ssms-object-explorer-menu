
# [SSMS Object Explorer Menu](https://github.com/brink-daniel/ssms-object-explorer-menu)

Extension for SQL Server Management Studio 19.1, allowing custom menu items to be added to the right-click context menu in the Object Explorer window. The menu items can be used to execute any tsql script file or inline tsql statement.

![Object Explorer](ObjectExplorer.png)

Source code, documentation and issues can be found at <https://github.com/brink-daniel/ssms-object-explorer-menu>

Information on how to access the Object Explorer and TreeView control was learnt by studying the [SSMS-Schema-Folders](https://github.com/nicholas-ross/SSMS-Schema-Folders) project by Nicholas Ross.


## Compatibility

This extension has only been tested and used with SQL Server Management Studio 19.1.

You can download the latest version of SSMS for free from [Microsoft](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).

This extension has not been tested alongside any other extensions. 


## Install

[Download the latest release](https://github.com/brink-daniel/ssms-object-explorer-menu/releases)

You must unblock the zip file **before** extracting it. Right click on the zip file in Windows Explorer and select Properties. 
If you see an `Unblock` button or checkbox then click it. 

Extract the zip file and copy the SSMSObjectExplorerMenu folder into the SSMS extension folder. Remove or replace any previous version. 

The default install location is `C:\Program Files (x86)\Microsoft SQL Server Management Studio 19\Common7\IDE\Extensions`

Please note that SSMS 19 does allow installing extensions in a different location. You may need to search around for the Extensions folder.


## Settings

Up to 20 menu items can be configured via the Options dialog window in SSMS 
`Tools > Options > SQL Server Object Explorer > SQLMedic`

* Context - Set the tree node level where to display the menu item.
* Enabled - Show/hide the menu item.
* Execute - Automatically run the selected script or tsql statements.
* Name - Text displayed on the menu item.
* Path - Location of script file to execute OR tsql statements to execute.

![Options Dialog](Options.png)

### Text substitution

The following tags are replaced in tsql scripts and statements before execution:

* `{SERVER}`
* `{DATABASE}`
* `{SCHEMA}`
* `{TABLE}`
* `{STORED_PROCEDURE}`

### Sample scripts

| Context | Script |
|---------|--------|
| All | [text_substitution_demo.sql](https://github.com/brink-daniel/ssms-object-explorer-menu/blob/main/scripts/text_substitution_demo.sql) |


## Known Issues

### Not running/No options
This happens when Windows security blocks dll files downloaded from the internet. Unblock the zip file BEFORE extracting it.

Please report any issues to <https://github.com/brink-daniel/ssms-object-explorer-menu/issues>.


## Change Log

### v1.0 (2023-07-04)
* Public beta release.
