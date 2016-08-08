Creating database objects
---

##Tables

Tables are the central and the most important objects in any relational database. The primary purpose of any database is to hold data that is logically stored in tables.

```
CREATE [{GLOBAL | LOCAL}
			 TEMPORARY] TABLE <table_name> (
			 <column_name> [<domain_name> | <datatype>
			 [<size1>[,<size2>] ] [<column_constraint>,...] [DEFAULT
			 <default_value>] [COLLATE <collation_name>],...
			 [<table_constraints>] [ON COMMIT {DELETE | PRESERVE} ROWS]
			 )
```
There are two types of temporary tables: local and global. Local temporary tables are visible only to their creators during the same connection to an instance of SQL Server as when the tables were first created or referenced. Local temporary tables are deleted after the user disconnects from the instance of SQL Server. Global temporary tables are visible to any user and any connection after they are created, and are deleted when all users that are referencing the table disconnect from the instance of SQL Server.

---

###Column constraints

Each column can have one or more column constraints.

NOT NULL means that the NULL values are not permitted in the column.

UNIQUE means all values in the column must be distinct values; NULLs are permitted.

PRIMARY KEY specifies that all column values must be unique and the column can't contain NULLs. In other words, it's a combination of the above two constraints.

REFERENCES means the column is a foreign key to the referenced table.

CHECK verifies that the column values obey certain rules; for example, only positive numbers are permitted, or only a certain set of strings is valid.

```
CREATE TABLE salesman ( 
        salesman_id_n INT CONSTRAINT pk_salesmanprim PRIMARY  KEY,
        salesman_code_s VARCHAR (2) CONSTRAINT uk_salescode UNIQUE,
        salesman_name_s VARCHAR (50) NOT NULL,
        salesman_status_s CHAR (1) CONSTRAINT chk_salesstatus  CHECK  (salesman_status_s in ('N', 'Y')) 
		)
			  
CREATE  TABLE address (  
        addr_id_n INT CONSTRAINT pk_addrprimary PRIMARY KEY, addr_custid_fn INT,
        addr_salesmanid_fn INT CONSTRAINT fk_addr_salesman REFERENCES salesman (salesman_id_n),
        addr_address_s VARCHAR(60),   
        addr_type_s VARCHAR(8) CONSTRAINT chk_addr_type CHECK  (addr_type_s IN ('BILLING', 'SHIPPING')),
        addr_city_s VARCHAR(18) CONSTRAINT nn_addr_city NOT NULL, addr_state_s CHAR(2),  
        addr_zip_s  VARCHAR(10) NOT NULL, addr_country_s CHAR(3) 
		)
```

---

### Column default values

Each column can optionally be given a default value (in range of its data type). In this case, if an INSERT statement omits the column, the default value will automatically be populated: 
```
CREATE TABLE product (
			 prod_id_n INTEGER NOT NULL, prod_price_n DECIMAL(10,2),
			 prod_num_s VARCHAR(10),
			 prod_description_s VARCHAR(44) NOT NULL, 
			 prod_status_s CHAR(1) DEFAULT 'Y',
			 prod_brand_s VARCHAR(20) NOT NULL,
			 prod_pltwid_n DECIMAL(5,2) NOT NULL,
			 prod_pltlen_n DECIMAL(5,2) NOT NULL,
			 prod_netwght_n DECIMAL(10,3),
			 prod_shipweight_n DECIMAL(10,3) ) 
			 
			 INSERT INTO product 
			 ( prod_id_n, prod_price_n, prod_num_s, prod_description_s,	 prod_brand_s, prod_pltwid_n, prod_pltlen_n, prod_netwght_n, prod_shipweight_n )
			 VALUES (990, 18.24, '990', 'SPRUCE LUMBER 30X40X50', 'SPRUCE LUMBER', 4, 6, 21.22577, 24.22577 ) 
			 
			 SELECT prod_id_n, prod_price_n, prod_status_s 
			 FROM product
			 
			 PROD_ID_N PROD_PRICE_N PROD_STATUS_S 
			 --------- ------------ ------------- 
			     990    		 18.24         Y
```
---

###Table constraints

UNIQUE. Similar to the column constraint, but can ensure uniqueness of the combination of two or more columns.

PRIMARY KEY. The combination of values in constrained column(s) must be unique; NULL values are not allowed.

FOREIGN KEY. Specifies a column or group of columns in the table vhat references a column (or group of columns) in the referenced table.

---

###Referential integrity constraints optional clauses

```
[ON DELETE {NO ACTION | CASCADE | SET NULL}] 
[ON UPDATE {NO ACTION | CASCADE | SET NULL | SET DEFAULT}]
```

---

###Physical properties clause

Now, it's a little bit of a simplification, but generally data is physically stored on a database server's hard disk(s). The precise definition is beyond the scope of a book about SQL, but we are going to cover the very basics to help you better understand the creation of the database objects.

The implementations use quite diverse approaches, but the idea is the same: to be able to separate different database objects by type and, ideally, to put them on separate physical disks to speed up database operations. For example, all table data would live on Disk1, all table indexes on Disk2, and all LOBs would be placed on Disk3. The importance of such an approach varies from vendor to vendor; many other factors, like database size, workload, server quality, and so on can also play their role.

This book assumes the ACME sample database will be used primarily for educational purposes. We don't expect you to use a real big server with multiple disks, so the physical storage has rather theoretical significance for now. 

```
CREATE TABLE phone (
				phone_id_n INTEGER NOT NULL,
				phone_custid_fn INTEGER, 
				phone_salesmanid_fn INTEGER,
				phone_phonenum_s VARCHAR(20), 
				phone_type_s VARCHAR(20), 
				
				CONSTRAINT chk_phone_type CHECK (phone_type_s IN ('PHONE', 'FAX')), 
				CONSTRAINT pk_phonerimary PRIMARY KEY (phone_id_n) ON INDEX01 )
				ON DATA01
```

---

###Identity clause

Sometimes in your database, you want to generate unique sequential values, for example for a primary key column, for order or invoice numbers, customer IDs, and so on.

```
CREATETABLE payment_terms ( 
-- The first 1 means "start with"; the second stands for "increment by" 
        payterms_id_n INT NOT NULL IDENTITY (1,1),
				payterms_code_s VARCHAR(6),
				payterms_desc_s VARCHAR(60),
				payterms_discpct_n DECIMAL(5,2), 
				payterms_daystopay_n INT, 
				CONSTRAINT pk_payterms PRIMARY KEY(payterms_id_n) 
			)
```

----

###Creating new table as a copy of another table

Sometimes it's very useful to be able to create a table as a copy of another table. You can "clone" an existing table by creating its exact copy (with or without data) in all "big three" databases with slightly different syntax.

In MS SQL Server, you can create a copy of the PAYMENT_TERMS table using this syntax: 

```
SELECT * INTO #PAYMENT_TERMS2 FROM PAYMENT_TERMS
```

This syntax creates a MS SQL local temporary table; if the pound sign were omitted, PAYMENT_TERMS2 would be created as a permanent table. 

---

##Indexes

Index is another database physical structure that occupies disk space in a way similar to that of a table. The main difference is that indexes are hidden from users and are not mentioned in any DML statements, even though they are often used behind the scene.

A database index is similar to an index at the end of a book — it stores pointers to the physical row locations on the disk in the same way a book's index points to the page numbers for the appropriate topics. From another viewpoint, it is similar to a database table with two or more columns: one for the row's physical address, and the rest for the indexed table columns. In other words, index tells the RDBMS where to look for a specific table row (or a group of rows) on the disk 

In most databases indexes are implemented as B-Tree indexes, that is, they use the so called B-Tree algorithm that minimizes the number of times the hard disk must be accessed to locate a desired record, thereby speeding up the process. Because a disk drive has mechanical parts, which read and write data far more slowly than purely electronic media, it takes thousands of times longer to access a data element from a hard disk as compared with accessing it from RAM.

Indexes can be created to be either unique or nonunique. Unique indexes are implicitly created on columns for which a PRIMARY KEY or a UNIQUE constraint is specified. Duplicate values are not permitted. Nonunique indexes can be created on any column or combination of columns without any regard to duplicates.

Indexes can be created on one column or on multiple columns. The latter can be useful if the columns are often used together in WHERE clauses. For example, if some frequently used query looks for a certain customer's orders created on a certain date, you may create a nonunique index on the ORDHDR_CUSTID_FN and ORDHDR_CREATEDATE_D columns of the ORDER_HEADER table.

---

###CREATE INDEX statement

```
CREATE
			 [UNIQUE] [CLUSTERED | NONCLUSTERED] INDEX <index_name> ON
			 <table_name> | <view_name> ( column [ ASC | DESC ],...) [ON
			 filegroup]


```

---

##Views

The most common view definition describes it as a virtual table. Database users can select rows and columns from a view, join it with other views and tables, limit, sort, group the query results, and so on. Actually, in most cases, users wouldn't even know if they were selecting values from a view or from a table. The main difference is that, unlike tables, views do not take physical disk space. View definitions are stored in RDBMS as compiled queries that dynamically populate data to be used as virtual tables for users' requests.

The details are implementation-specific — RDBMS can create a temporary table behind the scene, populate it with actual rows, and use it to return results from a user's query. The database engine may also combine a user's query with an internal view definition (which is, as you already know, also a query) and execute the resulting query to return data, and so on — from a user's viewpoint, it does not matter at all.

---

###CREATE VIEW statement

```
CREATE VIEW <view_name>
			 [(<column_name>,...)] AS <select_statement> [WITH [CASCADED |
			 LOCAL] CHECK OPTION]
```

####Column names

The column_name list is optional in most cases — if it's skipped, the view columns will be named based on the column names in the SELECT statement; it becomes mandatory though if at least one of the following conditions is true:

  - Any two columns would otherwise have the same name (ambiguity problem).
  - Any column contains a computed value (including concatenated strings) and the column is not aliased

####SELECT statement and updatable views

The select_statement can be virtually any valid SELECT statement with some minimal restrictions. For example, the ORDER BY clause cannot be included in view definition, but GROUP BY can be used instead;
the view definition cannot be circular; thus, view cannot be referenced in its own select_statement clause, and so on.

Views can be updatable or not updatable. If a view is updatable, that means you can use its name in DML statements to actually update, insert, and delete the underlying table's rows. A view can be updatable only if all these rules hold:

  - The select_statement does not contain any table joins; that is, the view is based on one and only one table or view. (In the latter case, the underlying view must also be updatable.)
  - All underlying table's mandatory (NOT NULL) columns are present in the view definition.
  - The underlying query does not contain set operations like UNION, EXCEPT, or INTERSECT; the DISTINCT keyword is also not allowed.
  - No aggregate functions or expressions can be specified in the select_statement clause
  - The underlying query cannot have a GROUP BY clause
  
####View constraints

SQL99 does not allow creating explicit constraints on views, but the CHECK OPTION can be viewed as some kind of a constraint. This clause can only be specified for updatable views and prohibits you from using DML statements on any underlying table's rows that are not visible through the view. The CASCADED option (default) means that if a view is based on another view(s), the underlying view(s) are also checked. The LOCAL keyword would only enforce checking at the level of the view created with this option. 

```
CREATE VIEW
			 [[<database_name>.]<owner>.]<view_name>
			 [(<column_name>,...)] [WITH {ENCRYPTION | SCHEMABINDING |
			 VIEW_METADATA,...}] AS select_statement [WITH CHECK OPTION]
	```
	
	The WITH ENCRYPTION clause gives you the ability to encrypt the system table columns containing the text of the CREATE VIEW statement. The feature can be used, for example, to hide proprietary code: 
	
	```
	CREATE VIEW v_phone_number (
			 phone_id, phone_number ) WITH ENCRYPTION AS SELECT phone_id_n, phone_phonenum_s
			 FROM phone WHERE phone_type_s = 'PHONE' WITH CHECK OPTION
	```
	
	The WITH SCHEMABINDING clause binds the view to the schema (more about schemas later in this chapter): 

```
CREATE VIEW
			 dbo.v_phone_number ( phone_id, phone_number ) WITH SCHEMABINDING AS SELECT
			 phone_id_n, phone_phonenum_s FROM dbo.phone WHERE phone_type_s =
			 'PHONE'
```

---

###Creating complex views

We mentioned before that Oracle's OR REPLACE clause can be a very useful feature. MS SQL Server does not have it, but it can easily be simulated using this syntax: 
```
IF EXISTS ( SELECT table_name 
            FROM information_schema.views 
            WHERE table_name = 'V_CUSTOMER_STATUS'
			    ) DROP VIEW V_CUSTOMER_STATUS GO CREATE VIEW v_customer_status ( name, status )
			 AS SELECT cust_name_s, cust_status_s 
			 FROM customer
```

####Join view with GROUP BY clause and aggregate function

V_CUSTOMER_TOTALS displays the total calculated order price grouped by the CUSTOMER_NAME and then by ORDER_NUMBER fields: 

```
CREATE VIEW v_customer_totals ( 
  customer_name, 
  order_number, 
  total_price 
  ) AS 
  ( 
SELECT
			 customer.cust_name_s, 
			 order_header.ordhdr_nbr_s,
			 sum(product.prod_price_n * order_line.ordline_ordqty_n) 
FROM customer, order_header, order_line, product 
WHERE 
    customer.cust_id_n = order_header.ordhdr_custid_fn 
AND order_header.ordhdr_id_n = order_line.ordline_ordhdrid_fn 
AND product.prod_id_n = order_line.ordline_prodid_fn 
AND order_line.ordline_ordqty_n IS NOT NULL
GROUP BY customer.cust_name_s, order_header.ordhdr_nbr_s 
)
```

####View based on another view example

```
CREATE VIEW
			 v_customer_totals_over_15000 AS 
			 SELECT * 
			 FROM v_customer_totals WHERE
			 total_price > 15000
```

####View with UNION example

```
CREATE VIEW v_contact_list (
			 name, phone_number, contact_type ) AS 
			 SELECT cust_name_s, phone_phonenum_s, 'customer' 
			 FROM customer, phone 
			 WHERE cust_id_n = phone_custid_fn 
			 AND phone_type_s = 'PHONE' 
			 UNION 
			 SELECT salesman_name_s, phone_phonenum_s, 'salesperson' 
			 FROM salesman, phone 
			 WHERE salesman_id_n = phone_salesmanid_fn
			 AND phone_type_s = 'PHONE'
```

####View with subquery

```
CREATE VIEW
			 v_wile_bess_orders ( order_number, order_date ) AS 
			 SELECT ordhdr_nbr_s,
			 ordhdr_orderdate_d 
			 FROM order_header 
			 WHERE ordhdr_custid_fn IN ( 
			 SELECT
			 cust_id_n 
			 FROM customer 
			 WHERE cust_name_s = 'WILE BESS COMPANY'
			 )
```

---

###CREATE Statement Cross-Reference

All you can use `CREATE` with in MSSQL 2000

  - DATABASE 
  - DEFAULT 
  - FUNCTION 
  - INDEX 
  - PROCEDURE 
  - RULE 
  - SCHEMA
  - STATISTICS
  - TABLE
  - TRIGGER 
  - VIEW
