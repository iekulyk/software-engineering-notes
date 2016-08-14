Loading Entities and Navigation Properties
---

###Lazy Loading Related Entities

You want to load an entity and then load related entities, only if and when they are needed by your application

===

Lazy loading behavior of Entity Framework is the default behavior for loading
related entity objects.

// Now, application is requesting information from the related entities, CustomerType
// and CustomerEmail, resulting in Entity Framework generating separate queries to each
// entity object in order to obtain the requested information.

---

###Eager Loading Related Entities

You want to load an entity along with some related entities in a single trip to the database.

===

```
var customers = context.Customers
    .Include("CustomerType")
    .Include("CustomerEmails");
```

```
var customerTypes = context.CustomerTypes
    .Include(x => x.Customers)
    .Select(y =>y.CustomerEmails));
```

---

###Finding Single Entities Quickly

You want to load a single entity, but you do not want to make another trip to the database if the entity is already loaded in
the context. Additionally, you want to implement the Code-First approach for Entity Framework 6 to manage data access.

===

```
public class Club
{
  public int ClubId { get; set; }
  public string Name { get; set; }
  public string City { get; set; }
}
```

```
var starCity = context.Clubs.SingleOrDefault(x => x.ClubId == starCityId);
starCity = context.Clubs.SingleOrDefault(x => x.ClubId == starCityId);
starCity = context.Clubs.Find(starCityId);
var desertSun = context.Clubs.Find(desertSunId);
var palmTree = context.Clubs.AsNoTracking().SingleOrDefault(x => x.ClubId == palmTreeId);
palmTree = context.Clubs.Find(palmTreeId);
var lonesomePintId = -999;
context.Clubs.Add(new Club {City = "Portland", Name = "Lonesome Pine", ClubId = lonesomePintId,});
var lonesomePine = context.Clubs.Find(lonesomePintId);
var nonexistentClub = context.Clubs.Find(10001);
```

expects an argument that represents the primary key of the desired object. Find() is very efficient, as it will first search
the underlying context for the target object. If the object is not found, it then automatically queries the underlying data
store. If still not found, Find() simply returns NULL to the caller. Additionally, Find() will return entities that have
been added to the context (think, having a state of “Added”), but not yet saved to the underlying database. Fortunately,
the Find() method is available with any of three modeling approaches: Database First, Model First, or Code First.

---

###Querying In-Memory Entities

You want to work with entity objects from your model, but do not want to make a round trip to the database if the
desired entity is already loaded in the in-memory context object. Additionally, you want to implement the Code-First
approach for Entity Framework 6 to manage data access.

===

In this model, we have a Club entity from which we can query information about various clubs. We can reduce
round trips to the database by directly querying the Local property of the underlying DbSet, which we use to wrap
the Club entity. The Local property exposes an observable collection of in-memory entity objects, which stays in sync
with the underlying context.

```
using (var context = new Recipe4Context())
{
  Console.WriteLine("\nLocal Collection Behavior");
  Console.WriteLine("=================");
  
  Console.WriteLine("\nNumber of Clubs Contained in Local Collection: {0}", context.Clubs.Local.Count);
  Console.WriteLine("=================");
  
  Console.WriteLine("\nClubs Retrieved from Context Object");
  Console.WriteLine("=================");
  foreach (var club in context.Clubs.Take(2))
  {
  Console.WriteLine("{0} is located in {1}", club.Name, club.City);
  }
  
  Console.WriteLine("\nClubs Contained in Context Local Collection");
  Console.WriteLine("=================");
  foreach (var club in context.Clubs.Local)
  {
  Console.WriteLine("{0} is located in {1}", club.Name, club.City);
  }
  
  context.Clubs.Find(desertSunId);
  
  Console.WriteLine("\nClubs Retrieved from Context Object - Revisted");
  Console.WriteLine("=================");
  
  foreach (var club in context.Clubs)
  {
  Console.WriteLine("{0} is located in {1}", club.Name, club.City);
  }
  
  Console.WriteLine("\nClubs Contained in Context Local Collection - Revisted");
  Console.WriteLine("=================");
  foreach (var club in context.Clubs.Local)
  {
  Console.WriteLine("{0} is located in {1}", club.Name, club.City);
  }
  
  // Get reference to local observable collection
  var localClubs = context.Clubs.Local;
  
  // Add new Club
  var lonesomePintId = -999;
  localClubs.Add(new Club
      {
      City = "Portland",
      Name = "Lonesome Pine",
      ClubId = lonesomePintId
      });
      
  // Remove Desert Sun club
  localClubs.Remove(context.Clubs.Find(desertSunId));
  
  Console.WriteLine("\nClubs Contained in Context Object - After Adding and Deleting");
  Console.WriteLine("=================");
  foreach (var club in context.Clubs)
  {
      Console.WriteLine("{0} is located in {1} with a Entity State of {2}",
      club.Name, club.City, context.Entry(club).State);
  }
  
  Console.WriteLine("\nClubs Contained in Context Local Collection - After Adding and Deleting");
  Console.WriteLine("=================");
  foreach (var club in localClubs)
  {
      Console.WriteLine("{0} is located in {1} with a Entity State of {2}",
      club.Name, club.City, context.Entry(club).State);
  }
  
  Console.WriteLine("\nPress <enter> to continue...");
  Console.ReadLine();
}
  
```

---

###Loading a Complete Object Graph

You have a model with several related entities, and you want to load the complete object graph of all the instances of
each entity in a single query. Normally, when a specific view requires a set of related entities in order to render, you’ll
prefer this approach as opposed to the lazy loading approach that fetches related data with a number of smaller queries.

===

```
var graph = context.Courses
    .Include("Sections.Instructor")
    .Include("Sections.Students");
```

```
var graph = context.Courses
    .Include(x => x.Sections.Select(y => y.Instructor))
    .Include(x => x.Sections.Select(z => z.Students));
```
    
---

###Loading Navigation Properties on Derived Types

You have a model with one or more derived types that are in a Has-a relationship (wherein one object is a part of
another object) with one or more other entities. You want to eagerly load all of the related entities in one round trip
to the database.

===

```
var plumber = context.Tradesmen.OfType<Plumber>()
    .Include("JobSite.Phone")
    .Include("JobSite.Foremen").First();
```

---

###Using Include( ) with Other LINQ Query Operators

You have a LINQ query that uses operators such as group by, join, and where; and you want to use the Include()
method to eagerly load additional entities

===

```
var events = from ev in context.Events
              where ev.Club.City == "New York"
              group ev by ev.Club
                  into g
                  select g.FirstOrDefault(e1 => e1.EventDate == g.Min(evt => evt.EventDate));
                  
var eventWithClub = events.Include("Club").First();
```

---

###Deferred Loading of Related Entities

You have an instance of an entity, and you want to defer the loading of two or more related entities in a single query.
Especially important here is how we use the Load() method to avoid requerying the same entity twice.

===

```
// Assume we already have an employee
var jill = context.Employees.First(o => o.Name == "Jill Carpenter");

// Get Jill's Department and Company, but we also reload Employees
var results = context.Employees
                     .Include("Department.Company")
                     .First(o => o.EmployeeId == jill.EmployeeId);
```

```
// More efficient approach, does not retrieve Employee again
// Assume we already have an employee
var jill = context.Employees.Where(o => o.Name == "Jill Carpenter").First();

// Leverage the Entry, Query, and Include methods to retrieve Department and Company data
// without requerying the Employee table

context.Entry(jill).Reference(x => x.Department).Query().Include(y => y.Company).Load();
```

---

###Filtering and Ordering Related Entities

You have an instance of an entity and you want to load a related collection of entities applying both a filter and an
ordering.

===

```
context.Entry(hotel)
                    .Collection(x => x.Rooms)
                    .Query()
                    .Include(y => y.Reservations)
                    .Where(y => y is ExecutiveSuite && y.Reservations.Any())
                    .Load();
```

---

###Executing Aggregate Operations on Related Entities

```
// Assume we have an instance of Order
var order = context.Orders.First();

// Get the total order amount
var amt = context.Entry(order)
                  .Collection(x => x.OrderItems)
                  .Query()
                  .Sum(y => y.Shipped * y.UnitPrice);
```                  

---

###Testing Whether an Entity Reference or Entity Collection Is Loaded

You want to test whether the related entity or entity collection is loaded in the context

===

```
var project = context.Projects.Include("Manager").First();

if (context.Entry(project).Reference(x => x.Manager).IsLoaded)
  Console.WriteLine("Manager entity is loaded.");
else
  Console.WriteLine("Manager entity is NOT loaded.");
  
if (context.Entry(project).Collection(x => x.Contractors).IsLoaded)
  Console.WriteLine("Contractors are loaded.");
else
  Console.WriteLine("Contractors are NOT loaded.");
  
Console.WriteLine("Calling project.Contractors.Load()...");
context.Entry(project).Collection(x => x.Contractors).Load();

if (context.Entry(project).Collection(x => x.Contractors).IsLoaded)
  Console.WriteLine("Contractors are now loaded.");
else
  Console.WriteLine("Contractors failed to load.");
```

---

###Loading Related Entities Explicitly

You want to load related entities directly, without relying on the default lazy loading behavior of Entity Framework

===

```
// disable lazy loading feature as we are explicitly loading
// child entities
context.Configuration.LazyLoadingEnabled = false;

var doctorJoan = context.Doctors.First(o => o.Name == "Joan Meyers");

if (!context.Entry(doctorJoan).Collection(x => x.Appointments).IsLoaded)
{
      context.Entry(doctorJoan).Collection(x => x.Appointments).Load();
      Console.WriteLine("Dr. {0}'s appointments were explicitly loaded.", doctorJoan.Name);
}

foreach (var appointment in context.Appointments)
{
  if (!context.Entry(appointment).Reference(x => x.Doctor).IsLoaded)
  {
    context.Entry(appointment).Reference(x => x.Doctor).Load();
    Console.WriteLine("Dr. {0} was explicitly loaded.", appointment.Doctor.Name);
  }
  else
    Console.WriteLine("Dr. {0} was already loaded.",  appointment.Doctor.Name);
}

```

---
