Sessions, transactions, locks
---

Whatever happens in terms of communication between an RDBMS server and a user accessing it happens in the context of a session. In a multiuser environment, one of the primary concerns is data integrity. When a client application establishes a connection to an RDBMS server, it is said that it opens a session. The session becomes this application's private communication channel. The user of the application may change some preferences within the session (for example, default language or default date format); these settings would affect only the session environment and remain valid only for the duration of the session. The details of the implementation and default behavior of the sessions might differ among the RDBMS, but these basic principles always remain the same.

The SQL standard specifies a number of parameters that could be set in a session. None of these are implemented directly by the RDBMS, though some elements made it into proprietary syntax, ditching the letter, preserving the spirit.

  - SET CONNECTION : If more than one connection is opened by a user to an RDBMS, this statement allows that user to switch between the connections.
  - SET CATALOG : This statement defines the default catalog for the session.
  - SET CONSTRAINTS MODE : Changes the constraints mode between DEFERRED, and IMMEDIATE.
  - SET DESCRIPTOR : Stores values in the descriptor area
  - SET NAMES : Defines the default character set for the SQL statements
  - SET SCHEMA : Sets the schema to be used as a default qualifier for all unqualified objects
  - SET SESSION AUTHORIZATION : Sets the authorization ID for the session, no other IDs can be used
  - SET TIME ZONE : Sets the default time zone for the session

---

Microsoft SQL Server 2000 has a number of statements that you can specify to alter the current session (some of them are shown in Table 7-2 and Table 7-3). These statements are not part of SQL standard, being rather part of the Transact-SQL dialect. They can be grouped in several categories: statements that affect date and time settings, query execution statements, statistics statements, locking and transaction statements, SQL-92 settings statements, and — the all-time favorite — miscellaneous settings.

Settings :
  - SET ANSI_DEFAULTS {ON | OFF} : Specifies that all the defaults used for the duration of the session should be these of ANSI defaults. This option is provided for compatibility with SQL Server 6.5 or later
  - SET ANSI_NULL_DFLT_OFF {ON | OFF} : Specifies whether columns could contain NULL value by default. If set to ON, the new columns created would allow NULL values (unless NOT NULL is specified); otherwise it would raise an error. It has no effect on the columns explicitly set for NULL. It is used to override default nullability of new columns when the ANSI null default option for the database is TRUE
  - SET ANSI_NULL_DFLT_ON {ON | OFF} : Essentially, the same as the statement above, with one exception: it is used to override default nullability of new columns when the ANSI null default option for the database is FALSE
  - SET ANSI_NULLS {ON | OFF} : Specifies the SQL-92 compliant behavior when comparing values using operators EQUAL (=) and NOT EQUAL (< >).
  - SET ANSI_PADDING {ON | OFF} : Specifies how the values that are shorter than the column size for CHAR, VARCHAR, BINARY, and VARBINARY data types are displayed
  - SET ANSI_WARNINGS {ON | OFF} : Specifies whether a warning should be issued when any of the following conditions occur: presence of NULL values in the columns evaluated in the aggregate functions (like SUM, AVG,COUNT, etc.); divide-by-zero and arithmetic overflow errors generate an error message and the statement rolls back when this option is set to ON; specifying OFF would cause a NULL value to be returned in the case
  
SET Statements :
  - SET DATEFORMAT {<format> | @<format ID>} : Specifies the order of the date parts for DATETIME and SMALLDATETIME input
  - SET CONCAT_NULL_YIELDS_NULL {ON | OFF} : Specifies what would be the result of concatenation of the column values (or expressions) should any or both of them contain NULL
  - SET LANGUAGE { <language> | @<language ID>} : Specifies the default language for the session. This setting affects the datetime format, and system messages returned by SQL Server.
  - SET NOCOUNT {ON | OFF} : SQL Server usually returns a message indicating how many rows were affected by any given statement. Issuing this command would stop this message
  - SET NUMERIC_ROUNDABORT {ON | OFF} : Specifies the severity of an error that results in loss of precision; if set to OFF the rounding generates no error; when it is set to ON, then an error will be generated and no results returned. Depending on some other settings, a NULL might be returned
  - SET ROWCOUNT <integer> : If this statement is used, Microsoft SQL Server stops processing a query after the required number of rows (specified in the SET statement) is returned
  
---
  
###Transactions
  
A transaction is one of the mechanisms provided within SQL to enforce database integrity and maintain data consistency
  
A transaction complements the concept of the session with additional granularity — it divides every operation that occurs within the session into logical units of work. In this way, database operations — those involving data and structure modifications — are performed step-by-step and can be rolled back at any time, or committed if every step is successful. The idea of the transaction is to provide a mechanism for ensuring that a multistep operation is performed as a single unit. If any of the steps involved in a transaction fails, the whole transaction is rolled back. If all steps have been completed successfully, the transaction can be either committed (to save all the changes into a database) or rolled back to undo all the changes.

The SQL standard defined transactions from the very beginning and enhanced the concept during subsequent iterations. According to the standard, a transaction is started automatically by RDBMS and continues until COMMIT or ROLLBACK statements are issued; the details were left for the vendors to implement.

A transaction must pass the ACID test:

  - Atomicity. Either all the changes are made or none.
  - Consistency. All the data involved into an operation must be left in a consistent state upon completion or rollback of the transaction; database integrity cannot be compromised.
  - Isolation. One transaction should not be aware of the modifications made to the data by any other transaction unless it was committed to the database. Different isolation levels can be set to modify this default behavior
  - Durability. The results of a transaction that has been successfully committed to the database remain there.

An implicit transaction has been chosen as the default in SQL92/99 standard. Whenever certain statements (of DDL and DML type) are executed within a session, they start (or continue) a transaction. A transaction is terminated by issuing either a COMMIT statement or a ROLLBACK statement.

An explicit transaction is started by the client application with a BEGIN TRANSACTION statement and is terminated in a manner similar to the implicit transaction protocol. This is a Microsoft SQL Server 2000–only feature, which is the default setting. Microsoft SQL Server 2000 provides a statement SET IMPLICIT_TRANSACTIONS {ON | OFF} to configure the default behavior of the transaction. When the option is ON, the SQL Server automatically starts a transaction when one of the following statements is specified: ALTER TABLE, CREATE, DELETE, DROP, FETCH, GRANT, INSERT, OPEN, REVOKE, SELECT, TRUNCATE TABLE and UPDATE. The transaction must be explicitly committed or rolled back, though; a new transaction is started once any of the listed statements gets executed. Turning the IMPLICIT_TRANSACTIONS option OFF returns the transaction to its default autocommit transaction mode.

While not required by the SQL standard, in every RDBMS implementation COMMIT is issued implicitly before and after any DDL statement.

---

####Transactions COMMIT and ROLLBACK

The COMMIT statement ends the current transaction and makes all changes made to the data during transaction permanent. The syntax is virtually identical for all three RDBMS vendors, as well as for the SQL99 standard, and is very straightforward: 

COMMIT [WORK]

```
BEGIN TRAN 
SELECT * 
FROM customer 
UPDATE customer SET cust_status_s = 'N' 
COMMIT TRAN
```

As with a COMMIT statement, all the locks are released if the ROLLBACK command is issued

Usually, a transaction consists of more than one SQL statement that you may want to either COMMIT or ROLLBACK. To add granularity to the transaction processing, the SAVEPOINT concept was introduced. It allows you to specify a named point within the transaction, usually after the last successful statement, and, if any error occurs after that, roll all the changes back not to the beginning of the transaction but to that particular SAVEPOINT. An explicit (or implicit, like the one issued after a DDL statement) COMMIT releases all SAVEPOINTs declared within a transaction.

```
SAVE TRAN[SACTION]
		  <savepoint name>
```

---

Transactions that involve more than one database are referred to as distributed transactions. Such transactions are by their very nature complex and require advanced skills and knowledge

In Microsoft SQL Server 2000, the task of managing the distributed transactions belongs with MSDTC (Microsoft Distributed Transaction Coordinator). (Other transaction managers complying to the X/Open XA specification could be employed instead.) The transaction can be explicitly started with the BEGIN DISTRIBUTED TRANS[ACTION] statement.

A distributed transaction must minimize the risk of data loss in case of a network failure. The two-phase commit protocol is employed in distributed transactions, and while details of the implementation are different between the vendors, they generally follow the same phases

  - Prepare Phase. When the transaction manager receives a COMMIT request, it communicates it to all resource managers involved in the transaction, and they prepare to do a COMMIT 
  - Commit Phase. In this phase, they actually issue COMMIT and report to the coordinator; when all COMMITs are successful, the coordinator sends notification to the client application. If any of the resource managers fails to notify the coordinator, a ROLLBACK command is issued to all resource managers. To perform a ROLLBACK after a COMMIT is executed, log files are normally used
  
---

###Transaction isolation levels

####READ UNCOMMITED 

This level is the lowest of all isolation levels, permitting dirty reads (i.e., able to see uncommitted data). No locks are issued, none honored.

---

####READ COMMITED 

This level specifies that shared locks will be held while data is being read. No dirty reads (containing uncommitted data) are permitted; though phantom reads (when row number changes between the reads) may occur.

---

####REPEATABLE READ 

No changes will be allowed for the data selected by a query (locked for updates, deletes, etc.), but phantom rows may appear.

---

####SERIALIZABLE 

The highest level of transaction isolation; places a lock for the whole dataset; no modifications from outside are allowed until the end of the transaction.

---

Microsoft SQL Server 2000 supports all four levels of isolation. The isolation level is set for the whole session, not just a single transaction. To specify a level within the session, the following statement is used:

```
SET TRANSACTION ISOLATION LEVEL
		  <level>
```

-------------

###Locks

Concurrency is one of the major concerns in a multiuser environment. When multiple sessions write or read data to and from shared resources, a database might loose its integrity. To prevent this from happening, every RDBMS worth its salt implements a concurrency control mechanisms. In the case of RDBMS servers, the concurrency is managed through various locking mechanisms. All three leading RDBMS vendors have implemented sophisticated mechanisms for concurrency management.

Most of the time, a user does not have to worry about locking, as RDBMS automatically select the most appropriate lock (or locks) for a particular operation; only if this programmed logic fails should you attempt to specify the locks manually, using the SQL statements.

----

###Locking modes

There are two broad categories of concurrency — optimistic and pessimistic. The names are self-explanatory. Transactions with optimistic concurrency work on the assumption that resource conflicts — when more than one transaction works on the same set of data — are unlikely (though possible). Optimistic transactions check for potential conflicts when committing changes to a database and conflicts are resolved by resubmitting data. Pessimistic transactions expect conflicts from the very beginning and lock all resources they intend to use. Usually RDBMS employ both optimistic and pessimistic transactions, and users can instruct their transactions to use either

Locking granularity has a significant effect on system performance. Row-level locking increases concurrency (i.e., does not block other transactions from accessing a table) but usually incurs overhead costs of administration. A full table lock is much less expensive in terms of system resources but comes at the price of concurrency. This is something to keep in mind when designing database applications

Locks are used to implement pessimistic transactions, and each RDBMS has its own levels of locking, though there are some similarities. In general, there are either share locks or exclusive locks, which refer to the way a resource (e.g., a table) is being used.

---

Microsoft SQL Server 2000 Lock Modes :

  - SHARED (S) : This type of lock is used for read-only operations
  - UPDATE (U) : This lock is used whenever the data is updated
  - EXCLUSIVE (X) : Prevents all other transactions from performing UPDATE, DELETE or INSERT
  - INTENT: This is used to establish a hierarchy of locking: intent, shared intent, exclusive, and shared with intent exclusive. An intent lock indicates that SQL Server wants to acquire a shared or exclusive lock on some resources down in the hierarchy (e.g., table — page — row); at the very least the intent lock prevents any transactions from acquiring an exclusive lock on the resource
  - SCHEMA : This lock type is used when a DDL operation is performed
  - BULK UPDATE : These locks are used when bulk copying is taking place
  
---

Microsoft SQL Server 2000 Locking Hints :

  - NOLOCK : This hint issued in a SELECT statement specifies that no shared locks should be used and no exclusive locks should be honored; this means that the SELECT statement could potentially read uncommitted transactions 
  - UPDLOCK : Instructs SQL Server to use UPDATE locking (as opposed to shared locks) while reading data; makes sure that data has not changed if an UPDATE statement follows next
  - XLOCK : Places an exclusive lock until the end of a transaction on all data affected by the transaction. Additional levels of granularity can be specified with this lock
  - ROWLOCK : Specifically instructs SQL Server to use row-level locks (as opposed to page and table-level)
  
The lock mode is either selected by the SQL Server itself, or based on the type of operation performed. To manually specify the locking mode, one should use the table-level locking hints that fall into one of the categories listed in Table 7-7. These locking hints override the transaction isolation level and should be used judiciously.
The hints in the Table provide just a sampling of what is available, and the list is by no means complete.

---

###Dealing with deadlocks

The classic deadlock situation arises when two (or more) sessions are waiting to acquire a lock on a shared resource, and none of them can proceed because a second session also has a lock on some other resource that is required by the first session. Imagine a situation, in which Session 1 holds resource A, while trying to access resource B; at the same time Session 2 holds resource B while trying to access resource A. 

Usually RDBMS resolves situations like this automatically by killing one of the processes and rolling back all the changes it may have made. 

Microsoft SQL Server 2000 employs a proprietary algorithm for detecting deadlocks and resolves them in a way similar to that implemented by Oracle or DB2 UDB: deadlocks are resolved automatically or manually through the Enterprise Manager Console. It is possible to volunteer a session to become a deadlock victim by setting the DEADLOCK_PRIORITY parameter within that session (see paragraph about sessions earlier in the chapter). 

SET DEADLOCK_PRIORITY LOW

Another way of dealing with the situation would be setting LOCK_TIMEOUT for the session. Setting the timeout means that the session will hold the resource under the lock no longer than a specified interval. Once the time set for locking expires, SQL Server returns an error and the transaction is rolled back. The resolution of the situation will be similar to that for every other RDBMS: handle the situation in which an error indicating a deadlock situation is returned (Error 1205 for SQL Server, SQLSTATE 40001) by re-running the transaction, redesigning the application to decrease or eliminate the deadlock possibility, and so on.


