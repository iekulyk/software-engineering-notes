Binary search 
---

In computer science, binary search, also known as half-interval search[1] or logarithmic search,[2] is a search algorithm that finds the position of a target value within a sorted array.[3][4] It compares the target value to the middle element of the array; if they are unequal, the half in which the target cannot lie is eliminated and the search continues on the remaining half until it is successful.

Binary search runs in at worst logarithmic time, making O(log ⁡ n } comparisons, where n is the number of elements in the array and lo} is the binary logarithm; and using only constant ( O ( 1 ) ) space.

Although specialized data structures designed for fast searching—such as hash tables—can be searched more efficiently, binary search applies to a wider range of search problems.

[dd](https://upload.wikimedia.org/wikipedia/commons/f/f7/Binary_search_into_array.png)

Characteristics

Every iteration eliminates half of the remaining possibilities. This makes binary searches very efficient - even for large collections. Our implementation relies on recursion, though it is equally as common to see an iterative approach.

Binary search requires a sorted collection. This means the collection must either be sorted before searching, or inserts/updates must be smart. Also, binary searching can only be applied to a collection that allows random access (indexing).

In The Real World

Binary searching is frequently used thanks to its performance characteristics over large collections. The only time binary searching doesn't make sense is when the collection is being frequently updated (relative to searches), since re-sorting will be required.

Hash tables can often provide better (though somewhat unreliable) performance. Typically, it's relatively clear when data belongs in a hash table (for frequent lookups) versus when a search is needed.

