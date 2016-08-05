Hash Table
---

A hash table, put simply, is an abstraction of an array that allows any value to be used as an index. While an array requires that indices be integers, a hash table can use a floating-point value, a string, another array, or even a structure as the index. This index is called the key, and the contents of the array element at that index is called the value. So a hash table is a data structure that stores key/value pairs and can be quickly searched by the key. Because insertion and removal are operations dependent on the speed of the search, they tend to be fast as well. 

To achieve this magic, a hash table uses a helper function that converts any object into an integral index suitable for subscripting the array. For example, to index an array with strings representing the numbers 0 through 9, a hash function might look like this: 

```
unsigned hash(const char key)
{
    return key - '0';
}
```
The first character is expected to always be '0', '1', '2', '3', '4', '5', '6', '7', '8', or '9', and the trick of subtracting '0' from one of those characters evaluates to the integer value that the character represents. This works because you can subtract the lowest value in a contiguous range from another value in that range and find the zero-based distance between them. So ('2'-'0') results in 2, ('0'-'0') results in 0, and ('9'-'0') results in 9. 

For those of you who aren't familiar with this trick, it might help to work with the actual values rather than character constants. Let's take an arbitrary range of [12, 16). You want 12 to represent 0, 13 to represent 1, 14 to represent 2, and so on up to 16 which should represent 4. To do this you can take any value in the range and subtract the lowest value, 12, from it. Try it with a calculator. 

The hash function shown above can then be used to index a suitable array. For illustrative purposes, I'll include a complete test program for you to play with. Notice how problems occur when two entries are hashed to the same index. This is called a collision, and properly handling collisions is where most of the effort in implementing hash tables comes in. 

This will cause collisions because there's now way to fit twenty possible values into only ten indices. For example, 0 and 10 will both be hashed into an index of 0, 5 and 15 will both be hashed into an index of 5. There are some situations where a collision can be resolved simply by replacing the item already present in the table with the new item, such as in a cache implementation, but most of the time we want both items to remain in the table, and that is where more sophisticated measures are needed. 

###Table size and range finding

The hash functions introduced in The Art of Hashing were designed to return a value in the full unsigned range of an integer. For a 32-bit integer, this means that the hash functions will return a value in the range [0..4,294,967,296). Because it is extremely likely that your table will be smaller than this, it is possible that the hash value may exceed the boundaries of the array. 

 The solution to this problem is to force the range down so that it fits the table size. A table size should not be chosen randomly because most of the collision resolution methods require that certain conditions be met for the table size or they will not work correctly. Most of the time, this required size is either a power of two, or a prime number.

A table size of a power of two may be desirable on some implementations where bitwise operations offer performance benefits. The way to force a value into the range of a power of two can be performed quickly with a masking operation. For example, to force the range of any value into eight bits, you simply use the bitwise AND operation on a mask of 0xff (hexadecimal for 255): 
```
table[hash(key) & 0xff]
```

This is a fast operation, but it only works with powers of two. If the table size is not a power of two, the remainder of division can be used to force the value into a desired range with the remainder operator. Note that this is slightly different than masking because while the mask was the upper value that you will allow, the divisor must be one larger than the upper value to include it in the range. This operation is also slower in theory than masking (in practice, most compilers will optimize both into the same machine code): 

###Collision resolution

In a hash table, collisions, where two keys map to the same index, are resolved by finding another place to put the new key without affecting the old key, and still allowing for quick lookup of the new key. Probably the most obvious way to do this is to create a second table for collisions and place the key at the first empty location. This method is called resolution by overflow, where an “overflow” table is used to hold collisions. 

Rather than use a cursor to mark the end of the overflow table, we can also search from the beginning each time. This makes deletions simpler, but also complicates updating the overflow table.

However, this solution is brittle at best because insertions will be slow if there is a collision with an overflow table that is large and mostly full. Searching will be slow for this same reason. If you allow deletions then what happens when searching for an item that overflowed, but the key in the hash table that caused the collision was deleted? In such a case you would have to search the overflow table even if a search in the hash table showed that that index was empty. So the most obvious method has subtle problems that would be awkward to fix. Fortunately, there are other ways to resolve collisions that are much easier to work with. 

###Separate chaining

An experienced programmer will probably consider using an array of linked lists as the hash table. When there is a collision, the colliding key can be pushed onto the list, thus preserving both values without a lot of awkwardness. When searching for a key, the index is hashed and then the list is searched, and deletion is as simple as deletion from a linked list. In theory this sounds like a good way to resolve collisions, and in practice, it is. The method is called separate chaining, where each linked list is called a chain. These chains are “separate” because they are not technically a part of the hash table, simply additions that are tacked on as necessary. 

The immediate question is how should the list be structured? Since the performance of a search depends on the performance of searching a linked list, it makes sense in theory to keep the lists ordered. That way for a minor cost during insertion, the average case for both a successful and unsuccessful search is the same, on average only half the list would be searched. If the lists are unordered, an unsuccessful search must look through the entire chain. 

 This sounds good in theory, but in practice it is more work than necessary because with a good hash function, the chains are likely to be short enough that the difference between an ordered list and an unordered list is negligable. Even more importantly, if new keys are inserted at the front of the list, aside from very fast insertion performance, the chain can then be used as a stack, which has desirable properties for frequency of access. In practice, front insertion is the easiest to implement, and has the best performance with a hash function that minimizes collisions.

Another option that has been toyed with is using a binary search tree instead of a linked list for the chains. This is, much like the ordered list, more trouble than it is worth, but you are welcome to experiment. Another variation is a list with a header. My jsw_hlib uses this variation to ease gathering the chain length measurement. 

A separately chained hash table is simply an array of linked lists. Once you index the array, it is just a matter of searching, inserting, or removing in a linked list. Assuming an unordered chain, the search is almost trivial...almost: 

###Open addressing

While separate chaining is tempting, there are ways to resolve collisions without resorting to any dynamically growing alternate data structure. These solutions resolve collisions by placing the colliding key into another index in a deterministic way. This process is then repeated for searches, so that any key can be found even if the actual index doesn't match the hashed index any longer. These methods are collectively known as “open addressing”. 

###Linear probing

By far the simplest open addressing strategy is the linear probe. When a collision is detected, the index is incremented (wrapping around to the beginning if it reaches the end) until an empty bucket is found. Typically, the increment is by 1, but other step sizes can be used as well, though more care should be taken because only a step size of 1 guarantees that all buckets will be encountered without extra precautions. 

 By far the simplest open addressing strategy is the linear probe. When a collision is detected, the index is incremented (wrapping around to the beginning if it reaches the end) until an empty bucket is found. Typically, the increment is by 1, but other step sizes can be used as well, though more care should be taken because only a step size of 1 guarantees that all buckets will be encountered without extra precautions.

In linear probing, keys tend to cluster. That is, several parts of the table may become full quickly while others remain completely empty. Because linear probing expects a large number of empty buckets uniformly interspersed among the used buckets, clusters will cause a large number of buckets to be walked through before an empty bucket is found. This slows down search significantly, and in turn slows down insertion and removal as well. As the load factor increases, so does the effect of clustering. The following is an example of primary clustering: 

###Quadratic probing

In an attempt to alleviate the problem of primary clustering, a non-constant step size can be used. In general, it has been found that a quadratically growing step size works well. Simply start with a step size of 1 and quadratically increase the step size until the desired index is found. This strategy is called quadratic probing, and the search algorithm is only slightly more complicated than linear probing, and insertion and deletion are equally simple changes. 

##Double hashing

Double hashing uses two independent hash functions. The first hash function is used as usual, and the second hash function is used to create a step size. Because the key itself determines the step size, primary clustering is avoided. The algorithm is simple, but two rules must be adhered to for double hashing to work correctly: First, the second hash cannot ever return 0 or there will be an infinite loop. Second, much like with linear probing, the table size must either be prime, or a power of two with the second hash returning an odd number. Beyond that, the implementation is similar to the other open addressing methods discussed so far

###Coalesced chaining

Coalesced chaining is a lesser known strategy that forms a hybrid of separate chaining and open addressing. In a separately chained hash table, items that hash to the same index are placed on a list at that index. This can result in a great deal of wasted memory because the table itself must be large enough to maintain a load factor that performs well (typically twice the expected number of items), and extra memory must be used for all but the first item in a chain (unless list headers are used, in which case extra memory must be used for all items in a chain). 

This strategy is effective and very easy to implement. However, sometimes the extra memory use might be prohibitive, and the most common alternative using open addressing has uncomfortable disadvantages when it comes to primary clustering. Coalesced hashing uses a similar technique as separate chaining, but instead of allocating new nodes for the linked list, buckets in the table are used, just like open addressing. The first empty bucket in the table is considered a collision bucket. When a collision occurs anywhere in the table, the key is placed in the collision bucket and a link is made between the colliding index and the collision bucket. Then the next empty bucket is searched for to give the next collision bucket. 



