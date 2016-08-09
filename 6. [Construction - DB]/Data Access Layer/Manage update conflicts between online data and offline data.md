Manage update conflicts between online data and offline data
---

When connectivity to mobile devices such as laptops is required, consider the implementation
of an occasionally connected application (OCA), which enables a remote worker to
continue to access information because the information is stored in a local database on the
user’s device. The OCA typically includes data synchronization capabilities to populate the
local database, to periodically synchronize the information stored in the client database
(such as SQL Server Compact), and to synchronize changes with a server database (such as
SQL Server).
Thus, a synchronization-based solution does not require a constant network connection
to the database server because the data is stored locally.

Synchronization between data stores has never been an easy task; it consumes a lot of
time and resources. This is where the Microsoft Sync Framework enters the picture. The
Microsoft Sync Framework simplifies the integration of application data synchronization from
any data store.

With the Microsoft Sync Framework, Microsoft released Microsoft Synchronization Services
for ADO.NET, Synchronization Services for File Systems, and Synchronization Services for
FeedSync. These services enable developers to perform synchronizations for specific environments,
whereas the Microsoft Sync Framework is used for building synchronization logic
within your application.

---

###Change Tracking

A method of change tracking is required to make data synchronization efficient. Change
tracking is the ability to maintain a list of the inserts, updates, and deletes that have been
made to the local database. With change tracking at the client, you don’t need to send all 
data back to the server; you send only the changes. With change tracking at the server, the
server needs to send changes only to the client.

SQL Server 2008 contains a method for tracking changes called SQL Server 2008 Change
Tracking. With this method, the database administrator can identify specific tables to be
monitored for changes. SQL Server 2008 will then keep track of the inserts, updates, or deletes.
When the client application requests changed data, SQL Server 2008 will provide all the
changes that have occurred since the last successful download by the requester.

In an OCA environment, the Microsoft Sync Framework takes advantage of SQL
Server
2008 Change Tracking by not requiring schema changes to enable change tracking.
Triggers aren’t even required, which translates to significantly better performance than
trigger-based change tracking solutions. The overhead of enabling SQL Server 2008 change
tracking on a table is conceptually the same as the overhead of maintaining a second index

---

###Conflict Detection

With OCA, conflicts are an issue that arises when two or more databases change the same
piece of data and then the synchronization engine tries to apply those changes in a single
database. What should happen if the traveling salesperson updates a customer record while
the home office personnel update the same customer record? The traveling salesperson has
the original customer record, and then the home office successfully updates the central database.
In the meantime, the traveling salesperson changes the customer record and attempts
to synchronize the update to the main database, which causes a conflict because the current
state of the row is different from what the synchronization engine expected.

To resolve conflicts, business rules must be implemented because conflict resolution will
be based on the problem domain. One way to resolve the conflict is to implement a business
rule stating that the last change sent to the database server is the one that wins. Another
resolution is a rule stating that the winner can be based on location (headquarters or remote
office) or title (president versus salesperson).

The Microsoft Sync Framework provides conflict detection and resolution capabilities out
of the box. Furthermore, SQL Server 2008 decreases the complexity associated with recognizing
conflicts. Using the built-in conflict detection, the home office personnel successfully
upload the change to the central server because this is the first change. When the traveling
salesperson uploads the change, a conflict is detected because the change version in the central
server does not exist in the current salesperson database. Logic in the remote application
determines how to handle the conflict.

---

###Data Prioritization

With slow network connections, you’ll be looking for ways to optimize the exchange of data.
You can prioritize data by defining the set of data that has a high priority or is critical. This
causes critical changes to be synchronized immediately and leaves less important data to be
synchronized later. The Microsoft Sync Framework enables your remote application to synchronize
on a table-by-table basis and on an upload-only or download-only basis.

The Microsoft Sync Framework supports synchronization by using a background thread. If
you are using a local database such as SQL Server Compact, synchronization can be executed
in the background.

---

###Implementing the Microsoft Sync Framework

You can add synchronization support to your application by using Sync Services for ADO.NET,
which uses SQL Server Compact 3.5 to create a lightweight data store on your local file system.
SQL Server Compact uses a file as its repository.

Before you implement Synchronization Services for ADO.NET, you must decide how
to track changes in your data. In Synchronization Services for ADO.NET, you can use the
SQL Server 2008 integrated change tracking, or you can use custom tracking by managing
change tracking yourself in the application database. Integrated change tracking does not
work with SQL Server Express.

To add synchronization services to your application, in Solution Explorer, rightclick
the project node and choose Add | New Item. Select your language and click
Data. In the data templates window, select Local Database Cache, change the name to
NorthwindLocalDataCache.
sync, and click Add. The Configure Data Synchronization window
opens.

you select a connection to a SQL Server 2008 database (not SQL Express), the Use
SQL Server change tracking check box will be accessible.Use this option
to enable integrated change tracking.

The Advanced section enables you to force changes to occur within a single transaction.
You might select that option when you want to ensure that either all or none of the changes
are persisted, but, often, you want to save as much data as possible and be notified of problems.
For those scenarios, leave the check box cleared.

In the Cached Tables list box, click Add to configure the tables to be cached locally. This
opens the Configure Tables For Offline Use window, as shown in Figure 8-8. In this window,
select the tables of which you want to keep local copies. In this example, the Customers table
has been selected. The Data To Download drop-down list enables you to select between
incremental synchronization of changes or synchronization by copying the complete table.
The Compare Updates, Deletes, and Inserts drop-down lists are disabled if you opt to use
SQL Server change tracking, but if you didn’t choose SQL Server change tracking, these dropdown
lists would be accessible for you to select a column that can confirm that a change took
place.

After selecting the desired tables to be cached, click OK to go back to the Configure
Data Synchronization screen. This screen has a Show Code Example
link. Click the link to display sample code. Click Copy Code To The Clipboard and close the
window. Click OK, and the Generate SQL Scripts window is displayed. 
SQL Server
needs its settings updated to perform change tracking, and you might want to
keep the scripts in your project for future use on your QA or production database. Click OK to
execute the scripts.

When the scripts execute on SQL Server 2008, tables that are enabled for integrated
change tracking log every data change in a change tracking log table. When you synchronize,
the Sync Services look at the log to identify changes since the last synchronization. You don’t
need to change the database schema to enable synchronization.

If you’re not using SQL Server 2008, as is the case for applications using SQL Server Express
or SQL Server 2005, integrated change tracking is not available. Consider using custom
change tracking, which identifies insertions and updates of records in a table with the help
of columns and identifies deletions with the help of a tombstone table. To help Sync Services
identify rows that have been updated or inserted since the last update, add new columns
to each table you want to track. These columns are Update Originator, Update Time, Create
Originator, and Create Time. You must also create a tombstone table to keep a log of all rows
that are removed. Within the table, you need at least two pieces of information: the time of
deletion and the row’s original primary key. The tombstone table is where Sync Services finds
entries that must be removed from the destination store because they have been removed
from the source. All this information helps Sync Services identify the changes since last
synchronization.


The next screen is the DataSource Configuration Wizard. This window enables you to
choose between implementing a typed data set or using the Entity Framework. Select
DataSet
and, on the next screen, select the Tables node, which selects the Customers table
and the offline overhead tables.

After the wizard has completed, you can add traditional ADO.NET code to load a data set
with the customers and bind the Customers DataTable to a DataGrid, as shown in the following
code sample.

```
private CustomersTableAdapter northwindDataSetCustomersTableAdapter = new CustomersTableAdapter();

private void mnuGetOfflineData_Click(object sender, RoutedEventArgs e)
{
    northwindDataSetCustomersTableAdapter.Fill(northwindDataSet.Customers);
    dg.ItemsSource = northwindDataSet.Customers;
}
```

When running this code, you will see that the DataGrid control, called dg, is populated
with customers. The customers came from the local cache, but this local cache is not being
updated. You can verify that the local cache is not being updated by changing the
ContactName
of the first customer and then restarting the program. You’ll see that the
change was not persisted. The following code saves the changes to the local cache.

```
private void mnuSaveOfflineData_Click(object sender, RoutedEventArgs e)
{
    northwindDataSetCustomersTableAdapter.Update(northwindDataSet.Customers);
    MessageBox.Show("Saved");
}
```

This code sample saves the customers to the local cache. If you run the application, make
changes, and then click the menu option to save, you see a message stating that the customers
were saved. If you stop running the application and restart the application, you see the
changed data, thus proving that the changes were persisted.

The only problem with the previous code sample is that the changes were saved only to
the local cache; the changes weren’t sent to SQL Server. If you open SQL Management Studio
and look at the Customers table, you see that Customer still has the original values for all
columns. To synchronize the local cache with SQL Server, add the following sample code.

```
private void mnuSyncOfflineData_Click(object sender, RoutedEventArgs e)
{
    var syncAgent = new NorthwindLocalDataCacheSyncAgent();
    syncAgent.Customers.SyncDirection = SyncDirection.Bidirectional;
    var syncStats = syncAgent.Synchronize();
    northwindDataSet.Customers.Merge(
    northwindDataSetCustomersTableAdapter.GetData());
    MessageBox.Show("In Sync");
}
```

If you run this code sample, the local cache will be synchronized with the SQL Server database.
This code starts by creating a NorthwindLocalDataCacheSyncAgent object. This class
was created by the wizard and inherits from the SqlCeClientSyncProvider class. You provide
each table with an enumeration value that specifies SyncDirection

  - Bidirectional : The first synchronization downloads the schema and data from the
server. Subsequent synchronizations upload changes from the client,
followed by downloading changes from the server

  - UploadOnly : The first synchronization downloads the schema and data from the
server. Subsequent synchronizations upload changes from the client.

  - DownloadOnly : The first synchronization downloads the schema and data from the
server. Subsequent synchronizations download changes from the
server.

  - Snapshot : The client downloads the complete set of data every time synchronization
takes place.

---



