Documenting and presenting estimation results
---

The way you communicate an estimate suggests how accurate the estimate is. If your presentation style implies an unfounded accuracy, you lay the groundwork for a difficult discussion about the estimate itself. This chapter presents several options for presenting estimates.

###Communicating Estimate Assumptions

An essential practice in presenting an estimate is to document the assumptions embodied in the estimate. Assumptions fall into several familiar categories:

  - Which features are required
  - Which features are not required
  - How elaborate certain features need to be
  - Availability of key resources
  - Dependencies on third-party performance
  - Major unknowns
  - Major influences and sensitivities of the estimate
  - How good the estimate is
  - What the estimate can be used for

Expressing Uncertainty
---

The key issue in estimate presentation is documenting the estimate's uncertainty in a way that communicates the uncertainty clearly and that also maximizes the chances that the estimate will be used constructively and appropriately. This section describes several ways to communicate uncertainty.

####Plus-or-Minus Qualifiers

An estimate with a plus-or-minus qualifier is an estimate such as "6 months, ±2 months" or "$600,000, +$200,000, -$100,000." The plus-or-minus style indicates both the amount and the direction of uncertainty in the estimate. An estimate of 6 months, +1/2 month, -1/2 month says that the estimate is quite accurate and that there's a good chance of meeting the estimate. An estimate of 6 months, +4 months, -1 month says that the estimate isn't very accurate and that there is less chance of meeting the estimate.

Be sure to consider whether the minus qualifier should be the same as the plus qualifier. If you're dealing with effort or schedule, typically the minus side will be smaller than the plus side for the reasons discussed in Section 1.4, "Estimates as Probability Statements."

A weakness of the plus-or-minus style is that, as the estimate is passed through the organization, it tends to get stripped down to just the core estimate. Occasionally, managers simplify such an estimate out of a desire to ignore the variability implied by the estimate. More often, they simplify the estimate because their manager or their corporate budgeting system can handle only estimates that are expressed as single-point numbers. If you use this technique, be sure you can live with the single-point number that's left after the estimate gets converted to a simplified form.

####Risk Quantification

Risk quantification is a combination of plus-or-minus qualifiers and communication of the estimate's assumptions. With risk quantification, you attach specific impacts to specific risks

||Estimate: 6 months, +5 months, -1 month |
|---|---|
|impact|description of risk|
|+1.5|This version needs more thatn 20% new features campared to Version 2.0|
|+1|Graphic formatting subsytem delivered later than planned|
|+1|New development tools don't work as well as planned|
|+1|Can't use 80% of the database code from previous version|
|+0.5|Average staff sickness during the summer months instead of less sickness|
|-0.5|All developers assigned 100% by April 1|
|-0.5|New Development tools work better than planed|

When you document the sources of uncertainty this way, you provide your project stakeholders with information they can use to reduce the risks to the project, and you lay the groundwork for explaining estimate changes in case any of the risks materialize.

If you're far enough into the project to have made a commitment, the risks listed in Table might be risks to meeting the commitment rather than risks to the estimate

This example does not present the generic uncertainty in the project that arises from the Cone of Uncertainty. If you haven't yet made a commitment, you might need to present the Cone-related uncertainty, too.

Tip #105  Be sure you understand whether you're presenting uncertainty in an estimate or uncertainty that affects your ability to meet a commitment.

####Confidence Factors

One of the questions that people often ask about a schedule is, "What chance do we have of making this date?" If you use the confidence-factor approach, you can answer that question

|Delivery Date|Probability of delivering on or before the scheduled date|
|---|---|
|January 15|20%|
|March 1|50%|
|November 1|80%|

avoid presenting highly confident percentages like "90% confident" unless you have a quantitatively derived basis for such a high percentage

Also, consider whether you really need to present low probability estimates. The fact that a result is remotely possible doesn't mean that you have to put it on the table. I doubt that you're currently presenting the options that are 1% likely or 0.0001% likely. Presenting only those options that are at least 50% likely is a legitimate estimation strategy.

Some people more easily understand data presented in a visual form than in a table form, so you might also consider a more visual presentation, 

####Case-Based Estimates

Case-based estimates are a variation on confidence-factor estimates. Present your estimates for best case, worst case, and current case combined with your commitment, or planned case. You can use the gaps between the planned case and the best and worst cases to communicate the degree of variability in the project and the degree of optimism in the plan. If the planned case is much closer to the best case, that implies an optimistic plan.

|Case | Estimate/Commitment |
|---|---|
|Best case (estimate)| January 15|
|Planned case (commitment)| March 1|
|Current case (estimate)| April 1|
|Worst case (estimate)| November 1|

The relationships between these different dates will be interesting. If the planned case and the best case are the same, and the current case and the worst case are the same, your project is in trouble!

If you use this technique, be prepared to explain to your project's stakeholders what would have to occur for you to achieve the best case or fall into the worst case. They will want to know about both possibilities.

Depending on whether you're managing more to a schedule or to a feature set, the case-based estimate can be expressed in terms of feature delivery instead of dates

####Coarse Dates and Time Periods

Try to present your estimate in units that are consistent with the estimate's underlying accuracy. If your estimates are rough, use obviously coarse numbers, such as "We can deliver this in second quarter" or "This project will require 10 staff years," rather than misleadingly precise numbers, such as "We'll deliver this May 21" or "This project will require 15,388 staff hours." Consider using the following:

  - Years
  - Quarters
  - Months
  - Weeks

In addition to expressing the message that the estimate is an approximation, the advantage of coarse numbers is that you don't lose information when the estimate is simplified. An estimate of "6 months, +3 months, -1 month" can be simplified to "6 months." An estimate such as "second quarter" is immune to such simplification.

As you work your way into the Cone of Uncertainty, you should be able to tighten up your time units. Early in the Cone you might present your estimate in quarters. Later, when you're creating bottom-up estimates based on effort for individual tasks, you can probably switch to months or weeks and eventually to days.

Using Ranges (of Any Kind)
---

As discussed throughout this book, ranges are the most accurate way to reflect the inherent inaccuracy in estimates at various points in the Cone of Uncertainty. You can combine ranges with the other techniques described in this chapter (that is, ranges of coarse time periods, using ranges for a risk-quantified estimate instead of plus-or-minus qualifiers, and so on).

When you present an estimate as a range, consider the following questions:

What level of probability should your range include? Should it include ±1 standard deviation (68% of possible outcomes), or does the range need to be wider?

How do your company's budgeting and reporting processes deal with ranges? Be aware that companies' budgeting and reporting processes often won't accept ranges. Ranges are often simplified for reasons that have little to do with software estimation, such as "The company budgeting spreadsheet won't allow me to enter a range." Be sensitive to the restrictions your manager is working under.

Can you live with the midpoint of the range? Occasionally, a manager will simplify a range by publishing the low end of the range. More often, managers will average the high and low ends and use that if they are not allowed to use a range.

Should you present the full range or only the part of the range from the nominal estimate to the top end of the range? Projects rarely become smaller over time, and estimates tend to err on the low side. Do you really need to present the low end to high end of your estimate, or should you present only the part of the range from the nominal estimate to the high end?

Can you combine the use of ranges with other techniques? You might want to consider presenting your estimate as a range and then listing assumptions or quantified risks.

Tip #108  Use an estimate presentation style that reinforces the message you want to communicate about your estimate's accuracy.
 
Usefulness of Estimates Presented as Ranges
---

Project stakeholders might think that presenting an estimate as a wide range makes the estimate useless. What's really happening is that presentation of the estimate as a wide range accurately conveys the fact that the estimate is useless! It isn't the presentation that makes the estimate useless; it's the uncertainty in the estimate itself. You can't remove the uncertainty from an estimate by presenting it without its uncertainty. You can only ignore the uncertainty, and that's to everyone's detriment.

The two largest professional societies for software developers—the IEEE Computer Society and the Association of Computing Machinery—have jointly decided that software developers have a professional responsibility to include uncertainty in their estimates. Item 3.09 in the IEEE-CS/ACM Software Engineering Code of Ethics reads as follows:

Software engineers shall ensure that their products and related modifications meet the highest professional standards possible. In particular, software engineers shall, as appropriate: 

3.09 Ensure realistic quantitative estimates of cost, scheduling, personnel, quality and outcomes on any project on which they work or propose to work and provide an uncertainty assessment of these estimates. [emphasis added] 

Including uncertainty in your estimates isn't just a nicety, in other words. It's part of a software professional's ethical responsibility.

Ranges and Commitments
---

Sometimes, when stakeholders push back on an estimation range, they're really pushing back on including a range in the commitment. In that case, you can present a wide estimation range and recommend that too much variability still exists in the estimate to support a meaningful commitment.

After you've reduced uncertainty enough to support a commitment, ranges are generally not an appropriate way to express the commitment. An estimation range illustrates what the nature of the commitment is—more or less risky—but the commitment itself should normally be expressed as a single-point number.

 Tip #109  Don't try to express a commitment as a range. A commitment needs to be specific.
 



