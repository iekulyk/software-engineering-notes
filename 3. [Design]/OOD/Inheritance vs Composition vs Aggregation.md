[**Inheritance vs Composition vs Aggregation**](http://enoshtechdiary.blogspot.com/2012/04/composition-vs-aggregation.html)
---------------------------------------------------

**Inheritance: (IS-A)**
------------------------------------
“Wiki” definition: inheritance is a way to form new classes (instances of which are called objects) using classes that have already been defined.

Other definition: One class can use features from another class to extend its functionality (an “Is a” relationship) i.e., a Car is a Automobile.

Inheritance is the inclusion of behaviour (i.e. methods) and state (i.e. variables) of a base class in a derived
class so that they are accessible in that derived class. The key benefit of Inheritance is that it provides the formal mechanism for code reuse.

The ‘is a’ relationship is expressed with inheritance and ‘has a’ relationship is expressed with composition. Both inheritance and composition allow you to place sub-objects inside your new class. Two of the main techniques for code reuse are class inheritance and object composition.

Inheritance is uni-directional. For example Car is a Vehicle. But Vehicle is not a Car. Inheritance uses extends key word. Composition: is used when Car has a Engine. It is incorrect to say Car is a
Engine. Composition simply means using instance variables that refer to other objects. The class Car will have an instance variable, which refers to a Engine object.

```
public class  Vehicle{
 . . .
}
public class  Car extends Vehicle {
 . . .
}
```

There are two types of inheritances:

1. Implementation inheritance (aka class inheritance)
2. Interface inheritance (aka type inheritance)

**ASSOCIATION: (HAS-A)**
-------------------------------------------
- Composition 
- Aggregation  

**Composition: **

Composition is an association in which one class belongs to a collection. This is a part of a whole relationship where a part CANNOT exist without a whole. If a whole is deleted then all parts are deleted.

“Wiki” definition: “object composition (not to be confused with function composition) is a way to combine simple objects or data types into more complex ones.”

Other definition: Allowing a class to contain object instances in other classes so they can be used to perform actions related to the class (an “has a” relationship) i.e., a person has the ability to walk.


As we know, inheritance gives us an 'is-a' relationship. To make the understanding of composition easier, we can say that composition gives us a 'part-of' relationship. 

If we were going to model a car, it would make sense to say that an engine is part-of a car. Within composition, the lifetime of the part (Engine) is managed by the whole (Car), in other words, when Car is destroyed, Engine is destroyed along with it.  
```
public class Engine
{
 . . .
}
public class Car
{
    Engine e = new Engine();
    .......
}
```

As you can see in the example code above, Car manages the lifetime of Engine.

  - Don’t use inheritance just to get code reuse. If there is no ‘is a’ relationship then use composition for code reuse. Overuse of implementation inheritance (uses the “extends” key word) can break all the subclasses, if the superclass is modified.
  - Do not use inheritance just to get polymorphism. If there is no ‘is a’ relationship and all you want is polymorphism then use interface inheritance with composition, which gives you code reuse
  
  **Aggregation:**
  
  Aggregation is an association in which one class belongs to a collection. This is a part of a whole
relationship where a part CAN exist without a whole.

Just like composition, aggregation occurs when an object is composed of multiple objects. However, with composition, the internal objects (such as Tyre , Seat and Engine ) are owned by the main object ( Car ). If you destroy the Car , you also likely want the Tyre , Seat and Engine instances destroyed because they are a composition which, together, form a single Car. 
he Car instance certainly doesn't own the Driver and you probably shouldn't assume that the Driver is destroyed if the Car is destroyed. Further, the Driver exists independent of the Car . The Driver can leave this Car and sit in another one. This independence makes a great deal of difference so this combination of objects is referred to as an aggregation instead of composition. When designing your applications, it is important to note that difference


```
public class Car
{
     private Driver driver;

     public Car(Driver driver)        // Constructor
     {
         this.driver = driver;
     }
     . . .
}
```

Car would then be used as follows:
```
Driver driver = new Driver ();


Car ford = new Car(driver);
or
Car ford = new Car(new Driver());
```
