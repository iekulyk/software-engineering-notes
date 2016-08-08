Combining the Results of Multiple Queries
---

It is possible to produce a single result combining the results of two or more queries. The combined resultset might be a simple aggregation of all records from the queries; or some operation related to the theory of sets (see Appendix L) could be performed before the final resultset was returned.

---

###UNION

The following query returns all the records containing some information about customers that do not yet have an assigned salesman:

```
SELECT   phone_custid_fn OWNER_ID,
         'CUSTOMER PHONE' PHONE_TYPE,
         phone_phonenum_s
FROM     phone
WHERE    phone_type_s = 'PHONE'
AND      phone_salesmanid_fn IS NULL
```

This query returns a total of 37 records. Now, assume that you also would like to include in the resultset the list of salesmen's phones who do not have a customer assigned to them yet. Here is the query to find these salesmen; it returns six records:

```
SELECT      phone_salesmanid_fn,
            'SALESMAN PHONE',
            phone_phonenum_s
FROM        phone
WHERE       phone_type_s = 'PHONE'
AND         phone_custid_fn IS NULL
```

To combine these records into a single resultset, you would use the UNION statement: 

```
SELECT             phone_custid_fn OWNER_ID,
                   'CUSTOMER PHONE' PHONE_TYPE,
                   phone_phonenum_s
FROM               phone
WHERE              phone_type_s = 'PHONE'
AND                phone_salesmanid_fn IS NULL

UNION

SELECT             phone_salesmanid_fn,
                   'SALESMAN PHONE',
                   phone_phonenum_s
FROM               phone
WHERE              phone_type_s = 'PHONE'
AND                phone_custid_fn IS NULL
ORDER BY   2, 1
```

Now you have a full list that includes all records from the query about customers, combined with the results brought by the query about salesmen. You may visualize this as two resultsets glued together. All queries in an SQL statement containing a UNION operator must have an equal number of expressions in their lists. In addition, these expressions (which could be columns, literals, results of functions, etc.) must be of compatible data types: For example, if the expression evaluates to a character string in one query, it cannot be a number in the second query that is joined to the first by the UNION operator.

The results of UNION could be ordered (as we can see in the UNION query above) but the ORDER BY clause could be used only with the final resultset — that is, it can refer to the result of the UNION, not to particular queries used in it.

If the queries potentially could bring duplicate records, you may want to filter the duplicates, or, conversely, make sure that they all are present. By default, the UNION operator excludes duplicate records; specifying UNION ALL makes sure that your final resultset has all the records returned by all the queries participating in the UNION.

---

###INTERSECT

The INTERSECT operator is used to evaluate results returned by two queries but includes only the records produced by the first query that have matching ones in the second.

Consider the query that selects customer IDs (field CUST_ID_N) from the CUSTOMER table of the ACME database and intersects them with results returned by a second query, producing a resultset of customer's IDs who placed an order: 

```
SELECT  cust_id_n
FROM    customer
INTERSECT
SELECT  ordhdr_custid_fn 
FROM    order_header
```

The same results are achievable in a variety of ways. Here is an example, using a subquery and an IN operator: 

```
SELECT cust_id_n
FROM   customer
WHERE  cust_id_n IN
 (SELECT ordhdr_custid_fn
  FROM   order_header)
```

---

###EXCEPT (MINUS)

When combining the results of two or more queries into a single resultset, you may want to exclude some records from the first query based on what was returned by the second.

```
SELECT cust_id_n
FROM   customer
```

```
SELECT ProductID   
FROM Production.Product  
EXCEPT  
SELECT ProductID   
FROM Production.WorkOrder ;  
```
