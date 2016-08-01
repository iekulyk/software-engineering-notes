[Algorithms complexity](https://www.interviewcake.com/article/python/big-o-notation-time-and-space-complexity)
---

Big O notation is the language we use for articulating how long an algorithm takes to run. 

It's how we compare the efficiency of different approaches to a problem. 

With big O notation we express the runtime in terms of—brace yourself—how quickly it grows relative to the input, as the input gets arbitrarily large. 

  1. how quickly the runtime grows—Some external factors affect the time it takes for a function to run: the speed of the processor, what else the computer is running, etc. So it's hard to make strong statements about the exact runtime of an algorithm. Instead we use big O notation to express how quickly its runtime grows. 
  2. relative to the input—Since we're not looking at an exact number, we need something to phrase our runtime growth in terms of. We use the size of the input. So we can say things like the runtime grows "on the order of the size of the input" (O(n)O(n)O(n)) or "on the order of the square of the size of the input" (O(n2)O(n^2)O(n​2​​)). 
  3. as the input gets arbitrarily large—Our algorithm may have steps that seem expensive when nnn is small but are eclipsed eventually by other steps as nnn gets huge. For big O analysis, we care most about the stuff that grows fastest as the input grows, because everything else is quickly eclipsed as nnn gets very large. If you know what an asymptote is, you might see why "big O analysis" is sometimes called "asymptotic analysis." 
  

Big O notation is like math except it's an awesome, not-boring kind of math where you get to wave your hands through the details and just focus on what's basically happening. 

If this seems abstract so far, that's because it is. Let's look at some examples. 

----

```
  def print_first_item(list_of_items):
    print list_of_items[0]
```

This function runs in O(1)O(1)O(1) time (or "constant time") relative to its input. The input list could be 1 item or 1,000 items, but this function would still just require one "step."

```
def print_all_items(list_of_items):
    for item in list_of_items:
        print item
```

This function runs in O(n)O(n)O(n) time (or "linear time"), where nnn is the number of items in the list. If the list has 10 items, we have to print 10 times. If it has 1,000 items, we have to print 1,000 times.

