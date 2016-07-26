Relationships
---
It's occasionally useful to divide relationships into "IsA" and "HasA" types. The concept is straightforward: entity A either IsA B or HasA B. For example, an Employee IsA SoftballTeam member; the same Employee HasA(n) Address. Of course, "is" and "has" are not always very good English terms to describe a relationship. An Employee doesn't "have" a SalesOrder, he "creates" one; but as it's clearly not the case that the Employee is a SalesOrder, the intellectual stretch isn't too great.

----|-               a single bar indicates "one"
----<-               a crow's foot indicates "many"
----o-               a circle indicates "optionally"
---|<-               one or many
---o|<               zero or one or many

####One-to-One Relationships

Perhaps the simplest type of relationship is the one-to-one relationship. If it's true that any instance of entity X can be associated with only one instance of entity Y, then the relationship is one-to-one. Most IsA relationships will be one-to-one, but otherwise, examples of one-to-one relationships are fairly rare in the problem domain. When choosing a one-to-one relationship between entities, you need to be sure that the relationship is either true for all time or, if it does change, that you don't care about past values.

There is a one-to-one relationship between Office and Employee

Office -|----|- Employee

---

####One-to-Many Relationships

The most common type of relationship between entities is one-to-many, wherein a single instance of one entity can be associated with zero, one, or many instances of another entity.
The majority of the normalization techniques result in relations with one-to-many relationships between them.

One-to-many relationships present few problems once they've been identified. However, it's important to be careful in specifying the optionality on each side of the relationship. It's commonly thought that only the many side of the relationship can be optional

Identifying the primary and foreign relations in a one-to-many relationship is easy. The entity on the one side of the relationship is always the primary relation; its candidate key is copied to the relation on the many side, which becomes the foreign relation. The key candidate of the primary relation often forms part of the candidate key for the relation on the many side, but it can never uniquely identify the tuples of foreign relation by itself. It must be combined with one or more other attributes to form a candidate key.

---

####Many-to-Many Relationships

Many-to-many relationships exist aplenty in the real world. Students take many courses; any given course is attended by many students. Customers shop in many stores; a store has many customers, or so one hopes! But many-to-many relationships can't be implemented in a relational database. Instead, they are modeled using an intermediary relation that has a one-to-many relationship with each of the original participants, as shown in Figure 3-13. Such an intermediary relation is usually called a junction table, even when working at the data model level, where of course we're talking about relations, not tables.

Since a many-to-many relationship is modeled as two one-to-many relationships, determining the primary and foreign relations is straightforward. As we've seen, the relation on the one side of a one-to-many relationship is always the primary relation. This means that each of the original entities will become a primary relation, and the junction table will be the foreign relation, receiving the candidate keys of the relations on each side of it.

Junction tables most often contain only the candidate keys of the two original participants, but they are really just a special case of the abstract relationship entities discussed earlier. As such, they can contain whatever additional attributes are appropriate.
