[Software Estimation: Demystifying the Black Art]

Analogy-based estimations
---

|Applicability of Techniques in This Chapter| |
|-------------------------------------------|---|
|| Estimation by Analogy|
| What's estimated | Size, Effort, Features,Effort|
| Size of project | S M L |
| Development stage | Early-Late|
| Iterative or sequential | Both |
| Accuracy possible | Medium |


Gigacorp (a fictional corporation) was about to begin work on Triad 1.0, a companion product to its successful AccSellerator 1.0 sales-presentation software. Mike had been appointed project manager of Triad 1.0, and he needed a ballpark estimate for an upcoming sales planning meeting. He called his staff meeting to order.

"As you know, we're embarking on development of Triad 1.0," he said. "The technical work is very similar to AccSellerator 1.0. I see this project as being a little bigger overall than AccSellerator 1.0, but not much bigger."

"The database is going to be quite a bit bigger," Jennifer volunteered. "But the user interface should be about the same size."

"It will have a lot more graphs and reports than AccSellerator 1.0 had, too, but the foundation classes should be very similar; I think we'll end up with the same number of classes." Joe said.

"That all sounds right to me," Mike said. "I think this gives me enough to do a back-of-the-envelope calculation of project effort. My notes indicate that the total effort for the last system was 30 staff months. What do you think is a reasonable ballpark estimate for the effort of the new system?"

What do you think is a reasonable ballpark estimate for the effort of the new system?


---

**Basic Approach to Estimating by Analogy**

I've had several hundred estimators create estimates for the Triad project. Using the approach implied in the example, their estimates have ranged from 30 to 144 staff months, with an average of 53 staff months. The standard deviation of their estimates is 24, or 46% of the average answer. That is not very good! A little bit of structure on the process helps a lot.

Here is a basic estimation by analogy process that will produce better results:

 - Get detailed size, effort, and cost results for a similar previous project. If possible, get the information decomposed by feature area, by work breakdown structure (WBS) category, or by some other decomposition scheme.
 - Compare the size of the new project piece-by-piece to the old project.
 - Build up the estimate for the new project's size as a percentage of the old project's size.
 - Create an effort estimate based on the size of the new project compared to the size of the previous project.
 - Check for consistent assumptions across the old and new projects.

**Step 1: Get Detailed Size, Effort, and Cost Results for a Similar Previous Project**

After the first meeting, Mike asked the Triad staff to gather more specific information about the sizes of the old system and the relative amount of functionality in the old and new systems. When their work was completed, Mike asked how they had done. "Did you get the data on the project I outlined last week?" he asked.

"Sure, Mike," Jennifer replied. "AccSellerator 1.0 had 5 subsystems. They stacked up like this:

|   |   |
|--------|-------------------------|
|Database|5,000 lines of code (LOC)|
|User Interface|14,000 LOC|
|Grapths and reports|9,000 LOC|
|Foundation classes|4,500 LOC|
|Business rules|11,000 LOC|
|Total|43,000 LOC|

"We also got some general information about the number of elements in each subsystem. Here's what we found:

|   |   |
|--------|-------------------------|
|Database|10 Tables|
|User Interface|14 web pages|
|Grapths and reports|10 graphs + 8 reports|
|Foundation classes|15 classes|
|Business rules|???|

"We've done a fair amount of work to scope out the new system. It looks like this:

|   |   |
|--------|-------------------------|
|Database|10 Tables|
|User Interface|19 web pages|
|Grapths and reports|14 graphs + 16 reports|
|Foundation classes|15 classes|
|Business rules|???|

"The comparison to most of the old system is pretty straightforward, but the business rules part is a little tough," Jennifer said. "We think it's going to be more complicated than the old system, but we're not sure how to put a number on it. We've talked it over, and our feeling is that it's at least 50% more complicated than the old system."

"That's great work," Mike said. "This gives me what I need to compute an estimate for my sales meeting. I'll crunch some numbers this afternoon and run them by you before the meeting."

**Step 2: Compare the Size of the New Project to a Similar Past Project**

The Triad details give us what we need to create a meaningful estimate by analogy. The Triad team has already performed Step 1, "Get detailed size, effort, cost results for a similar previous project." We can perform Step 2, "Compare the size of the new project piece-by-piece to the old project." Table 11-1 shows that detailed comparison. Writing down the numbers in columns 2 and 3 is the easy part. The tricky part is what to do in the Multiplication Factor entry in column 4. The main principle here is the Count, Compute, Judge principle. If we can find something to count, we're better off than if we insert subjective judgment.

|Subsystem | Actual Size of AccSellerator 1.0| Estimated Size of Triad 1.0|Multiplication Factor |
|---|---|---|---|
|Database| 10 tables| 14 tables |1.4|
|User interface| 14 Web pages| 19 Web pages |1.4|
|Graphs and reports| 10 graphs + 8 reports| 14 graphs + 16 reports |1.7|
|Foundation classes| 15 classes| 15 classes |1.0|
|Business rules | ??? | ??? |1.5|
 
The factors of 1.4 for database, 1.4 for user interface, and 1.0 for foundation classes seem straightforward

The factor of 1.7 for graphs and reports is a little tricky. Should graphs be weighted the same as reports? Maybe. Graphs might require more work than reports, or vice versa. If we had access to the code base for AccSellerator 1.0, we could check whether graphs and reports should be weighted equally or whether one should be weighted more heavily than the other. In this case, we'll just assume they're weighted equally. We should document this assumption so that we can retrace our steps later, if we need to.

The business rules entry is also problematic. The team in the case study didn't find anything they could count, so our estimate is on shakier ground in that area than in the other areas. For sake of the example, we'll just accept their claim that the business rules for Triad will be about 50% more complicated than the business rules were in AccSellerator.

**Step 3: Build Up the Estimate for the New Project's Size as a Percentage of the Old Project's Size**

In Step 3, we convert the size measures from the different areas to a common unit of measure, in this case, lines of code. This will allow us to perform a whole-system size comparison between AccSellerator and Triad. Table 11-2 shows how this works.

|Subsystem | Code Size of AccSellerator 1.0| Multiplication Factor |Estimated Code Size of Triad 1.0|
|---|---|---|---| 
|Database| 5000| 1.4|7000|
|User interface| 14000| 1.4|19600|
|Graphs and reports| 19000| 1.7|15300|
|Foundation classes| 4500| 1.0|4500|
|Business rules | 11000 |1.5|16500|
|Total | 43500 |-|62900|

The code sizes for AccSellerator are carried down from the information that was generated in Step 1. The multiplication factors are carried down from the work we did in Step 2. The estimated code size for Triad is simply AccSellerator's code size multiplied by the multiplication factors. The total size in lines of code becomes the basis for our effort estimate, which will in turn become the basis for schedule and cost estimates.

**Step 4: Create an Effort Estimate Based on the Size of the New Project Compared to the Previous Project**

We now have enough background to compute an effort estimate, which is shown in Table 

|Term | Value |
|---|---|
|Size of Triad 1.0 | 62,900 LOC|
|Size of AccSellerator 1.0 | ÷ 43,500 LOC|
|Size ratio| = 1.45|
|Effort for AccSellerator 1.0 |× 30 staff months|
|Estimated effort for Triad 1.0| = 44 staff months|
 
Dividing the size of Triad by the size of AccSellerator gives us a ratio of the sizes of the two systems. We can multiply that by AccSellerator's actual effort, and that gives us the estimate for Triad of 44 staff months.

The estimate you compute and the estimate you present are two different matters. In this computation, you ended up with a single-point estimate. When you present the estimate, you might well decide to present it as a range

I've had the same several hundred estimators who created the original rolled-up estimates for Triad follow this approach, and their results are more accurate and consistent. The standard deviation of their results is only 7% rather than the 46%, even with the uncertainty surrounding graphs, reports, and business rules.

**Step 5: Check for Consistent Assumptions Across the Old and New Projects**

 You should be checking your assumptions at each step. Some assumptions aren't completely checkable until you've computed the estimate. Look for the following major sources of inconsistency:

 - Significantly different sizes between the old and new projects—that is, more than the factor of 3 difference described in Section 5.1, "Project Size." In this case, the sizes are different, but only by a factor of 1.45, which is not enough of a difference to cause any worry about diseconomies of scale.

 - Different technologies (for example, one project in C# and the other in Java).

 - Significantly different team members (for small teams) or team capabilities (for large teams). Small differences are OK and often unavoidable.

 - Significantly different kinds of software. For example, an old system that was an internal intranet system and a new system that's a life-critical embedded system would not be comparable.

