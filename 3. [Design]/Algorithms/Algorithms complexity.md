[Algorithms complexity](https://www.interviewcake.com/article/python/big-o-notation-time-and-space-complexity)
---

Big O notation is the language we use for articulating how long an algorithm takes to run. 

It's how we compare the efficiency of different approaches to a problem. 

With big O notation we express the runtime in terms of—brace yourself—how quickly it grows relative to the input, as the input gets arbitrarily large. 

  1. how quickly the runtime grows—Some external factors affect the time it takes for a function to run: the speed of the processor, what else the computer is running, etc. So it's hard to make strong statements about the exact runtime of an algorithm. Instead we use big O notation to express how quickly its runtime grows. 
  2. relative to the input—Since we're not looking at an exact number, we need something to phrase our runtime growth in terms of. We use the size of the input. So we can say things like the runtime grows "on the order of the size of the input" (O(n)) or "on the order of the square of the size of the input" (O(n^2)). 
  3. as the input gets arbitrarily large—Our algorithm may have steps that seem expensive when nnn is small but are eclipsed eventually by other steps as nnn gets huge. For big O analysis, we care most about the stuff that grows fastest as the input grows, because everything else is quickly eclipsed as nnn gets very large. If you know what an asymptote is, you might see why "big O analysis" is sometimes called "asymptotic analysis." 
  

Big O notation is like math except it's an awesome, not-boring kind of math where you get to wave your hands through the details and just focus on what's basically happening. 

If this seems abstract so far, that's because it is. Let's look at some examples. 

----

```
  def print_first_item(list_of_items):
    print list_of_items[0]
```

This function runs in O(1) time (or "constant time") relative to its input. The input list could be 1 item or 1,000 items, but this function would still just require one "step."

```
def print_all_items(list_of_items):
    for item in list_of_items:
        print item
```

This function runs in O(n) time (or "linear time"), where nnn is the number of items in the list. If the list has 10 items, we have to print 10 times. If it has 1,000 items, we have to print 1,000 times.

```
def print_all_possible_ordered_pairs(list_of_items):
    for first_item in list_of_items:
        for second_item in list_of_items:
            print first_item, second_item
```

Here we're nesting two loops. If our list has nnn items, our outer loop runs nnn times and our inner loop runs nnn times for each iteration of the outer loop, giving us n^2 total prints. Thus this function runs in O(n^2) time (or "quadratic time"). If the list has 10 items, we have to print 100 times. If it has 1,000 items, we have to print 1,000,000 times. 

##N could be the actual input, or the size of the input 

Both of these functions have O(n) runtime, even though one takes an integer as its input and the other takes a list: 

```
def say_hi_n_times(n):
    for time in range(n):
        print "hi"

def print_all_items_in_list(the_list):
    for item in the_list:
        print item
```

o sometimes nnn is an actual number that's an input to our function, and other times nnn is the number of items in an input list (or an input map, or an input object, etc.). 


##Drop the constants 

This is why big O notation rules. When you're calculating the big O complexity of something, you just throw out the constants. So like: 

```
def print_all_items_twice(the_list):
    for item in the_list:
        print item
        
    for item in the_list:
        print item
```
This is O(2n), which we just call O(n). 

```
  def print_first_item_then_first_half_then_say_hi_100_times(the_list):
    print the_list[0]

    middle_index = len(the_list) / 2
    index = 0

    while index < middle_index:
        print the_list[index]
        index += 1

    for time in range(100):
        print "hi"
```
This is O(1+n/2+100), which we just call O(n). 

Why can we get away with this? Remember, for big O notation we're looking at what happens as nnn gets arbitrarily large. As n gets really big, adding 100 or dividing by 2 has a decreasingly significant effect. 

##Drop the less significant terms 

```
def print_all_numbers_then_all_pair_sums(list_of_numbers):

    print "these are the numbers:"
    for number in list_of_numbers:
        print number

    print "and these are their sums:"
    for first_number in list_of_numbers:
        for second_number in list_of_numbers:
            print first_number + second_number
```

Here our runtime is O(n + n^2), which we just call O(n^2). Even if it was O(n^2/2 + 100n), it would still be O(n^2). 

Similarly: 

    O(n^3+50n^2+10000) is O(n^3)O
    O((n+30)∗(n+5)) is O(n^2)

Again, we can get away with this because the less significant terms quickly become, well, less significant as n gets big. 

##We're usually talking about the "worst case" 

Often this "worst case" stipulation is implied. But sometimes you can impress your interviewer by saying it explicitly. 

Sometimes the worst case runtime is significantly worse than the best case runtime: 

```
  def contains(haystack, needle):

    # does the haystack contain the needle?
    for item in haystack:
        if item == needle:
            return True

    return False
```
 Here we might have 100 items in our haystack, but the first item might be the needle, in which case we would return in just 1 iteration of our loop.

In general we'd say this is O(n) runtime and the "worst case" part would be implied. But to be more specific we could say this is worst case O(n) and best case O(1) runtime. For some algorithms we can also make rigorous statements about the "average case" runtime. 
