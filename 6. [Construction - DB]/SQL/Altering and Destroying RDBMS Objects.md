Altering and Destroying RDBMS Objects
---

##Tables

###ALTER TABLE statement

MS SQL Server allows you to change a data type and collation sequence for existing columns, add new and drop existing columns, add or drop constraints, and disable or enable table triggers:3

```
ALTER TABLE [<qualifier>.]<table_name>
(
  [ALTER COLUMN <column_name> 
                <new_datatype> [<size1>[,<size2>]
  ]
  [COLLATE <collation_name>] |
  [ADD <new_column_definition> [<column_constraint>,...]] |
  [DROP COLUMN <column_name>,...]
  [ADD <table_constraint>,...] |
  [DROP CONSTRAINT <constraint_name>] |
  [{ENABLE | DISABLE} TRIGGER {ALL | <trigger_name>,...}]
)
```

####Adding new columns to a table

```
ALTER TABLE PHONE
ADD PHONE_PRIMARY_S   CHAR(1) DEFAULT 'Y'
                      CONSTRAINT chk_phoneprim
                      CHECK (PHONE_PRIMARY_S IN ('Y', 'N')),
PHONE_CATEGORY_S  CHAR(15)
```

####Modifying existing columns

For example, you cannot change the data type of a column on which a constraint is based or give it a default value. You also are unable to alter columns with TEXT, NTEXT, IMAGE, or TIMESTAMP data types. Some more restrictions apply; see vendor's documentation for details. 

Unlike in Oracle, you can decrease the size of a nonempty column as long as all existing data fits the new size. For example, MS SQL Server would let you decrease the size of the PHONE_TYPE_S column from VARCHAR(20) to VARCHAR(10) or even VARCHAR(5) because the longest string stored in this column PHONE is only five characters long

```
ALTER TABLE PHONE
ALTER COLUMN PHONE_TYPE_S VARCHAR(5)
```

MS SQL Server behaves similarly with numeric columns. You can decrease the scale, but only down to the size of the biggest column value

```
ALTER TABLE ORDER_LINE
ALTER COLUMN ORDLINE_ORDQTY_N NUMERIC(3)
```

####Removing table columns

For example, a column cannot be dropped if it is used in an index or in a constraint; associated with a default; or bound to a rule.

```
ALTER TABLE PHONE
DROP COLUMN PHONE_PRIMARY_S, PHONE_CATEGORY_S
```

####Creating and removing constraints

```
ALTER TABLE salesman
ADD CONSTRAINT uk_salesmancode UNIQUE (salesman_code_s);

ALTER TABLE SALESMAN
DROP CONSTRAINT uk_salesmancode;
```

---

##DROP TABLE statement

DROP TABLE is a part of DDL and is therefore irreversible. Specifically, it is committed to the database immediately without possibility of a rollback. Use it with extreme care.

```
DROP TABLE [<qualifier>.]<table_name>
```

Unlike Oracle, MS SQL Server would not let you drop a table in which a primary key is referenced by any foreign key. To drop the table CUSTOMER you would have to drop the referential integrity constraints FK_ADDR_CUST, FK_PHONE_CUST, and FK_ORDHDR_CUSTOMER first: 

---

##Indexes

As we already know, indexes are invisible for most database users, so in most cases they would not need to change indexes. Also, you can always drop and re-create an index rather than modify it. 

You have to specify both the table name in which the indexed column is located and the index name:

```
DROP INDEX phone.idx_phone_cust
```

---

###Reorganize and Rebuild Indexes

####Detecting Fragmentation

The first step in deciding which defragmentation method to use is to analyze the index to determine the degree of fragmentation. By using the system function sys.dm_db_index_physical_stats, you can detect fragmentation in a specific index, all indexes on a table or indexed view, all indexes in a database, or all indexes in all databases. For partitioned indexes, sys.dm_db_index_physical_stats also provides fragmentation information for each partition.

  - avg_fragmentation_in_percent : The percent of logical fragmentation (out-of-order pages in the index).
  - fragment_count :The number of fragments (physically consecutive leaf pages) in the index.
  - avg_fragment_size_in_pages : Average number of pages in one fragment in an index.
  
After the degree of fragmentation is known, use the following table to determine the best method to correct the fragmentation.

  - avg_fragmentation_in_percent value : > 5% and < = 30% - ALTER INDEX REORGANIZE
  - avg_fragmentation_in_percent value : > 30% - ALTER INDEX REBUILD WITH (ONLINE = ON)
  
  ```
  SELECT a.index_id, name, avg_fragmentation_in_percent  
  FROM 
  sys.dm_db_index_physical_stats 
  (DB_ID(N'AdventureWorks2012'), OBJECT_ID(N'HumanResources.Employee'), NULL, NULL, NULL) AS a  
  JOIN sys.indexes AS b ON a.object_id = b.object_id AND a.index_id = b.index_id;   
  ```
  
  ```
  ALTER INDEX IX_Employee_OrganizationalLevel_OrganizationalNode ON HumanResources.Employee  
  REORGANIZE ; 
  ```
  ```
  ALTER INDEX PK_Employee_BusinessEntityID ON HumanResources.Employee
  REBUILD;
  ```
  
---
  
##ALTER VIEW 
  
The ALTER VIEW in MS SQL Server enables you to change view columns, underlying select statements, and other view options without affecting dependent database objects or changing permissions (which would be different had you used DROP VIEW and CREATE VIEW statements). The syntax is practically the same as for CREATE VIEW: 
  
```
ALTER VIEW [<qualifier>.]<view_name>
[(<column_name>,...)]
[WITH {ENCRYPTION|SCHEMABINDING|VIEW_METADATA}]
AS <select_statement>
[WITH CHECK OPTION]
```

---

###DROP VIEW statement

```
DROP VIEW <view_name> [,...]
```
  
