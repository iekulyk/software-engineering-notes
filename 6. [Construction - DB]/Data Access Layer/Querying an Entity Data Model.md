Querying an Entity Data Model
---

###Querying Asynchronously 

You have a long-running Entity Framework querying operation. You do not want to block the application running on
the main thread while the query executes. Instead, you’d like the user to be able to perform other operations until
data is returned. Equally important, you will want to query the model leveraging the Microsoft LINQ-to-Entities
framework, which is the preferred approach for querying an entity data model.

---

```
private static void Main()
{
 var asyncTask = EF6AsyncDemo();
 foreach (var c in BusyChars())
 {
 if (asyncTask.IsCompleted)
 {
 break;
 }
 Console.Write(c);
 Console.CursorLeft = 0;
 Thread.Sleep(100);
 }
 Console.WriteLine("\nPress <enter> to continue...");
 Console.ReadLine();
}
private static IEnumerable<char> BusyChars()
{
 while (true)
 {
 yield return '\\';
 yield return '|';
 yield return '/';
 yield return '-';
 }
}
private static async Task EF6AsyncDemo()
{
 await Cleanup();
 await LoadData();
 await RunForEachAsyncExample();
 await RunToListAsyncExampe();
 await RunSingleOrDefaultAsyncExampe();
}

private static async Task Cleanup()
{
 using (var context = new EFRecipesEntities())
 {
 // delete previous test data
 // execute raw sql statement asynchronoulsy
 Console.WriteLine("Cleaning Up Previous Test Data");
 Console.WriteLine("=========\n");
 await context.Database.ExecuteSqlCommandAsync("delete from chapter3.AssociateSalary");
 await context.Database.ExecuteSqlCommandAsync("delete from chapter3.Associate");
 await Task.Delay(5000);
 }
}
private static async Task LoadData()
{
 using (var context = new EFRecipesEntities())
 {
 // add new test data
 Console.WriteLine("Adding Test Data");
 Console.WriteLine("=========\n");
 var assoc1 = new Associate { Name = "Janis Roberts" };
 var assoc2 = new Associate { Name = "Kevin Hodges" };
 var assoc3 = new Associate { Name = "Bill Jordan" };
 var salary1 = new AssociateSalary
 {
 Salary = 39500M,
 SalaryDate = DateTime.Parse("8/4/09")
 };
 var salary2 = new AssociateSalary
 {
 Salary = 41900M,
 SalaryDate = DateTime.Parse("2/5/10")
 };
 var salary3 = new AssociateSalary
 {
 Salary = 33500M,
 SalaryDate = DateTime.Parse("10/08/09")
 };
 assoc1.AssociateSalaries.Add(salary1);
 assoc2.AssociateSalaries.Add(salary2);
 assoc3.AssociateSalaries.Add(salary3);
 context.Associates.Add(assoc1);
 context.Associates.Add(assoc2);
 context.Associates.Add(assoc3);
 // update datastore asynchronoulsy
 await context.SaveChangesAsync();
 await Task.Delay(5000);
 }
}

private static async Task RunForEachAsyncExample()
{
 using (var context = new EFRecipesEntities())
 {
 Console.WriteLine("Async ForEach Call");
 Console.WriteLine("=========");
 // leverage ForEachAsync
 await context.Associates.Include(x => x.AssociateSalaries).ForEachAsync(x =>
 {
 Console.WriteLine("Here are the salaries for Associate {0}:", x.Name);
 foreach (var salary in x.AssociateSalaries)
 {
 Console.WriteLine("\t{0}", salary.Salary);
 }
 });
 await Task.Delay(5000);
 }
}
private static async Task RunToListAsyncExampe()
{
 using (var context = new EFRecipesEntities())
 {
 Console.WriteLine("\n\nAsync ToList Call");
 Console.WriteLine("=========");
 // leverage ToListAsync
 var associates = await context.Associates.Include(x => x.AssociateSalaries).OrderBy(x =>
x.Name).ToListAsync();
 foreach (var associate in associates)
 {
 Console.WriteLine("Here are the salaries for Associate {0}:", associate.Name);
 foreach (var salaryInfo in associate.AssociateSalaries)
 {
 Console.WriteLine("\t{0}", salaryInfo.Salary);
 }
 }
 await Task.Delay(5000);
 }
}

private static async Task RunSingleOrDefaultAsyncExampe()
{
 using (var context = new EFRecipesEntities())
 {
 Console.WriteLine("\n\nAsync SingleOrDefault Call");
 Console.WriteLine("=========");
 var associate = await context.Associates.
    Include(x => x.AssociateSalaries).
  O rderBy(x => x.Name).
 FirstOrDefaultAsync(y => y.Name == "Kevin Hodges");
 Console.WriteLine("Here are the salaries for Associate {0}:", associate.Name);
 foreach (var salaryInfo in associate.AssociateSalaries)
 {
 Console.WriteLine("\t{0}", salaryInfo.Salary);
 }
 await Task.Delay(5000);
 }
}
```

---

In this example, we demonstrate two key concepts of Entity Framework usage: Querying the model using the LINQ
extensions for Entity Framework and the new asynchronous capabilities implemented in Entity Framework 6.

We start by clearing out any previous test data in the underlying data store. Notice how we wrap the
Cleanup() operation inside an async method. We then generate native SQL statements using the new
ExecuteSqlCommandAsync() method. Note how we leverage the async/await patterns found in the 4.5 version of the
.NET framework. This pattern enables asynchronous operations without explicitly instantiating a background thread;
additionally, it frees up the current CLR thread while it is waiting for the database operation to complete.
Next we load test data for both Associate and Associate Salaries. To execute the call asynchronously, as before,
we wrap the LoadData() operation inside an async method and insert new test data into the underlying data store by
calling the newly added SaveChangesAsync() method.
Next, we present three different queries that go against the model. Each leverages the LINQ extensions
for Entity Framework. Each is contained within an async method, leveraging the await/async pattern. In the
RunForEachAsyncExample() method, we make use of the ForEachAsync() extension method, as there is no async
equivalent of a foreach statement. Leveraging this async method, along with the Include() method, we are able to
query and enumerate these objects asynchronously.
In the subsequent RunToListAsyncExample() and RunSingelOrDefaultAsyncExample() queries, we leverage the
new asynchronous methods for ToList() and SingleOrDefault().
Entity Framework now asynchronously exposes a large number of its operational methods. The naming
convention appends the suffix Async to the existing API name, making it relatively simple to implement asynchronous
processing when adding or fetching data from the underlying data store.

---

###Updating with Native SQL Statements

You want to execute a native SQL statement against the Entity Framework to update the underlying data store.

---

```
context.Database.ExecuteSqlCommand("delete from chapter3.payment");
```

```
var sql = @"insert into Chapter3.Payment(Amount, Vendor) values (@p0, @p1)";
 var rowCount = context.Database.ExecuteSqlCommand(sql, 99.97M, "Ace Plumbing");
```

---

The best practice is to use parameters
whenever possible. Here are some reasons why:
  
  - Parameterized SQL statements help prevent SQL Injection attacks. If you construct a complete
SQL statement as a string by dynamically appending together strings that you get from a
user interface, such as an ASP.NET TextBox control, you may end up inadvertently exposing
yourself to injected SQL statements that can significantly damage your database and reveal
sensitive information. When you use parameterized SQL statements, the parameters are
handled in a way that prevents this.
  - Parameterized SQL statements, as we have shown in this recipe, allow you to reuse parts of the
statement. This reuse can make your code more simple and easier to read
  - Following the re-use idea, most enterprise-class databases like Oracle Database, IBM DB2,
and even Microsoft SQL Server in some circumstances, can take advantage of parameterized
queries by reusing the parsed version of the query even if the parameters have changed. This
boosts performance and lowers the processing overhead for SQL statement re-use
  - Parameterized SQL statements make your code more maintainable and configurable. For
example, the statements could come from a configuration file. This would allow you to make
some changes to the application without changing the code

---

###Fetching Objects with Native SQL Statements 

You want to execute a native SQL statement and fetch objects from your database

---

```
string sql = "select * from Chapter3.Student where Degree = @Major";
var parameters = new DbParameter[] { new SqlParameter {ParameterName = "Major", Value = "Masters"}};
var students = context.Students.SqlQuery(sql, parameters);
```

 the underlying table match the properties in the Student entity type. Entity Framework will match the returned
values to the appropriate properties. This works fine in most cases, but if fewer columns returned from your query,
Entity Framework will throw an exception during the materialization of the object. A much better approach and best
practice is to enumerate the columns explicitly (that is, specify each column name) in your SQL statement.

If your SQL statement returns more columns than required to materialize the entity (that is, more column values
than properties in the underlying entity object), Entity Framework will happily ignore the additional columns. If you
think about this for a moment, you’ll realize that this isn’t a desirable behavior. Again, consider explicitly enumerating
the expected columns in your SQL statement to ensure they match your entity type.

There are some restrictions around the SqlQuery() method. If you are using Table per Hierarchy inheritance and
your SQL statement returns rows that could map to different derived types, Entity Framework will not be able to use
the discriminator column to map the rows to the correct derived types. You will likely get a runtime exception because
some rows don’t contain the values required for the type being materialized.

---

###Querying a Model with Entity SQL

You want to execute an Entity SQL statement that queries your underlying entity data model and returns
strongly-typed objects.

---

To query the model using Entity SQL (eSQL), a dialect of SQL implemented by Entity Framework.

Keep in mind that when querying the underlying data store, you should favor LINQ-to-Entity
queries over eSQL, due to feature-rich and strong-typing experience that LINQ provides. Entity SQL gives you the
flexibility to construct database queries dynamically against the entity data model.

```
String esql = "select value c from Customers as c"; 

var customers = ((IObjectContextAdapter)context).ObjectContext.CreateQuery<Customer>(esql);
```

```
using (var conn = new EntityConnection("name=EFRecipesEntities"))
{
 Console.WriteLine("Querying Customers with eSQL Leveraging Entity Client...");
 var cmd = conn.CreateCommand();
 conn.Open();
 cmd.CommandText = "select value c from EFRecipesEntities.Customers as c";
 using (var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
 {
 while (reader.Read())
 {
 Console.WriteLine("{0}'s email is: {1}",
 reader.GetString(1), reader.GetString(2));
 }
 }
}
```

With customers in the database, we demonstrate two different approaches to retrieving them using Entity SQL. In
the first approach, we use the CreateQuery() method exposed by the legacy object context to create an ObjectQuery
object. Note how we cast the DbContext to an ObjectContextAdapter type to get to its underlying ObjectContext type
(keep in mind the newer DbContext wraps the older ObjectContext to improve the developer experience). We do so as
the DbContext does not provide direct support for eSQL queries. Note as well how we assign the Customer class type
to the generic placeholder value for CreateQuery() and pass in the eSQL query as a parameter. As we iterate over the
customers collection, the query is executed against the database and the resulting collection is printed to the console.
Because each element in the collection is an instance of our Customer entity type, we can use the properties of the
Customer entity type to gain strongly typed usage.

In the second approach, we use the EntityClient libraries in a pattern that is very similar to how we would use
SqlClient or any of the other client providers in ADO.NET. We start by creating a connection to the database. With the
connection in hand, we create a command object and open the connection. Next we initialize the command object
with the text of the Entity SQL statement we want to execute. We execute the command using ExecuteReader() and
obtain an EntityDataReader, which is a type of the familiar DbDataReader. We iterate over the resulting collection
using the Read () method.

Note that the Entity SQL statement in listing 3-8 uses the value keyword. This keyword is useful when we need
to fetch the entire entity. If our Entity SQL statement projected a specific subset of columns (that is, we use some of
the columns and/or create columns using Entity SQL expressions), we can dispense with the value keyword. When
working with a context object, this means working with a DbDataRecord directly.

```
string esql = "select c.Name, c.Email from Customers as c";
var records = context.CreateQuery<DbDataRecord>(esql);
foreach (var record in records)
 {
 var name = record[0] as string;
 var email = record[1] as string;
 Console.WriteLine("{0}'s email is: {1}", name, email);
 }
```

```
using (var conn = new EntityConnection("name=EFRecipesEntities"))
{
 Console.WriteLine("Customers...");
 var cmd = conn.CreateCommand();
 conn.Open();
 cmd.CommandText = @"select c.Name, C.Email from
 EFRecipesEntities.Customers as c";
 using (var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
 {
 while (reader.Read())
 {
 Console.WriteLine("{0}'s email is: {1}",
 reader.GetString(0), reader.GetString(1));
 }
 }
}
```

----

###Returning Multiple Result Sets from a Stored Procedure

You have a stored procedure that returns multiple result sets, and you want to materialize entities from each result set.

---

```
var conn = context.Database.Connection;
var cmd = conn.CreateCommand();
cmd.CommandType = System.Data.CommandType.StoredProcedure;
cmd.CommandText = "Chapter3.GetBidDetails";
conn.Open();

var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
var jobs = ((IObjectContextAdapter)context).ObjectContext.Translate<Job>(reader, "Jobs", MergeOption.AppendOnly).ToList();

reader.NextResult();

((IObjectContextAdapter)context).ObjectContext.Translate<Bid>(reader, "Bids", MergeOption.AppendOnly).ToList();

``` 

Although we didn’t run into it in this example, it is important to note that Translate() bypasses the mapping
layer of the model. If you try to map an inheritance hierarchy or use an entity that has complex type properties,
Translate() will fail. Translate() requires that the DbDataReader have columns that match each property on
the entity. This matching is done using simple name matching. If a column name can’t be matched to a property,
Translate() will fail.

We used ToList() to force the evaluation of each query. This is required because the Translate() method
returns an ObjectResult<T>. It does not actually cause the results to be read from the reader. We need to force the
results to be read from the reader before we can use NextResult() to advance to the next result set. In practice, you
would most likely construct your code to continue to loop through each result set with NextResult() that the stored
procedure might return

---

### Comparing Against a List of Values

You want to query entities in which a specific property value matches a value contained in a given list

---

You want to find all of the books in a given list of categories. To do this using LINQ or Entity SQL, follow the
pattern : 

```
using (var context = new EFRecipesEntities())
{
 // delete previous test data
 context.Database.ExecuteSqlCommand("delete from chapter3.category");
 context.Database.ExecuteSqlCommand("delete from chapter3.book");
 // add new test data
 var cat1 = new Category { Name = "Programming" };
 var cat2 = new Category { Name = "Databases" };
 var cat3 = new Category {Name = "Operating Systems"};
 context.Books.Add(new Book { Title = "F# In Practice", Category = cat1 });
 context.Books.Add(new Book { Title = "The Joy of SQL", Category = cat2 });
 context.Books.Add(new Book { Title = "Windows 7: The Untold Story",
 Category = cat3 });
 context.SaveChanges();
}
using (var context = new EFRecipesEntities())
{
 Console.WriteLine("Books (using LINQ)");
 var cats = new List<string> { "Programming", "Databases" };
 var books = from b in context.Books
 where cats.Contains(b.Category.Name)
 select b;
 foreach (var book in books)
 {
 Console.WriteLine("'{0}' is in category: {1}", book.Title,
 book.Category.Name);
 }
}
using (var context = new EFRecipesEntities())
{
 Console.WriteLine("Books (using ESQL)");
 var esql = @"select value b from Books as b
 where b.Category.Name in {'Programming','Databases'}";
 var books = ((IObjectContextAdapter)context).ObjectContext.CreateQuery<Book>(esql);
 foreach (var book in books)
 {
 Console.WriteLine("'{0}' is in category: {1}", book.Title,
 book.Category.Name);
 }
}
```

---

### Filtering Related Entities

You want to want to retrieve some, but not all, related entities

---

In this model, we have a Worker who has experienced zero or more accidents. Each accident is classified by its
severity. We want to retrieve all workers, but we are interested only in serious accidents. These are accidents with a
severity greater than 2.
To start, this example leverages the Code-First approach for Entity Framework. In Listing 3-19, we create entity
classes for Worker and Accidents.

```
public class Worker
{
 public Worker()
 {
 Accidents = new HashSet<Accident>();
 }
 public int WorkerId { get; set; }
 public string Name { get; set; }
 public virtual ICollection<Accident> Accidents { get; set; }
}
```

```
public class Accident
{
 public int AccidentId { get; set; }
 public string Description { get; set; }
 public int? Severity { get; set; }
 public int WorkerId { get; set; }
 public virtual Worker Worker { get; set; }
}
```

```
public class EFRecipesEntities : DbContext
{
 public EFRecipesEntities() : base("ConnectionString") {}

 public DbSet<Accident> Accidents { get; set; }
 public DbSet<Worker> Workers { get; set; }
 protected override void OnModelCreating(DbModelBuilder modelBuilder)
 {
  modelBuilder.Entity<Accident>().ToTable("Chapter3.Accident");
  modelBuilder.Entity<Worker>().ToTable("Chapter3.Worker");
  base.OnModelCreating(modelBuilder);
 }
}
```

```
using (var context = new EFRecipesEntities())
{
 // explicitly disable lazy loading
 context.Configuration.LazyLoadingEnabled = false;
 var query = from w in context.Workers
   select new
   {
    Worker = w,
    Accidents = w.Accidents.Where(a => a.Severity > 2)
   };
 query.ToList();
 var workers = query.Select(r => r.Worker);
 Console.WriteLine("Workers with serious accidents...");
 foreach (var worker in workers)
 {
 Console.WriteLine("{0} had the following accidents", worker.Name);
  if (worker.Accidents.Count == 0)
 Console.WriteLine("\t--None--");
foreach (var accident in worker.Accidents)
{
Console.WriteLine("\t{0}, severity: {1}",
accident.Description, accident.Severity.ToString());
}
}
}
```
