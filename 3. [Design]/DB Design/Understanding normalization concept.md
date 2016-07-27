Understanding normalization concept
---

The principles of normalization discussed in the rest of this chapter are tools for controlling the structure of data in the same way that a paper clip controls sheets of paper. The normal forms (we'll discuss six) specify increasingly stringent rules for the structure of relations. Each form extends the previous one in such a way as to prevent certain kinds of update anomalies.

Bear in mind that the normal forms are not a prescription for creating a "correct" data model. A data model could be perfectly normalized and still fail to answer the questions asked of it; or, it might provide the answers, but so slowly and awkwardly that the database system built around it is unusable. But if your data model is normalized—that is, if it conforms to the rules of relational structure—the chances are high that the result will be an efficient, effective data model. Before we turn to normalization, however, you should be familiar with a couple of underlying principles.


---

###Lossless Decomposition

The relational model allows relations to be joined in various ways by linking attributes. The process of obtaining a fully normalized data model involves removing redundancy by dividing relations in such a way that the resultant relations can be recombined without losing any of the information. This is the principle of lossless decomposition.

###Candidate Keys and Primary Keys
In Chapter 1, I defined a relation body as an unordered set of zero or more tuples and pointed out that by definition each member of a set is unique. This being the case, for any relation there must be some combination of attributes that uniquely identifies each tuple. This set of one or more attributes is called a candidate key.

There might be more than one candidate key for any given relation, but it must always be the case that each candidate key uniquely identifies each tuple, not just for any specific set of tuples but for all possible tuples for all time. The inverse of this principle must also be true, by the way. Given any two tuples with the same candidate key, both tuples must represent the same entity. The implication of this statement is that you cannot determine a candidate key by inspection. Just because some field or combination of fields is unique for a given set of tuples, you cannot guarantee that it will be unique for all tuples, which it must be to qualify as a candidate key. Once again, you must understand the semantics of the data model.

Consider the Invoices relation shown in Figure 2-9. The CustomerID is unique in the example, but it's extremely unlikely that it will remain that way—and almost certainly not the intention of the company! Despite appearances, the semantics of the model tell us that this field is not a candidate key.

By definition, all relations must have at least one candidate key: the set of all attributes comprising the tuple. Candidate keys can be composed of a single attribute (a simple key) or of multiple attributes (a composite key). However, an additional requirement of a candidate key is that it must be irreducible, so the set of all attributes is not necessarily a candidate key. In the relation shown in Figure 2-10, the attribute CategoryID is a candidate key, but the set {CategoryID, CategoryName}, although it is unique, is not a candidate key, since the CategoryName attribute is unnecessary.

It is sometimes the case—although it doesn't happen often—that there are multiple possible candidate keys for a relation. In this case, it is customary to designate one candidate key as a primary key and consider other candidate keys alternate keys. This is an arbitrary decision and isn't very useful at the logical level. (Remember that the data model is purely abstract.) To help maintain the distinction between the model and its physical implementation, I prefer to use the term "candidate key" at the data model level and reserve "primary key" for the implementation.

---

###First Normal Form

A relation is in first normal form if the domains on which its attributes are defined are scalar. This is at once both the simplest and most difficult concept in data modeling. The principle is straightforward: each attribute of a tuple must contain a single value. But what constitutes a single value? In the relation shown in Figure 2-12, the Items attribute obviously contains multiple values and is therefore not in first normal form. But the issue is not always so clear cut.

---

###Second Normal Form1

A relation is in second normal form if it is in first normal form and in addition all its attributes are dependent on the entire candidate key. The key in Figure 2-15, for example, is {ProductName, SupplierName}, but the SupplierPhoneNumber field is dependent only on the SupplierName, not on the full composite key.

Logically, this is an issue of not trying to represent two distinct entities, Products and Suppliers, in a single relation. By separating the representation, you're not only eliminating the redundancy, you're also providing a mechanism for storing information that you couldn't otherwise capture. In the example in Figure 2-16, it becomes possible to capture information about Suppliers before obtaining any information regarding their products. That could not be done in the first relation, since neither component of a primary key can be empty.

The other way that people get into trouble with second normal form is in confusing constraints that happen to be true at any given moment with those that are true for all time. The relation shown in Figure 2-17, for example, assumes that a supplier has only one address, which might be true at the moment but will not necessarily remain true in the future.

---

###Third Normal Form

A relation is in third normal form if it is in second normal form and in addition all nonkey attributes are mutually independent. Let's take the example of a company that has a single salesperson in each state. Given the relation shown in Figure 2-18, there is a dependency between Region and Salesperson, but neither of these attributes is reasonably a candidate key for the relation.

