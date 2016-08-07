User Classes
---

A product's users differ, among other ways, in the following respects:

  - The frequency with which they use the product
  - Their application domain experience and computer systems expertise
  - The features they use
  - The tasks they perform in support of their business processes
  - Their access privilege or security levels (such as ordinary user, guest user, or administrator)

You can group users into a number of distinct user classes based on these differences. An individual can belong to multiple user classes. For example, an application's administrator might also interact with it as an ordinary user at times. The terminators shown outside your system on a context diagram (as discussed in Chapter 5) are candidates for user classes. A user class is a subset of a product's users, which is a subset of a product's customers, which is a subset of its stakeholders

Certain user classes are more important to you than others. Favored user classes receive preferential treatment when you're making priority decisions or resolving conflicts between requirements received from different user classes. Favored user classes include those groups whose acceptance and use of the system will cause it to meet—or fail to meet—its business objectives. This doesn't mean that the stakeholders who are paying for the system (who might not be users at all) or who have the most political clout should necessarily be favored. Disfavored user classes are those groups who aren't supposed to use the product for legal, security, or safety reasons
You might elect to ignore still other user classes. They get what they get, but you don't specifically build the product to suit them. The remaining user classes are of roughly equal importance in defining the product's requirements.

Each user class will have its own set of requirements for the tasks that members of the class must perform. They might also have different nonfunctional requirements, such as usability, that will drive user interface design choices. Inexperienced or occasional users are concerned with how easy the system is to learn (or relearn) to use. These users like menus, graphical user interfaces, uncluttered screen displays, verbose prompts, wizards, and consistency with other applications they have used. Once users gain sufficient experience with the product, they become more concerned about ease of use and efficiency. They now value keyboard shortcuts, macros, customization options, toolbars, scripting facilities, and perhaps even a command-line interface instead of a graphical user interface.

It might sound strange, but user classes need not be human beings. You can consider other applications or hardware components with which your system interacts as additional user classes. A fuel injection system would be a user class for the software embedded in an automobile's engine controller. The fuel injection system can't speak for itself, so the analyst must get the requirements for the fuel-injection control software from the engineer who designed the injection system.

Identify and characterize the different user classes for your product early in the project so that you can elicit requirements from representatives of each important class. A useful technique for this is called "Expand Then Contract" (Gottesdiener 2002). Begin by brainstorming as many user classes as you can think of. Don't be afraid if there are dozens at this stage, because you'll condense and categorize them later. It's important not to overlook a user class because that will come back to bite you later. Next, look for groups with similar needs that you can either combine or treat as a major user class with several subclasses. Try to pare the list down to no more than about 15 distinct user classes. 

Document the user classes and their characteristics, responsibilities, and physical locations in the SRS. The project manager of the Chemical Tracking System discussed in earlier chapters identified the user classes and characteristics shown in Table 6-1. Include all pertinent information you have about each user class, such as its relative or absolute size and which classes are favored. This will help the team prioritize change requests and conduct impact assessments later on. Estimates of the volume and type of system transactions help the testers develop a usage profile for the system so that they can plan their verification activities.

Consider building a catalog of user classes that recur across multiple applications. Defining user classes at the enterprise level lets you reuse those user class descriptions in future projects. The next system you build might serve the needs of some new user classes, but it probably will also be used by user classes from your earlier systems.


