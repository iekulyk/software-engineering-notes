Challenges with Estimating Effort 
---

The largest influence on a project's effort is the size of the software being built. The second largest influence is your organization's productivity.

Even within the same organization, productivity can still vary because of diseconomies of scale and other factors. The Microsoft Windows NT project produced code at a much slower rate than other Microsoft projects did, both because it was a systems software project rather than an applications software project and because it was much larger.

If you don't have historical data on your organization's productivity, you can approximate your productivity by using industry-average figures for different kinds of software: internal business systems, life-critical systems, games, device drivers, and so on. But beware of the factor of 10 differences in productivity for different organizations within the same industry. If you do have data on your organization's historical productivity, you should use that data to convert your size estimates to effort estimates instead of using industry-average data.

####Computing an effort estimate from a size estimate is where we start to run into some of the weaknesses of the art of estimation and need to rely more on the science of estimation.

Suppose you're estimating the effort for a new business system, and you've estimated the size of the new software to be 65,000 to 100,000 lines of Java code, with a most likely size of 80,000 lines of code. Project C is too small to use for comparison purposes because it is less than one-third the size of the low end of your range. Project E is too large to use for comparison purposes because it is more than 3 times the top end of your range. Thus your relevant historical productivity range is 986 LOC per staff month (Project B) to 1,612 LOC per staff month (Project A). Dividing the lowest end of your size range by the highest productivity rate gives a low estimate of 40 staff months. Dividing the highest end of your size range by the lowest productivity gives a high estimate of 101 staff months. Your estimated effort is 40 to 101 staff months.

A good working assumption is that the range includes 68% of the possible outcomes (that is, ±1 standard deviation, unless you have reasons to assume otherwise). You can refer back to Table 10-6, "Percentage Confident Based on Use of Standard Deviation," to consider other probabilities that the 40 to 101 staff-month range might include.

Because you're using historical data to create this estimate, it includes whatever effort is included in the historical data. If the historical data included effort only for development and testing, and only for the part of the project from end of requirements through system testing, that's what the estimate includes. If the historical data also included effort for requirements, project management, and user documentation, that's what the estimate includes.

In principle, estimates that are based on industry-average data usually include all technical work, but not management work, and all development work except requirements. In practice, the data that goes into computing industry-average data doesn't always follow these assumptions, which is part of why industry-average data varies as much as it does.

The science of estimation produces somewhat different results than the informal comparison to past projects does. If you plug the same assumptions into Construx Estimate (that is, using the historical data listed to calibrate the estimate), you get an expected result of 80 staff months, which is in the middle of the range produced by the less-formal approach. Construx Estimate gives a Best Case estimate (20% confident) of 65 staff months, and a Worst Case (80% confident) estimate of 94 staff months.

When Construx Estimate is calibrated with industry-average data instead of historical data, it produces a nominal estimate of 84 staff months and a 20% to 80% range of 47 to 216 staff months, which is a much wider range. This again highlights the benefit of using historical data, whenever possible.

 Tip #85  Use software tools based on the science of estimation to most accurately compute effort estimates from your size estimates.
 
