[Planning Extreme Programming]

Story based estimations
---

Base your story estimates on a similar story you've already done. This story will take
about the same amount of time as a comparable story

How do you come up with estimates? We've seen a lot of words devoted to this topic.
We've seen quite a few mathematical formulae. The best of these are based on the lines of
code yet to be written. These can tell you how much time it will take to develop so many
thousand lines of code. This is particularly useful since it's so easy to estimate precisely
how many lines of code a solution will require before you start writing it. (Spotted the
sarcasm yet?)

Let's be clear, estimation is an art at best. You're not going to get accurate figures
however hard you try. With a little bit of effort you can, however, get good enough
numbers, and you can get better numbers over time.

There are three keys to effective estimation:

 - Keep it simple.
 - Use what happened in the past.
 - Learn from experience.

The best guide to estimating the future is to look for something that happened in the past
that was about the same as the future thing. Then just assume that history will repeat
itself. It often does. If there's a significant difference between then and now, then use a
very simple way to factor it in. Don't try to be too sophisticated; estimates will never be
anything other than approximate, however hard you try. 

**Estimating the Size of a Story**

A simple, effective way to estimate the size of a story is to look for a similar story that
you've already delivered. Then look at your records to see how long it took to build. Then
assume the new story will take the same amount of effort. "Oh, another report. Reports
always take us a week."

If you can't find a story that is the same size, look for something half as big or twice as
big. Multiply or divide as appropriate. Do not worry that Martin probably failed to get an
A in his Further Maths A level because of his unfortunate habit of multiplying by two
when he should have divided. You're a lot cleverer than he is

It doesn't actually matter what units you express the estimate in. The only important thing
is that you always use the same unit. In this book we use ideal weeks. Ideal weeks are the
number of person weeks that the story would take to implement if the programmers could
dedicate 100 percent of their time to it. 

(You'll notice a slight flaw in this approach. How do you estimate when you haven't built
anything yet and you don't have anything to compare it to? See Chapter 15 for a
thoroughly unsatisfactory solution to this problem.) 

Estimation is a team effort. The team discusses the story, considers how long it may take
to implement, and decides upon an estimate. The team members may disagree regarding
the estimate. Some may think the story is hard and will take a long time to develop.
Others may think it is easy and will take a short time to develop. We follow the rule
"Optimism wins." That is, if after reasonable discussion the disagreement persists, we
choose the shortest estimate.

Remember, estimates are not commitments. And a couple of bad estimates are not
disasters. What we are aiming for is to continuously improve our ability to make
estimates. By choosing the most optimistic estimate we accomplish two things: We keep
tension in the estimates so that they don't grow hideously long, and we keep tension in
the team so that the team learns not to be too optimistic. Team members whose optimism
burned the team once will learn to temper that optimism.

Another issue that worries many people is dependencies between the stories. As we say
in Chapter 13, you can mostly ignore dependencies. However, mostly doesn't mean
always. You will get some cases where you say "Flooping the thingummy will take six
weeks, but if we do it after we burble the foobar it'll take only four weeks." In this case
use the appropriate number for flooping depending on its position and make a note of the
assumption. You will have only a few of these.

Periodically you will reestimate every story, which gives you a chance to incorporate
additional information such as dependencies that have been erased or technologies that
turn out to be difficult (or easy, we suppose).

**Estimating How Much You Can Do in an Iteration**

You can think of each iteration as a box, each of which can hold a limited number of
wine bottles. The key question to any oenophile is how many bottles can you fit in a box?
You could measure the box, measure the bottles and do some geometric analysis, you
could form a committee of august persons, or you could just try it and see. 

We use the latter approach: Yesterday's Weather. At the end of each iteration we measure
how much stuff got done and assume we'll get the same work done this time. However,
when we talked about Yesterday's Weather, we just talked about the general principle. To
apply it to release planning we need to figure out how to measure the stuff. We could just
count the number of stories we do, but not all stories are the same size. 

So we have to measure the size of each story. At the end of each iteration we look at all
the stories that got done, and we record how many weeks of ideal time it took to do each
story. We then add up all the ideal time in all the stories, and that tells us how much ideal
time there is in each iteration. 

Following this simple rule violates one of the dictums of project management: Work
expands to fill the available space. That may be true for some activities, but it isn't true
when you have motivated and capabable software developers. 

Be wary of adjusting velocity to cope with changes in a team's size. As we discussed in
Chapter 7, changing the composition of a team has a nonlinear and delayed effect on
velocity. Don't predict the effect; measure it. Predicting the effect of adding people is
particularly difficult, because you rarely know how long it will take for the new people to
begin helping. 

We also use velocity for individual developers. We might say that one programmer has a
velocity of 5 ideal days. That means that that programmer can sign up for 5 ideal days of
work in each iteration. Most developers will have the same velocity. However, someone
working parttime, or someone who is new to the team, will have a lower velocity. 

You have to be careful not to attach too much meaning to velocity. Say you have two
teams of the same size with the same iteration lengths but different velocities. What does
this mean? 

The answer is all sorts of things tangled up together. It might mean one team is more
talented or that one team had better tools. But it might also mean that one team tended to
use more optimistic estimates than the other and needed a smaller velocity to compensate.
In the end, all of this stuff about ideal time is one almighty fudge to compensate for the
difficulty of estimating software development. 

**The Meaning of Ideal Time**

There's been a fair bit of discussion in the XP community about what units of effort we
should use. 

In many ways, the simplest unit would be calendar effort, which is based on calendar
time. 

Calendar time is the familiar passage of time, modified to handle working days. If you
are working Mondays to Fridays, then four calendar weeks is equal to 20 calendar days. 

Calendar effort is the number of people times calendar time. A team of six people has
30 calendar development days of effort available per calendar week. In four weeks they
would have 24 calendar development weeks of effort available. If one person on the team
worked half-time, the team would have 22 calendar development weeks of effort
available in that same four-week period.

Most people measure all tasks in terms of calendar effort. This makes sense because it's
easy to measure. However, it makes estimating harder. Estimating is much simpler if you
think of people as working at reasonable efficiency. Typically this means they don't get
interrupted and distracted. Distractions tend to even out over the long haul but can have a
big effect in short periods of a week or two. As such they really make a mess of historical
data, which is the backbone of a good estimation system. 

So in XP we come up with a second kind of time: ideal time.Ideal time is time without
interruption where you can concentrate on your work and you feel fully productive. We
measure and estimate using ideal time, because that allows us to compare tasks without
worrying about interruptions. If we look at a task and see it is about as complicated as
one that took two ideal days last week, we can estimate it will take two ideal days this
week. The elapsed time could well be very different, but that is something we monitor
separately. 

We use the term "ideal time," but really it's ideal effort. A team of six people might have
ten ideal development days of effort available a week. Typically when people talk of task
lengths they say, "That'll take three ideal days." What they really mean is that it will take
"three ideal development days," but that's too much of a mouthful. 

The notion of ideal time has little to do with time. Indeed some people like to use
something like story points, task points, or Gummi Bears to measure the effort for stories
and tasks. This works because the only important thing is that you use the same unit for
the actual stories you measured in the past as you use for your estimates today. 

We like using ideal weeks because the concept has some correspondence to the familiar,
yet the word ideal is there to remind us that things aren't perfect. It also can help early on
when doing your first plan

