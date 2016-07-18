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
