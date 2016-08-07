Levels of Requirements
---

This section presents definitions that I will use for some terms commonly encountered in the requirements engineering domain. Software requirements include three distinct levels
  - business requirements, 
  - user requirements, 
  - functional requirements. 
  
####Business requirements represent high-level objectives of the organization or customer who requests the system.
  
Business requirements typically come from the funding sponsor for a project, the acquiring customer, the manager of the actual users, the marketing department, or a product visionary. Business requirements describe why the organization is implementing the system—the objectives the organization hopes to achieve. I like to record the business requirements in a vision and scope document, sometimes called a project charter or a market requirements document. 
Defining the project scope is the first step in controlling the common problem of scope creep.

####User requirements describe user goals or tasks that the users must be able to perform with the product.

Valuable ways to represent user requirements include use cases, scenario descriptions, and event-response tables. User requirements therefore describe what the user will be able to do with the system. An example of a use case is "Make a Reservation" using an airline, a rental car, or a hotel Web site. 

####Functional requirements specify the software functionality that the developers must build into the product to enable users to accomplish their tasks, thereby satisfying the business requirements.

Sometimes called behavioral requirements, these are the traditional "shall" statements: "The system shall e-mail a reservation confirmation to the user."  
The term system requirements describes the top-level requirements for a product that contains multiple subsystems—that is, a system (IEEE 1998c). A system can be all software or it can include both software and hardware subsystems. People are a part of a system, too, so certain system functions might be allocated to human beings.

**Business rules** include corporate policies, government regulations, industry standards, accounting practices, and computational algorithms. As you'll see in Chapter 9, "Playing By the Rules," business rules are not themselves software requirements because they exist outside the boundaries of any specific software system. However, they often restrict who can perform certain use cases or they dictate that the system must contain functionality to comply with the pertinent rules. Sometimes business rules are the origin of specific quality attributes that are implemented in functionality. Therefore, you can trace the genesis of certain functional requirements back to a particular business rule.

**Functional requirements** are documented in a software requirements specification (SRS), which describes as fully as necessary the expected behavior of the software system. I'll refer to the SRS as a document, although it can be a database or spreadsheet that contains the requirements, information stored in a commercial requirements management tool—see Chapter 21, "Tools for Requirements Management"—or perhaps even a stack of index cards for a small project. The SRS is used in development, testing, quality assurance, project management, and related project functions. 



