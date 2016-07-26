Software Architecture AntiPatterns
---

###Stovepipe Enterprise
A Stovepipe System is characterized by a software structure that inhibits change. The refactored solution describes how to abstract subsystem and components to achieve an improved system structure. The Stovepipe Enterprise AntiPattern is characterized by a lack of coordination and planning across a set of systems. 

###Jumble
When horizontal and vertical design elements are intermixed, an unstable architecture results. The intermingling of horizontal and vertical design elements limits the reusability and robustness of the architecture and the system software components. 

###Stovepipe System
Subsystems are integrated in an ad hoc manner using multiple integration strategies and mechanisms, and all are integrated point to point. The integration approach for each pair of subsystems is not easily leveraged toward that of other subsystems. The Stovepipe System AntiPattern is the single-system analogy of Stovepipe Enterprise, and is concerned with how the subsystems are coordinated within a single system. 

###Cover Your Assets
Document-driven software processes often produce less-than-useful requirements and specifications because the authors evade making important decisions. In order to avoid making a mistake, the authors take a safer course and elaborate upon alternatives. 

###Vendor Lock-In
Vendor Lock-In occurs in systems that are highly dependent upon proprietary architectures. The use of architectural isolation layers can provide independence from vendor-specific solutions. 

###Wolf Ticket
A Wolf Ticket is a product that claims openness and conformance to standards that have no enforceable meaning. The products are delivered with proprietary interfaces that may vary significantly from the published standard. 

###Architecture by Implication
This AntiPattern is characterized by the lack of architecture specifications for a system under development. Usually, the architects responsible for the project have experience with previous system construction, and therefore assume that documentation is unnecessary.

###Warm Bodies
Software projects are often staffed with programmers with widely varying skills and productivity levels. Many of these people may be assigned to meet staff size objectives (so-called “warm bodies”). Skilled programmers are essential to the success of a software project. So-called heroic programmers are exceptionally productive, but as few as 1 in 20 have this talent. They produce an order of magnitude more working software than an average programmer. 

###Design by Committee
The classic AntiPattern from standards bodies, Design by Committee creates overly complex architectures that lack coherence. Clarification of architectural roles and improved process facilitation can refactor bad meeting processes into highly productive events. 

###Swiss Army Knife
A Swiss Army Knife is an excessively complex class interface. The designer attempts to provide for all possible uses of the class. In the attempt, he or she adds a large number of interface signatures in a futile attempt to meet all possible needs. 

###Reinvent the Wheel
The pervasive lack of technology transfer between software projects leads to substantial reinvention. Design knowledge buried in legacy assets can be leveraged to reduce time-to-market, cost, and risk. 

###The Grand Old Duke of York
Egalitarian software processes often ignore people’s talents to the detriment of the project. Programming skill does not equate to skill in defining abstractions. There appear to be two distinct groups involved in software development: abstractionists and their counterparts the implementationists. 

