Challenges with Estimating Size 
---

Numerous measures of size exist, including the following:
  - Features
  - User stories
  - Story points
  - Requirements
  - Use cases
  - Function points
  - Web pages
  - GUI components (windows, dialog boxes, reports, and so on)
  - Database tables
  - Interface definitions
  - Classes
  - Functions/subroutines
  - Lines of code
  
####Role of Lines of Code in Size Estimation

---
Using lines of code is a mixed blessing for software estimation. On the positive side, lines of code present several advantages:

  - Data on lines of code for past projects is easily collected via tools.
  - Lots of historical data already exists in terms of lines of code in many organizations.
  - Effort per line of code has been found to be roughly constant across programming languages, or close enough for practical purposes. (Effort per line of code is more a function of project size and kind of software than of programming language, as described in Chapter 5, "Estimate Influences." What you get for each line of code will vary dramatically, depending on the programming language.)
  - Measurements in LOC allow for cross-project comparisons and estimation of future projects based on data from past projects.
  - Most commercial estimation tools ultimately base their effort and schedule estimates on lines of code.

On the negative side, LOC measures present several difficulties when used to estimate size:

  - Simple models such as "lines of code per staff month" are error-prone because of software's diseconomy of scale and because of vastly different coding rates for different kinds of software.
  - LOC can't be used as a basis for estimating an individual's task assignments because of the vast differences in productivity between different programmers.
  - A project that requires more code complexity than the projects used to calibrate the productivity assumptions can undermine an estimate's accuracy.
  - Using the LOC measure as the basis for estimating requirements work, design work, and other activities that precede the creation of the code seems counterintuitive.
  - Lines of code are difficult to estimate directly, and must be estimated by proxy.
  - What exactly constitutes a line of code must be defined carefully to avoid the problems described in "Issues Related to Size Measures" in Section 8.2, "Data to Collect."

Some experts have argued against using lines of code as a measure of size because of problems associated with using them to analyze productivity across projects of different sizes, kinds, programming languages, and programmers (Jones 1997). Other experts have pointed out that variations of the same basic issues apply to other size measurements, including function points (Putnam and Myers 2003).

The underlying issue that's common to lines of code, function points, and other simple size measures is that measuring anything as multifaceted as software size using a single-dimensional measure will inevitably give rise to anomalies in at least a few circumstances (Gilb 1988, Gilb 2005).

We don't use single-dimensional measures to describe the economy or other complex entities. We can't even use a single measure to determine who the best hitter in baseball is. We consider batting average, home runs, runs batted in, on-base percentage, and other factors—and then we still argue about what the numbers mean. If we can't measure the best hitter using a simple measure, why would we expect we could measure something as complex as software size using a simple measure?

My personal conclusion about using lines of code for software estimation is similar to Winston's Churchill's conclusion about democracy: The LOC measure is a terrible way to measure software size, except that all the other ways to measure size are worse. For most organizations, despite its problems, the LOC measure is the workhorse technique for measuring size of past projects and for creating early-in-the-project estimates of new projects. The LOC measure is the lingua franca of software estimation, and it is normally a good place to start, as long as you keep its limitations in mind.

