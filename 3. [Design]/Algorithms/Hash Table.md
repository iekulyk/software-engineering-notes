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

