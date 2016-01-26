[Kanban](http://kanbanblog.com/explained/)
--------------------------------------------------
Kanban is a new technique for managing a software development process in a highly efficient way. Kanban underpins Toyota's "just-in-time" (JIT) production system. Although producing software is a creative activity and therefore different to mass-producing cars, the underlying mechanism for managing the production line can still be applied.


A software development process can be thought of as a pipeline with feature requests entering one end and improved software emerging from the other end.

Inside the pipeline, there will be some kind of process which could range from an informal ad hoc process to a highly formal phased process. In this article, we'll assume a simple phased process of: (1) analyse the requirements, (2) develop the code, and (3) test it works.

The Effect of Bottlenecks
--------------------------------------------------------------
A bottleneck in a pipeline restricts flow. The throughput of the pipeline as a whole is limited to the throughput of the bottleneck.

Using our development pipeline as an example: if the testers are only able to test 5 features per week whereas the developers and analysts have the capacity to produce 10 features per week, the throughput of the pipeline as a whole will only be 5 features per week because the testers are acting as a bottleneck.

If the analysts and developers aren't aware that the testers are the bottleneck, then a backlog of work will begin to pile up in front of the testers.

![bottleneck](http://kanbanblog.com/explained/image/bottleneck-inventory.png)

The effect is that lead times go up. And, like warehouse stock, work sitting in the pipeline ties up investment, creates distance from the market, and drops in value as time goes by.

Inevitably, quality suffers. To keep up, the testers start to cut corners. The resulting bugs released into production cause problems for the users and waste future pipeline capacity.

If, on the other hand, we knew where the bottleneck was, we could redeploy resources to help relieve it. For example, the analysts could help with testing and the developers could work on test automation.

But how do we know where the bottleneck is in any given process? And what happens when it moves?

Kanban reveals bottlenecks dynamically
------------------------------------------------------------
Kanban is incredibly simple, but at the same time incredibly powerful. In its simplest incarnation, a kanban system consists of a big board on the wall with cards or sticky notes placed in columns with numbers at the top.

Limiting work-in-progress reveals the bottlenecks so you can address them.
The cards represent work items as they flow through the development process represented by the columns. The numbers at the top of each column are limits on the number of cards allowed in each column.

The limits are the critical difference between a kanban board and any other visual storyboard. Limiting the amount of work-in-progress (WIP), at each step in the process, prevents overproduction and reveals bottlenecks dynamically so that you can address them before they get out of hand.


Worked Example
------------------------------------------
The board below shows a situation where the developers and analysts are being prevented from taking on any more work until the testers free up a slot and pull in the next work item. At this point the developers and analysts should be looking at ways they can help relieve the burden on the testers.

![board](http://kanbanblog.com/explained/image/kanban-board-1.png)

