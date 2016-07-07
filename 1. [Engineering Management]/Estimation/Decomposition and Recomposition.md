[Software Estimation: Demystifying the Black Art]

Decomposition and Recomposition 
---


|   Applicability of Techniques in This Chapter ||||
|---|---|---|---|
|| Decomposition by Feature or Task  | Decomposition by Work Breakdown Structure (WBS) | Computing Best and Worst Cases from Standard Deviation |
| What's estimated | Size, Effort, Features|Effort|Effort, Schedule| 
| Size of project | S M L | M L | S M L |
| Development stage | Early-Late (small projects); Middle-Late (medium and large projects)| Early-Middle | Early-Late (small projects);Middle-Late (medium and large projects) |
| Iterative or sequential | Both | Both | Both |
| Accuracy possible | Medium-High | Medium | Medium |

Decomposition is the practice of separating an estimate into multiple pieces, estimating each piece individually, and then recombining the individual estimates into an aggregate estimate. This estimation approach is also known as "bottom up," "micro estimation," "module build up," "by engineering procedure," and by many other names (Tockey 2005).

Decomposition is a cornerstone estimation practice—as long as you watch out for a few pitfalls. This chapter discusses the basic practice in more detail and explains how to avoid such pitfalls.

**Calculating an Accurate Overall Expected Case**

---

Scene: The weekly team meeting… 

YOU: We need to create an estimate for a new project. I want to emphasize how important accurate estimation is to this group, and so I'm betting a pizza lunch that I can create a more accurate estimate for this project than you can. If you win, I'll buy the pizza. If I win, you'll buy. Any takers? 

TEAM: You're on! 

YOU: OK, let's get started.

You look up information about a similar past project, and you find that that project took 18 staff weeks. You estimate that this project is about 20 percent larger than the past project, so you create a total estimate of 22 staff weeks.

Meanwhile, your team has created a more detailed, feature-by-feature estimate.


|Feature|Estimated Staff Weeks to Complete|
|---|---|
|Feature 1|1.5|
|Feature 2|4|
|Feature 3|3|
|Feature 4|1|
|Feature 5|4|
|Feature 6|6|
|Feature 7|2|
|Feature 8|1|
|Feature 9|3|
|Feature 10|15|
|Total:|27|

YOU: 27 weeks? Wow, I think your estimate is high, but I guess we'll find out.

A few weeks later… 

YOU: Now that the project is done, we know that it took a total of 29 staff weeks. It looks like your estimate of 27 staff weeks was optimistic by 2 weeks, which is an error of 7%. My estimate of 22 staff weeks was off by 7 staff weeks, about 24%. It looks like you win, so I'm buying the pizza.

By the way, I want to see which of you good estimators cost me the pizza. Let's take a look at which detailed estimates were the most accurate.

You take a few minutes to compute the magnitude of relative error of each individual estimate and write the results on the whiteboard. Table 10-2 shows the results.

|Feature|Estimated Staff Weeks to Complete|Actual Effort|Raw Error|Magnitude of Relative Error|
|-------|---------------------------------|-------------|---------|---------------------------|
|Feature 1|1.5|3.0|-1.5|50%|
|Feature 2|4|2.5| 2.0| 80%|
|Feature 3|3|1.5| 1.5| 100%|
|Feature 4|1|2.5|-1.5|60%|
|Feature 5|4|4.5|-0.5|11|
|Feature 6|6|4.5|1.5|33%|
|Feature 7|2|3.0|-1.0|33%|
|Feature 8|1|1.5|-0.5|33%|
|Feature 9|3|2.5|0.5|20%|
|Feature 10|1.5|3.5|-2.0|57%|
|Total:|27|29|-2|-|
|Average|-|-|-7%|46%|

TEAM: Wow, that's interesting. Most of our individual estimates weren't any more accurate than yours. Our estimates were nearly all wrong by 30% to 50% or more. Our average error was 46%—which is way higher than your error. But our overall error was still only 7% and yours was 24%.

But the joke is on you. Even though our estimates were worse than yours, you're still buying the pizza! 

Somehow the team's estimate was more accurate than your estimate even though their individual feature estimates were worse. How is that possible?

**The Law of Large Numbers**

---

The team's estimate benefited from a statistical property called the Law of Large Numbers. The gist of this law is that if you create one big estimate, the estimate's error tendency will be completely on the high side or completely on the low side. But if you create several smaller estimates, some of the estimation errors will be on the high side, and some will be on the low side. The errors will tend to cancel each other out to some degree. Your team underestimated in some cases, but it also overestimated in some cases, so the error in the aggregate estimate is only 7%. In your estimate, all 24% of the error was on the same side.

**How Small Should the Estimated Pieces Be?**

Seen from the perspective shown in Figure 10-1, software development is a process of making larger numbers of steadily smaller decisions. At the beginning of the project, you make such decisions as "What major areas should this software contain?" A simple decision to include or exclude an area can significantly swing total project effort and schedule in one direction or another. As you approach top-level requirements, you make a larger number of decisions about which features should be in or out, but each of those decisions on average exerts a smaller impact on the overall project outcome. As you approach detailed requirements, you typically make hundreds of decisions, some with larger implications and some with smaller implications, but on average the impact of these decisions is far smaller than the impact of the decisions made earlier in the project

By the time you focus on software construction, the granularity of the decisions you make is tiny: "How should I design this class interface? How should I name this variable? How should I structure this loop?" And so on. These decisions are still important, but the effect of any single decision tends to be localized compared with the big decisions that were made at the initial, software-concept level.

The implication of software development being a process of steady refinement is that the further into the project you are, the finer-grained your decomposed estimates can be. Early in the project, you might base a bottom-up estimate on feature areas. Later, you might base the estimate on marketing requirements. Still later, you might use detailed requirements or engineering requirements. In the project's endgame, you might use developer and tester task-based estimates.

The limits on the number of items to estimate are more practical than theoretical. Very early in a project, it can be a struggle to get enough detailed information to create a decomposed estimate. Later in the project, you might have too much detail. You need 5 to 10 individual items before you get much benefit from the Law of Large Numbers, but even 5 items are better than 1.

**Decomposition via an Activity-Based Work Breakdown Structure**

Sometimes unseen work hides in the form of forgotten features. Sometimes it hides in the form of forgotten tasks. Decomposing a project via an activity-based work breakdown structure (WBS) helps you avoid forgetting tasks. It also helps fine-tune thinking about whether the project you're estimating is bigger or smaller than similar past projects. Comparing the new project to the old project in each WBS category can sharpen your assessment of which parts are bigger and which are smaller.

Table shows a generic, activity-based WBS for a small-to-medium-sized software project. The left column lists the category of activities such as Planning, Requirements, Coding, and so on. The other columns list the kinds of work within each categories, such as Creating, Planning, Reviewing, and so on.

|Category|Create/Do|Plan|Manage|Review|Rework|Report Defects|
|--------|---------|----|------|------|------|--------------|
|General Managment|||||||
|Planning|||||||
|Corporate activities|||||||
|Hardware setup|||||||
|Staff preparation|||||||
|Technicak Processes|||||||
|Requirements work|||||||
|Coordinate with other projects|||||||
|Change management|||||||
|User-interface prototyping|||||||
|Architecture work|||||||
|Detailed designing|||||||
|Coding|||||||
|Component acquisition|||||||
|Automated build|||||||
|Integration|||||||
|Manual system tests|||||||
|Automated system tests|||||||
|Software release|||||||
|Documentation|||||||

To use the generic WBS, you combine the column descriptions with the categories—for example, Create/Do Planning, Manage Planning, Review Planning, Create/Do Requirements Work, Manage Requirements Work, Review Requirements Work, Create/Do Coding, Manage Coding, Review Coding, and so on. The dots in the table represent the most common combinations.

This WBS presents an extensive list of the kinds of activities that you might consider when creating an estimate. You will probably need to extend the list to include at least a few additional entries related to specifics of your organization's software-development approach. You might also decide to exclude some of this WBS's categories, which will be fine as long as that's a conscious decision.

**Hazards of Adding Up Best Case and Worst Case Estimates**

Have you ever had the following experience? You put together a detailed task list. You carefully estimate each of the tasks on the list, thinking, "We can pull this off if we try hard enough." After you go through meticulous planning, you work hard on the first task and deliver it on time. The second task turns up some unexpected problems, but you work late and get it done on schedule. The third task turns up a few more problems, and you leave it unfinished at the end of the day, thinking you'll polish it off the next morning. By the end of the next day, you've barely finished that task, and haven't yet started the task you were supposed to do that day. By the end of the week, you're more than a full task behind schedule.

How did that happen? Were your estimates wrong, or did you just not perform very well?

The answer lies in some of the statistical subtleties involved in combining individual estimates. Statistical subtleties? Yes, for better or worse, this is an area in which we must dig into the mathematics a little to understand how to avoid common problems associated with building up an estimate from decomposed task or feature estimates.

|Feature|Estimated Staff Weeks to Complete|Actual Effort|
|-------|---------------------------------|-------------|
|Feature 1|1.5|3.0|
|Feature 2|4|2.5|
|Feature 3|3|1.5|
|Feature 4|1|2.5|
|Feature 5|4|4.5|
|Feature 6|6|4.5|
|Feature 7|2|3.0|
|Feature 8|1|1.5|
|Feature 9|3|2.5|
|Feature 10|1.5|3.5|
|Total:|27|29|

In this example, the accuracy of the 20-staff-week estimate obtained through a simple summation of decomposed, single-point estimates is actually worse than the aggregate estimate of 22 staff weeks that you provided earlier in the case study. How can this be?

The root cause is a combination of the "90% confident" problem that that was discussed in Chapter 1 ("What Is an 'Estimate'?") and the optimism problem discussed in Chapter 4 ("Where Does Estimation Error Come From?"). When developers are asked to provide single-point estimates, they often unconsciously present Best Case estimates. Let's say that each of the individual Best Case estimates is 25% likely, meaning that you have only a 25% chance of doing as well or better than the estimate. The odds of delivering any individual task according to a Best Case estimate are not great: only 1 in 4 (25%). But the odds of delivering all the tasks are vanishingly small. To deliver both the first task and the second task on time, you have to beat 1 in 4 odds for the first task and 1 in 4 odds for the second task. Statistically, those odds are multiplied together, so the odds of completing both tasks on time is only 1 in 16. To complete all 10 tasks on time you have to multiply the 1/4s 10 times, which gives you odds of only about 1 in 1,000,000, or 0.000095%. The odds of 1 in 4 might not seem so bad at the individual task level, but the combined odds kill software schedules. The statistics of combining a set of Worst Case estimates work similarly.

These statistical anomalies are another reason to create Best Case, Worst Case, Most Likely Case, and Expected Case estimates, as described in Chapter 9, "Individual Expert Judgment." Table shows how that might work out if the developers who produced the estimates in Table above were asked to produce Best Case, Worst Case, and Most Likely Case estimates, and if the Expected Case estimates were computed from those.

|Feature|Best Case(25% Likely)|Most Likely|Worst Case (75% Likely)|Expected Case (50% Likely)|
|-------|---------------------|-----------|-----------------------|--------------------------|
|Feature 1|1.6|2|3.0|2.1|
|Feature 2|1.8|2.5|4.0|2.63|
|Feature 3|2|3.0|4.2|3.03|
|Feature 4|0.8|1.2|1.6|1.2|
|Feature 5|3.8|4.5|5.2|4.5|
|Feature 6|3.8|5.0|6|4.97|
|Feature 7|2.2|2.4|3.4|2.53|
|Feature 8|0.8|1.2|2.2|1.3|
|Feature 9|1.6|2.5|3.0|2.43|
|Feature 10|1.6|4.0|6.0|3.93|
|Total:|20|28.3|38.6|28.62|

**Creating Meaningful Overall Best Case and Worst Case Estimates**

If you can't use the sum of the best cases and worst cases to produce overall Best Case and Worst Case estimates, what do you do? A common approximation in statistics is to assume that 1/6 of the range between a minimum and a maximum approximately equals one standard deviation. This is based on the assumption that the minimum is only 0.135% likely and the assumption that the maximum includes 99.86% of all possible values.




