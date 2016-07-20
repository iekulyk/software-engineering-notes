Count, Compute, Judge techniques 
---

|Applicability of Techniques in This Chapter| | |
|-------------------------------------------|---|---|
||Count|Compute|
| What's estimated | Size, Features|Size, Effort, Schedule, Features|
| Size of project | S M L |S M L|
| Development stage | Early-Late| Early-Middle|
| Iterative or sequential | Both | Both |
| Accuracy possible | High | High | 

Suppose you're at a reception for the world's best software estimators. The room is packed, and you're seated in the middle of the room at a table with three other estimators. All you can see as you scan the room are wall-to-wall estimators. Suddenly, the emcee steps up to the microphone and says, "We need to know exactly how many people are in this room so that we can order dessert. Who can give me the most accurate estimate for the number of people in the room?"

The estimators at your table immediately break out into a vigorous discussion about the best way to estimate the answer. Bill, the estimator to your right, says, "I make a hobby of estimating crowds. Based on my experience, it looks to me like we've got about 335 people in the room."

The estimator sitting across the table from you, Karl, says, "This room has 11 tables across and 7 tables deep. One of my friends is a banquet planner, and she told me that they plan for 5 people per table. It looks to me like most of the tables do actually have about 5 people at them. If we multiple 11 times 7 times 5, we get 385 people. I think we should use that as our estimate."

The estimator to your left, Lucy, says, "I noticed on the way into the room that there was an occupancy limit sign that says this room can hold 485 people. This room is pretty full. I'd say 70 to 80 percent full. If we multiply those percentages by the room limit, we get 340 to 388 people. How about if we use the average of 364 people, or maybe just simplify it to 365?"

Everyone looks at you. You say, "I need to check something. Would you excuse me for a minute?" Lucy, Karl, and Bill give you curious looks and say, "OK."

You return a few minutes later. "Remember how we had to have our tickets scanned before we entered the room? I noticed on my way into the room that the handheld ticket scanner had a counter. So I went back and talked to the ticket taker at the front door. She said that, according to her scanner, she has scanned 407 tickets. She also said no one has left the room so far. I think we should use 407 as our estimate. What do you say?"

Count First
---

One of the secrets of this book is that you should avoid doing what we traditionally think of as estimating! If you can count the answer directly, you should do that first. That approach produced the most accurate answer in the story.

If you can't count the answer directly, you should count something else and then compute the answer by using some sort of calibration data. In the story, Karl had the historical data of knowing that the banquet was planned to have 5 people per table. He counted the number of tables and then computed the answer from that.

Similarly, Lucy based her estimate on the documented fact of the room's occupancy limit. She used her judgment to estimate the room was 70 to 80 percent full

The least accurate estimate came from, Bill, the person who used only judgment to create the answer.

#Count if at all possible. Compute when you can't count. Use judgment alone only as a last resort.


What to Count
---

Software projects produce numerous things that you can count. Early in the development life cycle, you can count marketing requirements, features, use cases, and stories, among other things.

In the middle of the project, you can count at a finer level of granularity—engineering requirements, Function Points, change requests, Web pages, reports, dialog boxes, screens, and database tables, just to name a few.

Late in the project, you can count at an even finer level of detail—code already written, defects reported, classes, and tasks, as well as all the detailed items you were counting earlier in the project.

You can decide what to count based on a few goals.

Find something to count that's highly correlated with the size of the software you're estimating 

---

When you look for something to count, look for something that will be a strong indicator of the software's size. Number of marketing requirements, number of engineering requirements, and Function Points are all examples of countable quantities that are strongly associated with final system size.

Tip #31  Look for something you can count that is a meaningful measure of the scope of work in your environment.
 
Find something to count that's available sooner rather than later in the development cycle 

---

The sooner you can find something meaningful to count, the sooner you'll be able to provide long-range predictability. The count of lines of code for a project is often a great indicator of project effort, but the code won't be available to count until the very end of the project. Function Points are strongly associated with ultimate project size, but they aren't available until you have detailed requirements. If you can find something you can count earlier, you can use that to create an estimate earlier. For example, you might create a rough estimate based on a count of marketing requirements and then tighten up the estimate later based on a Function Point count.

Find something to count that will produce a statistically meaningful average 

---
 
Find something that will produce a count of 20 or more. Statistically, you need a sample of at least 20 items for the average to be meaningful. Twenty is not a magic number, but it's a good guideline for statistical validity.

Understand what you're counting 

---

For your count to serve as an accurate basis for estimation, you need to be sure the same assumptions apply to the count that your historical data is based on and to the count that you're using for your estimate. If you're counting marketing requirements, be sure that what you counted as a "marketing requirement" for your historical data is similar to what you count as a "marketing requirement" for your estimate. If your historical data indicates that a past project team in your company delivered 7 user stories per week, be sure your assumptions about team size, programmer experience, development technology, and other factors are similar in the project you're estimating.

Find something you can count with minimal effort 

---

All other things being equal, you'd rather count something that requires the least effort. In the story at the beginning of the chapter, the count of people in the room was readily available from the ticket scanner. If you had to go around to each table and count people manually, you might decide it wasn't worth the effort.

Use Computation to Convert Counts to Estimates
---

|Quantity to Count | Historical Data Needed to Convert the Count to an Estimate |
|---|---|
|Marketing requirements| 1. Average effort hours per requirement for development <br> 2. Average effort hours per requirement for  <br> 3. independent testing - Average effort hours per requirement for documentation <br>  4. Average effort hours per requirement to create <br> 5. engineering requirements from marketing requirements |
|Features| 1. Average effort hours per feature for development and/or testing |
|Use Cases|1. Average total effort hours per use case <br> 2. Average number of use cases that can be delivered in a particular amount of calendar time |
|Stories|1. Avarage total effort hours per story <br> 2. Avarage number of stories that can be delivered in a particular amoint of calendar time|
|Engineering requirements| 1. Average number of engineering requirements that can be formally inspected per hour <br>2. Average effort hours per requirement for development/test/documentation|
|Function Points| 1. Average development/test/documentation effort per Function Point <br> 2. Average lines of code in the target language per Function Point|
|Change requests|1.Average development/test/documentation effort per change request|
|Web Pages| 1. Average effort per Web page for user interface work <br> 2. Average whole-project effort per Web page|
|Reports|1. Average effort per report for report work|
|Dialog Boxes| 1. Average effort per dialog for user interface work|
|Database Tables|1. Average effort per table for database work<br> 2. Average whole-project effort per table|
|Classes|1. Average effort hours per class for development<br> 2.Average effort hours to formally inspect a class<br>3. Average effort hours per class for testing|
|Defects Found| 1. Average effort hours per defect to fix <br> 2. Average effort hours to formally inspect a class <br> 3. Average effort hours per class for testing|
|Configuration Settingss| 1. Average effort per configuration setting|
|Lines of code already written| 1. Average number of defects per line of code <br> 2. Average lines of code that can be formally inspected per hour <br>3. Average new lines of code from one release to the next|
|Test cases already written| 1. Average amount of release-stage effort per test case|

Use Judgment Only as a Last Resort
---

So-called expert judgment is the least accurate means of estimation. Estimates seem to be the most accurate if they can be tied to something concrete. In the story told at the beginning of this chapter, the worst estimate was the one created by the expert who used judgment alone. Tying the estimate to the room occupancy limit was a little better, although it was subject to more error because that approach required a judgment about how full the room was as a percentage of maximum occupancy, which is an opportunity for subjectivity or bias to contaminate the estimate.


