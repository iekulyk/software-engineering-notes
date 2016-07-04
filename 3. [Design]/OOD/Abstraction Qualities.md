**Coupling**
How closely do classes rely on each other?
Inheritance makes for strong coupling (generally a bad thing) but takes advantage of the re-use of an abstraction (generally a good thing).

--

**Cohesion**
How tied together are the state and behavior of a class? Does the abstraction model a cohesive, related, integrated thing in the problem space?

--

**Sufficiency**
Does the class capture enough of the details of the thing being modeled to be useful?

--

**Completeness**
Does the class capture all of the useful behavior of the thing being modeled to be re-usable? What about future users (reusers) of the class? How much more time does it take to provide completeness? Is it worth it?

--

**Primitive**
Do all the behaviors of the class satisfy the condition that they can only be implemented by accessing the state of the class directly? If a method can be written strictly in terms of other methods in the class, it isn't primitive.
Primitive classes are smaller, easier to understand, with less coupling between methods, and are more likely to be reused. If you try to do too much in the class, then you're likely to make it difficult to use for other designers.
Sometimes issues of efficiency or interface ease-of-use will suggest you violate the general recommendation of making a class primitive. For example, you might provide a general method with many arguments to cover all possible uses, and a simplified method without arguments for the common case.
The truism "Make the common case fast" holds, but in this case ÒfastÓ means "easy". Easy may violate primitive.
