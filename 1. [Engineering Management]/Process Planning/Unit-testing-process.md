Unit-testing process
---------------------------------

Developers have been unit testing since the first lines of code were written. Unfortunately, unstructured unit testing produces code that is of only slightly better quality than untested code, and that is not acceptable in today’s business environment.

Structured and automated unit testing, however, is something different. Unlike the haphazard technique of the past (in which the developer, looking at the running application, would say, “Hey … let’s try this”), automated unit testing, when combined with a structured approach to unit test definitions, creates high-quality code with only a marginal increase in the time it takes to produce the code. In some cases, it might take even less overall time to produce the application. The goal in this chapter is to describe how to approach unit testing in a structured manner so that the appropriate increase in code quality can be achieved.

The real power of unit testing is the confidence it brings to making changes to the application. A well-designed suite of unit tests means that the implementation of a class can be improved-or bugs fixed-late in the project with minimal risk of introducing new problems. But note that “well-designed” phrase. To take full advantage of the power of automated testing, you need to create a set of unit tests that covers the tested class sufficiently to give you confidence to make the changes. This chapter describes how to design your unit tests to do that. As a developer who has converted to the power of unit tests, I can’t stress how useful and freeing this is.

**Characteristics of a Good Unit Test**

  - Runs quickly   Developers don’t like wasting time sitting with nothing to do. And waiting for tests to run qualifies as just that. A test that takes too long to run won’t be run often.

  - Tests only one thing   If a test exercises more than one part of an application, it becomes more difficult to isolate the cause of a failure, and constructing a test suite that provides adequate coverage of functionality is more complex.

  - Clearly reveals its intention   Unit tests have the side benefit of documenting how a method is used. Other developers should be able to look at the test and understand how methods are to be used.

  - Isolates or simulates environmental dependencies   This characteristic includes databases, the file system, message queues, networks, and so on. Tests that use these resources are bad for two reasons. First, failures in the external resource will cause a failure in the test, which means that the test is actually testing more than one condition. Also, tests that use external resources will take longer to run.

  - Runs in isolation   Tests that require special environmental setup are awkward to use at best. At worst, they are the sort of annoying gnat-like problem that developers detest. Tests that don’t run in isolation should be simplified, or the dependent resource should be extracted from the test. A test that runs only on the developer’s system is not acceptable under any circumstances.

  - Uses stubs and mock objects   This technique allows external dependencies to be eliminated from the application. It is likely that, to use this technique, changes will be made to the code base. In fact, writing code that can easily be tested frequently results in an increase in the use of interfaces.

**What to Test**
ex.:
  - Constructor test   Determines whether the class can be constructed with all of the necessary initializations performed correctly.
  - SuccessfulProductLoad   Ensures that, for a product number that exists in the database, the values in the database are correctly mapped to the properties in the class
  - Dispose test   If the Product class implements the IDisposable interface, this test would invoke the Dispose method and then ensure that the allocated resources have been properly released.
  - FailedProductLoad   Ensures that the method responds appropriately if the specified product number doesn’t exist in the database
  - InvalidProductNumberFormat   If the product number has a particular format or includes a check digit, a test should be created to ensure that the validation takes place before the database access.
  - DatabaseInvalidAccess   This test ensures that the appropriate exception is thrown if the userid and password aren’t valid to access the database.

------------------------------------------------
The key to a successful unit test suite is having all of the functionality exposed by the class under test covered by unit tests, but simply creating more unit tests doesn’t necessarily guarantee this. Quality is more important than quantity. 

In an ideal world, developers would be able, at will, to change how a class achieves its purpose. After all, changing to find a better way is part of the creative process that motivates many developers. The problem is that developers are also wary of side effects. Many developers have been surprised by making a change to a piece of code only to introduce a new problem in a supposedly complete and separate part of the application.

Here is where confidence in the coverage of a unit test suite is necessary. If the unit tests for a class cover all of the functionality of a class, developers will feel easier about making a change or detecting any side-effect bugs before such bugs wreak havoc on the rest of the application. Further, the test suite can be used on changes made to production code as well, allowing developers to contain the risk associated with bug fixes and minor enhancements. The sighs of relief from developers who are now able to sleep easier is almost deafening.

Code Coverage
--------------------------
Code coverage is actually an interesting conjunction of metrics and reality. As a basic definition, code coverage measures how much of a class is being tested when a particular test suite is executed. Even within that limited scope, however, there are a couple of definitions that are in common use.

  - Statement Coverage : is a measure of the percentage of statements executed. It is calculated as the number of lines of code that were executed at least once during the unit test, divided by the total number of lines of code. The theory behind this is that if a line of code isn’t executed by a test, then any bugs hiding in the code are not likely to be discovered.
  - Branch Coverage : This type of coverage analysis is also known as multiple condition coverage. It assesses the branches that exist within your code and ensures that the unit test suite causes each condition within your code to be evaluated to both true and false.
  
Isolating Components
-------------------------------------
Some of the problems with components that have dependencies on external resources have already been discussed from a testing perspective. Mostly, the problems fall into the categories of speed and complexity of test setup. Although it’s easy to say that components should be designed with a minimum of dependencies, the reality is that, sometimes, that’s not possible. Older classes that were designed before the latest wave of unit testing tools are also likely to fall into this category. In this instance, the need to retrieve data from a particular database might be hard-coded into the implementation. This inflexibility can make it difficult to construct unit tests.

As it turns out, the most common example of dependencies results from needing to access a database. This is the example covered in the next section. Specifically, you will examine the case in which business logic is accessing a data access component, which, in turn, talks to a database server.

As it turns out, the process of isolating components for testing purposes starts with the design. The link between the business logic and the data access component needs to be interfacebased.

The idea behind isolating components lies in the interface. When the application runs in production, the data access component is instantiated and used. When the application is being tested, an object that emulates the data access component is instantiated. The name given to the object that does the emulation is called a mock object.

**Test Double** - the generic term for any kind of pretend object used in place of a real object for testing purposes.

**Mock objects** - A mock object is an object that mimics the interface of another object. Mock objects are generally used in testing or as stubs for objects that have yet to be implemented. The most common usage is testing, in which mock objects emulate hard-to-replicate testing conditions such as network failure or out-of-range data.
**Mocks** - objects pre-programmed with expectations which form a specification of the calls they are expected to receive.

**Fake** objects actually have working implementations, but usually take some shortcut which makes them not suitable for production
 
**Stubs** - provide canned answers to calls made during the test, usually not responding at all to anything outside what's programmed in for the test. Stubs may also record information about calls, such as an email gateway stub that remembers the messages it 'sent', or maybe only how many messages it 'sent'.
 
**Dummy** objects are passed around but never actually used. Usually they are just used to fill parameter lists

Of these kinds of doubles, only mocks insist upon behavior verification. The other doubles can, and usually do, use state verification. Mocks actually do behave like other doubles during the exercise phase, as they need to make the SUT believe it's talking with its real collaborators - but mocks differ in the setup and the verification phases.
  


