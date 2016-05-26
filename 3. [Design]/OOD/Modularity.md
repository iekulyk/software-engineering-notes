[**Modularity**](https://msdn.microsoft.com/en-us/library/ff921069%28v=pandp.20%29.aspx?f=255&MSPPError=-2147217396)
------------------------------------
**Modularity** is designing a system that is divided into a set of functional units (named modules) that can be composed into a larger application. A module represents a set of related concerns. It can include a collection of related components, such as features, views, or business logic, and pieces of infrastructure, such as services for logging or authenticating users. Modules are independent of one another but can communicate with each other in a loosely coupled fashion.

**High cohesion**
**High Cohesion ** is an evaluative pattern that attempts to keep objects appropriately focused, manageable and understandable. High cohesion is generally used in support of Low Coupling. High cohesion means that the responsibilities of a given element are strongly related and highly focused. Breaking programs into classes and subsystems is an example of activities that increase the cohesive properties of a system. Alternatively, low cohesion is a situation in which a given element has too many unrelated responsibilities. Elements with low cohesion often suffer from being hard to comprehend, hard to reuse, hard to maintain and averse to change

**Loose coupling**
In computing and systems design a loosely coupled system is one in which each of its components has, or makes use of, little or no knowledge of the definitions of other separate components. Sub-areas include the coupling of classes, interfaces, data, and services.Coupling refers to the degree of direct knowledge that one component has of another. Loose coupling in computing is interpreted as encapsulation vs. non-encapsulation.

A composite application exhibits modularity. For example, consider an online banking program. The user can access a variety of functions, such as transferring money between accounts, paying bills, and updating personal information from a single user interface (UI). However, behind the scenes, each of these functions is a discrete module. These modules communicate with each other and with back-end systems such as database servers. Application services integrate components within the different modules and handle the communication with the user. The user sees an integrated view that looks like a single application.

**Why Choose a Modular Design?**
  - Simplified modules. Properly defined modules have a high internal cohesion and loose coupling between modules. The coupling between the modules should be through well-defined interfaces.
  - Developing and/or deploying modules independently. Modules can be developed, tested, and/or deployed on independent schedules when modules are developed in a loosely coupled way. By doing this, you can do the following:
    - You can independently version modules.
    - You can develop and test modules in isolation.
    - You can have modules developed by different teams.
  - Loading modules from different locations. A Windows Presentation Foundation (WPF) application might retrieve modules from the Web, from the file system and/or from a database. A Silverlight application might load modules from different XAP files. However, most of the time, the modules come from one location; for example, there is a specific folder that contains the modules or they are in the same XAP file.
  - Minimizing download time. When the application is not on the user's local computer, you want to minimize the time required to download the modules. To minimize the download time, only download modules that are required to start-up the application. The rest are loaded and initialized in the background or when they are required.
  - Minimizing application start-up time. To get part of the application running as fast as possible, only load and initialize the module(s) that are required to start the application.
  - Loading modules based on rules. This allows you to only load modules that are applicable for a specific role. An application might retrieve from a service the list of modules to load.
  

**Designing a Modular System**
------------------------------------------
When you develop in a modularized fashion, you structure the application into separate modules that can be individually developed, tested, and deployed by different teams. Modules can enforce separation of concerns by vertically partitioning the system and keeping a clean separation between the UI and business functionality. Not having modularity makes it difficult for the team to introduce new features and makes the system difficult to test and to deploy.

The following are general guidelines for developing a modular system:

  - Modules should be opaque to the rest of the system and initialized through a well-known interface.
  - Modules should not directly reference one another or the application that loaded them.
  - Modules should use loosely coupled techniques, such as shared services, to communicate with the application or with other modules, instead of communicating directly.
  - Modules should not be responsible for managing their dependencies. These dependencies should be provided externally, for example, through dependency injection.
  - Modules should not rely on static methods that can inhibit testability.
  - Modules should support being added and removed from the system in a pluggable fashion.

When you design a modular system, consider the following steps:

1. Define the goals for the modular design. As described earlier, there are several reasons why you might decide to implement a modular design for your application.
2. Decide how you are going to partition your modules and define your module's responsibilities. Each module should have a distinct set of responsibilities. The most common approach is to partition your application so that each module has its own functional area, such as Customers or Orders. In this case, each module will consist of its own presentation layer, a business or domain layer, and a resource access layer. There are other ways to approach the design of modules. For example, if you want to make it easier to replace the UI of your application, it might make sense to place the presentation layer in one or more easy-to-replace modules. If you want your application to support different resource-access strategies, another example might be to put your resource access layer in a separate module. By replacing the resource access layer module, you can have the application access a local database or a remote Web service.
3. Define the communication patterns between the modules.
Even though modules should have low coupling between each other, it is common for modules to communicate with each other. There are several loosely coupled communication patterns, each with their own strengths. Typically, combinations of these patterns are used to create the resulting solution. The following are some of these patterns:
  - **Loosely coupled events** A module can broadcast that a certain event has occurred. Other modules can subscribe to those events so they will be notified when the event occurs. Loosely coupled events are a lightweight manner of setting up communication between two modules; therefore, they are easily implemented. However, a design that relies too heavily on events can become hard to maintain, especially if many events have to be orchestrated together to fulfill a single task. In that case, it might be better to consider a shared service.
  - **Shared services**. A shared service is a class that can be accessed through a common interface. Typically, shared services are found in a shared assembly and provide system-wide services, such as authentication, logging, or configuration.
  - **Shared resources**. If you do not want modules to directly communicate with each other, you can also have them communicate indirectly through a shared resource, such as a database or a set of Web services.
