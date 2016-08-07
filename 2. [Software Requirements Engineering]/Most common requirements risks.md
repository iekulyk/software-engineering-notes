Most common requirements risks
---

###Insufficient User Involvement

Customers often don't understand why it is so essential to work hard on gathering requirements and assuring their quality. Developers might not emphasize user involvement, either because working with users isn't as much fun as writing code or because they think they already know what the users need. In some cases, it's difficult to gain access to people who will actually use the product, and user surrogates don't always understand what users really need. Insufficient user involvement leads to late-breaking requirements that delay project completion.

---

###Creeping User Requirements

As requirements evolve and grow during development, projects often exceed their planned schedules and budgets. Such plans aren't always based on realistic understandings of the size and complexity of the requirements; constant requirements modifications make the problem worse. The problem lies partly in the users' frequent requests for changes in the requirements and partly in the way that developers respond to these requests.

To manage scope creep, begin with a clear statement of the project's business objectives, strategic vision, scope, limitations, success criteria, and expected product usage. Evaluate all proposed new features or requirements changes against this reference framework. An effective change process that includes impact analysis will help the stakeholders make informed business decisions about which changes to accept and the associated costs in time, resources, or feature trade-offs. Change is often critical to success, but change always has a price.

As changes propagate through the product being developed, its architecture can slowly crumble. Code patches make programs harder to understand and maintain. Added code can cause modules to violate the solid design principles of strong cohesion and loose coupling.

---

###Ambiguous Requirements

Ambiguity is the great bugaboo of requirements specifications (Lawrence 1996). One symptom of ambiguity is that a reader can interpret a requirement statement in several ways. Another sign is that multiple readers of a requirement arrive at different understandings of what it means.

Ambiguity leads to different expectations on the part of various stakeholders. Some of them are then surprised with whatever is delivered. Ambiguous requirements result in wasted time when developers implement a solution for the wrong problem. Testers who expect the product to behave differently from what the developers intended waste time resolving the differences.

---

###Gold Plating

Gold plating takes place when a developer adds functionality that wasn't in the requirements specification but that the developer believes "the users are just going to love." Often users don't care about this excess functionality, and the time spent implementing it is wasted. Rather than simply inserting new features, developers and analysts should present the customers with creative ideas and alternatives for their consideration. Developers should strive for leanness and simplicity, not for going beyond what the customer requests without customer approval.

Customers sometimes request features or elaborate user interfaces that look cool but add little value to the product. Everything you build costs time and money, so you need to maximize the delivered value. To reduce the threat of gold plating, trace each bit of functionality back to its origin so that you know why it's included. The use-case approach for eliciting requirements helps to focus requirements elicitation on the functionality that lets users perform their business tasks.

---

###Minimal Specification

Sometimes marketing staff or managers are tempted to create a limited specification, perhaps just a product concept sketched on a napkin. They expect the developers to flesh out the spec while the project progresses. This might work for a tightly integrated team that's building a small system, on exploratory or research projects, or when the requirements truly are flexible (McConnell 1996). In most cases, though, it frustrates the developers (who might be operating under incorrect assumptions and with limited direction) and disappoints the customers (who don't get the product they envisioned).

---

###Overlooked User Classes

Most products have several groups of users who might use different subsets of features, have different frequencies of use, or have varying experience levels. If you don't identify the important user classes for your product early on, some user needs won't be met. After identifying all user classes, make sure that each has a voice.

---

###Inaccurate Planning

"Here's my idea for a new product; when will you be done?" Don't answer this question until you know more about the problem being discussed. Vague, poorly understood requirements lead to overly optimistic estimates, which come back to haunt us when the inevitable overruns occur. An estimator's off-the-cuff guess sounds a lot like a commitment to the listener. The top contributors to poor software cost estimation are frequent requirements changes, missing requirements, insufficient communication with users, poor specification of requirements, and insufficient requirements analysis (Davis 1995). When you present an estimate, provide either a range (best case, most likely, worst case) or a confidence level ("I'm 90 percent sure I can have that done within three months").

