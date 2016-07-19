[Software Estimation : Demystifying the Black Art]

Source of Estimation Errors
---

Suppose you're developing an order-entry system and you haven't yet pinned down the requirements for entering telephone numbers. Some of the uncertainties that could affect a software estimate from the requirements activity through release include the following:

 - When telephone numbers are entered, will the customer want a Telephone Number Checker to check whether the numbers are valid?

 - If the customer wants the Telephone Number Checker, will the customer want the cheap or expensive version of the Telephone Number Checker? (There are typically 2-hour, 2-day, and 2-week versions of any particular feature—for example, U.S.-only versus international phone numbers.)

 - If you implement the cheap version of the Telephone Number Checker, will the customer later want the expensive version after all?

 - Can you use an off-the-shelf Telephone Number Checker, or are there design constraints that require you to develop your own?

 - How will the Telephone Number Checker be designed? (Typically there is at least a factor of 10 difference in design complexity among different designs for the same feature.)

 - How long will it take to code the Telephone Number Checker? (There can be a factor of 10 difference—or more—in the time that different developers need to code the same feature.)

 - Do the Telephone Number Checker and the Address Checker interact? How long will it take to integrate the Telephone Number Checker and the Address Checker?

 - What will the quality level of the Telephone Number Checker be? (Depending on the care taken during implementation, there can be a factor of 10 difference in the number of defects contained in the original implementation.)

 - How long will it take to debug and correct mistakes made in the implementation of the Telephone Number Checker? (Individual performance among different programmers with the same level of experience varies by at least a factor of 10 in debugging and correcting the same problems.)

The reason the estimate contains variability is that the software project itself contains variability. The only way to reduce the variability in the estimate is to reduce the variability in the project.

An important—and difficult—concept is that the Cone of Uncertainty represents the best-case accuracy that is possible to have in software estimates at different points in a project. The Cone represents the error in estimates created by skilled estimators. It's easily possible to do worse. It isn't possible to be more accurate; it's only possible to be more lucky

Chaotic Development Processes
---

 - Requirements that weren't investigated very well in the first place
 - Lack of end-user involvement in requirements validation
 - Poor designs that lead to numerous errors in the code
 - Poor coding practices that give rise to extensive bug fixing
 - Inexperienced personnel
 - Incomplete or unskilled project planning
 - Prima donna team members
 - Abandoning planning under pressure
 - Developer gold-plating
 - Lack of automated source code control

Unstable Requirements
---

The first challenge is that unstable requirements represent one specific flavor of project chaos. If requirements cannot be stabilized, the Cone of Uncertainty can't be narrowed, and estimation variability will remain high through the end of the project.

The second challenge is that requirements changes are often not tracked and the project is often not reestimated when it should be. In a well-run project, an initial set of requirements will be baselined, and cost and schedule will be estimated from that baselined set of requirements. As new requirements are added or old requirements are revised, cost and schedule estimates will be modified to reflect those changes.

If you do want to estimate the effect of unstable requirements, you might consider simply incorporating an allowance for requirements growth, requirements changes, or both into your estimates. Figure 4-5 shows a revised Cone of Uncertainty that accounts for approximately 50% growth in requirements over the course of a project. (This particular Cone is for purposes of illustration only. The specific data points are not supported by the same research as the original Cone.)

Omitted Activities
---

One of the most common sources of estimation error is forgetting to include necessary tasks in the project estimates.

Omitted work falls into three general categories: missing requirements, missing software-development activities, and missing non-software-development activities.

Functional and Nonfunctional Requirements Commonly Missing from Software Estimates 

---

Functional Requirements Areas :
 - Setup/installation program
 - Data conversion utility
 - Glue code needed to use third-party or open-source software
 - Help system
 - Deployment mode
 - Interfaces with external systems

Nonfunctional Requirements :
 - Accuracy
 - Interoperability
 - Modifiability
 - Performance
 - Portability
 - Reliability
 - Responsiveness
 - Reusability
 - Scalability
 - Security
 - Survivability
 - Usability

Software-Development Activities Commonly Missing from Software Estimates : 
- Ramp-up time for new team members
- Mentoring of new team members
- Management coordination/manager meetings
- Cutover/deployment
- Data conversion
- Installation
- Customization
- Requirements clarifications
- Maintaining the revision control system
- Supporting the build
- Maintaining the scripts required to run the daily build
- Maintaining the automated smoke test used in conjunction with the daily build
- Installation of test builds at user location(s)
- Creation of test data
- Management of beta test program
- Participation in technical reviews
- Technical support of existing systems during the project
- Maintenance work on previous systems during the project
- Defect-correction work
- Performance tuning
- Learning new development tools
- Administrative work related to defect tracking
- Coordination with test (for developers)
- Coordination with developers (for test)
- Answering questions from quality assurance
- Input to user documentation and review of user documentation
- Review of technical documentation
- Demonstrating software to customers or users
- Demonstrating software at trade shows
- Demonstrating the software or prototypes of the software to upper management, clients, and end users
- Interacting with clients or end users; supporting beta installations at client locations
- Reviewing plans, estimates, architecture, detailed designs, stage plans, code, test cases, and so on Integration work
- Processing change requests
- Attendance at change-control/triage meetings
- Coordinating with subcontractors

Non-Software-Development Activities Commonly Missing from Software Estimates :

- Vacations
- Company meetings
- Holidays
- Department meetings
- Sick days
- Setting up new workstations
- Training
- Installing new versions of tools on workstations
- Weekends
- Troubleshooting hardware and software problems
 
Unfounded Optimism
---

Subjectivity and Bias
---

Subjectivity creeps into estimates in the form of optimism, in the form of conscious bias, and in the form of unconscious bias. I differentiate between estimation bias, which suggests an intent to fudge an estimate in one direction or another, and estimation subjectivity, which simply recognizes that human judgment is influenced by human experience, both consciously and unconsciously.

As far as bias is concerned, the response of customers and managers when they discover that the estimate does not align with the business target is sometimes to apply more pressure to the estimate, to the project, and to the project team. Excessive schedule pressure occurs in 75% to 100% of large projects 

The reality is the opposite. The more control knobs an estimate has, the more chances there are for subjectivity to creep in. The issue is not so much that estimators deliberately bias their estimates. The issue is more that the estimate gets shaded slightly higher or slightly lower with each of the subjective inputs. If the estimation technique has a large number of subjective inputs, the cumulative effect can be significant.

Off-The-Cuff Estimates
---

Project teams are sometimes trapped by off-the-cuff estimates. Your boss asks, for example, "How long would it take to implement print preview on the Gigacorp Web site?" You say, "I don't know. I think it might take about a week. I'll check into it." You go off to your desk, look at the design and code for the program you were asked about, notice a few things you'd forgotten when you talked to your manager, add up the changes, and decide that it would take about five weeks. You hurry over to your manager's office to update your first estimate, but the manager is in a meeting. Later that day, you catch up with your manager, and before you can open your mouth, your manager says, "Since it seemed like a small project, I went ahead and asked for approval for the print-preview function at the budget meeting this afternoon. The rest of the budget committee was excited about the new feature and can't wait to see it next week. Can you start working on it today?"

Other Sources of Error
---

 - Unfamiliar business area
 - Unfamiliar technology area
 - Incorrect conversion from estimated time to project time (for example, assuming the project team will focus on the project eight hours per day, five days per week)
 - Misunderstanding of statistical concepts (especially adding together a set of "best case" estimates or a set of "worst case" estimates)
 - Budgeting processes that undermine effective estimation (especially those that require final budget approval in the wide part of the Cone of Uncertainty)
 - Having an accurate size estimate, but introducing errors when converting the size estimate to an effort estimate
 - Having accurate size and effort estimates, but introducing errors when converting those to a schedule estimate
 - Overstated savings from new development tools or methods
 - Simplification of the estimate as it's reported up layers of management, fed into the budgeting process, and so on

