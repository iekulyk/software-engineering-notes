Diseconomies of Scale 
---

Diseconomies of scale are the forces that cause larger firms and governments to produce goods and services at increased per-unit costs. The concept is the opposite of economies of scale

People naturally assume that a system that is 10 times as large as another system will require something like 10 times as much effort to build. But the effort for a 1,000,000-LOC system is more than 10 times as large as the effort for a 100,000-LOC system, as is the effort for a 100,000-LOC system compared to the effort for a 10,000-LOC system.

The basic issue is that, in software, larger projects require coordination among larger groups of people, which requires more communication. As project size increases, the number of communication paths among different people increases as a squared function of the number of people on the project.

The consequence of this exponential increase in communication paths (along with some other factors) is that projects also have an exponential increase in effort as a project size increases. This is known as a diseconomy of scale.

Outside software, we usually discuss economies of scale rather than diseconomies of scale. An economy of scale is something like, "If we build a larger manufacturing plant, we'll be able to reduce the cost per unit we produce." An economy of scale implies that the bigger you get, the smaller the unit cost becomes.

A diseconomy of scale is the opposite. In software, the larger the system becomes, the greater the cost of each unit. If software exhibited economies of scale, a 100,000-LOC system would be less than 10 times as costly as a 10,000-LOC system. But the opposite is almost always the case.

Much of the software-estimating world's focus has been on determining the exact significance of diseconomies of scale. Although that is a significant factor, remember that the raw size is the largest contributor to the estimate. The effect of diseconomy of scale on the estimate is a second-order consideration, so put the majority of your effort into developing a good size estimate. We'll discuss how to create software size estimates more specifically in Chapter 18, "Special Issues in Estimating Size."

[1]The actual number of paths is n x (n — 1) / 2, which is an n2 function
