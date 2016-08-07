Transactions : Concurrency, Locks, Isolation
---

###Concurrency

Large databases are used by many people. Many transactions to be run on the database. It is desirable to let them run at the same time as each other.
Need to preserve isolation. f we don’t allow for concurrency then transactions are run sequentially. Have  a queue of transactions. Long transactions (eg backups) will make others wait for long time.

####Concurrency Problems

  - In order to run transactions concurrently we interleave their operations
  - Each transaction gets a share of the computing time
  - This leads to several sorts of problems
    - Lost updates
    - Uncommitted updates
    - Incorrect analysis
  - All arise because isolation is broken
  
#### Lost Update

T1 and T2 read X, both modify it, then both write it out
```
T1 -> Read(x); x = x - 5;                     Write(X);           Commit;
```
```
T2 ->                     Read(X); x = x + 5;           Write(x);        Commit;
```
The net effect of T1 and T2 should be no change on X. Only T2;s change is seen, however, so the final value of X has increase by 5

#### Uncommitted Update (“dirty read”)

T2 sees the change to X made by T1, but T1 is rolled back 
```
T1 -> Read(x); x = x - 5; Write(X);                              Rollback;
```
```
T2 ->                               Read(X); x = x + 5; Write(x);          Commit;
```

The change made by T1 is undone on rollback. It should be as if that change never happened.

#### Inconsistent analysis

T1 doesn’t change the sum of X and Y, but T2 sees a change
```
T1 -> Read(x); x = x - 5; Write(X);                               Read(Y); Y = Y + 5; Write(Y)
```
```
T2 ->                               Read(X); Read(Y); Sum = X + Y;
```
T1 consists of two parts – take 5 from X and then add 5 to Y.

T2 sees the effect of the first, but not the second.

-----------------------

###Schedules

A schedule is a sequence of the operations
by a set of concurrent transactions that
preserves the order of operations in each of
the individual transactions

A serial schedule is a schedule where
operations of each transaction are executed
consecutively without any interleaved
operations from other transactions (each
transaction commits before the next one is
allowed to begin)

###Serial schedules

Serial schedules are guaranteed to avoid
interference and keep the database
consistent

 However databases need concurrent access
which means interleaving operations from
different transactions

####Serialisability

Two schedules are equivalent if they always
have the same effect.

A schedule is serialisable if it is equivalent
to some serial schedule.

if two transactions only read some data items,
then the order is which they do it is not important

If T1 reads and updates X and T2 reads and
updates a different data item Y, then again they
can be scheduled in any order.

###Conflict Serialisability

Two transactions
have a conflict : 

YES If at least one is
a write and they use
the same resource

NO If they refer to
different resources

NO If they are reads

A schedule is conflict
serialisable if
transactions in the
schedule have a
conflict but the
schedule is still
serialisable

###Locking

Locking is a procedure used to control
concurrent access to data (to ensure
serialisability of concurrent transactions)+

 In order to use a ‘resource’ (table, row, etc)
a transaction must first acquire a lock on
that resource

This may deny access to other transactions
to prevent incorrect results

####Two types of locks

  - Two types of lock:
    -  Shared lock (S-lock or read-lock)
    -  Exclusive lock (X-lock or write-lock)
  - Read lock allows several transactions simultaneously to read a resource (but no transactions can change it at the same time)
  - Write lock allows one transaction exclusive access to write to a resource. No other transaction can read this resource at the same time.
  - The lock manager in the DBMS assigns locks and records them in the data dictionary
  
####Locking

  - Before reading from a
resource a transaction
must acquire a read-lock
  - Before writing to a
resource a transaction
must acquire a write-lock
  - Locks are released on
commit/rollback
  - A transaction may not
acquire a lock on any
resource that is writelocked
by another
transaction
  - A transaction may not
acquire a write-lock on a
resource that is locked
by another transaction
  -  If the requested lock is
not available, transaction
waits


###Resolving Concurrency Problems with Locks

#### Lost Update

```
T1 -> Read(x); S-Lock;                  x = x + 1; X-Lock Request; Waiting.....
```
```
T2 ->                  Read(X); S-Lock;                           x = x + 1; X-Lock Request; Waiting.....
```

Deadlock !!!

#### Uncommitted Update (“dirty read”)

```
T1 -> Update(X); X-Lock;                               Commit/Rollback; X-Lock Removed;
```
```
T2 ->                   Read(X); S-Lock; Waiting.......................................;Read(X);S-Lock;
```

```
T1 -> Update(X); X-Lock;                               Commit/Rollback; X-Lock Removed;
```
```
T2 ->                   Update(X); X-Lock; Waiting.......................................;Update(X);X-Lock;
```

#### Inconsistent analysis

```
T1 -> Read(X); S-Lock(X);Sum = 40;--- Read(Y);S-Lock(Y); Sum = 40;Read(Z);S-Lock(Z); Waiting..........
```
```
T2 ->                    Read(Z);S-Lock(Z);Upadte(X);X-Lock(Z);Read(X);S-Lock(X);Waiting..............
```

Deadlock !!!

-----------------------


###Deadlocks

 A deadlock is an
impasse that may
result when two or
more transactions
are waiting for locks
to be released which
are held by each
other.

see above.

---

### Isolation

In database systems, isolation determines how transaction integrity is visible to other users and systems. For example, when a user is creating a Purchase Order and has created the header, but not the Purchase Order lines, is the header available for other systems/users, carrying out concurrent operations (such as a report on Purchase Orders), to see?

A lower isolation level increases the ability of many users to access data at the same time, but increases the number of concurrency effects (such as dirty reads or lost updates) users might encounter. Conversely, a higher isolation level reduces the types of concurrency effects that users may encounter, but requires more system resources and increases the chances that one transaction will block another.

####Read uncommitted

This is the lowest isolation level. In this level, dirty reads are allowed, so one transaction may see not-yet-committed changes made by other transactions.

####Read committed

In this isolation level, a lock-based concurrency control DBMS implementation keeps write locks (acquired on selected data) until the end of the transaction, but read locks are released as soon as the SELECT operation is performed (so the non-repeatable reads phenomenon can occur in this isolation level, as discussed below). As in the previous level, range-locks are not managed.

Putting it in simpler words, read committed is an isolation level that guarantees that any data read is committed at the moment it is read. It simply restricts the reader from seeing any intermediate, uncommitted, 'dirty' read. It makes no promise whatsoever that if the transaction re-issues the read, it will find the same data; data is free to change after it is read.

####Repeatable reads

In this isolation level, a lock-based concurrency control DBMS implementation keeps read and write locks (acquired on selected data) until the end of the transaction. However, range-locks are not managed, so phantom reads can occur.

####Serializable

With a lock-based concurrency control DBMS implementation, serializability requires read and write locks (acquired on selected data) to be released at the end of the transaction. Also range-locks must be acquired when a SELECT query uses a ranged WHERE clause, especially to avoid the phantom reads phenomenon (see below).

-------------------------

####Read phenomena

The ANSI/ISO standard SQL 92 refers to three different read phenomena when Transaction 1 reads data that Transaction 2 might have changed.

####Dirty reads (aka uncommitted dependency)

A dirty read occurs when a transaction is allowed to read data from a row that has been modified by another running transaction and not yet committed.

####Non-repeatable reads

A non-repeatable read occurs, when during the course of a transaction, a row is retrieved twice and the values within the row differ between reads.

#####Phantom reads

A phantom read occurs when, in the course of a transaction, two identical queries are executed, and the collection of rows returned by the second query is different from the first.


