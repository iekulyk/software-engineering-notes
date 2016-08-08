Joins understanding
---

Inner joins only return rows with matching values from both joined tables excluding all other rows.

```
FROM  <table1>
[INNER | NATURAL | CROSS] JOIN
      <table2>
[ON <condition>] | [USING <column_name>,...],...
```

---

###Inner join options

  - Keyword INNER is optional; it could be used for clarity to distinguish between inner and outer joins.
  - Keyword NATURAL is used to specify a natural join between two tables, i.e., join them by column(s) with identical names. You cannot invoke either the ON or USING clause along with the NATURAL keyword. Out of all our "big three" RDBMS, it is available only in Oracle 9i. The natural join is discussed in more detail later in this chapter.
  - Keyword CROSS is used to produce a cross join, as discussed later in this chapter
  
####ON and USING clauses

The ON clause is to specify the join condition (equijoin or nonequijoin, explained later in the chapter); all our "big three" databases have it in their syntax. 

When you are specifying an equijoin of columns that have the same name in both tables, a USING clause can indicate the column(s) to be used. You can use this clause only if the join columns in both tables have the same name.

```
FROM A JOIN B
USING (CUST_ID, PROD_ID)
```

same results could easily be achieved with ON clause: 

```
FROM A JOIN B
ON A.CUST_ID = B.CUST_ID
AND A.PROD_ID = B.PROD_ID
```

---

###Cross join (Cartesian product)

Cross join, or the Cartesian product of two tables, can be defined as another (rather virtual) table that consists of all possible pairs of rows from the two source tables.

---------------

##Outert Joins

You probably noticed in the RESELLER table presented earlier in this chapter that the query returns all table records except one for ACME, INC. This is because the ACME, INC. record in the RESELLER table has NULL in the RESELLER_SUPPLIER_ID column, so an RDBMS cannot find the corresponding value in the table you are trying to join (in this case, the other instance of RESELLER table). As the result, the query returns nine rows even though the table contains ten records. That's just the way the standard (inner) join works. Sometimes, however, you want a query to return all rows from table A and the corresponding rows from table B — if they exist. That's where you use outer joins.

---

```
FROM  <table1>
  {LEFT | RIGHT | FULL [OUTER]} | UNION JOIN
      <table2>
  [ON <condition>] | [USING <column_name>,...],...

```

---

###Left outer join

In fact, the term "left outer join" is just a convention used by SQL programmers. You can achieve identical results using left or right outer joins as we will demonstrate later in this chapter. The whole idea behind an outer join is to retrieve all rows from table A (left) or table B (right), even though there are no matching columns in the counterpart table, so the join column(s) is NULL. A left (or right) outer join also returns nulls for all unmatched columns from the joined table (for rows with NULL join columns only).

---

```
SELECT            r.reseller_id_n   AS res_id,  
                  r.reseller_name_s AS res_name, 
                  s.reseller_id_n   AS sup_id, 
                  s.reseller_name_s AS sup_name
FROM              reseller r 
LEFT OUTER JOIN reseller s
ON              r.reseller_supplier_id = s.reseller_id_n
```

```
RES_ID RES_NAME                     SUP_ID SUP_NAME
------ ---------------------------- ------ --------------------------
      1 ACME, INC.                  NULL   NULL
      2 MAGNETICS USA INC.          1      ACME, INC
      3 MAGNETOMETRIC DEVICES INC.  1      ACME, INC
      4 FAIR PARK GARDENS           2      MAGNETICS USA INC.
      5 FAIR AND SONS AIR CONDTNG   2      MAGNETICS USA INC.
      6 FABRITEK INC.               2      MAGNETICS USA INC.
      7 WILE ELECTRONICS INC.       3      MAGNETOMETRIC DEVICES INC.
      8 INTEREX USA                 3      MAGNETOMETRIC DEVICES INC.
      9 JUDCO MANUFACTURING INC.    4      FAIR PARK GARDENS
     10 ELECTRO BASS INC.           5      FAIR AND SONS AIR CONDTNG
```

---

###Right outer join

As we mentioned before, the only difference between left and right outer joins is the order in which the tables are joined in the query. To demonstrate that we'll use queries that produce exactly same output as in the previous section.

---

As you can see, the resulting set of the inner join of ORDER_HEADER and CUSTOMER is on the right-hand side from the PAYMENT_TERMS table: 

```
SELECT  cust_name_s, 
        ordhdr_nbr_s, 
        payterms_desc_s  
FROM    payment_terms 
  RIGHT OUTER JOIN 
        order_header
  ON    payterms_id_n = ordhdr_payterms_fn 
  JOIN    
        customer
ON      cust_id_n = ordhdr_custid_fn
WHERE   cust_id_n = 152
```

---

###Full outer join

Full outer join is the combination of left and right outer join. It returns all rows from both "left" and "right" tables, no matter if the counterpart table has matching rows or not. For example, in the ACME database there are some customers that did not place any orders yet — as well as some orders with no customers assigned to them.

---

```
SELECT  customer.cust_name_s, 
        order_header.ordhdr_nbr_s
FROM    customer 
   FULL OUTER JOIN 
        order_header 
   ON customer.cust_id_n = order_header.ordhdr_custid_fn
```

```
CUST_NAME_S                                 ORDHDR_NBR_S
   
----------------------------------------    -------------
...
WILE SEAL CORP.                                    523774
WILE SEAL CORP.                                    523775
WILE SEAL CORP.                                    523776
WILE SEAL CORP.                                    523777
WILE SEAL CORP.                                    523778
...                                                ...
WILE BESS COMPANY                                  523730
NULL                                               523727
NULL                                               523728
MAGNETICS USA INC.                                 NULL
MAGNETOMETRIC DEVICES INC.                         NULL
FAIR PARK GARDENS                                  NULL
```


----

###Union join

The UNION join (not to be confused with the UNION operator) could be thought of as the opposite of an inner join — its resulting set only includes those rows from both joined tables for which no matches were found; the columns from the table without matching rows are populated with nulls. 

