Manage connection strings and objects
---

###Using Providers to Move Data

  - OleDb Contains classes that provide general-purpose data access to many data
sources. You can use this provider to access SQL Server 6.5 and earlier, SyBase,
DB2/400, and Microsoft Access.
  - Odbc Contains classes that provide general-purpose data access to many data
sources. This provider is typically used when no newer provider is available.
  - SQL Server Contains classes that provide functionality similar to the generic OleDb
provider. The difference is that these classes are tuned for SQL Server 7 and later data
access. SQL Server 6.5 and earlier must use the OleDb provider.

---

lists the primary provider classes and interfaces. The classes are subclassed by the
provider, which replaces the Db prefix with a provider prefix such as Sql, Odbc, or OleDb. You
can use the base classes with factory classes to create client code that is provider agnostic.
The following sections describe these classes in detail.

```
BASE CLASSES              | SQLCLIENT CLASSES         | GENERIC INTERFACE
-------------------------------------------------------------------------------
DbConnection                SqlConnection               IDbConnection
DbCommand                   SqlCommand                  IDbCommand
DbDataReader                SqlDataReader               IDataReader/IDataRecord
DbTransaction               SqlTransaction              IDbTransaction
DbParameter                 SqlParameter                IDbDataParameter
DbParameterCollection       SqlParameterCollection      IDataParameterCollection
DbDataAdapter               SqlDataAdapter              IDbDataAdapter
DbCommandBuilder            SqlCommandBuilder
DbConnectionStringBuilder   SqlConnectionStringBuilder
DbDataPermission            SqlPermission
```

------

###Getting Started with the DbConnection Object

You need a valid, open connection object to access a data store. The DbConnection class is an
abstract class from which the provider inherits to create provider-specific classes.

---

####Opening and Closing the Connection

You need a valid connection string to create a connection. The following code sample shows
how first to create the connection and then assign the connection string. With a valid connection
string, you can open the connection and execute commands. When you are finished
working with the connection object, you must close the connection to free up the resources
being held.

```

var connection = new SqlConnection();
connection.ConnectionString =
"Server=.;Database=Northwind;Trusted_Connection=true";
connection.Open();
//Do lots of cool work here
connection.Close();

```

The ConnectionString property is initialized with a string that contains key=value pairs
separated by a semicolon. The first part of the connection string (“Server=.”) dictates the
use of your local computer. The period can be replaced with an actual computer name
or IP address. The second part of the connection string (Database=Northwind) indicates
that you want to connect the Northwind database. The last part of the connection string
(Trusted_Connection=true) indicates that you will use your Windows login account for authentication
with SQL Server.

By creating an instance of the SqlConnection class, a DbConnection object is created because
SqlConnection inherits from DbConnection. This is accomplished by the SQL Server .NET
provider. The connection string is the same regardless of the programming language used.

---

####Configuring an ODBC Connection String

The connection string can be the most difficult object to set up when you’re working with a
provider for the first time. Open Database Connectivity (ODBC) is one of the older technologies
the .NET Framework supports, primarily because you still need the .NET Framework to
connect to older database products that have ODBC drivers.

```
KEYWORD             | DESCRIPTION
------------------------------------------------------
Driver                The ODBC driver to use for the connection
DSN                   A data source name, which can be configured by navigating through Control Panel | Administrative Tools | Data Sources(ODBC)
Server                The name of the server to which to connect
Trusted_Connection    Specifies that security is based on using the domain account ofthe currently logged-on user
Database              The database to which to connect
DBQ                   Typically refers to the physical path to a data source

```

####Sample ODBC Connection Strings

The following connection string instructs the text driver to treat the files located in the
C:\Test\MyFolder subdirectory as tables in a database.

```
Driver={Microsoft Text Driver (*.txt; *.csv)};
DBQ=C:\\Test\\MyFolder;
```

The following connection string instructs the Access driver to open the Northwind database
file located in the C:\Program Files\myApp folder.

```
Driver={Microsoft Access Driver (*.mdb)};
DBQ=C:\\program files\\myApp\\Northwind.mdb
```

The following connection string uses the settings that have been configured as a data
source name (DSN) on the current machine.

```
DSN=My Application DataSource
```

The following is a connection to an Oracle database on the ORACLE8i7 servers. The name
and password are passed in as well.

```
Driver={Microsoft ODBC for Oracle};
  Server=ORACLE8i7;
  UID=john;
  PWD=s3$W%1Xz
```

The following connection string uses the Excel driver to open the MyBook.xls file.

```
Driver={Microsoft Excel Driver (*.xls)};
DBQ=C:\\Samples\\MyBook.xls
```

The following connection string uses the SQL Server driver to open the Northwind database
on MyServer, using the passed-in user name and password.

```
DRIVER={SQL Server};
SERVER=MyServer;
UID=AppUserAccount;
PWD=Zx%7$ha;
DATABASE=Northwind;
```

This connection string uses the SQL Server driver to open the Northwind database on
MyServer using SQL Server trusted security.

```
DRIVER={SQL Server};
SERVER=MyServer;
Trusted_Connection=yes
DATABASE=Northwind;
```

----

###Configuring an OLEDB Connection String

Another common but earlier technology used to access databases is Object Linking and
Embedding for Databases

```
KEYWORD                 | DESCRIPTION
---------------------------------------------------
Data Source               The name of the database or physical location of the database file.
File Name                 The physical location of a file that contains the real connectionstring.
Persist Security Info     If set to true, retrieving the connection string returns the complete connection string that was originally provided. If set to fals, the
                          connection string will contain the information that was originally
                          provided, minus the security information.
Provider                  The vendor-specific driver to use for connecting to the data store.
```

####Sample OLEDB Connection Strings

```
Provider=Microsoft.Jet.OLEDB.4.0;
Data Source=C:\Program Files\myApp\demo.mdb;
Persist Security Info=False
```

---

####Configuring an SQL Server Connection String

The SQL Server provider enables you to access SQL Server 7.0 and later. If you need to connect
to SQL Server 6.5 and earlier, use the OLEDB provider

----


###Storing the Connection String in the Application Configuration File

You can store ConnectionString properties in the machine, application, or Web configuration
file, so the connection strings can be changed without requiring a recompile of the application.
You place the <connectionStrings> element under the <configuration> root element.
This section supports the <add>, <remove>, and <clear> tags,

```
<connectionStrings>
  <clear />
  <add name="nw"
    providerName="System.Data.SqlClient"
    connectionString=
    "Data Source=.\SQLEXPRESS;
      AttachDbFilename=|DataDirectory|Northwind.MDF;
      Integrated Security=True;
      User Instance=True"/>
</connectionStrings>
```

This example clears the list of connection settings that might have been defined in the
machine configuration file and then adds a new connection string setting called nw. The connection
strings can be accessed in code by using the static ConnectionStrings collection on
the ConfigurationManager class (implemented in the System.Configuration.dll assembly), as
shown in the following code sample.

```
//Get the settings from the configuration file
var nw = ConfigurationManager.ConnectionStrings["nw"];
var connection = new SqlConnection(nw.ConnectionString);
//name = "nw"
var name = nw.Name;
//provider = "System.Data.SqlClient"
var provider = nw.ProviderName;

//cnString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|
// \Northwind.MDF;Integrated Security=True;User Instance=True"
var cnString = nw.ConnectionString;
MessageBox.Show("From App.Config: " + cnString);
```

---

###Encrypted Communications to SQL Server

To enable encrypted communications between the client and SQL Server, a digital certificate
must be installed at SQL Server, and then you can use the Encrypt setting in the connection
string to turn on encryption.
The following is an example of a connection string that can turn on encrypted
communications.

```
Data Source=.\SQLEXPRESS;
  AttachDbFilename=C:\MyApplication\Northwind.MDF;
  Integrated Security=True;
  User Instance=True;
  Encrypt=true
```
If you’re using C#, don’t forget that you must escape the strings with backslashes by using
two backslashes (\\) for each single backslash, or by preceding the string with an at (@) symbol
to turn off escape processing. The Encrypt setting is set to true so that all communication
between the client and the server is encrypted.

---

###Storing Encrypted Connection Strings in Web Applications

Web applications don’t have an App.config file; they have a Web.config file. It’s common
practice to store connection strings in the Web.config file. This makes it easy to change
the connection string without requiring a recompile of the application. However, connection
strings can contain logon information such as user names and passwords. You certainly
don’t want this information to be easily readable by anyone. The solution is to encrypt the
connection strings.You can do this by using the aspnet_regiis.exe utility to encrypt the
connectionStrings section. You can use the /? option to get help on the utility.

You encrypt and decrypt the contents of a Web.config file by using System.Configuration
.DPAPIProtectedConfigurationProvider, which uses the Windows Data Protection API (DPAPI)
to encrypt and decrypt data, or System.Configuration.RSAProtectedConfigurationProvider,
which uses the RSA encryption algorithm to encrypt and decrypt data

When you use the same encrypted configuration file on many computers in a Web farm,
only System.Configuration.RSAProtectedConfigurationProvider enables you to export the
encryption keys that encrypt the data and import them on another server. This is the default
setting.

---

####Implementing an Encrypted ConnectionString Property

You can encrypt the Web.config file by running the Visual Studio .NET command prompt and
executing the following command, specifying the full path to your website folder

```
aspnet_regiis -pef "connectionStrings" "C:\...\EncryptWebSite"
```

Note that the –pef switch requires you to pass the physical website path, which is the last
parameter. Be sure to verify the path to your Web.config file.

changes are made to the connectionStrings section—for example, if another connection
is added using the GUI tools—the new connection will be encrypted; that is, you won’t have
to run the aspnet_regiis utility again.
You can decrypt the connectionStrings section by using the following command:

```
aspnet_regiis -pdf "connectionStrings" "C:\...\EncryptWebSite"
```

---

###Connection Pooling

Creating a physical connection to the database is an expensive task. Connection pooling
is reusing existing active connections with the same connection string instead of creating
new connections when a request is made to the database. It involves the use of a connection
manager that is responsible for maintaining a list, or pool, of available connections for a
given connection string. Several pools exist if different connection strings ask for connection
pooling.

When the connection manager receives a request for a new connection, it checks in the
pool corresponding to the connection string for available connections. If a connection is
available, it is returned. If no connections are available and the maximum pool size has not
been reached, a new connection is created, added to the pool, and returned. If the maximum
pool size has been reached, the connection request is added to a queue to wait until a connection
becomes available and is returned. If the connection time-out defined in the connection
string expires, an exception is raised.

Connection pooling is controlled by parameters placed into the connection string. The following
parameters affect pooling

  - Connection Timeout
  - Min Pool Size
  - Max Pool Size
  - Pooling
  - Connection Reset
  - Load Balancing Timeout (Connection Lifetime)
  - Enlist
  
To implement connection pooling, you must follow a few rules.

  - The connection string must be the same for every user or service that participates in
the pool. Each character must match in terms of lowercase and uppercase as well.
  - The user ID must be the same for every user or service that participates in the pool.
Even if you specify integrated security=true, the Windows user account of the process
determines pool membership.
  - The process ID must be the same. It has never been possible to share connections
across processes, and this limitation extends to pooling.

---

####Where’s the Pool?

Connection pooling is a client-side technology. The database has no idea that one or more
connection pools might be involved in your application. Client-side means that the connection
pooling takes place on the machine initiating the DbConnection object’s Open statement

---

####When Is the Pool Created

The connection pool group is an object that manages the connection pools for a specific
ADO.NET provider. When the first connection is instantiated, a connection pool group is created.
However, a connection pool is not created until the first connection is opened. When
a connection is closed or disposed, it goes back to the pool as available and will be returned
when a new connection request is done.

----

####How Long Will the Connection Stay in the Pool

A connection is removed from the pool of available connections when used and then returned
to the pool of available connections when the connection is closed. By default, when a
connection is returned to the connection pool, it has an idle lifetime of 4 to 8 minutes (a time
that is set somewhat randomly). This means the connection pool will not continue to hold on
to idle connections indefinitely. If you want to make sure that at least one connection is available
when your application is idle for long periods, you can set the connection string’s Min
Pool Size to one or more

---

####Load-Balancing Timeout (Connection Lifetime)

The connection string has a setting called Load Balancing Timeout, formerly known as
Connection
Lifetime. Connection Lifetime still exists for backward compatibility, but the new
name describes this setting’s intended use better. Use this setting only in an environment with
clustered servers because it is meant to aid in load balancing database connections. This setting
is examined only when the connection is closed. If the connection stays open longer than
its Load Balancing Timeout setting, the connection is destroyed. Otherwise, it is added back
into the pool.

---

####Exceeding the Pool Size

The default maximum connection pool size is 100. You can modify this by changing the Max
Pool Size connection string setting, although the default setting is fine for most scenarios.
How do you know whether you need to change this value? You can use Performance Monitor
to watch the .NET DataProvider for SqlServer/NumberOfPooledConnections counter. If the
maximum pool size is reached, any new requests for a connection will be blocked until a connection
frees up or the Connection Timeout connection string setting expires. The Connection
Timeout setting has a default value of 15 seconds. If you exceed the Connection Timeout
value, an InvalidOperationException will be thrown. This same exception is thrown if you try to
connect to a database server and the server cannot be reached or if the server is found but
the database service is down.

---

####When to Turn Off Pooling

It’s a good idea to keep pooling on at all times, but if you need to troubleshoot connectionrelated
problems, you can turn it off. Pooling is on by default, but you can change the Pooling
setting in the connection string to false to turn off pooling. Remember that performance will
suffer because each Open statement creates a new connection to the database, and each
Dispose/Close statement destroys the connection. Also, without any limits in terms of number
of connections, the server might deny the requests for a connection if the licensing limit is
exceeded or the administrator has set connection limits at the server.

---

####Clearing the Pool

A database server might not always be available; it might have been removed from a cluster,
or you might have needed to stop and start the service. When a database server becomes
unavailable, the connections in the pool become corrupted.

You can use two methods in your code to recover from a corrupted connection
pool: ClearPool and ClearAllPools. These are static methods on the SqlConnection and
OracleConnection
classes. If the database service is stopped and restarted, the previous code
will cause a SqlException to be thrown, stating that a transport-level error has occurred. To
recover from this exception silently, you can clean the pools and then re-execute the code.

---

###Working with the SqlConnection Class

```
<connectionStrings>
  <add name="db" connectionString="Data Source=.\SQLEXPRESS;Integrated Security=True" />
</connectionStrings>
```

Add a reference to System.Configuration.DLL.

```
cnString = ConfigurationManager
              .ConnectionStrings["db"]
              .ConnectionString;
              
CheckConnectivity();
PopulateDataSet();

dgVehicles.DataSource = ds;
dgVehicles.DataMember = "Vehicles";
dgRepairs.DataSource = ds;
dgRepairs.DataMember = "Vehicles.vehicles_repairs";
```

```
private bool CheckConnectivity()
{
  try
  {
    using (var cn = new SqlConnection(cnString))
    {
      cn.Open();
      var version = cn.ServerVersion;
      MessageBox.Show("Connectivity established! " + version);
    }
  }
  catch (Exception ex)
  {
    MessageBox.Show(ex.Message);
    return false;
  }
  return true;
}
```

```
private void gridError(object sender, DataGridViewDataErrorEventArgs e)
{
    MessageBox.Show(e.Exception.Message);
}
```

-----

###Reading and Writing Data

To execute commands to the database, you must have an open connection and a command
object.

---

####DbCommand Object

You use the DbCommand object to send a Structured Query Language (SQL) command to the
data store. DbCommand can be a Data Manipulation Language (DML) command to retrieve,
insert, update, or delete data. The DbCommand object can also be a Data Definition Language
(DDL) command, which enables you to create tables and modify schema information
at the database. The DbCommand object requires a valid open connection to issue the command
to the data store. A DbConnection object can be passed into the DbCommand object’s
constructor or attached to the DbCommand object’s Connection property after DbCommand
is created, but the best way to create a DbCommand object is to use the CreateCommand
method on the DbConnection object so that provider-specific code is limited to the creation
of the DbConnection object, and the DbConnection object automatically creates the appropriate
provider-specific command object behind the scene.

DbCommand also requires a valid value for its CommandText and CommandType properties.
The following code sample shows how to create and initialize a DbCommand object

```
var nw = ConfigurationManager.ConnectionStrings["nw"];
var connection = new SqlConnection(nw.ConnectionString);
var cmd = connection.CreateCommand();

cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "CustOrderHist";
//don't forget to close the connection!
```

This code creates a DbConnection object that is an instance of SqlConnection. The
DbConnection
object is then used to create a SqlCommand object, which is assigned to cmd.
The DbConnection object must be opened before any command can be submitted. If it
executes a stored procedure, the CommandText property contains the name of the stored
procedure, whereas CommandType indicates that this is a call to a stored procedure

---

###DbParameter Objects

Stored procedures typically require parameter values to be passed to them to execute. For
example, a stored procedure called CustOrderHist might require a customer identification to
retrieve information about the appropriate customer. You can create System.Data.Common
.DbParameter objects by using the Parameters.Add method on the Command object, as
shown here.

```
var nw = ConfigurationManager.ConnectionStrings["nw"];
var connection = new SqlConnection();
connection.ConnectionString = nw.ConnectionString;

var cmd = connection.CreateCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "CustOrderHist";

DbParameter parm = cmd.CreateParameter();
parm.ParameterName = "@Id";
parm.Value = "ANATR";
cmd.Parameters.Add(parm);
```

This code creates a DbConnection object and a DbCommand object. It also configures
the DbCommand object to execute a stored procedure called uspGetCustomerById, which
requires a single parameter called @Id that is assigned the value “ANATR.”

You can use the name assigned to the DbParameter object to access the parameter
through code. For example, to retrieve the value currently in the @Id SQL parameter, use the
following code:

```
var id = (string)cmd.Parameters["@Id"].Value;
```

---

###ExecuteNonQuery Method

You execute a DbCommand object differently depending on the data being retrieved
or modified or the database object you are creating, altering, or dropping. You use the
ExecuteNonQuery
method when you don’t expect a command to return any rows—an insert,
update, or delete query, for example. This method returns an integer that represents the
number of rows affected by the operation. The following example executes a SQL command
to add 10% to the unit price of the product whose ProductID is 10, and it returns the number
of rows that were updated.

```
var nw = ConfigurationManager.ConnectionStrings["nw"];
int count = 0;
using (var connection = new SqlConnection())
{
    connection.ConnectionString = nw.ConnectionString;
    var cmd = connection.CreateCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText =  "UPDATE Products SET UnitPrice = UnitPrice * 1.1 WHERE ProductID =
    connection.Open();
    count = cmd.ExecuteNonQuery();
}
MessageBox.Show(count.ToString());
```

---

###ExecuteReader Method

The ExecuteReader method returns a DbDataReader instance. (DbDataReader is covered
in more detail in the next section.) The DbDataReader object is a forward-only, readonly,
server-side cursor. DbDataReader objects can be created only by executing one of
the ExecuteReader
methods on the DbCommand object. The following example uses the
ExecuteReader
method to create a DbDataReader object with the selection results and then
continuously loops through the results until the end of data has been reached (when the Read
method returns false).

```
var nw = ConfigurationManager.ConnectionStrings["nw"];
var connection = new SqlConnection();
connection.ConnectionString = nw.ConnectionString;

var cmd = connection.CreateCommand();
cmd.CommandType = CommandType.Text;
cmd.CommandText = "SELECT ProductID, UnitPrice FROM Products";
connection.Open();

DbDataReader rdr = cmd.ExecuteReader();

while (rdr.Read())
{
    MessageBox.Show(rdr["ProductID"] + ": " + rdr["UnitPrice"]);
}
connection.Close();
```

---

###ExecuteScalar Method

Queries are often expected to return a single row with a single column. In these situations,
the results can be treated as a single return value. For example, the following SQL returns a
result that consists of a single row with a single column.

```
SELECT COUNT(*) FROM Products
```

If you use the ExecuteScalar method, the .NET Framework run time will not incur the overhead
to produce objects that read the result stream, which means less resource usage and
better performance. The following code shows how to use the ExecuteScalar method to easily
retrieve the number of rows in the Sales table directly into a variable called count.

```
var nw = ConfigurationManager.ConnectionStrings["nw"];
var connection = new SqlConnection();
connection.ConnectionString = nw.ConnectionString;

var cmd = connection.CreateCommand();
cmd.CommandType = CommandType.Text;

cmd.CommandText = "SELECT COUNT(*) FROM Products";

connection.Open();

int count = (int)cmd.ExecuteScalar();

connection.Close();

MessageBox.Show(count.ToString());
```

---

###DbDataReader Object

A DbDataReader object provides a high-performance method of retrieving data from
the data store. It delivers a forward-only, read-only, server-side cursor. This makes the
DbDataReader
object an ideal choice for populating ListBox objects and DropDownList objects.
When you run reports, you can use the DbDataReader object to retrieve the data from
the data store, but it might not be a good choice when you are coding an operation that
modifies data and needs to send the changes back to the database. For data modifications,
the DbDataAdapter object, which is covered in the next section, might be a better choice.

The DbDataReader object contains a Read method that retrieves data into its buffer. Only
one row of data is ever available at a time, which means that all the data from the database
does not need to be completely read into the application before it is processed. For example,
the sample code in the previous section created a DbDataReader and looped through the
data, using a while loop that could have exited from the loop, pending some condition being
met. This example, however, populates a new DataTable object directly with the list of
Products from the Northwind database. The table is then bound to a ComboBox object called
cmbProducts.

```
var nw = ConfigurationManager.ConnectionStrings["nw"];
var connection = new SqlConnection();
connection.ConnectionString = nw.ConnectionString;

var cmd = connection.CreateCommand();
cmd.CommandType = CommandType.Text;
cmd.CommandText = "SELECT ProductID, ProductName FROM Products";

connection.Open();

var rdr = cmd.ExecuteReader();

var products = new DataTable();

products.Load(rdr, LoadOption.Upsert);

connection.Close();

cmbProducts.DataSource = products;
cmbProducts.DisplayMember = "ProductName";
cmbProducts.ValueMember = "ProductID";
```

The DataTable object’s Load method has a LoadOption parameter that gives you the option
of deciding which DataRowVersion object should get the incoming data. For example,
if you load a DataTable object, modify the data, and then save the changes back to the
database, you might encounter concurrency errors if someone else has modified the data
between the time you got the data and the time you attempted to save the data. One option
is to load the DataTable object again, using the default PreserveCurrentValues enumeration
value, which loads the original DataRowVersion object with the data from the database while
leaving the current DataRowVersion object untouched. Next, you can simply execute the
Update method again, and the database will be updated successfully.


For this to work properly, the DataTable object must have a defined primary key. Failure
to define a primary key results in duplicate DataRow objects being added to the DataTable
object. 

---

###Using Multiple Active Result Sets (MARS) to Execute Multiple Commands on a Connection

Using the DbDataReader object is one of the fastest methods to retrieve data from the database,
but one of the problems with DbDataReader is that it keeps an open server-side cursor
while you are looping through the results of your query. If you try to execute another command
while the first command is still executing, you will receive an InvalidOperationException,
stating, “There is already an open DataReader associated with this Connection which must be
closed first.” You can avoid this exception by setting the MultipleActiveResultSets connection
string option to true when connecting to Multiple Active Result Sets (MARS)–enabled hosts
such as SQL Server 2005 and later. For example, the following connection string shows how
this setting is added into a new connection string called nwMars.

```
<connectionStrings>
    <clear />
        <add name="nw" providerName="System.Data.SqlClient" connectionString= "Data Source=.\SQLEXPRESS; AttachDbFilename=|DataDirectory|Northwind.MDF;Integrated Security=True; User Instance=True"/>
        <add name="nwMars" providerName="System.Data.SqlClient" connectionString= "Data Source=.\SQLEXPRESS; AttachDbFilename=|DataDirectory|Northwind.MDF; Integrated Security=True; User Instance=True;MultipleActiveResultSets=True"/>
</connectionStrings>
```


---


###Performing Bulk Copy Operations with a SqlBulkCopy Object

Often, you need to copy large amounts of data from one location to another. Most of the database
servers provide a means to copy from one database to another, either by a Windows
GUI interface such as the SQL Server Enterprise Manager or by a command-line tool such as
the SQL Server Bulk Copy Program (BCP.exe). In addition to using the tools provided by the
database vendor, you also can write your own bulk copy program, using the SqlBulkCopy
class.

The SqlBulkCopy class provides a high-performance method for copying data to a table
in a SQL Server database. The source of the copy is constrained by the overloads of the
WriteToServer
method, which can accept an array of DataRow objects, an object that implements
the IDataReader interface, a DataTable object, or DataTable and DataRowState.
variety of parameters means you can retrieve data from most
locations.

---

###DbDataAdapter Object

You use the DbDataAdapter object to retrieve and update data between a data table and a
data store. DbDataAdapter is derived from the DataAdapter class and is the base class of the
provider-specific DbDataAdapter classes

DbDataAdapter has a SelectCommand property you use when retrieving the data.
SelectCommand
must contain a valid DbCommand object, which must have a valid connection.
Internally, SelectCommand has an ExecuteReader method, which is executed to get a
DbDataReader object to populate a DataTable object.

DbDataAdapter also has InsertCommand, UpdateCommand, and DeleteCommand properties,
which might contain DbCommand objects. You use these commands if you want to save
DataTable changes back to the data store. You need not create these command objects if you
need only to read data from the data store, but if you create one of these latter three commands,
you must create all four of them (select, insert, update, and delete).

When DbDataAdapter is used to retrieve or update data, it examines the status of the connection.
If the connection is open, the DbDataAdapter uses the open connection and leaves
the connection open. If the connection is closed, DbDataAdapter opens the connection, uses
it, and then closes it automatically. If you never open the connection, you don’t have to close
the connection. However, if you have many data adapters that will be used in one operation,
you can get better performance by manually opening the connection before you call all the
data adapters; just be sure to close the connection when you’re done.

---

###Saving Changes to the Database Using the Update Method

The Update method saves the data table modifications to the database by retrieving the
changes from the data table and then using the respective InsertCommand, UpdateCommand,
or DeleteCommand property to send the appropriate changes to the database on a row-byrow
basis. The Update method retrieves the DataRow objects that have changed by looking
at the RowState property of each row. If RowState is anything but Unchanged, the Update
method sends the change to the database.

For the Update method to work, all four commands must be assigned to the
DbDataAdapter
object. Normally, this means creating individual DbCommand objects
for each command. You can easily create the commands by using the DbDataAdapter
Configuration
Wizard, which starts when a DbDataAdapter object is dropped onto the
Windows
form. The wizard can generate stored procedures for all four commands.

---

