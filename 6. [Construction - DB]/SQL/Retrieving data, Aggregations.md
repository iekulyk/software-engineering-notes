Retrieving data, Aggregations
---

Here is the generic SELECT statement, as it is defined by the SQL99 standard, for selecting data from a single table. The query includes the SELECT command, followed by the list of identifiers (table or view columns); then comes the mandatory FROM clause that contains names of the tables, from which these columns are selected. The rest of the clause is optional, used to increase selectiveness of the query, as well as add some ordering capabilities. All of these pieces make up the complete SELECT statement. 

```
SELECT [DISTINCT] [<qualifier>.]<column_name> | 
                  * | 
                  <expression> 
                   [AS <column_alias>],...
FROM  <table_or_view_name> | 
      <inline_view> 
       [[AS] <table_alias>] 
[WHERE <predicate>]
[GROUP BY [<qualifier>.]<column_name>,... 
 [HAVING <predicate>]
]
[ORDER_BY <column_name> | 
          <column_number> 
           [ASC | DESC],...
];
```

In the relational databases the SELECT statement selects values in the columns, literal values, or expressions. The returned values themselves could be of any valid data types. These values can be displayed in the client application, or written into a file, used in the intermediate calculations, or entered into database tables.

---

###Single-column select

You can select as many or as few columns as you wish from a table (or a view) for which you have SELECT privileges.

```
SELECT cust_name_s
FROM   customer
CUST_NAME_S
```

---

###Multicolumn SELECT

A single column SELECT, while useful, is certainly not the limit of the SQL capabilities. It's very likely that you'll be selecting more than one column at a time in your queries.

```
SELECT   cust_id_n, 
         cust_status_s, 
         cust_name_s
FROM     customer
```

---

###Selecting all columns

```
SELECT *
FROM status
```

---

###Selecting all columns plus an extra column

```
ELECT status.*, status_desc_s
FROM status;
```

---

###Selecting distinct values

```
SELECT DISTINCT payterms_discpct_n
FROM            payment_terms
```

---

###Using literals, functions, and calculated columns

Columns are not the only things that you can select in the relational database world, and the SELECT statement does not always involve a table. Selecting columns from a table is a very straightforward concept, much more so than selecting expressions and literals. 

When a value we are after does not exist up to the moment we call it, because it is returned by a function, or being calculated on the fly, you still need to SELECT from somewhere. This "somewhere" could be any table existing within the database and to which you have select privilege .

```
SELECT (5+5) FROM sysibm.sysdummy1
```

```
SELECT (5+5) num_sum
```

```
SELECT DISTINCT payterms_discpct_n AS discount_percent
FROM            payment_terms
```

```
SELECT cust_name_s, 
       100 AS NUMERIC_CONSTANT, 
       'ABC' AS STRING_CONSTANT 
FROM   customer
```

```
SELECT CAST(prod_id_n AS CHAR(5)) || ' ' || prod_brand_s 
 AS ID_AND_BRAND 
FROM   product
```

---

###Using subqueries in a SELECT clause

The concept of a subquery is simple — it is a query within a query that supplies necessary values for the first query. A SELECT query could have an embedded subquery as a way to retrieve unknown values, and the nesting level (how many subqueries you could have within each other) is limited only by the RDBMS capability.

```
SELECT 
  prod_num_s, 
  prod_price_n, 
    (SELECT stax_amt_n 
     FROM sales_tax 
     WHERE stax_state_s = 'WA') AS TAX_RATE,
     prod_price_n * 
    (SELECT stax_amt_n 
     FROM sales_tax 
     WHERE stax_state_s = 'WA')/100 AS SALES_TAX 
FROM product
```
---

###WHERE Clause

While selecting everything a table or view could contain might be of value for some operations, most of the time you will be looking for specific information — a person with a particular phone number, data falling into a certain date range, and so on. The table might contain several million rows, and you simply have no time to search for the information all by yourself. The SQL WHERE clause provides a mechanism for setting horizontal limits;

---

###Using comparison operators

```
SELECT cust_id_n,
       cust_name_s,
       cust_status_s                                        
FROM   customer
WHERE  cust_id_n = 7
```

```
SELECT  prod_description_s, 
        prod_price_n
FROM    product
WHERE   prod_price_n > 20
```

---

###Compound operators: Using AND and OR

```
SELECT  phone_salesmanid_fn, 
             phone_phonenum_s, 
             phone_type_s
FROM         phone
WHERE        phone_custid_fn IS NULL
AND          phone_type_s = 'PHONE'
```

```
SELECT ordhdr_id_n,
       ordhdr_custid_fn
FROM   order_header
WHERE  ordhdr_id_n = 30661
OR     ordhdr_custid_fn = 63
```

---

###BETWEEN operator

While it is possible to use a combination of => (greater than or equal to) and <= (less than or equal to) operators to achieve exactly the same results, the BETWEEN operator provides a more convenient (and often more efficient) way for selecting a range of values

```
SELECT  prod_description_s, 
        prod_price_n
FROM    product
WHERE   prod_price_n BETWEEN 23.10 AND 30
```

---

###IN operator

When there is more than one exact criterion for the WHERE clause, and these criteria do not fit any range of values, you may use an OR statement. Consider the following query:

```
SELECT  cust_name_s, 
        cust_credhold_s 
FROM    customer
WHERE   cust_alias_s = 'MNGA71396' OR
        cust_alias_s = 'MNGA71398' OR
        cust_alias_s = 'MNGA71400'
```

Any records that correspond to either of the three specified criteria make it into the final resultset. The same result is easier achieved using an IN operator: 

```
SELECT  cust_name_s, 
        cust_credhold_s 
FROM    customer
WHERE   cust_alias_s IN 
        ('MNGA71396', 'MNGA71398', 'MNGA71400')
```

---

###The NOT operator

The NOT operator negates results of the operator by making it perform a search for the results exactly opposite to those specified. Any of the operators and queries discussed to this point could have produced opposite results if NOT was used. The following example returns all the results that do not match the specified criteria — having the name with the second letter I, third L, and fourth E; only records that do not have such a sequence starting from the second position within the company name are selected: 

```
SELECT  cust_name_s
FROM    customer
WHERE  cust_name_s  NOT LIKE  '_ILE%'
```

---

###IS NULL operator

We have mentioned before that relational databases are using a special value to signify the absence of the data in the database table column — NULL. Since this value does not comply with the rules that all the other values follow (e.g., comparison, operations, etc.), they cannot be detected with the equation/comparison operator =; i.e., the syntax WHERE <column_name> = NULL, while being technically valid in Oracle or DB2 UDB (and valid in Microsoft SQL Server 2000 under certain circumstances), would never yield any data because the equation will always evaluate to FALSE. 

The test for NULL is performed with the IS keyword, as in the example below, which retrieves information about salesmen that have customers without a PHONE_CUSTID_FN number. 

```
SELECT  phone_salesmanid_fn, 
        phone_phonenum_s, 
        phone_type_s
FROM    phone
WHERE   phone_custid_fn IS NULL
```

In Microsoft SQL Server 2000 Transact-SQL, a NULL is never equal to another NULL unless you specifically instruct SQL Server to do so by issuing command SET ANSI_NULLS OFF; setting this parameter OFF within the session would allow you to compare a NULL value with another NULL value, setting it back ON (default) brings back the SQL99 standard behavior.

---

###Using subqueries in a WHERE clause

As in the SELECT clause, the subqueries could be used with the WHERE clause to provide missing values (or a set of values). For example, you cannot find information from the ORDER_HEADER table using a customer's name only, because the ORDER_HEADER table contains customer IDs, not the names; thus, the customer ID could be found in the table CUSTOMER using the customer name as a criterion, and then used to select values from the ORDER_HEADER table: 

```
SELECT  ordhdr_nbr_s,
        ordhdr_orderdate_d
FROM    order_header
WHERE   ordhdr_custid_fn = 
(SELECT cust_id_n
 FROM   customer
 WHERE  cust_name_s = 'WILE ELECTRONICS INC.')
```

---

###Nested subqueries 

```
SELECT cust_name_s, 
       cust_alias_s 
FROM   customer 
WHERE  cust_id_n IN 

  (SELECT ordhdr_custid_fn 
   FROM order_header 
   WHERE ordhdr_id_n in 
   
    (SELECT ordline_ordhdrid_fn 
     FROM order_line 
     WHERE ordline_prodid_fn = 
     
      (SELECT prod_id_n  
       FROM product 
       WHERE prod_description_s = 'CRATING MATERIAL 12X48X72'
       )
    )
  ) 
```

---

###GROUP BY and HAVING Clauses

Grouping records in the resultset based on some criteria could provide a valuable insight into data that has accumulated in the table. For example, you would like to see the final resultset of your orders (where there could be one or more order items per order) not in the random order they were entered in, but rather in groups of items that belong to the same order:

```
SELECT   ordline_ordhdrid_fn, 
         ordline_ordqty_n AS QTY_PER_ITEM
FROM     order_line
GROUP BY ordline_ordhdrid_fn,
         ordline_ordqty_n;
```

```
SELECT
         SUM(ordline_ordqty_n) AS TOT_QTY_PER_ORDER
FROM     order_line;
```

The single value that summed up all ordered quantities for all the records in the table was returned. While useful, this information could be more valuable if the ordered quantity is summed up per order — you would know how many items were ordered in each and every order. Here is the query that accomplishes this task:

```
SELECT   ordline_ordhdrid_fn, 
         SUM(ordline_ordqty_n) AS TOT_QTY_PER_ORDER
FROM     order_line
GROUP BY ordline_ordhdrid_fn
```

Here is an example of another aggregate function AVG, 
which calculates the average of the values. In this case, you are 
going to calculate the average quantity per order.

```
SELECT   ordline_ordhdrid_fn, 
         AVG(ordline_ordqty_n) AS AVG_QTY_PER_ORDER
FROM     order_line
GROUP BY ordline_ordhdrid_fn
```

---

###HAVING

The HAVING clause used exclusively with the GROUP BY clause provides a means of additional selectivity. Imagine that you need to select not all records in your GROUP BY query but only those that would have their grouped value greater than 750. Adding additional criterion to the WHERE clause would not help, as the value by which we could limit the records is calculated using GROUP BY and is unavailable outside it before the query has completed execution. The HAVING clause used within the GROUP BY clause allows us to add this additional criterion to the results of the GROUP BY operation

```
SELECT    ordline_ordhdrid_fn, 
          SUM(ordline_ordqty_n) TOT_QTY_PER_ORDER
FROM      order_line
GROUP BY  ordline_ordhdrid_fn
HAVING   SUM(ordline_ordqty_n) > 750
```

We could have used a column ORDLINE_ORDHDRID_FN, without the SUM aggregate function in the HAVING clause to restrict the returned records by some other criteria, but we cannot use just any column from the SELECT clause: It also has to be listed in the GROUP BY clause to be used with HAVING. Here is a query example that sums up order quantities grouped by order header ID only if they fall into a specified list of orders: 

```
SELECT   ordline_ordhdrid_fn, 
         SUM(ordline_ordqty_n) TOT_QTY_PER_ORDER
FROM     order_line
GROUP BY ordline_ordhdrid_fn
HAVING   ordline_ordhdrid_fn IN (30607,30608,30611,30622)
```

While GROUP BY would consider the null values in the columns by which the grouping is performed a valid group, this is not the way the NULLs are treated by the aggregate functions. Aggregate functions simply exclude the NULL records — they will not make it to the final result.

---

###ORDER BY Clause

The query returns results matching the criteria unsorted — i.e., in the order they've been found in the table. To produce sorted output — alphabetically or numerically — you would use an ORDER BY clause. The functionality of this clause is identical across all "big-three" databases.

```
SELECT cust_name_s, 
            cust_alias_s, 
            cust_status_s
FROM        customer
ORDER BY    cust_name_s;
```

The results could be sorted in either ascending or descending order. To sort in descending order, you must specify keyword DESC after the column name; to sort in ascending order you may use ASC keyword (or omit it altogether, as it is done in the above query, since ascending is the default sorting order). 

