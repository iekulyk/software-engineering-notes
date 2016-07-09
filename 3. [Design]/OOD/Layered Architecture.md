Layered Architecture
---

The Layers pattem helps to structure applications that can be
decomposed into groups of subtasks in which each group of
subtasks is at a particular level of abstraction.

Networking protocols are probably the best-known example of layered
architectures. 

Imagine that you are designing a system whose dominant
characteristic is a mix of low- and high-level issues, where high-level
operations rely on the lower-level ones. Some parts of the system
handle low-level issues such as hardware traps, sensor input,
reading bits from a file or electrical signals from a wire. At the other
end of the spectrum there may be user-visible functionality such as
the interface of a multi-user 'dungeon' game or high-level policies
such as telephone billing tariffs. A typical pattem of communication
flow consists of requests moving from high to low level, and answers
to requests, incoming data or notification about events traveling in
the opposite direction.

Structure your system into an appropriate number of layers and
place them on top of each other. Start at the lowest level of
abstraction-ca11 it Layer 1. This is the base of your system. Work
your way up the abstraction ladder by putting Layer Jon top of Layer
J -1 until you reach the top level of functionality-callit Layer N 

The main structural characteristic of the Layers pattern is that the
services of Layer J are only used by Layer J + I-there are no further
direct dependencies between layers. This structure can be compared 
with a stack, or even an onion. Each individual layer shields a1llower
layers from direct access by higher layers.

![Example Diagram](https://i-msdn.sec.s-msft.com/dynimg/IC351011.png)

**Design Steps for a Layered Structure**

---

When starting to design an application, your first task is to focus on the highest level of abstraction and start by grouping functionality into layers. Next, you must define the public interface for each layer, which depends on the type of application you are designing. Once you have defined the layers and interfaces, you must determine how the application will be deployed. Finally, you choose the communication protocols to use for interaction between the layers and tiers of the application. Although your structure and interfaces may evolve over time, especially if you use agile development, these steps will ensure that you consider the important aspects at the start of the process.

- Step 1 – Choose Your Layering Strategy
- Step 2 – Determine the Layers You Require
- Step 3 – Decide How to Distribute Layers and Components
- Step 4 – Determine If You Need to Collapse Layers
- Step 5 – Determine Rules for Interaction between Layers
- Step 6 – Identify Cross Cutting Concerns
- Step 7 – Define the Interfaces between Layers
- Step 8 – Choose Your Deployment Strategy
- Step 9 – Choose Communication Protocols

---

   - Define the abstraction clite1ion
   - Determine the number of abstraction levels
   - Name the layers and assign tasks to each of them
   - Specify the services
   - Refine the layering
   - Specify an interfacefor each layer
   - Structure individual layers
   - Specify the communication between adjacent layers
   - Decouple adjacent layers
   - Design an error-handling strategy

   
