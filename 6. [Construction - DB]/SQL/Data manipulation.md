Data manipulation

---

"Classical" DML consists of three statements: INSERT, UPDATE, and DELETE

---

###INSERT 

The INSERT statement is used to add rows to a table, either directly or through an updateable view.

```
INSERT INTO <table_or_view_name>
[(<column_name>,...)]
{ {VALUES (<literal> | 
           <expression> |
           NULL |
           DEFAULT,...)} | 
  {<select_statement>} }
```

---

###INSERT statement and integrity constraints

Inserting rows into a table obeys certain rules and restrictions. For example, all column values have to be of same or at least compatible data types and sizes with corresponding column definitions. There are some implementation-specific variations — for example, Oracle performs implicit conversions whenever possible (from character string data types to numeric, from dates to strings, etc.), and in DB2 you always have to explicitly convert values to a compatible data type — but in general there is no RDBMS that would allow you to insert a customer name into a numeric or date column. An error will be generated and the whole row (or even multiple rows) is rejected.

A similar problem happens when you try to insert a value that violates an integrity constraint. You cannot insert NULL values into NOT NULL columns; duplicate values will be rejected for UNIQUE and PRIMARY KEY columns, and so on.

---

###UPDATE: Modifying Table Data

The UPDATE statement serves the purpose of modifying existing database information. We can emphasize two general situations when we need to change data. 

Somevimes when you insert rows into a table, you don't know all information yet (that's where NULL values come in handy); later on, when the information becomes available, you can update the appropriate row(s). For example, you may want to create a new customer before you know who the customer's salesperson is going to be, or generate a new order line entry with an unknown shipped quantity. (There is no way to know what this quantity is before the order is actually shipped.)

```
UPDATE <table_or_view_name>
SET {<column_name> = <literal> | 
                     <expression> | 
                     (<single_row_select_statement>) |
                   NULL | 
                   DEFAULT,...}
[WHERE <predicate>]
```

The UPDATE statement allows you to update one table at a time. Other than that, it provides great flexibility on what set of values you are updating. You could update single or multiple columns of a single row or multiple rows, or (though it is rarely employed) you could update each and every column of all table rows. The granularity is determined by different clauses of the UPDATE statement. 


---  

###DELETE

```
DELETE FROM <table_or_view_name>
WHERE <predicate>
```

```
DELETE order_header
FROM order_header JOIN customer
ON ordhdr_custid_fn = cust_id_n
WHERE cust_name_s = 'WILE SEAL CORP.'
```

---

###MERGE

MERGE statement that could be thought of as a combination of INSERT and UPDATE. MERGE inserts a row if it does not yet exist and updates specified columns based on given criteria if the target row has previously been inserted. The syntax for the statement is 

```
MERGE INTO [<qualifier>.]<table_name1>
USING [<qualifier>.]<table_name2> ON (<condition>)
WHEN MATCHED THEN 
UPDATE SET {<column> = {<expression> | DEFAULT},...}
WHEN NOT MATCHED THEN 
INSERT [(<column>,...)] VALUES (<expression> | DEFAULT,...);
```

---

###TRUNCATE

In addition to the standard DML statements described in this chapter, Oracle and MS SQL Server also introduce a TRUNCATE statement that is functionally identical to DELETE without a WHERE clause — it removes all rows from the target table. The difference is that TRUNCATE is much faster and uses fewer system resources than DELETE. The main limitation of TRUNCATE is that you cannot use it on a table referenced by an enabled FOREIGN KEY constraint.

```
TRUNCATE TABLE <table_name>
```
