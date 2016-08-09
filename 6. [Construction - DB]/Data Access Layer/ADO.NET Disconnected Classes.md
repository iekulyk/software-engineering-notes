ADO.NET Disconnected Classes
---

When trying to solve a problem, my first goal is to find the solution. The
solution is not always elegant or pretty, but the goal is to find a solution,
right? After that, the next step is to refactor your code and look for better performance.
This book covers some aspects of ADO.NET performance, but a good book
that delivers more in-depth information regarding ADO.NET performance tuning
is Improving .NET Application Performance and Scalability, and you can download
it for free. Chapter 12, “Improving ADO.NET Performance,” focuses on ADO.NET
performance.

###Working with the DataTable and DataSet Classes

The ADO.NET class hierarchy can be split into two categories: connected and disconnected
objects. Figure 1-1 shows the principal connected and disconnected classes. This lesson
describes the two primary disconnected classes, DataTable and DataSet, as shown in the diagram,
and many other classes of this category as well. The disconnected classes are covered in
detail because these classes can be used without ever creating a connection to a data store.

With each new version of ADO.NET, changes
have been made to these primary classes to improve functionality and performance.

The disconnected data access classes you instantiate in your applications are implemented
in the System.Data.dll assembly from the .NET Framework. These classes are in the
System.
Data
namespace. Because you must use the DataTable object when you’re using disconnected
classes, this chapter begins by covering the DataTable object and the objects with
which the DataTable object works closely. The DataSet object is covered in detail later on.

---

###The DataTable Class

A DataTable object represents tabular data as an in-memory, tabular cache of rows, columns,
and constraints. You typically use the DataTable class to perform any disconnected data
access. You start by creating an instance of the DataTable class, and then add DataColumn
objects that define the type of data to be held and insert DataRow objects that contain the
data. The following code, which creates a table for storing cars information, demonstrates the
creation of a data table:

```
DataTable cars = new DataTable ("Cars");
```

This code creates an empty data table for which the TableName property is set to Cars.
You can use the TableName property to access this data table when it is in a DataTable collection
(as detailed later in this chapter in the section titled “Using a DataSet Object to Coordinate
Work between Data Tables”).

---

###Adding DataColumn Objects to Create a Schema

The DataTable object is not useful until it has a schema, which is created by adding
DataColumn
objects and setting the constraints of each column. Constraints help maintain
data integrity by limiting the data that can be placed in the column. The following code adds
DataColumn objects to the cars DataTable object:

```
//Add the DataColumn using all properties
DataColumn vin = new DataColumn("Vin");
vin.DataType = typeof(string);
vin.MaxLength = 23;
vin.Unique = true;
vin.AllowDBNull = false;
vin.Caption = "VIN";
cars.Columns.Add(vin);

//Add the DataColumn using defaults
DataColumn make = new DataColumn("Make");
make.MaxLength = 35;
make.AllowDBNull = false;
cars.Columns.Add(make);

DataColumn year = new DataColumn("Year", typeof(int));
year.AllowDBNull = false;
cars.Columns.Add(year);

//Derived column using expression
DataColumn yearMake = new DataColumn("Year and Make");
yearMake.DataType = typeof(string);
yearMake.MaxLength = 70;
yearMake.Expression = "Year + ' ' + Make";
cars.Columns.Add(yearMake);
```

---

###Creating Primary Key Columns

The primary key of a DataTable object consists of a column or columns that make up a unique
identity for each data row. In the previous example, the vehicle identification number (VIN) is
considered as a unique key from which data for a given car can be retrieved. In other situations,
getting a unique key might require combining two or more fields. For example, a sales
order might contain sales order details that comprise the items being purchased on the sales
order. The primary key for each of the sales order detail rows might be the combination of
the order number and the line number. The PrimaryKey property must be set to an array of
DataColumn objects to accommodate composite (multiple) keys. The following code shows
how to set the PrimaryKey property for the cars DataTable object:

```
cars.PrimaryKey = new DataColumn[] {vin};
```

---

###Using Automatic Numbering for the Primary Key Column

You can also designate a column in your table as an auto-increment column. This column
will be automatically populated with a number that will be the primary key. To set up
an auto-increment
column, set the AutoIncrement property of your data column to true.
After
that, you set AutoIncrementSeed to the value of the first number you want and set
AutoIncrementStep
to the value you want to increment by each time a new row is added.

Auto incrementing is found in many database products, but how can it possibly work
properly in your application? The connected classes haven’t been covered yet, but you can
imagine that at some point you might want to send your new data to a back-end database. If
your application supplies the auto-increment values, what will the database do, especially if it
receives duplicate values from different client applications?

The answer is that these auto-increment values are never sent to the database because the
auto-increment column in the database table will provide a value when the new row is added.
After each new row is added, the back-end database table generates a new auto-increment
number, and then your application will query the database to get the newly created number.
Your application will then update its primary key number to the values that came from the
database. This means that all foreign key references will need to be updated as well.

So what happens if you add new rows in your application to generate auto-increment
values of 1 to 100 and then send these rows back to the database table, and the table already
has 10 rows? When the first row is sent from your application, it has an auto-increment value
of 1. The new auto-increment number created in the database will be 11. Your application
queries for the 11 and tries to change the 1 to an 11 but throws an exception because 11 is
already in your data table.

To solve this problem, set AutoIncrementSeed to -1 and set AutoIncrementStep to -1. This
will cause negative numbers to be generated; they won’t conflict with the values coming from
the database because the database doesn’t generate negative numbers.

---

###Creating DataRow Objects to Hold Data

After the DataTable object is created and contains DataColumn objects, you can populate the
DataTable object by adding DataRow objects. A DataRow object can be created only in the
context of a data table because the data row must conform to constraints of the DataTable
object’s columns.

---

###Adding Data to the Data Table

The DataTable object contains a Rows property of type DataRowCollection that stores
DataRow
objects. There are several ways to insert data into this collection.

DataRowCollection has an Add method that accepts a DataRow object. The Add method
is also overloaded to accept an array of objects instead of a DataRow object. If an array of
objects is passed to the Add method, the array object count must match the exact number of
DataColumn objects the data table has.

The Add method works well when you are creating a new row of data. If you want to
import DataRow objects that have been modified, you can use the ImportDataRow method,
which will preserve the original state and all other settings. The DataTable class also provides
several overloaded Load methods, which can be used to update existing DataRow objects or
load new DataRow objects. The data table requires the PrimaryKey property to be set so the
DataTable object can locate the rows to be updated. If you need to generate a data row, you
can use the LoadDataRow method, which accepts an array of objects, and a LoadOption enumeration
value.

---

###Viewing the State of the DataRow Object by Using DataRowState

DataRow goes through a series of states that can be viewed and filtered at any time. You can
retrieve the current state of a data row from its RowState property, which returns a value from
the DataRowState enumeration.

```
ROWSTATE                    | VALUE DESCRIPTION
-------------------------------------------------------------------------------------------
Detached                      The data row has been created but not added to a data table.
Added                         The data row has been created and added to the data table.
Unchanged                     The data row has not changed since the last call to the AcceptChanges method. 
                              When the AcceptChanges method is called, the data row changes to this state. 
Modified                      The data row has been modified since the last time the AcceptChanges method was called. 
                              Adding a row and modifying the row will keep the row in the Added state.
                              The row changes to the Modified state only if it was previously in the Unchanged state.
Deleted                       An attached data row is deleted by using the Delete method of the
                              DataRow object or when it is removed from its table by calling the
                              DataTable.DeleteRow method.
```

---

###Managing Multiple Copies of Data by Using DataRowVersion

The DataTable object can hold up to three versions of the data row data: Original, Current,
and Proposed. When the data row is loaded, it contains a single copy of the data. At that time,
only the Current version exists. You might be wondering why you have only the Current version
and not the Original version: Original implies that the row has been modified. Executing
the BeginEdit method will place the row into edit mode, and changes to the data are placed
into a second instance of the data, called the Proposed version. When the EndEdit method is
executed, the Current version becomes the Original version, the Proposed version becomes
the Current version, and the Proposed version no longer exists. After EndEdit is called, there
are two instances of the DataRow data, the Original and the Current versions. If the BeginEdit
method is called again, the Current version of the data is copied to a third instance of the
data, which is the Proposed version. Once again, calling the EndEdit method causes the
Proposed version to become the Current version, and the Proposed version no longer exists.
Notice that the Original version is not changed.

DataRow contains the HasVersion method that can query for the existence of a particular
data row version. Using the HasVersion method, you can check for the existence of a data row
version before attempting to retrieve it.

---

###Resetting the State by Using the AcceptChanges and RejectChanges Methods

You can use the AcceptChanges method to reset the DataRow state to Unchanged. This
method exists on the DataRow, DataTable, and DataSet objects. (This chapter covers the
DataSet
object later, in the section titled, “Using a DataSet Object to Coordinate Work between
Data Tables.”) In a typical data environment (after data has been loaded), the DataRow
state of the loaded rows is set to Added. Calling AcceptChanges on the data table resets the
row state of all the DataRow objects to Unchanged. Next, if you modify the DataRow objects,
their row state changes to Modified. When it is time to save the data, you can easily query
the DataTable
object for its changes by using the DataTable object’s GetChanges method.
This method returns a DataTable object populated with only the DataRow objects that have
changed since the last time AcceptChanges was executed. Only these changes need to be sent
to the data store.

After the changes have been successfully sent to the data store, you must change the state
of the DataRow objects to Unchanged, which essentially indicates that the DataRow objects
are synchronized with the data store. You use the AcceptChanges method for this purpose.
Note that executing the AcceptChanges method also causes the DataRow object’s Current
data row version to be copied to the DataRow object’s Original version.

The RejectChanges method rolls DataTable content back to what it was since its creation
or before the last time AcceptChanges has been called. Note that both AcceptChanges and
RejectChanges typically reset RowState to Unchanged, but RejectChanges also copies the
DataRow
object’s Original data row version to the DataRow object’s Current data row version.

---

###Using SetAdded and SetModified to Change RowState

DataRow contains the SetAdded and SetModified methods, which enable a data row state to
be set forcibly to Added or Modified, respectively. These operations are useful when you want
to force a data row to be stored in a data store different from the data store from which the
data row was originally loaded. For example, if you loaded a row from one data store, and
you want to send that row to a different data store, you execute the SetAdded method to
make the row look like a new row. DataAdapter object sends
changes to the data store. When you connect to the destination data store, the data adapter
object sees that your row has an Added row state, so the data adapter object executes an
insert statement to add the row to the destination data store.

hese methods can be executed only on DataRow objects whose row state is Unchanged.
An attempt to execute these methods on a DataRow object with a different row state throws
the exception called InvalidOperationException.

If the SetAdded method is executed, the DataRow object discards its Original data row version
because DataRow objects that have a row state of Added never contain an Original data
row version.

If the SetModified method is executed, the DataRow object’s RowState property is simply
changed to Modified without modifying the Original or Current data row version.

---

###Deleting the Data Row, and What About Undeleting?

DataRow contains a Delete method with which you can set the row state of the data row
to Deleted. DataRow objects that have a row state of Deleted indicate rows that need to be
deleted from the data store. When the DataRow object is deleted, the Current and Proposed
data row versions are discarded, but the Original data row version remains.

Sometimes you need to recover a deleted data row. The DataRow object doesn’t have an
Undelete method. However, in some situations, you can use the RejectChanges method to roll
back to a previous state when the deleted row was still there. Be aware that executing the
RejectChanges method copies the Original data row version to the Current data row version.
This effectively restores the DataRow object to its state at the time the last AcceptChanges
method was executed, but any subsequent changes that were made to the data prior to deleting
have been discarded.

---

### Enumerating the Data Table

It is possible to loop through the rows and columns of the data table by using a foreach
statement. The following code shows how the rows and columns of a data table can be
enumerated.

```
public void EnumerateTable(DataTable cars)
{
    var buffer = new System.Text.StringBuilder();
    foreach (DataColumn dc in cars.Columns)
    {
        buffer.AppendFormat("{0,15} ", dc.ColumnName);
    }
    buffer.Append("\r\n");
    foreach (DataRow dr in cars.Rows)
    {
      if (dr.RowState == DataRowState.Deleted)
      {
          buffer.Append("Deleted Row");
      }
      else
      {
          foreach (DataColumn dc in cars.Columns)
          {
              buffer.AppendFormat("{0,15} ", dr[dc]);
          }
      }
      buffer.Append("\r\n");
    }
    textBox1.Text = buffer.ToString();
}
```

---

###Copying and Cloning the Data Table

Sometimes you want to create a full copy of a data table. You can do this by using the
DataTable
object’s Copy method, which copies the DataTable object’s schema and data. The
following code sample shows how to invoke the Copy method

```
DataTable copy = cars.Copy( );
```

On some occasions, you might need a copy of the DataTable schema without data. To
copy just the schema without data, you can invoke the DataTable object’s Clone method. This
method is commonly used when an empty copy of the data table is required; at a later time,
DataRow objects can be added.

```
DataTable clone = cars.Clone( );
```

###Importing DataRow Objects into a Data Table

After cloning a data table, you might need to copy certain DataRow objects from one data
table to another. DataTable contains an ImportRow method, which you can use to copy a data
row from a data table that has the same schema. The ImportRow method is useful when the
Current and Original data row version must be maintained. For example, after editing a data
table, you might want to copy the changed DataRow objects to a different data table but
maintain the Original and Current data row version. The ImportRow method on the DataTable
object will import the DataRow objects as long as a data row with the same primary key does
not exist. (If a duplicate data row exists, a ConstraintException is thrown.) The following code
sample shows the process for cloning the data table and then copying a single data row to
the cloned copy.

```
DataTable clone = cars.Clone();
//import the row and include all row versions
clone.ImportRow(cars.Rows[0]);
```

---

###Using DataView as a Window into a Data Table

The DataView object provides a window into a data table that can be sorted and filtered.
A data table can have many DataView objects assigned to it, so the data can be viewed in
many ways without requiring it to be reread from the database.

The Sort, RowFilter, and
RowStateFilter
properties on the DataView object can be combined as needed. You can use
the DataView object’s AllowDelete, AllowEdit, and AllowNew properties to constrain user
input.

Internally, the DataView object is essentially an index. You can provide a sort definition to
sort the index in a certain order, and you can provide a filter to simply filter the index entries.

---

###Ordering Data Using the Sort Property

```
DataView view = new DataView(cars);
view.Sort = "Make ASC, Year DESC";
```

---

###Narrowing the Search by Using the RowFilter and RowStateFilter Properties


```
DataView view = new DataView(cars);
view.RowFilter = "Make like 'B%' and Year > 2003";
```

The RowStateFilter property provides a filter that applies on the RowState property or
on each data row. This filter provides an easy method of retrieving specific versions of rows
within the data table. The RowStateFilter property requires the use of DataViewRowState
enumeration values.

The DataViewRowState enumeration is a bit-flag enumeration, which means you can use the bitwise OR operator (that is, |) to build
compound filters. For example, the default RowState filter value is set to display multiple
states by using | to combine the Unchanged, Added, and ModifiedCurrent enumeration values.
Note that this combination is so useful that a dedicated value has been defined in the enumeration:
CurrentRows.

```
DataView view = new DataView(cars);
view.RowFilter = "Make like 'B%' and Year > 2003";
view.RowStateFilter = DataViewRowState.Deleted;
```

---

###Exporting a DataView Object to a New Data Table

A DataView object can be used to export data from one DataTable object to another. This can
be especially useful when a user-defined set of filters is applied and the user wants to convert
the view that is seen into a new data table. Exporting to a new data table is done with the
DataView object’s ToTable method.

```
//here is the method signature that will be used
//DataTable DataView.ToTable(string tableName, bool distinct, params string[] columnNames)
DataTable export = view.ToTable("MyCarTable", true, "Vin", "Make", "Year");
```

---

###Using a DataSet Object to Coordinate Work Between Data Tables

DataSet is a memory-based, tabular, relational representation of data and is the primary disconnected
data object. Conceptually, think of DataSet as an in-memory relational database,
but it’s simply cached data and doesn’t provide any of the transactional properties (atomicity,
consistency, isolation, durability) that are essential to today’s relational databases. DataSet
contains a collection of DataTable and DataRelation objects. The DataTable objects can contain unique and
foreign key constraints to enforce data integrity. DataSet also provides methods for cloning the DataSet schema,
copying the data set, merging with other DataSet objects, and listing changes.

You can create the DataSet schema programmatically or by providing an XML schema
definition. The following code demonstrates the creation of a simple data set containing a 
data table for vendors and a data table for parts. The two DataTable objects are joined using
a DataRelation object named vendors_parts.

```
//create vendor dataset
DataSet vendorData = new DataSet("VendorData");

DataTable vendors = vendorData.Tables.Add("Vendors");
vendors.Columns.Add("Id", typeof(Guid));
vendors.Columns.Add("Name", typeof(string));
vendors.Columns.Add("Address1", typeof(string));
vendors.Columns.Add("Address2", typeof(string));
vendors.Columns.Add("City", typeof(string));
vendors.Columns.Add("State", typeof(string));
vendors.Columns.Add("ZipCode", typeof(string));
vendors.Columns.Add("Country", typeof(string));
vendors.PrimaryKey = new DataColumn[] { vendors.Columns["Id"] };

DataTable part = vendorData.Tables.Add("Parts");
parts.Columns.Add("Id", typeof(Guid));
parts.Columns.Add("VendorId", typeof(Guid));
parts.Columns.Add("PartCode", typeof(string));
parts.Columns.Add("PartDescription", typeof(string));
parts.Columns.Add("Cost", typeof(decimal));
parts.Columns.Add("RetailPrice", typeof(decimal));
parts.PrimaryKey = new DataColumn[] { parts.Columns["Id"] };

vendorData.Relations.Add("vendors_parts", vendors.Columns["Id"], parts.Columns["VendorId"]);
```

---

###Being More Specific with Typed DataSet Objects

The previous code created a schema for a data set. Accessing the data table corresponding to
the vendors would require code like this:

```
DataTable vendorTable = vendorData.Tables["Vendors"];
```

What happens if the table name is spelled incorrectly? An exception is thrown, but not until
run time. A better approach is to create a new, specialized DataSet class that inherits from
DataSet, adding a property for each of the tables. For example, a specialized DataSet class
might contain a property called Vendors that can be accessed as follows:

```
DataTable vendorTable = vendorData.Vendors
```

Using this syntax, a compile-time error is generated if Vendor is not spelled correctly. Also,
the chances of incorrect spelling are significantly reduced because Visual Studio IntelliSense
displays the Vendors property for quick selection when the line of code is being typed. The
standard DataSet class is an untyped data set, whereas the specialized data set is a typed
data set.

You can create a typed DataSet class manually, but it’s usually better to provide an XML
schema definition (XSD) file to generate the typed DataSet class.Visual Studio contains a tool
called the DataSet Editor that you can use to create and modify an XSD file graphically, which,
in turn, can generate the typed DataSet class. You can invoke the DataSet Editor by adding a
DataSet file to a Visual Studio project: Right-click the project, choose Add, choose New Item,
and select the DataSet template in the Data section. After you add the DataSet template to
the project, the template will be open for you to edit by using the DataSet Editor.

---

###Connecting the Tables with DataRelation Objects

The DataRelation objects join DataTable objects in the same data set. Joining DataTable
objects creates a path from a column of one DataTable object to a column of another. This
DataRelation object can be traversed programmatically from parent data table to child data
table or from child data table to parent data table, which enables navigation between the
DataTable objects. The following code example populates the vendor and part DataTable
objects and then demonstrates DataRelation object navigation, first from parent to child and
then from child to parent, using the vendors_parts data relation.

```
//add vendors and parts
DataRow vendorRow = null;
vendorRow = vendors.NewRow();
Guid vendorId = Guid.NewGuid();
vendorRow["Id"] = vendorId;
vendorRow["Name"] = "Tailspin Toys";
vendors.Rows.Add(vendorRow);

DataRow partRow = null;
partRow = parts.NewRow();
partRow["Id"] = Guid.NewGuid();
partRow["VendorId"] = vendorId;
partRow["PartCode"] = "WGT1";
partRow["PartDescription"] = "Widget 1 Description";
partRow["Cost"] = 10.00;
partRow["RetailPrice"] = 12.32;
parts.Rows.Add(partRow);

partRow = parts.NewRow();
partRow["Id"] = Guid.NewGuid();
partRow["VendorId"] = vendorId;
partRow["PartCode"] = "WGT2";
partRow["PartDescription"] = "Widget 2 Description";
partRow["Cost"] = 9.00;
partRow["RetailPrice"] = 11.32;
parts.Rows.Add(partRow);

DataRow[] childParts = vendorRow.GetChildRows("vendors_parts");

DataRow parentRow = parts.Rows[1].GetParentRow("vendors_parts");
```

###Creating Primary and Foreign Key Constraints

You can create a DataRelation object with or without unique and foreign key constraints for
the sole purpose of navigating between parent and child DataTable objects. The DataRelation
class provides a constructor that enables the creation of a unique constraint on the parent
DataTable object and a foreign key constraint on the child DataTable object. These constraints
enforce data integrity by ensuring that a parent DataRow object exists for any child DataRow
object. The following code demonstrates the creation of the DataRelation object named
vendor_part, passing true to create constraints if they don’t already exist.

```
vendorData.Relations.Add("vendors_parts", vendors.Columns["Id"], parts.Columns["VendorId"], true);
```

---

###Cascading Deletes and Cascading Updates

foreign key constraint ensures that a child DataRow object cannot be added unless a valid
parent DataRow object exists. In some situations, it is desirable to force the deletion of the
child DataRow objects when the parent DataRow object is deleted. You can do this by setting
DeleteRule to Cascade on the ForeignKeyConstraint constraint of the child table corresponding
to the relation. Cascade is the default setting.

As with deleting, on some occasions, you’ll want to cascade changes to a unique key in the
parent DataRow object to the child DataRow object’s foreign key. You can set ChangeRule to
a member of the Rule enumeration to get the appropriate behavior.

---

###Using Merge to Combine DataSet Data

For example, a sales application might need to combine serialized DataSet objects received
by email from a number of sales people. Even internally within an application, you might
want to create a copy of DataTable objects the user can edit, and, based on the user clicking
Update, the modified data can be merged back to the original data set.

The DataSet class contains a method called Merge that can be used to combine data
from multiple DataSet objects. The Merge method has several overloads to merge data from
DataSet, DataTable, or DataRow objects.

```
//Create an initial DataSet
DataSet masterData = new DataSet("Sales");
DataTable people = masterData.Tables.Add("People");
people.Columns.Add("Id", typeof(Guid));
people.Columns.Add("Name", typeof(string));
people.PrimaryKey = new DataColumn[] { person.Columns["Id"] };
people.Rows.Add(Guid.NewGuid(), "Joe");

//get Joe's info
DataTable tempPeople = tempData.Tables["People"];
DataRow joe = tempPeople.Select("Name='Joe'")[0];
Guid joeId = (Guid)joe["Id"];

//Modify joe's name
joe["Name"] = "Joe in Sales";

DataTable orders = tempData.Tables.Add("Orders");
orders.Columns.Add("Id", typeof(Guid));
orders.Columns.Add("PersonId", typeof(Guid));
orders.Columns.Add("Amount", typeof(decimal));
orders.PrimaryKey = new DataColumn[] { orders.Columns["Id"] };
orders.Rows.Add(Guid.NewGuid(), joeId, 100);

//Now merge back to master
masterData.Merge(tempData, false, MissingSchemaAction.AddWithKey);
```

This code creates a data set that contains a single DataTable object, called People. A person
named Joe was added to the people DataTable object. The data row state for Joe’s data row
is Added. Next, the code copies the masterData DataSet object to a DataSet object called
tempData. The code modifies the tempData DataSet object by changing Joe’s name to “Joe in
Sales”, and then it creates a new DataTable object called Orders and adds an order.

The Merge method on masterData, which takes three parameters, is then called.
The first parameter is the tempData object. The second parameter is a Boolean called
preserveChanges,
which specifies whether updates from the tempData data set should
overwrite changes made in the masterData object. For example, Joe’s data row state in
the masterData data set is not Unchanged, so if the preserveChanges setting is true, Joe’s
name change (to “Joe in Sales”) will not be merged into masterData. The last parameter is a
MissingSchemaAction
enumeration member. The AddWithKey value is selected, which means
the Sales data table and its data are added to masterData.

When you use the Merge method, make sure the DataTable objects have a primary key.
Failure to set the PrimaryKey property of the DataTable object results in DataRow objects being
appended rather than existing DataRow objects being modified.

---

