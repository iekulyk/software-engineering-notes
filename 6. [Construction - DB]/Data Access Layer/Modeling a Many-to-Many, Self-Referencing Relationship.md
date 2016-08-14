Modeling a Many-to-Many, Self-Referencing Relationship
---

###Retrieving the Link Table in a Many-to-Many Association

You want to retrieve the keys in the link table that connect two entities in a many-to-many association.

===

```
var evsorg1 = from ev in context.Events
              from organizer in ev.Organizers
              select new { ev.EventId, organizer.OrganizerId };
```

```
var evsorg2 = context.Events
                .SelectMany(e => e.Organizers,
                    (ev, org) => new { ev.EventId, org.OrganizerId });
```

---

###Exposing a Link Table as an Entity

You want to expose a link table as an entity instead of a many-to-many association.

---

```
[Table("Worker", Schema="Chapter6")]
public class Worker
{
[Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int WorkerId { get; set; }
public string Name { get; set; }
[ForeignKey("WorkerId")]
public virtual ICollection<WorkerTask> WorkerTasks { get; set; }
}

[Table("Task", Schema = "Chapter6")]
public class Task
{
[Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int TaskId { get; set; }
public string Title { get; set; }
[ForeignKey("TaskId")]
public virtual ICollection<WorkerTask> WorkerTasks { get; set; }
}

[Table("WorkerTask", Schema = "Chapter6")]
public class WorkerTask
{
[Key]
[Column(Order = 1)]
public int WorkerId { get; set; }
[Key]
[Column(Order = 2)]
public int TaskId { get; set; }
[ForeignKey("WorkerId")]
public virtual Worker Worker { get; set; }
[ForeignKey("TaskId")]
public virtual Task Task { get; set; }
}

```

---

###Modeling a Many-to-Many, Self-Referencing Relationship

You have a table with a many-to-many relationship with itself, and you want to model this table and relationship.

===

```
[Table("Product", Schema = "Chapter6")]
public class Product
{
  public Product()
  {
    RelatedProducts = new HashSet<Product>();
    OtherRelatedProducts = new HashSet<Product>();
  }
  
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int ProductId { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  
  // Products related to this product
  public virtual ICollection<Product> RelatedProducts { get; set; }
  
  // Products to which this product is related
  public virtual ICollection<Product> OtherRelatedProducts { get; set; }
}
```

```
modelBuilder.Entity<Product>()
      .HasMany(p => p.RelatedProducts)
      .WithMany(p => p.OtherRelatedProducts)
      .Map(m =>
            {
                  m.MapLeftKey("ProductId");
                  m.MapRightKey("RelatedProductId");
                  m.ToTable("RelatedProduct", "Chapter6");
            });
```

