Understanding RDBMS architecture
---

The architecture of a database management system can be broadly divided into three levels : 
  - External level (AKA user view layer) most close to user and related to techniques of data representation
  - Conceptual level (AKA common layer) an intermidiate layer
  - Internal level (AKA phisical layer) most close to data storage techniques
  
---

###The External Level

This is the highest level, one that is closest to the user. It is also called the user view. The user view is different from the way data is stored in the database. This view describes only a part of the actual database. Because each user is not concerned with the entire database, only the part that is relevant to the user is visible. For example, end users and application programmers get different external views.

For example, an instructor will view the database as a collection of students and courses offered by the university. An administrator will view the database as a collection of records on the stock of course material provided by the university. The instructor is concerned with only a portion of database that is relevant to the instructor and the administrator is concerned with only the portion of database that is relevant to the administrator. These portions of database, which are viewed, by the instructor and administrator are reffered as their user’s view or external view.

Each user uses a language to carry out database operations. The application programmer uses either a conventional third-generation language, such as COBOL or C, or a fourth-generation language specific to the DBMS, such as visual FoxPro or MS Access.

The end user uses a query language to access data from the database. A query language is a combination of three subordinate language :

   Data Definition Language (DDL)<br>
   Data Manipulation Language (DML)<br>
   Data Control Language (DCL)<br>

The data definition language defines and declares the database object, while the data manipulation language performs operations on these objects. The data control language is used to control the user’s access to database objects.

---

###The Conceptual Level

This level comes between the external and the internal levels. The conceptual level represents the entire database as a whole, and is used by the DBA. This level is the view of the data “as it really is”. The user’s view of the data is constrained by the language that they are using. At the conceptual level, the data is viewed without any of these constraints.

---

###The Internal Level

This level deals with the physical storage of data, and is the lowest level of the architecture. The internal level describes the physical sequence of the stored records.

---

###THE DATABASE ADMINISTRATOR

  - Defines conceptual schema
  - Defines internal schema
  - Communicates with users
  - Defines security and integrity checks
  - Defines backup and recovery procedures
  - Monitors performance and decide when to reorganize the database
 
---

###THE DATABASE MANAGEMENT SYSTEM

  1. A user issues an access request
  2. DBMS interpretes the request
  3. DBMS performs external/conceptual and conceptual/interal mappings
  4. DBMS executes the necessary operations on stored database

####THUS DBMS MUST SUPPORT####

  - data definition
  - data manipulation
  - routine and unplanned requests
  - data security and integrity
  - data recovery and concurrency
  - data dictionary
  - performance tuning

---

###DISTRIBUTED DATABASE SYSTEMS

