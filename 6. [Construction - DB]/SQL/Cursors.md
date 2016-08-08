Cursors
---

Cursor is a special programming construct that allows you to create a named working area and access its stored information. The main advantage of cursors is the ability to work with individual rows one-by-one rather than with the record set as a whole. For example, all DML statements work with record sets, so you could change "all or nothing". If your update statement is changing hundreds of thousands rows, just one single row could cause the whole statement to fail and roll back all the changes if it violates a column constraint, resulting in serious time losses. Fortunately, cursors are able to handle such situations working with each row individually. A logic that combines cursors, loops, and conditional statements could generate a warning, store the unsuccessfull row information in a special table, and continue processing. Also, cursors give you flexibility on commits and rollbacks (you can commit after each row, after ten rows, or after every five hundred rows), which sometimes can be very useful to save system memory space; you can employ conditional logic and perform calculations on certain values before they are used in your DML statements; using cursors, you are able to update multiple tables with the same values, and much more.

Different RDBMS vendors implement cursors in different ways. Both syntax and functionality vary, which makes it difficult to talk about some generic cursor. SQL99 standards require a cursor to be scrollable, that is, you should be able to move back and forth from one record in the record set to another, but until recently only a few RDBMS vendors (notably MS SQL Server) implemented such functionality. The main reason is that a scrollable cursor is a huge resource waste and not every system can afford it. It is a known fact that many MS SQL Server developers are explicitly warned against using cursors unless it is absolutely necessary, whereas for PL/SQL programmers cursor use is an integral part of their everyday work

---

###DECLARE

```
SO Syntax  
DECLARE cursor_name [ INSENSITIVE ] [ SCROLL ] CURSOR   
     FOR select_statement   
     [ FOR { READ ONLY | UPDATE [ OF column_name [ ,...n ] ] } ]  
[;]  
Transact-SQL Extended Syntax  
DECLARE cursor_name CURSOR [ LOCAL | GLOBAL ]   
     [ FORWARD_ONLY | SCROLL ]   
     [ STATIC | KEYSET | DYNAMIC | FAST_FORWARD ]   
     [ READ_ONLY | SCROLL_LOCKS | OPTIMISTIC ]   
     [ TYPE_WARNING ]   
     FOR select_statement   
     [ FOR UPDATE [ OF column_name [ ,...n ] ] ]  
[;]  
```

####INSENSITIVE

INSENSITIVE means that a temporary copy of data based on the <select_statement> is made, so the cursor fetches are not sensitive to any DML changes of underlying tables that may happen afterwards; the default is SENSITIVE, which means every subsequent fetch uses the actual data at this particular moment of time. 

---

####SCROLL

Specifies that all fetch options (FIRST, LAST, PRIOR, NEXT, RELATIVE, ABSOLUTE) are available. If SCROLL is not specified in an ISO DECLARE CURSOR, NEXT is the only fetch option supported. SCROLL cannot be specified if FAST_FORWARD is also specified.

---

####select_statement

Is a standard SELECT statement that defines the result set of the cursor. The keywords FOR BROWSE, and INTO are not allowed within select_statement of a cursor declaration

####READ ONLY

Prevents updates made through this cursor. The cursor cannot be referenced in a WHERE CURRENT OF clause in an UPDATE or DELETE statement. This option overrides the default capability of a cursor to be updated.

---

####Local

Specifies that the scope of the cursor is local to the batch, stored procedure, or trigger in which the cursor was created. The cursor name is only valid within this scope. The cursor can be referenced by local cursor variables in the batch, stored procedure, or trigger, or a stored procedure OUTPUT parameter. An OUTPUT parameter is used to pass the local cursor back to the calling batch, stored procedure, or trigger, which can assign the parameter to a cursor variable to reference the cursor after the stored procedure terminates. The cursor is implicitly deallocated when the batch, stored procedure, or trigger terminates, unless the cursor was passed back in an OUTPUT parameter. If it is passed back in an OUTPUT parameter, the cursor is deallocated when the last variable referencing it is deallocated or goes out of scope.

---

####GLOBAL

Specifies that the scope of the cursor is global to the connection. The cursor name can be referenced in any stored procedure or batch executed by the connection. The cursor is only implicitly deallocated at disconnect.

---

####OPEN statemenet

The OPEN statement executes the underlying query and identifies the result set consisting of all rows that meet the conditions specified on the cursor declaration.

---

####Fetch statement

FETCH retrieves the current row (for nonscrollable cursors) or a specific row (for scrollable cursors), parses the row, and puts the column values into predefined set of variables

---

####CLOSE statement

The CLOSE statement deallocates memory, releases locks, and makes the cursor's result set undefined.

---

