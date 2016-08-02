[Array sorting methods](https://www.cs.usfca.edu/~galles/visualization/ComparisonSort.html)
--

The ideal sorting algorithm would have the following properties:

-    Stable: Equal keys aren’t reordered.
-    Operates in place, requiring O(1) extra space.
-    Worst-case O(n·lg(n)) key comparisons.
-    Worst-case O(n) swaps.
-    Adaptive: Speeds up to O(n) when data is nearly sorted or when there are few unique keys.


###Insertion Sort

Insertion sort is a simple sorting algorithm that builds the final sorted array (or list) one item at a time. It is much less efficient on large lists than more advanced algorithms such as quicksort, heapsort, or merge sort. However, insertion sort provides several advantages:

  - Efficient for (quite) small data sets, much like other quadratic sorting algorithms
  - More efficient in practice than most other simple quadratic (i.e., O(n2)) algorithms such as selection sort or bubble sort
  
![dd](https://upload.wikimedia.org/wikipedia/commons/0/0f/Insertion-sort-example-300px.gif)

Properties:
  -  Stable
  -  O(1) extra space
  -  O(n^2) comparisons and swaps
  -  Adaptive: O(n) time when nearly sorted
  -  Very low overhead

###Selection Sort

In computer science, selection sort is a sorting algorithm, specifically an in-place comparison sort. It has O(n2) time complexity, making it inefficient on large lists, and generally performs worse than the similar insertion sort. Selection sort is noted for its simplicity, and it has performance advantages over more complicated algorithms in certain situations, particularly in which auxiliary memory is limited.

The algorithm divides the input list into two parts: the sublist of items already sorted, which is built up from left to right at the front (left) of the list, and the sublist of items remaining to be sorted that occupy the rest of the list. Initially, the sorted sublist is empty and the unsorted sublist is the entire input list. The algorithm proceeds by finding the smallest (or largest, depending on sorting order) element in the unsorted sublist, exchanging (swapping) it with the leftmost unsorted element (putting it in sorted order), and moving the sublist boundaries one element to the right.
~[DD](https://upload.wikimedia.org/wikipedia/commons/9/94/Selection-Sort-Animation.gif)

Properties:

  -  Not stable
  -  O(1) extra space
  -  Θ(n^2) comparisons
  -  Θ(n) swaps
  -  Not adaptive

###Bubble Sort

Bubble sort, sometimes referred to as sinking sort, is a simple sorting algorithm that repeatedly steps through the list to be sorted, compares each pair of adjacent items and swaps them if they are in the wrong order. The pass through the list is repeated until no swaps are needed, which indicates that the list is sorted. The algorithm, which is a comparison sort, is named for the way smaller elements "bubble" to the top of the list. Although the algorithm is simple, it is too slow and impractical for most problems even when compared to insertion sort.[1] It can be practical if the input is usually in sorted order but may occasionally have some out-of-order elements nearly in position.

~[DD](https://upload.wikimedia.org/wikipedia/commons/c/c8/Bubble-sort-example-300px.gif)

Properties:

  -  Stable
  -  O(1) extra space
  -  O(n2) comparisons and swaps
  -  Adaptive :  O(n) when nearly sorted

###Shell Sort

Shellsort, also known as Shell sort or Shell's method, is an in-place comparison sort. It can be seen as either a generalization of sorting by exchange (bubble sort) or sorting by insertion (insertion sort).[3] The method starts by sorting pairs of elements far apart from each other, then progressively reducing the gap between elements to be compared. Starting with far apart elements, it can move some out-of-place elements into position faster than a simple nearest neighbor exchange. Donald Shell published the first version of this sort in 1959.[4][5] The running time of Shellsort is heavily dependent on the gap sequence it uses. For many practical variants, determining their time complexity remains an open problem.

Because of its low overhead, relatively simple implementation, adaptive properties, and sub-quadratic time complexity, shell sort may be a viable alternative to the O(n·lg(n)) sorting algorithms for some applications when the data to be sorted is not very large.

[Animation is here](https://www.cs.usfca.edu/~galles/visualization/ComparisonSort.html)

Properties:

  -  Not stable
  -  O(1) extra space
  -  O(n3/2) time as shown (see below)
  -  Adaptive: O(n·lg(n)) time when nearly sorted

###Merge Sort

In computer science, merge sort (also commonly spelled mergesort) is an efficient, general-purpose, comparison-based sorting algorithm. Most implementations produce a stable sort, which means that the implementation preserves the input order of equal elements in the sorted output. Mergesort is a divide and conquer algorithm that was invented by John von Neumann in 1945.[1] A detailed description and analysis of bottom-up mergesort appeared in a report by Goldstine and Neumann as early as 1948.[2]

Conceptually, a merge sort works as follows:

  - Divide the unsorted list into n sublists, each containing 1 element (a list of 1 element is considered sorted).
  - Repeatedly merge sublists to produce new sorted sublists until there is only 1 sublist remaining. This will be the sorted list.
  
  Merge sort is very predictable. It makes between 0.5lg(n) and lg(n) comparisons per element, and between lg(n) and 1.5lg(n) swaps per element. The minima are achieved for already sorted data; the maxima are achieved, on average, for random data. If using Θ(n) extra space is of no concern, then merge sort is an excellent choice: It is simple to implement, and it is the only stable O(n·lg(n)) sorting algorithm. Note that when sorting linked lists, merge sort requires only Θ(lg(n)) extra space (for recursion).
  
  Merge sort is the algorithm of choice for a variety of situations: when stability is required, when sorting linked lists, and when random access is much more expensive than sequential access (for example, external sorting on tape).
  
  There do exist linear time in-place merge algorithms for the last step of the algorithm, but they are both expensive and complex. The complexity is justified for applications such as external sorting when Θ(n) extra space is not available.
  
  Properties:
    - Stable
    - Θ(n) extra space for arrays (as shown)
    - Θ(lg(n)) extra space for linked lists
    - Θ(n·lg(n)) time
    - Not adaptive
    - Does not require random access to data

###Heap Sort

Heap sort is simple to implement, performs an O(n·lg(n)) in-place sort, but is not stable.

In computer science, heapsort is a comparison-based sorting algorithm. Heapsort can be thought of as an improved selection sort: like that algorithm, it divides its input into a sorted and an unsorted region, and it iteratively shrinks the unsorted region by extracting the largest element and moving that to the sorted region. The improvement consists of the use of a heap data structure rather than a linear-time search to find the maximum

[Animation is here](https://www.cs.usfca.edu/~galles/visualization/HeapSort.html)

Properties:
  - Not stable
  - O(1) extra space (see discussion)
  - O(n·lg(n)) time
  - Not really adaptive
  
###Quick Sort

Quicksort (sometimes called partition-exchange sort) is an efficient sorting algorithm, serving as a systematic method for placing the elements of an array in order. Developed by Tony Hoare in 1959,[1] with his work published in 1961,[2] it is still a commonly used algorithm for sorting. When implemented well, it can be about two or three times faster than its main competitors, merge sort and heapsort

Quicksort is a comparison sort, meaning that it can sort items of any type for which a "less-than" relation (formally, a total order) is defined. In efficient implementations it is not a stable sort, meaning that the relative order of equal sort items is not preserved. Quicksort can operate in-place on an array, requiring small additional amounts of memory to perform the sorting.

Algorithm : 

Quicksort is a divide and conquer algorithm. Quicksort first divides a large array into two smaller sub-arrays: the low elements and the high elements. Quicksort can then recursively sort the sub-arrays.

The steps are: 
  - Pick an element, called a pivot, from the array.
  - Partitioning: reorder the array so that all elements with values less than the pivot come before the pivot, while all elements with values greater than the pivot come after it (equal values can go either way). After this partitioning, the pivot is in its final position. This is called the partition operation.
  - Recursively apply the above steps to the sub-array of elements with smaller values and separately to the sub-array of elements with greater values.

Properties:

  -  Not stable
  -  O(lg(n)) extra space (see discussion)
  -  O(n2) time, but typically O(n·lg(n)) time
  -  Not adaptive

[dd](https://upload.wikimedia.org/wikipedia/commons/6/6a/Sorting_quicksort_anim.gif)

