The Code Review Process
--------------------------------------
Computers are stupid. Yes, they’re incredibly fast at doing what they do, but all they do is follow directions very fast. They are not capable of understanding what users expect of them. Add a zero to an invoice amount. Attempt to divide by zero. Use an object that hasn’t yet been instantiated. When encountering such situations, the computer will assume that’s what you meant to do, regardless of how illogical it is to you.

This means that, in the vast majority of cases, defects introduced into the application are caused by the developer, although not intentionally, of course. The computer, however, is only doing what is asked of it. The question becomes, “How can you keep computers from doing the stupid things a user tells it to do?”

Why Review Code?
------------------------------
Finding bugs is an area that unit testing is supposed to address-and it does, or at least some of it. But unit testing is not sufficient by itself. Gaps in the specifications, errors in assumptions, and even mistakes all contribute to this problem. Ultimately, the more eyes that can look at a block of code, the less likely that a defect will exist.

There are many types of reviews that run the gamut from informal to formal. Some of the more common ones are described in the next sections.

**Inspection**
Possible roles are the:

  - Reader   Responsible for just reading the code that is being reviewed to the other participants. This is not necessarily the author and, in fact, a good argument can be made to not have the author perform this task. Having another person present the code to the assemblage allows the author to see it from a fresh perspective. 

  - Reviewer   This person is included in the review because of his or her technical expertise. He or she is responsible for a critical analysis of the code from that perspective.

  - Observer   This person’s realm of knowledge is in the domain covered by the code. In other words, he or she knows what the application is supposed to do from a business perspective.

  - Moderator   This person is in control of the review meeting. His or her job is to ensure that the meeting stays on topic. He or she will record any decisions that are made and act as an arbiter during the process.
  
Any defects that are discovered are recorded in great detail. This includes not only the location (easily determined because the inspection process is focusing on only a small part of code) but also the severity, the type (algorithmic, documentation, error handling), and the phase at which the error was introduced (developer error, requirements gap, design oversight).

The elements presented at a code walkthrough include some or all of the following aspects.

  - Design   This is a description of the code block at a high level. The purpose is to give the reviewer a better idea of the choices that had to be made and why the code chose what was implemented.

  - Code   This is the source code that is being reviewed. Typically, the reviewer will be looking for clarity, fulfillment of requirements, adequate consideration given to performance, correctness of algorithms, and proper adherence to standards (such as exceptions and input validation).

  - Test Plan   Because the code must have passed a unit test suite before reaching the walkthrough stage, there must be a set of unit tests for the block of code. The reviewer needs to see the test so that suggestions can be made about areas that haven’t yet been addressed.

Pair Programming
---------------------------------
There are a number of benefits to pair programming, not all of which have to do with code review. Because this is a chapter on code review, the following benefits relate only to aspects of a code block that relate to the code review process

  - Better code   Not only does the quality of the code produced by a pair of developers improve, but the number of defects decreases. There is a constant check on the code being written so that, overall, the quality level of code rises. There is also less likelihood that a developer will become sidetracked, resulting in time wasted on unproductive areas.

  - Better design   One of the keys to good code in the long term is the ability of a developer to “do the right thing” even if it means the code takes longer to write. It is very easy for a single developer, when faced with a choice between a quick path to the solution and one that takes longer to code but results in a better long-term design, to choose the quick path. Yes, the code is written faster, but it’s not in the best interest of the application. When one developer is paired with another developer, the tendency is to choose the better design.

  - Greater responsibility   In environments in which pair programming is practiced and the pairs are rotated on a regular basis, there is a greater feeling of ownership in the code base. Although this might seem trivial, developers who feel ownership of code are much more likely to make decisions that benefit the code over making their development process easier. This results in an application that is in a better position to withstand the inevitable changes and enhancements that will come later in the life cycle.

Over the Shoulder Review
------------------------------------------
At the bottom of the list (in terms of formality) is the over-the-shoulder review. This usually consists of a developer pulling a colleague into the cubicle and talking him or her through the code that is being written. The author drives the review, describing the design choices, demonstrating the code, and answering any questions the reviewer might have. Suggestions are frequently implemented while the review is still going on.

Also, the informality frequently leads to some of the code in an application not being reviewed. This is especially true after the bulk of an application has been developed, or the application has already entered its maintenance phase. When an informal approach is taken, a large number of small changes get checked into the main branch of a project without review. Rationale such as “It’s just not worth the effort” or “It was only a small change” might be heard. This is not the best way to ensure a consistent level of quality across a code base.

Code Review Excuses
------------------------------------
There can be no good reason for avoiding code reviews in the development process.

**Too Much Code**
For applications that are being newly created, there is little that can be done to avoid this. As with most daunting tasks, addressing a little at a time can help, but ultimately, all of the code needs to be reviewed.

For modified applications, however, the review effort is much lighter. The trick is to make sure that only the modified code is reviewed. There are certainly tools that will highlight the differences between the current code and the modifications. By focusing on the changes, the amount of effort involved is greatly decreased.

**Logistics**
Having teams in multiple locations can make the code review process difficult, from more than just the technical perspective, too. If you’ve ever been in a room full of developers, you know how difficult it is to get them to focus on the conversation at hand. The life of a developer is a busy one and there are always more important tasks that need to be addressed.

This problem is multiplied across a virtual connection. It is even easier to be distracted by other things on the desktop. This problem isn’t easily solved, unfortunately. Discipline and ensuring that all parties contribute regularly is the best way to deal with the issue. Developers expected to provide an opinion on a regular basis will pay attention during the in-between times

**Preparation Time**
The efforts required to prepare for a code review are significant. In many cases, it takes longer to prepare properly for a code review than to participate in the review itself. Documentation, design notes, and other materials must be put together and then read by the attendees.

To reduce preparation time, spread it across the entire project. A tool such as nDoc*(any other nowaday) can help by automatically combining code comments into an easily viewable document. Tools such as Visual Studio Team System that map requirements and design documents to work items and the associated code can help to cut down on the preparation time also.

**Consistency or Lack Thereof**
For a code review process to be successful, there must be a level of consistency. A block of code cannot be accepted by one reviewer but rejected by another. If this happens, the developers will become frustrated, and they will seek out the easy reviewers for their code.

The solution is to ensure that there is a consensus among the reviewers. This implies that a checklist or published standard must be created. 

Using a standard of some kind actually has an additional benefit. By documenting how certain situations need to be addressed and publishing them to the developers, you help standardize the coding style across the development team. This means that, when facing a code review, reviewers can focus on the parts of the application that are out of the ordinary rather than rehashing the same old coding patterns.

**Reluctant Developers**
You have already read about some of the less obvious ways (for instance, not paying attention during the meeting) that developers show their reluctance to be involved in the code review process. However, developers have also used other, more overt techniques that, in some companies, have made code reviews look much closer to public humiliations.

The key to avoiding this situation lies with management. Whether a development manager or a designate is heading the code review, the leader must make clear the boundaries placed on participation. Managers should make an effort to ensure that criticism remains constructive rather than becoming destructive. It is possible, even when egos are involved, to keep the tone of the code review positive and productive.

What Should a Review Look For?
------------------------------------------------
**Design**
The first place to start a code review is with the design. This means that the work item against which the code is written needs to be discussed and dissected. The choices the developer makes in writing the code are eligible for discussion as well. This is one of the areas in which keeping egos in check is important because, in many cases, the design decisions are more subjective than objective. 

The main questions for this section include:

  - Is the design understandable?

  - Is there a strong relation between the design and the implementation?

   -Are all the functions in the design coded?

  - Does the design address the issue observed by the work item?
  
**Coding Standards**
This area of focus for a code review starts with the assumption that the development team has a published set of coding standards and guidelines. If your team doesn’t have such a document, start by creating one. Although it can be fun to debate how to capitalize method names and create strings, the creation of a standard must not devolve into an examination of minutiae. Instead, publish a clear document with some simple standards. These standards will be expanded as situations arise-and they will probably arise out of code reviews. But having a document, any document, is more important than its contents.

Once the coding standards are in place, the main questions associated with this section become:

  - Does the code adhere to the coding standards?

  - Is the intent of the code understandable?

  - Are any constants embedded in the code that should be extracted as a constant or static property?

  - Does the documentation of the method include a description of all the parameters and the return value? Are there any range limitations on the parameters? Does the method throw any exceptions?
  
**Maintainability**
Beyond coding standards lies the maintainability of the code. Although it is common knowledge that a large portion of the code of an application maintains it after its initial deployment, that knowledge is frequently not applied to the actual coding.

Developers, in general, like solutions that are cute and tricky. The pride that is displayed by concise code is dangerous for the next person trying to understand what is being done and modifying it to support the latest enhancement. Therefore, the code review should take steps to ensure that the code is easily envisioned by the next developer to touch it. The questions that arise from this goal are:

  - Are the comments found in the code accurate? 

  - Are the comments found in the code necessary?

  - Are any constraints or attributes documented, such as units of measure associated with any variables? This question assumes that the constraints and attributes aren’t obvious from the names of the variables.

  - Are there unit tests for any changes (assuming that the code review is for a modification)?

  - Do the unit tests provide adequate coverage of new code?

  - Is the code understandable?
  
**Security**
This is an area that has gained a great deal of attention lately, and the importance placed on security questions depends on the audience for the application. If a Web application is being developed for commercial deployment, the security issues must be addressed closely. Likewise, if it is a commercial Windows Forms application, the security and privacy questions will be high on the list of concerns. For internal applications, the need to address security issues is much less, although not nonexistent.

As for the questions to ask, they are many and varied, and they depend on the type of application that is being developed. The easiest way to deal with security issues is to have a checklist for each type of application

**Performance**
Outside of the questions to ask, there are two areas to focus on for performance questions: frequently executed code paths and loops that execute many times. Within these boundaries, there are a number of improvements to look for.

  - Resource cleanup   If there are resources being allocated and not released, these are definite implications for performance and scalability. It is important to ensure that the code review considers the appropriate use of Dispose and the using statement.

  - Exceptions   Although proper exception handling is an important part of any application, developers sometimes go overboard. Throwing exceptions is a relatively slow process and should, therefore, not be used to control flow within the application.

  - String management   It is fairly common knowledge that StringBuilder is faster than string concatenations after a certain number. This number is traditionally assumed to be three. Even though it is common knowledge, though, it should still be examined as part of the code review. Common knowledge has a tendency to be known not nearly as commonly as might be hoped.

  - Threading   The use of threads within an application should be a signal that intense examination of the code is required. The complexity associated with ensuring that race conditions, dead locks, or other multithreading issues don’t arise is significant.

  - Boxing   The boxing of a variable involves two operations: heap allocation and a memory copy. Although this is sometimes necessary, excessive boxing is usually indicative of other design issues. For example, it is quite common for developers to create a struct (which is a class that is supposed to be allocated on the stack) and then place it in an ArrayList, which requires that they be allocated on the heap. This sort of pattern is exactly what code reviews are intended to catch.





