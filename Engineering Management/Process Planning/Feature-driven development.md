[Feature-driven development](https://en.wikipedia.org/wiki/Feature-driven_development)
------------------------------------------
![visualization](https://upload.wikimedia.org/wikipedia/commons/9/99/Fdd_process_diagram.png)

**Feature-driven development (FDD)** is an iterative and incremental software development process. It is one of a number of lightweight or Agile methods for developing software. FDD blends a number of industry-recognized best practices into a cohesive whole. These practices are all driven from a client-valued functionality (feature) perspective. Its main purpose is to deliver tangible, working software repeatedly in a timely manner.

**Develop overall model**
The FDD project starts with a high-level walkthrough of the scope of the system and its context. Next, detailed domain models are created for each modeling area by small groups and presented for peer review. One of the proposed models, or a combination of them, is selected to become the model for each domain area. Domain area models are progressively merged into an overall model.

**Build feature list**
The knowledge gathered during the initial modeling is used to identify a list of features, by functionally decomposing the domain into subject areas. Subject areas each contain business activities, and the steps within each business activity form the basis for a categorized feature list. Features in this respect are small pieces of client-valued functions expressed in the form "<action> <result> <object>", for example: 'Calculate the total of a sale' or 'Validate the password of a user'. Features should not take more than two weeks to complete, else they should be broken down into smaller pieces.

**Plan by feature**
After the feature list is completed, the next step is to produce the development plan; assigning ownership of features (or feature sets) as classes to programmers.

**Design by feature**
A design package is produced for each feature. A chief programmer selects a small group of features that are to be developed within two weeks. Together with the corresponding class owners, the chief programmer works out detailed sequence diagrams for each feature and refines the overall model. Next, the class and method prologues are written and finally a design inspection is held.

**Build by feature**
After a successful design inspection a per feature activity to produce a completed client-valued function (feature) is planned. The class owners develops the code for their classes. After a unit test and a successful code inspection, the completed feature is promoted to the main build.

Milestones
------------------------------
Since features are small, completing a feature is a relatively small task. For accurate state reporting and keeping track of the software development project it is however important to mark the progress made on each feature. FDD therefore defines six milestones per feature that are to be completed sequentially. The first three milestones are completed during the Design By Feature activity, the last three are completed during the Build By Feature activity. To help with tracking progress, a percentage complete is assigned to each milestone. In the table below the milestones (and their completion percentage) are shown. At the point that coding begins a feature is already 44% complete (Domain Walkthrough 1%, Design 40% and Design Inspection 3% = 44%).



| Domain Walkthrough | Design |	Design Inspection |	Code |	Code Inspection |	Promote To Build |
|--------------------|--------|-------------------|------|------------------|------------------|
|         1%  	 		 |   40%  |         3%        | 45%  |        10%       |         1%       |

**Best practices**
Feature-Driven Development is built on a core set of software engineering best practices, all aimed at a client-valued feature perspective.

  - **Domain Object Modeling* consists of exploring and explaining the domain of the problem to be solved. The resulting domain object model provides an overall framework in which to add features.
  - **Developing by Feature**. Any function that is too complex to be implemented within two weeks is further decomposed into smaller functions until each sub-problem is small enough to be called a feature. This makes it easier to deliver correct functions and to extend or modify the system.
  - **Individual Code Ownership**.  Individual class ownership means that distinct pieces or grouping of code are assigned to a single owner. The owner is responsible for the consistency, performance, and conceptual integrity of the class.
  - **Feature Teams**  A feature team is a small, dynamically formed team that develops a small activity. By doing so, multiple minds are always applied to each design decision and also multiple design options are always evaluated before one is chosen.
  - **Inspections** Inspections are carried out to ensure good quality design and code, primarily by detection of defects.
  - **Configuration Management** Configuration management helps with identifying the source code for all features that have been completed to date and to maintain a history of changes to classes as feature teams enhance them.
  - **Regular Builds** ensure there is always an up to date system that can be demonstrated to the client and helps highlighting integration errors of source code for the features early.
  - **Visibility of progress and results** By frequent, appropriate, and accurate progress reporting at all levels inside and outside the project, based on completed work, managers are helped at steering a project correctly.
  
  Activities and sub-activities
  ----------------------------------------
  
| Activity               | Sub-activity |	Description      |
|------------------------|--------------|------------------|
|  Develop Overall Model |   Form Modeling Team           |        The MODELING TEAM comprises permanent members from the domain and development areas, specifically the domain experts and the chief programmers. Other project staff members are then rotated through the modeling sessions so that everyone gets a chance to participate and to see the process in action.          |
||Conduct Domain Walk-through|A domain expert gives a DOMAIN OVERVIEW of the domain area to be modeled. This should also include information that is related to this DOMAIN AREA but not necessarily a part of its implementation.|
||Study Documents|Optionally the team studies available REFERENCE or REFERENCED REQUIREMENTS documents such as object models, functional requirements (traditional or use-case format), data models, and user guides.|
||Develop Small Group Models|Forming groups of no more than three, each SMALL GROUP will compose a SMALL GROUP MODEL in support of the domain area. The Chief Architect may propose a ´strawman´ model to facilitate the progress of the teams. A member from each small group presents that groups proposed model for the domain area. The Chief Architect may also propose further model alternatives.|
