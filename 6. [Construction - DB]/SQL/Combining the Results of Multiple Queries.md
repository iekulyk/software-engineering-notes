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
