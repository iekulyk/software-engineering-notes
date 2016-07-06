Chain of Responsibility
---

- Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.
- Launch-and-leave requests with a single processing pipeline that contains many possible handlers.
- An object-oriented linked list with recursive traversal.

![Diagram](http://www.dofactory.com/images/diagrams/net/chain.gif)

Problem

---

There is a potentially variable number of "handler" or "processing element" or "node" objects, and a stream of requests that must be handled. Need to efficiently process the requests without hard-wiring handler relationships and precedence, or request-to-handler mappings.

![Diagram](https://sourcemaking.com/files/v2/content/patterns/Chain_of_responsibility_1-2x.png)

