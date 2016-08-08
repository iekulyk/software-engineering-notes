SQL data types
(up to date version)[https://msdn.microsoft.com/en-us/library/ms187752.aspx]
---

###Character strings

sequence. A string of zero length is called an empty string. It can be an equivalent to NULL (special concept introduced at the end of this chapter) or not, depending on implementation. SQL99 specifically differentiates between empty strings and nulls.

All strings in SQL can be of fixed length or varying length. The difference is quite simple, but sometimes not very easy to understand for people with no technical background, so let us explain it in some greater detail.

---

###MS SQL SERVER 2000 char types

  - CHAR
  - VARCHAR
  - TEXT
  - NCHAR
  - NVARCHAR
  - NTEXT
  
  CHAR and VARCHAR are used for fixed-length and variable-length character data correspondingly. The maximum length is 8,000 characters. 
  
  TEXT is similar to VARCHAR, but can hold much larger values. Its maximum length is two gigabytes or 231 – 1 (2,147,483,647) characters
  
  NCHAR and NVARCHAR, and NTEXT are Unicode equivalents to CHAR, VARCHAR, and TEXT. NCHAR and NVARCHAR can hold up to 4,000 characters; NTEXT is much larger — one gigabyte or 230 – 1 (1,073,741,823) characters
  
---

###Binary strings

  - BINARY[(n)] 
  - VARBINARY[(n)] 
  - IMAGE
  
BINARY is a fixed-length data type to store binary data. The size can be specified from 1 to 8,000; the actual storage volume is size + 4 bytes

VARBINARY can hold variable-length binary data. The size is from 1 through 8,000. Storage size is the actual length of the data entered + 4 bytes. The data entered can be 0 bytes in length.

IMAGE is a variable-length binary data type that can hold from 0 through 2,147,483,647 bytes (two gigabytes) of data.


---

###Exact numbers

  - INT
  - BIGINT
  - SMALLINT
  - TINYINT
  - NUMERIC[(p[,s])]
  - DEC[p,[,s]]
  - MONEY
  - SMALLMONEY
  - BIT
  
INT (or INTEGER) is to store whole numbers from negative 231 to positive 231 – 1. It occupies four bytes.

BIGINT is to store large integers from negative 263 through positive 263 – 1. The storage size is eight bytes. BIGINT is intended for special cases where INTEGER range is"not sufficient.

SMALLINT is for smaller integers ranging from negative 215 to positive 215 – 1

TINYINT is convenient for small nonnegative integers from 0 through 255. It only takes one byte to store such number.

DECIMAL is compliant with SQL99 standards. NUMERIC is a synonym to DECIMAL. Valid values are in the range from negative 1038 +1 through positive 1038 – 1.

MONEY is a special eight-byte MS SQL Server data type to represent monetary and currency values. The range is from negative 922,337,203,685,477.5808 to positive 922,337,203,685,477.5807 with accuracy to a ten-thousandth

SMALLMONEY is another monetary data type designated for smaller amounts. It is four bytes long and can store values from negative 214,748.3648 to positive 214,748.3647 with the same accuracy as MONEY.

---

###Approximate numbers

  - FLOAT[(p)] 
  - REAL


MS SQL Server has one data type for floating-point numbers — FLOAT. It also has a number of synonyms for SQL99 compliance 
FLOAT data type can hold the same range of real numbers as DOUBLE in DB2. The actual storage size can be either four or eight bytes.

---

###Introduction to complex data types

  - DATE
  - TIME
  - DATETIME 
  - DATETIME2
  - SMALLDATETIME
  - DATETIMEOFFSET
  
  
####DATE

  - Range : 0001-01-01 through 9999-12-31 (1582-10-15 through 9999-12-31 for Informatica)
  - Default : 1900-01-01

####TIME

  - Range : 00:00:00.0000000 through 23:59:59.9999999 (00:00:00.000 through 23:59:59.999 for Informatica)
  - Default : 00:00:00
  
####DATETIME

  - Range : January 1, 1753, through December 31, 9999 ; 00:00:00 through 23:59:59.997
  - Default : 1900-01-01 00:00:00
  
####DATETIME2

  - Range : 0001-01-01 through 9999-12-31 ; 00:00:00 through 23:59:59.997
  - Default : 1900-01-01 00:00:00

####SMALLDATETIME

  - Range : 0001-01-01 through 9999-12-31 ; 00:00:00 through 23:59:59.997
  - Default : 1900-01-01 00:00:00

####DATETIMEOFFSET

Defines a date that is combined with a time of a day that has time zone awareness and is based on a 24-hour clock.

  - Range : 1900-01-01 through 2079-06-06 - January 1, 1900, through June 6, 2079 ; 00:00:00 through 23:59:59.9999999
  - Default : 1900-01-01 00:00:00

---

###Object and User-Defined Data Types

You can access user-defined type (UDT) functionality in Microsoft SQL Server from the Transact-SQL language by using regular query syntax. UDTs can be used in the definition of database objects, as variables in Transact-SQL batches, in functions and stored procedures, and as arguments in functions and stored procedures.

  - In Object Explorer, expand Databases, expand a database, expand Programmability, expand Types, right-click User-Defined Data Types, and then click New User-Defined Data Type.
  
```
CREATE TYPE ssn  
FROM varchar(11) NOT NULL ;  
```
