[PERT (Program evaluation and review technique) analysis](https://en.wikipedia.org/wiki/Program_evaluation_and_review_technique)
---

The program (or project) evaluation and review technique, commonly abbreviated PERT, is a statistical tool, used in project management, which was designed to analyze and represent the tasks involved in completing a given project. First developed by the United States Navy in the 1950s, it is commonly used in conjunction with the critical path method

PERT is a method to analyze the involved tasks in completing a given project, especially the time needed to complete each task, and to identify the minimum time needed to complete the total project.

PERT was developed primarily to simplify the planning and scheduling of large and complex projects. It was developed for the U.S. Navy Special Projects Office in 1957 to support the U.S. Navy's Polaris nuclear submarine project. It is more of an event-oriented technique rather than start- and completion-oriented, and is used more in projects where time is the major factor rather than cost. It is applied to very large-scale, one-time, complex, non-routine infrastructure and Research and Development projects.

  - PERT event: a point that marks the start or completion of one or more activities. It consumes no time and uses no resources. When it marks the completion of one or more activities, it is not "reached" (does not occur) until all of the activities leading to that event have been completed.
  - predecessor event: an event that immediately precedes some other event without any other events intervening. An event can have multiple predecessor events and can be the predecessor of multiple events.
  - successor event: an event that immediately follows some other event without any other intervening events. An event can have multiple successor events and can be the successor of multiple events.
  - PERT activity: the actual performance of a task which consumes time and requires resources (such as labor, materials, space, machinery). It can be understood as representing the time, effort, and resources required to move from one event to another. A PERT activity cannot be performed until the predecessor event has occurred.
  - PERT sub-activity: a PERT activity can be further decomposed into a set of sub-activities. For example, activity A1 can be decomposed into A1.1, A1.2 and A1.3. Sub-activities have all the properties of activities; in particular, a sub-activity has predecessor or successor events just like an activity. A sub-activity can be decomposed again into finer-grained sub-activities.
  - optimistic time: the minimum possible time required to accomplish an activity (o) or a path (O), assuming everything proceeds better than is normally expected
  - pessimistic time: the maximum possible time required to accomplish an activity (p) or a path (P), assuming everything goes wrong (but excluding major catastrophes).
  - most likely time: the best estimate of the time required to accomplish an activity (m) or a path (M), assuming everything proceeds as normal.
  - expected time: the best estimate of the time required to accomplish an activity (te) or a path (TE), accounting for the fact that things don't always proceed as normal (the implication being that the expected time is the average time the task would require if the task were repeated on a number of occasions over an extended period of time).
  - standard deviation of time : the variability of the time for accomplishing an activity (σte) or a path (σTE)
  - float or slack is a measure of the excess time and resources available to complete a task. It is the amount of time that a project task can be delayed without causing a delay in any subsequent tasks (free float) or the whole project (total float). Positive slack would indicate ahead of schedule; negative slack would indicate behind schedule; and zero slack would indicate on schedule.
  - critical path: the longest possible continuous pathway taken from the initial event to the terminal event. It determines the total calendar time required for the project; and, therefore, any time delays along the critical path will delay the reaching of the terminal event by at least the same amount.
  - critical activity: An activity that has total float equal to zero. An activity with zero float is not necessarily on the critical path since its path may not be the longest.
  - Lead time: the time by which a predecessor event must be completed in order to allow sufficient time for the activities that must elapse before a specific PERT event reaches completion.
  - lag time: the earliest time by which a successor event can follow a specific PERT event.
  - fast tracking: performing more critical activities in parallel
  - crashing critical path: Shortening duration of critical activities

Implementation
---

The first step to scheduling the project is to determine the tasks that the project requires and the order in which they must be completed. The order may be easy to record for some tasks (e.g. When building a house, the land must be graded before the foundation can be laid) while difficult for others (There are two areas that need to be graded, but there are only enough bulldozers to do one). Additionally, the time estimates usually reflect the normal, non-rushed time. Many times, the time required to execute the task can be reduced for an additional cost or a reduction in the quality.

In the following example there are seven tasks, labeled A through G. Some tasks can be done concurrently (A and B) while others cannot be done until their predecessor task is complete (C cannot begin until A is complete). Additionally, each task has three time estimates: the optimistic time estimate (o), the most likely or normal time estimate (m), and the pessimistic time estimate (p). The expected time (te) is computed using the formula (o + 4m + p) ÷ 6.

Once this step is complete, one can draw a Gantt chart or a network diagram.

![Diagram](https://upload.wikimedia.org/wikipedia/en/7/73/Pert_example_gantt_chart.gif)

A Gantt chart created using Microsoft Project (MSP). Note (1) the critical path is in red, (2) the slack is the black lines connected to non-critical activities, (3) since Saturday and Sunday are not work days and are thus excluded from the schedule, some bars on the Gantt chart are longer if they cut through a weekend.

A network diagram can be created by hand or by using diagram software. There are two types of network diagrams, activity on arrow (AOA) and activity on node (AON). Activity on node diagrams are generally easier to create and interpret. To create an AON diagram, it is recommended (but not required) to start with a node named start. This "activity" has a duration of zero (0). Then you draw each activity that does not have a predecessor activity (a and b in this example) and connect them with an arrow from start to each node. Next, since both c and d list a as a predecessor activity, their nodes are drawn with arrows coming from a. Activity e is listed with b and c as predecessor activities, so node e is drawn with arrows coming from both b and c, signifying that e cannot begin until both b and c have been completed. Activity f has d as a predecessor activity, so an arrow is drawn connecting the activities. Likewise, an arrow is drawn from e to g. Since there are no activities that come after f or g, it is recommended (but again not required) to connect them to a node labeled finish.

![Diagram](https://upload.wikimedia.org/wikipedia/en/4/40/Pert_example_network_diagram.gif)
Note the critical path is in red.

By itself, the network diagram pictured above does not give much more information than a Gantt chart; however, it can be expanded to display more information. The most common information shown is:

The activity name
The normal duration time
The early start time (ES)
The early finish time (EF)
The late start time (LS)
The late finish time (LF)
The slack


Advantages
---

PERT chart explicitly defines and makes visible dependencies (precedence relationships) between the work breakdown structure (commonly WBS) elements.
PERT facilitates identification of the critical path and makes this visible.
PERT facilitates identification of early start, late start, and slack for each activity.
PERT provides for potentially reduced project duration due to better understanding of dependencies leading to improved overlapping of activities and tasks where feasible.
The large amount of project data can be organized & presented in diagram for use in decision making.
PERT can provide a probability of completing before a given time.

Disadvantages
---

There can be potentially hundreds or thousands of activities and individual dependency relationships.
PERT is not easily scalable for smaller projects.
The network charts tend to be large and unwieldy requiring several pages to print and requiring specially sized paper.
The lack of a timeframe on most PERT/CPM charts makes it harder to show status although colours can help (e.g., specific colour for completed nodes).
