[Technical feasibility](https://en.wikipedia.org/wiki/Technical_feasibility)
----------------------------------------------------------------------------------

Application development projects often have limited budgets and constrained timelines, set by the stakeholders and upper management. These same people typically provide the business vision and funding for the project. They make decisions about which projects to execute based on both the business value of the resulting project and a professional developer’s estimate of the effort associated with the project. It is their confidence you need to gain before you will be trusted with the budget to execute the project. This means demonstrating that you understand the business problems you will be trying to solve and that you will be successful in translating their vision into tangible software before budgets and timelines are exhausted. To professional developers, this means reviewing requirements and recommending, evaluating, and refining a design for the application.


Evaluate the technical feasibility of an application design concept:
  - Evaluate the proof of concept
  - Recommend the best technologies for the features and goals of the application. Considerations include Message Queuing, Web         services, .NET Framework remoting, and so on
  - Weigh implementation considerations
  - Investigate existing solutions for similar business problems
  

------------------------------------------

  - Recognize poor requirements and propose improvements
  - Evaluate a set of application requirements for their completeness and feasibility
  - Recommend technologies based on a set of requirements
  - Investigate and evaluate existing alternatives to your recommendations
  - Define a high-level application design based on requirements and recommendations
  - Determine whether an application’s design is feasible and practical 

-------------------------------------------

you should be comfortable with all of the following tasks:

  - Reviewing goals and requirements for Web and/or Windows applications

  - Detailing the functional specifications for an application

  - Identifying how .NET architectures and related technologies solve specific business problems

  - Understanding distributed n-tier architectures

  - Working with object-oriented development concepts

  - Reading and working with class diagrams and other technical models

--------------------------------------------

Mike Snell 

Not every problem should be solved with code or technology. As technologists, our first instinct to any problem might be to write some code. However, this is often not the best choice. Some problems are too costly in terms of dollars, resources, or time to implement. You need to take a step back and look at a problem not just as a developer but from the perspective of what is best for your organization. You will find that looking at problems with this attitude might change the way you would approach a specific solution. The results of this thinking are beneficial to the organization. However, it also shows your management that you see a bigger picture beyond just the technology and can be relied on to add business value.

--------------------------------------------

  - Recognize poor requirements and propose improvements.

  - Evaluate a set of application requirements for their completeness and feasibility.

  - Investigate and evaluate existing alternatives to your recommendations.

  - Define a high-level application design based on requirements and recommendations.

  - Determine whether an application’s design is feasible and practical.
  
---------------------------------------------

   - Business Requirement
   - User Requirement
   - Functional Requirement
   - Quality of Service Requirement

When you are presented with a set of requirements, you need to be able to evaluate them and determine whether they are complete, feasible, and sufficient. The categories of requirements that must be present to make a complete set have already been mentioned: business, user, functional, and QOS. The following list represents criteria or questions that you can use to determine whether the requirements are sufficient.

   - **Requirement perspectives**   Are all requirement perspectives considered? Do you have a definition of the business, user, and QOS requirements? Can you derive the functional requirements and design from this set of requirements?

   - **Unambiguous**   Is each requirement written using specifics? Can each requirement be acted upon? You want to make sure that there are no unclear requirements. You want to eliminate phrases such as “the application should be easy to use” from the requirements. This is a goal. A requirement would indicate something such as “the application should implement a task pane of common user actions that are available for a given module.”

   - **Complete**   Are the requirements complete? You need to identify missing elements in the requirements. You should also indicate where further clarification of one or more requirements is warranted. Perhaps, for example, some requirements need further fleshing out through use cases. If you are having trouble understanding a requirement or designing to it, then it’s not complete.

   - **Necessary**   Are all the requirements actually necessary to satisfy the goals of the application? This is the opposite of complete. Sometimes business analysts, developers, and architects can add things to the system that are not really required. You need to watch for overzealous requirement definitions that inflate the scope of the project. 

   - **Feasible**   Are the requirements as documented really feasible? You need to review the requirements against known constraints such as budget, timeline, and technology. It’s better to raise red flags during the requirements definition phase than to wait until the project is already over budget.


Creating a High-Level Application Design
---------------------------------
You have your application requirements. You have evaluated these requirements and confirmed them as good. You then put together a technology recommendation based on the requirements. Your next step is to define a model for the application’s high-level design. This design should help document and explain the application you intend to create. Therefore, it must define the technologies that you intend to use and indicate how these technologies will be connected.

 Creating a Proof-of-Concept Prototype to Refine an Application’s Design
-------------------------------------
Enterprise applications often include multiple clients, Web servers, database servers, application servers, frameworks, and networks all working in concert to provide a complete software solution. Suppose you’ve evaluated the requirements and proposed an appropriate mix of these items. It is then that questions begin to arise regarding the use of things such as multiple threads, component distribution strategies, and inter-application communication techniques. It is best to answer these questions as quickly as possible. A proof of concept is a risk-averse, low-cost means of determining the feasibility of a proposed implementation. It enables you to learn about new technologies, to demonstrate complicated designs, to identify pitfalls, and to improve estimations for your software system.

Prototyping mitigates (and uncovers) real risks for both the organization and the development team. My team was recently handed a requirements document and asked to put together a set of high-level estimates. We documented a lot of assumptions and made key technology recommendations. Based on this information, we estimated the project to require about six months of effort for our team. The client was pleased with this information and ready to get started. However, this was a new business domain for us and a new client, so we suggested beginning with a three-to-five-week prototyping phase.

During the prototyping phase, we confirmed the requirements, identified all the user interface (UI) elements, and validated our technology choices. The result was that we uncovered scores of new requirements, an unforeseen set of more than 30 maintenance screens, and implied integration points for which we had not accounted. This was a big surprise to both us and our client. It seems that the project was much bigger than our original estimate of six months. This forced the client to reappraise the need for this software based on its cost. More important, it saved us both from entering into a project in which neither the client nor we would be successful.

-------------------------------------------
**What Constitutes a Good Prototype?**
A good prototype answers the questions left open from the requirements and technology recommendations. Often, these questions are not so much asked as just exist. This is called a gap. There might be a gap between what a user defines as a requirement or scenario and what the user really wants to see. There might be a gap between what a developer has defined for the application architect and what the project stakeholders understand. There might be a gap between a new architecture that an architect has read about and is proposing and what is truly required. These gaps exist whether they are defined or not. A prototype is meant to reduce the overall project risk by closing some of these gaps.

**Mockups and Proof-of-Concept Prototypes**
There are many types of prototypes. Some projects create UI prototypes. Others might prototype an architecture consideration. Still others might look at the feasibility of using a specific technology such as BizTalk or Host Integration Server. In fact, every project might have different needs for a prototype. However, for the present purposes, these prototypes can be classified into two principal groups: mockups and proof of concept.


**Mockup**
A mockup is meant to verify the requirements and use cases through the creation of a number of key forms in the system. Mockups are also called horizontal prototypes because they reveal a single horizontal picture of the application. They do not go deeply (or vertically) into the other layers of the application such as the business objects and the database. Mockups are a great way to determine whether the requirements are complete and understood. They also help validate the use cases, the navigational structure, and some of the logical interactions of the application.

Mockups do have shortcomings. They do not prove out any of the architecture of the system. They also do not validate the technology decisions. Mockups, however, are a great tool to move from words on paper to something much more tangible. Users often have different opinions when they see something as a picture versus a block of text in a document. Mockups are also useful for defining how the application will look and behave. This removes ambiguity from the implementation and builds early consensus on what will be delivered. The effect is a smoother, faster transition to real working code once development gets started.

**Proof of Concept**
A proof-of-concept prototype is meant to validate the requirements and confirm the technology recommendations and high-level design. A proof-of-concept prototype is also called a vertical prototype because it looks at the application through the entire stack or layers of the application (UI, services, business objects, and database). Proof-of-concept prototypes have also been called reference architectures because they provide a reference to the development team about just how the system should work from top to bottom. This removes ambiguity, creates a standard, and eliminates a lot of risk.

You create a proof-of-concept prototype by choosing a key use case (or set of use cases) of the application and then building it out through each layer of the design. It makes more sense to prove out a riskier use case than to work with a well-known use case. The latter might be easy, but it lacks the risk reduction you are looking for with a proof of concept.

Creating a Prototype to Evaluate Key Design Decisions
------------------------------------------
You must make a lot of key design decisions when recommending any technology. These, like all design decisions, come with a certain amount of risk. The risks are usually related to the ability of the technology to satisfy all the requirements and the developer’s solid grasp of just how that technology works. The following are all risks that you should consider reducing when proposing technologies. Each of these risks can be mitigated through the creation of a proof-of-concept prototype.

**Confirm the Client Technology and Application Container**
The application container is the shell that houses the application and provides base services. In a Windows scenario, this is understood to be a main form with the navigation, status indicator, and base functionality such as undo, cut, copy, paste, auto-update, and so on. In a Web application, this might include your master pages, style sheets, themes and skins, the navigation, and any shared controls that you intend to create. There are many other client variations such as Windows mobile, Smart Client, and Office client.

The time to define your application container is in the prototype phase. This allows the technical leaders of the application to set this very key decision about how developers will add user interface elements to the system. It also removes the ambiguity around this key factor. Also, defining the application container through the prototype gives users a better understanding of how the system will operate as a whole even though you will not implement everything the container defines.

**Defining User Interface Elements to Confirm Requirements**

  - Data entry form   Represents a form in which you are requesting the user to enter data for the application.

  - Data list form   A form that displays a list of data. This list might require paging, sorting, filtering, and so on.

  - Wizard   You might have a set of forms (or tabs) that work together as a wizard to capture user data.

  - Report   You might have a number of report-like forms in the system. These reports might allow for data filtering through parameters or viewing the data graphically.

  - Property page   Represents a form that is used to set and select various properties or settings. These screen types are sometimes implemented in panels or in separate dialog boxes.

  - Navigation and action panes   These forms are employed by the user to navigate within the system or select key actions. Think of the folder pane in Office Outlook as an example. Depending on your application, you might have one or more of these screen types per module.
  
Create a working prototype of at least one of each screen type.

**Evaluating Web Service and Remoting Recommendations**

  - How will users be connected to the application server?

  - How will the application behave when there is no connection or the connection is slow? Are the results acceptable to the users, or do you have to consider design alternatives?

  - How will you manage transaction reliability and ensure no data loss? Will all calls to the application server be synchronous?

  - How will you manage concurrency issues? Will the last user to save unknowingly overwrite someone else’s changes?
  

**Evaluating Your Proposed Security Model**

  - Feasibility   You need to be sure that what you are proposing is feasible. If, for instance, you are proposing that each user authenticate through an Active Directory directory service account, you need to make sure that all users have such accounts or that they can be created. 

  - Authentication   You need to confirm your choice for user authentication. Will you need to implement authentication by saving user credentials in a database? Or can you use Windows authentication?

  - Authorization   You need to confirm your authorization strategy and perhaps filter data based on a user’s access rights. You might even need to control this on a field-by-field basis in a business object. You also need to define how you intend to access key resources in the application. Are there files that need to be checked against an access control list? How should the database connection string be stored securely?

  - Connectivity between resources   You need to validate the feasibility of your proposed high-level design. This might be less of a prototype task and require some discussions with your infrastructure team. For instance, there might be firewall rules that prevent some of your communication decisions between clients and application servers.

  - Data security and encryption   You need to understand what data in the system is sensitive and requires additional considerations. For example, some data might require that it be encrypted when passed between application layers or stored in the database.

  - Application and data access   Some features and data in the system will require that you log their use and access. You need to determine which user activities need to be logged, how you intend to do the logging, and how you plan to manage the data in the access log.

**Evaluating Proposed Data Access and Storage Methods**

The proof of concept phase is also a good time to evaluate your recommendations about data access and storage. If, for example, you are proposing SQL Everywhere be loaded on PDAs and other mobile devices to support offline and synchronization requirements, and you have never done so, you need to prototype. Again, this will help you evaluate your decision in terms of feasibility, practicality, and level of effort.

**Evaluating Your State Management Decisions**

  - Shared state   Do users have to be able to share application state as in an auction system? If so, how will this state be shared from one client to another? Through an application server?

  - State persistence   How will state be maintained on the user’s desktop? The application server? Does the user have offline access to this state? Will a stateless load balancer be required? Should state be moved to a state server to increase scalability?
  
  - Saving state   How will state move from in-memory to at-rest? Will it be saved locally? How will it get to the database?
  
  - Caching   If you have an application server, can some application state be cached on that server and shared? What are the ramifications of the caching strategy in terms of reading old data, updating the cache, and consuming server resources?

**Confirming and Refining the Recommended Architecture**
Your prototype also offers the chance to refine your architecture recommendations. If, for example, you are proposing to create a framework for the application, then now is the time to validate the feasibility of that framework. You might have the functional requirement to eliminate the need for developers to manage saving and retrieving object data, for example. This type of framework needs to be reviewed and validated through a proof of concept.

You might also want to prove out how you will partition the layers of the application. A good reference architecture will demonstrate to a developer how the code should behave and where it should be located. For example, if you create a user interactivity layer for the application that should be used to house user interface code, then you should prototype just what code goes in this layer and how the controls of the user interface might interact with this code. Prototypes are often as much about validating proposed architectures as they are about evaluating or demonstrating recommended technologies. 


-----------------------------
  - A good prototype answers the questions left open from the requirements and technology recommendations.

  - A mockup is a horizontal view of the application at the user interface level. A proof of concept takes a vertical slice of the application and implements it through the layers.

  - A reference architecture is an implementation of the architecture through the application layers. For example, it might include a Windows form, a set of business objects, the data access methods, and the data storage solution-all for a single feature or use case.
  


**Demonstrating the Feasibility of the Design**
-------------------------------------------------------------
You need to evaluate and prove the effectiveness of the prototype. Remember that your intent is to understand and establish the requirements and design recommendations better. The prototype is meant to build confidence and foster a sense of mutual understanding between users, stakeholders, and the developers-before it’s too late.

Go into the prototype phase expecting to find issues with the requirements and design. Do not be afraid to make changes in your assumptions, your design, or your requirements. That is the point. You need to find conflicts between documented requirements and what is practical and feasible. For this reason, spend time evaluating the effectiveness of your prototype. Consider all of the following contingencies.


You need to evaluate and prove the effectiveness of the prototype. Remember that your intent is to understand and establish the requirements and design recommendations better. The prototype is meant to build confidence and foster a sense of mutual understanding between users, stakeholders, and the developers-before it’s too late.

Go into the prototype phase expecting to find issues with the requirements and design. Do not be afraid to make changes in your assumptions, your design, or your requirements. That is the point. You need to find conflicts between documented requirements and what is practical and feasible. For this reason, spend time evaluating the effectiveness of your prototype. Consider all of the following contingencies.

  - Missing or poor requirements   Did you identify requirements that were incomplete or ambiguous? Were there areas that required additional clarification or use cases?

  - Design challenges   What portions of the application will present additional design challenges? Identify areas that will need more focus. Also, consider whether you need to extend the prototype session to complete this effort.

  - Technology recommendations   Are there different recommendations that you would make, based on the prototype? Did your recommendations satisfy everything you had hoped?

  - Level of effort   The prototype should help you understand how much effort will be required to build the application. Take a look at what was required for the reference architecture. Now make sure that you have enough time built into the project based on this effort (adjusted for the skills of the team). 

  - Usability   A good gauge of the prototype is, “Does it seem natural to the users, or do they require training to work with the screens?” If your prototype leans toward the latter, you need to keep working.

Finally, you need to take what you’ve learned from the prototype and put together a presentation for the stakeholders. This will help communicate formally what you’ve learned and accomplished during the prototype phase. This demonstration will help the stakeholders make the decision to release funds to move the project to the next level.













