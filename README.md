# DB_ObjectTransfer
Transfers objects (tables and indexes) DB_ObjectTransfer from one database to another

## Problem 
Especially after DBCC corruptions almost all of the recommendations ends up in creating new database and transferring all the schema objects 
and data. For my case i had 28000 tables in one of my databases. I thought writing SSIS packages, script work, etc. It was hard to manage erroneous
cases so i ended up writing an application. 

## Solution
DB_ObjectTransfer can connect to two databases and transfer tables and indexes with data. 