[Types vs Classes](http://stackoverflow.com/questions/468145/what-is-the-difference-between-type-and-class).
----------------------------------------------


An objects's class defines how the object is implemented .The class defines object's internal state and the implementation of its operations.

In contrast, an objects's type only refers to its interface -the set of requests to which it can respond.

An object can have many type, and object of different classes can have the same type.


---
I always think of a 'type' as an umbrella term for 'classes' and 'primitives'.

int foo; // Type is int, class is nonexistent.

MyClass foo; // Type is MyClass, class is MyClass
