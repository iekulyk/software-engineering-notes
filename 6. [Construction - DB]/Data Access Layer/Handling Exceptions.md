Handling Exceptions
---

Prevent the exception
from being thrown when possible. If you can’t prevent an exception, handle the exception
gracefully. In this lesson, you learn about areas in which you prevent exceptions and implement
error handling to improve the behavior of your application when errors occur.

There are two primary reasons for handling exceptions in your applications. One is to recover
gracefully from an exception that you are aware might occur. In this scenario, you have
identified that a SqlException is thrown when attempting to connect to the database server
while it’s being restarted. You might want to offer the ability to retry or simply try three times
before ending the application.

The other reason is to minimize the amount of information that might be conveyed to a
malicious user. For example, if such a user is causing an exception to occur, you certainly don’t
want to display a detailed error message that includes source code. It’s important to display a
user-friendly message that has little information about the error and log as much information
as possible.

---

###Preventing Connection and Command Exceptions

When opening a connection to the database server, an exception might be thrown because
the server is not available. The connection timeout defaults to 15 seconds, and you should
consider your scenario to decide whether to increase or decrease this time. For fast networks,
you might lower this time so you can fail quickly. Why wait more than five seconds to fail
when you know that most of your connections take only one second? However, if you’re on a
slow connection, you might set the connection timeout to a higher value.

You set the connection timeout in your connection string, as shown in the following connection
string sample that sets the connection timeout to 30 seconds.

```
"server=.;database=northwind;integrated security=true;connection timeout=30"
```

You might also have a scenario in which certain queries are throwing an exception because
they take too long to execute. You can set the CommandTimeout property to give more time
for commands to execute before the timeout exception is thrown. In all these examples, the
default value is 30, in seconds.

To set the command timeout with traditional ADO.NET classes, DbCommand has a
CommandTimeout property you can set.

```
private void mnuAdoNetCommandTimeout_Click(object sender, RoutedEventArgs e)
{
    var cnSetting = ConfigurationManager.ConnectionStrings["nw"];
    using(var cn = new SqlConnection())
    using(var cmd = cn.CreateCommand())
    {
        cn.ConnectionString = cnSetting.ConnectionString;
        cmd.CommandTimeout = 60;
        cmd.CommandText = "Select @@version";
        cn.Open();
        MessageBox.Show(cmd.ExecuteScalar().ToString());
    }
}
```

When working with LINQ to SQL classes, you can set the CommandTimeout property of
the DataContext object.

```
private void mnuLinqToSqlCommandTimeout_Click(object sender, RoutedEventArgs e)
{
    using(var db = new LinqToSql.NorthwindDataContext())
    {
        db.CommandTimeout = 60;
        var count = db.Employees.Count();
        MessageBox.Show(String.Format("Employee Count:{0}", count));
    }
}
```

When working with the Entity Framework, the ObjectContext object contains a
CommandTimeout that you can set.

```
private void mnuEntityFrameworkCommandTimeout_Click(object sender, RoutedEventArgs e)
{
    using (var db = new NorthwindEntities())
    {
        db.CommandTimeout = 60;
        var count = db.Employees.Count();
        MessageBox.Show(String.Format("Employee Count:{0}", count));
    }
}
```

---

###Handling Connection and Query Exceptions

There are many scenarios in which you can’t prevent an exception proactively. For example,
you might be readying data from the database server and the server loses power. This
throws an exception, and you’ll need a way to catch it. This is when you can benefit from the
try/catch block in your code.

The try block should contain all the “happy path” code, meaning that all the code that
should execute if no errors take place should be in the try block. The catch blocks contain the
alternate code paths that execute if an exception is thrown.

If an exception is thrown, you should have catch blocks for each type of exception for
which you have specific handling. Also, you should consider a catch block that catches
Exception,
which is the default if there is no match to any of the other catch blocks you have.
Why would you want to catch an exception? If you don’t know what the exception is, how can
you recover from it? In many scenarios, it’s more appropriate to catch only exceptions from
which you know how to recover. You could, however, catch an exception for the purpose of
logging the exception just before ending the application.

```
private void mnuAdoNetTryCatch_Click(object sender, RoutedEventArgs e)
{
    try
    {
        var cnSetting = ConfigurationManager.ConnectionStrings["nw"];
        using (var cn = new SqlConnection())
        using (var cmd = cn.CreateCommand())
        {
            cn.ConnectionString = cnSetting.ConnectionString;
            cmd.CommandTimeout = 60;
            cmd.CommandText = "Select @@version";
            cn.Open();
            MessageBox.Show(cmd.ExecuteScalar().ToString());
        }
    }
    catch (SqlException ex)
    {
        MessageBox.Show("SQL Exception: " + ex.Message);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Exception: " + ex.Message);
    }
}
```

In this example, the using block is inside the try block, so if an error occurs, SqlCommand
and SqlConnection will be disposed before the catch block is called. Also, you could certainly
use a finally block to dispose SqlCommand and SqlConnection, but you would be required to
declare the cn and cmd variables outside the try/catch/finally block to access these variables
in a finally block.

Like the previous code sample, the using block in this sample is inside the try block, so if
an error occurs, SqlCommand and SqlConnection will be disposed before the catch block is
called.

---

###Handling Exceptions When Submitting Changes

Handling exceptions when submitting changes to the database requires a bit more work.
First, ensure that your changes are saved as part of a transaction. Next, consider what you will
do if you can’t submit changes successfully. Finally, if the changes have been submitted successfully,
reset the state of your data to Unchanged. By resetting the state, you are essentially
declaring that you are now in sync with the database.

The following code sample demonstrates handling exceptions with the traditional
ADO.NET classes when submitting changes. First, a DataTable object is loaded, then changes
are made, and, finally, the changes are submitted within a transaction.

```
private void mnuAdoNetSubmitChanges_Click(object sender, RoutedEventArgs e)
{
    var cnSetting = ConfigurationManager.ConnectionStrings["nw"];
    var sql = "SELECT * FROM PRODUCTS";
    var da = new SqlDataAdapter(sql, cnSetting.ConnectionString);
    var bldr = new SqlCommandBuilder(da);
    var dt = new DataTable("Products");
    //retrieve data
    try
    {
      da.Fill(dt);
    }
    catch (SqlException ex)
    {
      MessageBox.Show("SQL Exception: " + ex.Message);
      return;
    }
    catch (Exception ex)
    {
      MessageBox.Show("Exception: " + ex.Message);
      return;
    }
    //modify
    foreach (DataRow row in dt.Rows)
    {
        var price = (decimal)row["UnitPrice"];
        row["UnitPrice"] = price * 1.1m;
    }
    //submit the changes
    try
    {
        using (var tran = new TransactionScope())
        {
            da.ContinueUpdateOnError = false;
            da.Update(dt);
            dt.AcceptChanges();
            tran.Complete();
        }
    }
    catch (SqlException ex)
    {
        MessageBox.Show("SQL Exception: " + ex.Message);
        return;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Exception: " + ex.Message);
        return;
    }
    MessageBox.Show("Update Complete");
}
```

When working with the LINQ to SQL classes, the submission of changes to the database is
automatically handled within a transaction when you call the SubmitChanges method on the
DataContext object. Also, the AcceptChanges method is automatically called if no exception
is thrown when updating, which will reset the state of all objects to Unchanged. Although the
SubmitChanges method is executed within a transaction, you might need to create your own
transaction if you must perform other operations within the same transaction.

----
