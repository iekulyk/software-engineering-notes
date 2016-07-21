Story based scope definition: scoping project, release planning
---

###Scoping a Project

To get a quick feel for how big the project is, run the planning process at coarse
resolution.
Let's say you're the only one on the project so far. What's the first step? How can you use
shopping to bring a project into existence?

  • Items— Big stories<br>
  • Prices— Rough estimates of the time to implement each story<br>
  • Budget— Roughly how many people you have to work on the project<br>
  • Constraints— Supplied by someone with business knowledge <br>

The purpose of this first plan is to quickly answer the question "Does the project make
any sense at all?" Often these sanity plans are made before there are any technical people
on the project at all. Don't worry about getting perfect numbers. If the project makes any
sense then you'll invest enough to prepare a plan you have some confidence in. 

What if we were to implement a space-age travel system? (For the full story of the system
see Example of Stories.) We might have a few big stories in mind. Before we can assign
prices to them, we have to know a little more about the system. We ask a few questions:

• How many reservations do we need to handle?<br>
• How much of the time do we need to have the system available?<br>
• What kind of machines will be used to access the system?<br>

With that in mind, we can guess at how long a team of ten would need to implement each
feature as shown in Table 9.1.

Table 9.1. Stories<br>
Story Estimate<br>
Book a space flight 2 months<br>
Book a hotel 1 month<br>
Check itinerary 1 month<br>
Adventure trips 2 months<br>
Holographic planetary simulation 6 months<br>
Cross-species orientation 4 months<br>
Auto-translator 8 months<br>

We make some simplifying assumptions as we go along.

• The stories are completely independent of each other.<br>
• We will develop the necessary infrastructure along with the story, but only the infrastructure absolutely needed for that story.<br>

We know these assumptions aren't exactly accurate, but then again neither is anything
else. If we were trying to predict the future, this would worry us. Since we aren't, it
doesn't.

So, the bottom line is that we can implement the system in 24 months. 

The shouting starts. "We have to go to market in six months, tops, or we're dead." Yes,
we understand. "If you can't do it, we'll hire someone who can." You should do that, but
perhaps we can talk a little first. "You programmers can't tell me what to do." Of course
not, but perhaps you would like to know what you can't do. 

Now the negotiation starts. "What if we just made a booking system first? We'd need the
first three stories. That's four months. But we can't launch without the holographic
simulation. What can you give me in two months?" 

Within a few hours or days, we have a rough plan from which we can move forward. 

The purpose of the big plan is to answer the question "Should we invest more?" We
address this question in three ways:

• Break the problem into pieces.<br>
• Bring the pieces into focus by estimating them.<br>
• Defer less valuable pieces<br>

Start with a conversation about the system (this works best if you involve at least one
other person). As you talk, write down your thoughts, one per index card. If your
thoughts get too detailed, stop writing until you get abstract again.

Some cards will contain business functionality. These are stories. Lay these out in the
middle of a big table. Some of the cards will contain ideas that are context—throughput,
reliability, budget, sketches of happy customers. Set these to one side. 

Now you need to estimate how long each story would take your team to implement (just
guess at a size at first). Give yourself plenty of padding. There will be plenty of time for
stone-cold reality later. Bask in the glow of infinite possibilities for the moment.

If your estimates are too small (like days or weeks), you've slipped into detail land. Put
those cards to one side and start over. If you can't imagine being able to estimate a story
("Easy to Use" is the classic example), put it to one side. Better yet, think about some
specific things that would make the system easy to use, and turn them into stories (for
example, "Personal Profiles")

You can only estimate from experience. What if you don't have any experience? Then
you'd better fake it. Write a little prototype. Ask a friend who knows. Invite a
programmer into the conversation.
Move fast. You're sketching here, trying to quickly capture a picture of the whole system.
Don't spend more than a few hours on your first rough plan. 

###Release Planning

In release planning the customer chooses a few months' worth of stories, typically
focusing on a public release

The big plan helped us decide that it wasn't patently stupid to invest in the project. Now
we need to synchronize the project with the business. We have to synchronize two
aspects of the project:

• Date

• Scope 

Often, important dates for a project come from outside the company:

• The date on the contract

• COMDEX

• When the VC money will run out

Even if the date of the next release is internally generated, it will be set for business
reasons. You want to release often to stay ahead of your competition, but if you release
too often, you won't ever have enough new functionality to merit a press release, a new
round of sales calls, or champagne for the programmers. 

Release planning allocates user stories to releases and iterations—what should we work
on first? what will we work on later? The strategies you will use are similar to making the
big plan in the first place:

• Break the big stories into smaller stories.

• Sharpen the focus on the stories by estimating how long each will take.

• Defer less valuable stories until what is left fits in the time available. 

Release planning is a joint effort between the customer and the programmers. The
customer drives release planning, and the programmers help navigate. The customer 
chooses which stories to place in the release and which stories to implement later, while
the programmers provide the estimates required to make a sensible allocation.

The customer

• Defines the user stories

• Decides what business value the stories have

• Decides what stories to build in this release 

The programmers

• Estimate how long it will take to build each story

• Warn the customer about significant technical risks

• Measure their team progress to provide the customer with an overall budget 

