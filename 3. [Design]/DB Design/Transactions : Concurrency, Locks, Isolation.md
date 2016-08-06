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


