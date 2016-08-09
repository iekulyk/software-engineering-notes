Entity Data Modeling Fundamentals
---

###Creating a Simple Model

You have a brand new project, and you want to create a model.

Let’s imagine that you want to create an application to hold the names and phone numbers of people that you know.
To keep things simple, let’s assume that you need just one entity type: Person.

  - Right-click your project, and select Add ➤ New Item.

  - From the templates, select ADO.NET Entity Data Model and click Add. This template is
located in Data under Visual C# Items

  - In the first step of the wizard, choose Empty Model and click Finish. The wizard will create
a new conceptual model with an empty design surface.

  - Right-click the design surface, and select Add ➤ Entity.

  - Type Person in the Entity name field, and select the box to Create a key property. Use Id
as the Key Property. Make sure that its Property Type is Int32. Click OK, and a new Person
entity will appear on the design surface

  - Right-click near the top of the Person entity, and select Add ➤ Scalar Property.
A new scalar property will be added to the Person entity

  - Rename the scalar property FirstName. Add scalar properties for LastName, MiddleName,
and PhoneNumber.

  - Right-click the Id property, and select Properties. In the properties view, change
the StoreGeneratedPattern property to Identity if it is not already set to Identity.
This flags the Id property as a value that will be computed by the store layer (database).
The database script we get at the end will flag the Id column as an identity column,
and the storage model will know that the database will automatically manage the values
in this column.

---

You now have a simple conceptual model. To generate a database for our model, there are a few things we still
have to do:

  - We need to change a couple of properties of our model to help with housekeeping.
Right-click the design surface, and select properties. Change the Database Schema Name
to Chapter2, and change the Entity Container Name to EF6RecipesContext

  - Right-click the design surface, and select Generate Database Script from Model. Select an
existing database connection or create a new one.

  - Run the database script in an SSMS query window to create the database and the
People table.

---

The Entity Framework Designer is a powerful tool for creating and updating a conceptual model, storage model,
and mapping layer. This tool provides support for bidirectional model development. You can either start with a clean
design surface and create a model; or start with a database that you already have and import it to create a conceptual
model, storage model, and mapping layer. The current version of the Designer supports somewhat limited roundtrip
modeling, allowing you to re-create your database from a model and update the model from changes in your
database.

The model has a number of properties that affect what goes in the generated storage model and database script.
We changed two of these properties. The first was the name of the container. This is the class derived from DbContext.
We called this EF6RecipesContext to be consistent with the contexts we use throughout this book.

Additionally, we changed the schema to “Chapter 2.” This represents the schema used to generate the storage
model as well as the database script.

The best practice here is always to wrap your code in the using(){} block when creating new instances of
DbContext. It’s one more step to help bulletproof your code.

---

###Modeling a Many-to-Many Relationship with No Payload

You have a couple of tables in an existing database that are related to each other via a link or junction table. The link
table contains just the foreign keys used to link the two tables together into a many-to-many relationship. You want
to import these tables to model this many-to-many relationship.

---

  - Add a new model to your project by right-clicking your project and selecting Add ➤ New
Item. Choose ADO.NET Entity Data Model from the Visual C# Items Data templates

  - Select Generate from database. Click Next.
  
  - Use the wizard to select an existing connection to your database, or create a new
connection.

  - From the Choose Your Database Object dialog box, select the tables Album, LinkTable,
and Artist. Leave the Pluralize and Foreign Key options checked. Click Finish


The many-to-many relationship between Album and Artist is represented by a line with the * character on
both ends. Because an Album can have many Artists, and an Artist can responsible for many Albums, each of these
navigation properties is of type EntityCollection.

---

### Modeling a Many-to-Many Relationship with a Payload

You have a many-to-many relationship in which the link table contains some payload data (any additional columns
beyond the foreign keys), and you want to create a model that represents the many-to-many relationship as two
one-to-many associations.

---

Entity Framework does not support associations with properties, so creating a model like the one in the previous
recipe won’t work. As we saw in the previous recipe, if the link table in a many-to-many relationship contains just the
foreign keys for the relationship, Entity Framework will surface the link table as an association and not as an entity
type. If the link table contains additional information, Entity Framework will create a separate entity type to represent
the link table.

---

So here’s the best practice: If you have a payload-free many-to-many relationship and you think there is some
chance that it may change over time to include a payload, start with an extra identity column in the link table. When
you import the tables into your model, you will get two one-to-many relationships, which means the code you write
and the model you have will be ready for any number of additional payload columns that come along as the project
matures. The cost of an additional integer identity column is usually a pretty small price to pay to keep the model
more flexible.

---

###Modeling a Self-Referencing Relationship with a Code-First Approach

You have a table that references itself, and you want to model this as an entity with a self-referencing association using
a Code-First approach.

---

```
public class PictureCategory
{
 [Key]
 [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
 public int CategoryId { get; private set; }
 public string Name { get; set; }
 public int? ParentCategoryId { get; private set; }
 [ForeignKey("ParentCategoryId")]
 public PictureCategory ParentCategory { get; set; }
 public List<PictureCategory> Subcategories { get; set; }
 public PictureCategory()
 {
 Subcategories = new List<PictureCategory>();
 }
}
```

```
public class EF6RecipesContext : DbContext
{
 public DbSet<PictureCategory> PictureCategories { get; set; }
 public PictureContext() : base("name=EF6CodeFirstRecipesContext")
 {

 }
 protected override void OnModelCreating(DbModelBuilder modelBuilder)
 {
 base.OnModelCreating(modelBuilder);
 modelBuilder.Entity<PictureCategory>()
 .HasMany(cat => cat.SubCategories)
 .WithOptional(cat => cat.ParentCategory);
 }
}
```

---

###Splitting an Entity Among Multiple Tables

You have two or more tables that share the same primary key, and you want to map a single entity to these two tables.

---

```
public class Product
{
 [Key]
 [DatabaseGenerated(DatabaseGeneratedOption.None)]
 public int SKU { get; set; }
 public string Description { get; set; }
 public decimal Price { get; set; }
 public string ImageURL { get; set; }
}
```

```
public class EF6RecipesContext : DbContext
{
 public DbSet<Product> Products { get; set; }
 
 public ProductContext() : base("name=EF6CodeFirstRecipesContext")
 {
 }
 
 protected override void OnModelCreating(DbModelBuilder modelBuilder)
 {
  base.OnModelCreating(modelBuilder);
 
  modelBuilder.Entity<Product>()
    .Map(m =>
      {
        m.Properties(p => new {p.SKU, p.Description, p.Price});
        m.ToTable("Product", "Chapter2");
      })
    .Map(m =>
      {  
        m.Properties(p => new {p.SKU, p.ImageURL});
        m.ToTable("ProductWebInfo", "Chapter2");
      });
  }
}
```

The downside of vertical splitting is that retrieving each instance of our entity now requires an additional join for
each additional table that makes up the entity type

---

###Splitting a Table Among Multiple Entities

You have a table with some frequently used fields and a few large, but rarely needed fields. For performance reasons,
you want to avoid needlessly loading these expensive fields on every query. You want to split the table across two or
more entities

---

```
public class Photograph
{
 [Key]
 [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
 
 public int PhotoId { get; set; }
 public string Title { get; set; }
 public byte[] ThumbnailBits { get; set; }
 
 [ForeignKey("PhotoId")]
 public virtual PhotographFullImage PhotographFullImage { get; set; }
}
```

```
public class PhotographFullImage
{
 [Key]
 public int PhotoId { get; set; }
 
 public byte[] HighResolutionBits { get; set; }
 
 [ForeignKey("PhotoId")]
 public virtual Photograph Photograph { get; set; }
}
```
 
```
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
 base.OnModelCreating(modelBuilder);
 
 modelBuilder.Entity<Photograph>()
      .HasRequired(p => p.PhotographFullImage)
      .WithRequiredPrincipal(p => p.Photograph);
      
 modelBuilder.Entity<Photograph>().ToTable("Photograph", "Chapter2");
 modelBuilder.Entity<PhotographFullImage>().ToTable("Photograph", "Chapter2");
}
```

Entity Framework does not directly support the notion of lazy loading of individual entity properties. To get the effect
of lazy loading expensive properties, we exploit Entity Framework’s support for lazy loading of associated entities.
We created a new entity type to hold the expensive full image property and created a one-to-one association between
our Photograph entity type and the new PhotographFullImage entity type. We added a referential constraint on the
conceptual layer that, much like a database referential constraint, tells Entity Framework that a PhotographFullImage
can’t exist without a Photograph.

```
// explicitly load the "expensive" entity,
PhotographFullImagecontext.Entry(photo).Reference(p => p.PhotographFullImage).Load(); 
```

---

### Modeling Table per Type Inheritance

You have some tables that contain additional information about a common table, and you want to model this using
table per type inheritance.

---

```
[Table("Business", Schema = "Chapter2")]
public class Business
{
 [Key]
 [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
 
 public int BusinessId { get; protected set; }
 public string Name { get; set; }
 public string LicenseNumber { get; set; }
}
```

```
[Table("eCommerce", Schema = "Chapter2")]
public class eCommerce : Business
{
 public string URL { get; set; }
}
```

```
[Table("Retail", Schema = "Chapter2")]
public class Retail : Business
{
 public string Address { get; set; }
 public string City { get; set; }
 public string State { get; set; }
 public string ZIPCode { get; set; }
}
```

Table per type is one of three inheritance models supported by Entity Framework. The other two are Table per
Hierarchy (discussed in this chapter) and Table per Concrete Type.

Table per type inheritance provides a lot of database flexibility because we can easily add tables as new derived
types find their way into our model as an application develops. However, each derived type involves additional joins
that can reduce performance. In real-world applications, we have seen significant performance problems with TPT
when many derived types are modeled.

---

###Modeling Table per Hierarchy Inheritance

You have a table with a type or discriminator column that you use to determine what the data in a row represents in
your application. You want to model this with table per hierarchy inheritance.

---

```
[Table("Employee", Schema="Chapter2")]
public abstract class Employee
{
 [Key]
 [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
 public int EmployeeId { get; protected set; }
 public string FirstName { get; set; }
 public string LastName { get; set; }
}
```

```
public class FullTimeEmployee : Employee
{
 public decimal? Salary { get; set; }
}
```

```
public class HourlyEmployee : Employee
{
 public decimal? Wage { get; set; }
}
```

```
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
 base.OnModelCreating(modelBuilder);
 
 modelBuilder.Entity<Employee>()
    .Map<FullTimeEmployee>(m => m.Requires("EmployeeType").HasValue(1))
    .Map<HourlyEmployee>(m => m.Requires("EmployeeType").HasValue(2));
}
```

In table per hierarchy inheritance, often abbreviated TPH, a single table is used to represent the entire inheritance
hierarchy. Unlike table per type inheritance, the TPH rows for the derived types as well as the base type are
intermingled in the same table. The rows are distinguished by a discriminator column. In our example,
the discriminator column is EmployeeType

In TPH, mapping conditions, which are set in entity configuration, are used to indicate the values of the
discriminator column that cause the table to be mapped to the different derived types. We marked the base type as
abstract. By marking it as abstract, we didn’t have to provide a condition for the mapping because an abstract entity
can’t be created. We will never have an instance of an Employee entity. We did not implement an EmployeeType
property in the Employee entity. A column used in a condition is not, in general, mapped to a property.

---

### Modeling Is-a and Has-a Relationships Between Two Entities

You have two tables that participate in both Is-a and Has-a relationships, and you want to model them as two entities
with the corresponding Is-a and Has-a relationships.

---

Let’s say that you have two tables that describe scenic parks and their related locations. In your database, you
represent these with a Location table and a Park table. For the purposes of your application, a park is simply a type
of location. Additionally, a park can have a governing office with a mailing address, which is also represented in the
Location table. A park, then, is both a derived type of Location and can have a location that corresponds to the park’s
governing office. It is entirely possible that the office is not located on the grounds of the park. Perhaps several parks
share an office in a nearby town.

---

  - Add a new model to your project by right-clicking your project and selecting Add ➤ New
Item. Choose ADO.NET Entity Data Model from the Visual C# Data templates.

  - Select Generate from database. Click Next
  - Use the wizard to select an existing connection to your database or create a new
connection.
  - From the Choose Your Database Object dialog box, select the Location and Park tables.
Leave the Pluralize and Foreign Key options checked. Click Finish
  - Delete the one-to-zero or one association created by the Entity Data Model Wizard
  - Right-click the Location entity, and select Add ➤ Inheritance. Select the Park entity as the
derived entity and the Location entity as the base entity
  - Delete the ParkId property from the Park entity type
  - Click the Park entity to view the Mapping Details window. If the Mapping Details window
is not visible, show it by selecting View ➤ Other Windows ➤ Entity Data Model Mapping
Details. Map the ParkId column to the LocationId property
  - Change the name of the Location1 navigation property in the Park entity type to Office.
This represents the office location for the park.

---

Entities can have more than one association with other entities. In this example, we created an Is-a relationship using
table per type inheritance with Location as the base entity type and Park as the derived entity type. We also created a
Has-a relationship with a one-to-many association between the Location and Park entity types.

---

###Creating, Modifying, and Mapping Complex Types

You want to create a complex type, set it as a property on an entity, and map the property to some columns on a table

---

You want to create a Name complex type for the FirstName and
LastName columns. You also want to create an Address complex type for the AddressLine1, AddressLine2, City, State,
and ZIPCode columns. You want to use these complex types for properties in your model.

---

  - Add a new model to your project by right-clicking your project and selecting Add ➤ New
Item. Choose ADO.NET Entity Data Model from the Visual C# Data templates
  - Select Generate from database. Click Next
  - Use the wizard to select an existing connection to your database or create a new
connection
  - From the Choose Your Database Object dialog box, select the Agent table. Leave the
Pluralize and Foreign Key options checked. Click Finish
  - Select the FirstName and LastName properties, then right-click and select Refactor Into
Complex Type. 
  - In the Model Browser, rename the new complex type from ComplexType1 to Name.
This changes the name of the type. On the Agent, rename the ComplexTypeProperty
to Name. This changes the name of the property
  - We’ll create the next complex type from scratch so that you can see an alternative
approach. Right-click on the design surface, and select Add ➤ Complex Type.
  - In the Model Browser, rename the new complex type from ComplexType1 to Address
  - Select the AddressLine1, AddressLine2, City, State, and ZIPCode properties in the Agent.
Right-click and select Cut. Paste these properties onto the Address complex type in the
Model Browser.
  - Right-click the Agent, and select Add ➤ Complex Property. Rename the property Address
  - Right-click on the new Address property and select Properties. Change its type to Address.
This changes the new property’s type to the new Address complex type

---
