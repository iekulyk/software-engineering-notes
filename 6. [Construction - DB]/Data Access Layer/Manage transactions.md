Manage transactions
---

A transaction is an atomic unit of work that must be completed in its entirety. The transaction
succeeds if it is committed and fails if it is aborted. Transactions have four essential attributes:
atomicity, consistency, isolation, and durability (known as the ACID attributes).

  - ■ Atomicity The work cannot be broken into smaller parts. Although a transaction
might contain many SQL statements, they must be run as an all-or-nothing proposition,
which means that if a transaction is half complete when an error occurs, the work
reverts to its state prior to the start of the transaction.
  - ■ Consistency A transaction must operate on a consistent view of the data and must
leave the data in a consistent state. Any work in progress must not be visible to other
transactions until the transaction has been committed.
  - ■ Isolation A transaction should appear to be running by itself; the effects of other ongoing
transactions must be invisible to this transaction, and the effects of this transaction
must be invisible to other ongoing transactions.
  - ■ Durability When a transaction is committed, it must be persisted so it will not be lost
in the event of a power failure or other system failure. Only committed transactions are
recovered during power-up and crash recovery; uncommitted work is rolled back.

---

###Concurrency Models and Database Locking

The attributes of consistency and isolation are implemented by using the database’s locking
mechanism, which keeps one transaction from affecting another. If one transaction
needs access to data with which another transaction is working, the data is locked until the
first transaction is committed or rolled back. Transactions that must access locked data are
forced to wait until the lock is released, which means that long-running transactions can affect
performance and scalability. The use of locks to prevent access to the data is known as a
“pessimistic”
concurrency model.
In an “optimistic” concurrency model, locks are not used when the data is read. Instead,
when updates are made, the data is checked to see whether the data has changed since it
was read. If the data has changed, an exception is thrown and the application applies business
logic to recover.

---

###Transaction Isolation Levels

Complete isolation can be great, but it comes at a high cost. Complete isolation means that
any data read or written during a transaction must be locked. Yes, even data that is read is
locked because a query for customer orders should yield the same result at the beginning of
the transaction and at the end of the transaction

Depending on your application, you might not need complete isolation. By tweaking the
transaction isolation level, you can reduce the amount of locking and increase scalability and
performance. The transaction isolation level affects whether you experience the following:

  - ■ Dirty read Being able to read data that has been changed by another transaction but
not committed yet. This can be a big problem if the transaction that has changed data
is rolled back.
  - ■ Nonrepeatable read When a transaction reads the same row more than once with
different results because another transaction has modified the row between reads.
  - ■ Phantom read When a transaction reads a row that a different transaction will delete
or when a second read finds a new row that has been inserted by another transaction.

---

###Single Transactions and Distributed Transactions

A transaction is a unit of work that must be performed with a single durable resource (such as
a database or a message queue). In the .NET Framework, a transaction typically represents all
the work that can be done on a single open connection.
A distributed transaction spans multiple durable resources. In the .NET Framework, if
you need a transaction to include work on multiple connections, you must perform a distributed
transaction. A distributed transaction uses a two-phase commit protocol and a
dedicated transaction manager. In Windows operating systems since Microsoft Windows NT,
the dedicated transaction manager for managing distributed transactions is the Distributed
Transaction
Coordinator (DTC).

---

###Creating a Transaction

The two types of transactions are implicit and explicit. Each SQL statement runs in its own implicit
transaction. If you don’t explicitly create a transaction, a transaction is implicitly created
for you on a statement-by-statement basis. This ensures that a SQL statement that updates
many rows is either completed as a unit or rolled back

---

###Creating a Transaction by Using T-SQL

```
SQL: Explicit Transaction
SET XACT_ABORT ON
BEGIN TRY
  BEGIN TRANSACTION
  --work code here
  COMMIT TRANSACTION
END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION
  --cleanup code
END CATCH
```

---

###Creating a Transaction by Using the ADO.NET DbTransaction Object

Another way to create an explicit transaction is to put the transaction logic in your .NET
Framework code. The DbConnection object has the BeginTransaction method, which creates a
DbTransaction object. The following code sample shows how this is done.

```
private void beginTransactionToolStripMenuItem_Click(object sender, EventArgs e)
{
    ConnectionStringSettings cnSetting = ConfigurationManager.ConnectionStrings["nw"];
    using (SqlConnection cn = new SqlConnection())
    {
        cn.ConnectionString = cnSetting.ConnectionString;
        cn.Open();
        using (SqlTransaction tran = cn.BeginTransaction())
        {
            try
            {
                //work code here
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.Transaction = tran;
                    cmd.CommandText = "SELECT count(*) FROM employees";
                    int count = (int)cmd.ExecuteScalar();
                    MessageBox.Show(count.ToString());
                }
                //if we made it this far, commit
                tran.Commit();
            }
            catch (Exception xcp)
            {
                tran.Rollback();
                //cleanup code
                MessageBox.Show(xcp.Message);
            }
        }
    }   
}
```

creates a transaction object by executing the BeginTransaction method. The try block does
the work and commits the transaction. If an exception is thrown, the catch block rolls back the
transaction. Although the data has been rolled back, if you need to reset any variables as a
result of the rollback, you can do so at the Clean Up Code comment is. Also, the SqlCommand
object must have its Transaction property assigned to the connection’s transaction.
The scope of the transaction is limited to the code within the try block, but the transaction
was created by a specific connection object, so the transaction cannot span to a different
connection object.

---

###Setting the Transaction Isolation Level

Each SQL Server connection (SQL session) can have its transaction isolation level set. The setting
you assign remains until the connection is closed or until you assign a new setting. One
way to assign the transaction isolation level is to add the SQL statement to your stored procedure.
For example, to set the transaction isolation level to Repeatable Read, add the following
SQL statement to your stored procedure..

```
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
``

Another way to set the transaction isolation level is to add a query hint to your SQL statement.
For example, the following SQL statement overrides the current session’s isolation setting
and uses the Read Uncommitted isolation level to perform the query.

```
SELECT * FROM CUSTOMERS WITH (NOLOCK)
```

---

###Introducing the System.Transactions Namespace

The System.Transactions namespace offers enhanced transactional support for managed
code and makes it possible to handle transactions in a rather simple programming model.
System.
Transactions
is designed to integrate well with SQL Server 2005 and later and offers
automatic promotion of standard transactions to fully distributed transactions.

---

###Creating a Transaction by Using the TransactionScope Class

You can also create a transaction in your .NET Framework code by using classes in the
System.
Transactions
namespace. The most commonly used class is the TransactionScope class;
it creates a standard transaction called a “local lightweight transaction” that is automatically
promoted to a full-fledged distributed transaction if required. This automatically promoted
transaction is commonly referred to as an implicit transaction. The distinction is worth
mentioning because it seems to give a somewhat different meaning to this term. Even in this
context, you are not explicitly creating the transaction for the work and explicitly issuing a
commit or rollback. Instead, you are creating a scope in which a transaction will exist and will
automatically commit or roll back.

```
private void systemTransactionToolStripMenuItem_Click(object sender, EventArgs e)
{
    ConnectionStringSettings cnSetting = ConfigurationManager.ConnectionStrings["nw"];
    using (TransactionScope ts = new TransactionScope())
    {
        using (SqlConnection cn = new SqlConnection())
        {
            cn.ConnectionString = cnSetting.ConnectionString;
            cn.Open();
            //work code here
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "SELECT count(*) FROM employees";
                int count = (int)cmd.ExecuteScalar();
                MessageBox.Show(count.ToString());
            }
            //if we made it this far, commit
            ts.Complete();
        }
    }
}
```

This code starts by creating a TransactionScope object in a using block. If a connection
is created, the TransactionScope object assigns a transaction to this connection so
you don’t need to add anything to your code to enlist this connection into the transaction.
The SqlCommand
object doesn’t need to have the Transaction property assigned,
but the SqlCommand
object joins the transaction. If an exception is thrown within the
TransactionScope
object’s using block, the transaction aborts, and all work is rolled back. The
last line of the TransactionScope object’s using block calls the Complete method to commit
the transaction. This method sets an internal Boolean flag called complete. The Complete
method can be called only once. This is a design decision that ensures that you won’t continue
adding code after a call to Complete and then try calling Complete again. A second call
to Complete will throw an InvalidOperationException.

The scope of the transaction is limited to the code within the TransactionScope object’s
using block, which includes any and all connections created within the block, even
if the connections are created in methods called within the block. You can see that the
TransactionScope
object offers more functionality than ADO.NET transactions and is easy
to code.

---

###Setting the Transaction Options

You can set the isolation level and the transaction’s timeout period on the TransactionScope
object by creating a TransactionOptions object. The TransactionOptions structure has an
IsolationLevel property you can use to deviate from the default isolation level of Serializable
and employ another isolation level (such as Read Committed). The isolation level is merely
a suggestion (hint) to the database. Most database engines try to use the suggested level if
possible. The TransactionOptions type also has a Timeout property that can be used to deviate
from the default of one minute.

---

###Working with Distributed Transactions

Before the release of the classes in the System.Transactions namespace, developers had to create
classes that inherited from the ServicedComponent class in the System.EnterpriseServices
namespace to perform distributed transactions, as shown in the following sample.

```
[Transaction]
public class MyClass : ServicedComponent
{
    [AutoComplete]
    public void MyMethod()
    {
        // calls to other serviced components
        // and resource managers like SQL Server
    }
}
```

The Transaction and AutoComplete attributes ensure that any method called within the
class is in a transactional context. The AutoComplete attribute makes it simple to commit a
transaction in a declarative way, but you can also use the ContextUtil class for better control
of the transaction from within your code.

The problem with this old approach is that you must inherit from the ServicedComponent
class; that is, you lose the flexibility of inheriting from a class that might be more appropriate
to your internal application’s class model. Also, the DTC is always used, which is too resource
intensive if you don’t really need to execute a distributed transaction. Ideally, the DTC should
be used only when necessary. This approach uses the COM+ hosting model, by which your
component must be loaded into Component Services.

The System.Transactions namespace includes the Lightweight Transaction Manager (LTM)
in addition to the DTC. Use the LTM to manage a single transaction to a durable resource
manager such as SQL Server 2005 and later. Volatile resource managers, which are memory
based, can also be enlisted in a single transaction. The transaction managers are intended to
be invisible to the developer, who never needs to write code to access them.

Using the TransactionScope object and the same programming model you used for single
transactions, you can easily create a distributed transaction. When you access your first
durable resource manager, a lightweight committable transaction is created to support the
single transaction. When you access a second durable resource manager, the transaction is
promoted to a distributed transaction. When a distributed transaction is executed, the DTC
manages the two-phase commit protocol to commit or roll back the transaction.

The LTM and the DTC represent their transaction by using the System.Transactions
.Transaction
class, which has a static (Visual Basic shared) property called Current that gives
you access to the current transaction. The current transaction is known as the ambient transaction.
This property is null (Visual Basic Nothing) if there is no ongoing transaction. You can
access the Current property directly to change the transaction isolation level, roll back the
transaction, or view the transaction status.

---

###Promotion Details

When a transaction is first created, it always attempts to be a lightweight committable
transaction, managed by the LTM. The LTM allows the underlying durable resource manager,
such as SQL Server 2005 and later, to manage the transaction. A transaction managed by
the underlying manager is known as a delegated transaction. The only thing the LTM does
is monitor the transaction for a need to be promoted. If promotion is required, the LTM tells
the durable resource manager to provide an object that is capable of performing a distributed
transaction. To support the notification, the durable resource manager must implement
the IPromotableSinglePhaseNotification interface. This interface, and its parent interface, the
ITransactionPromoter.

---




