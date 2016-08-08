Stored procedures, user-defined functions, triggers
---

stored procedures are linear or sequential programs. The syntax varies from implementation to implementation, but some common features can be emphasized. Stored procedures can accept parameters and allow local variable declarations; they are structured and allow the use of submodules; also, they allow repeated and conditional statement execution

---

````
CREATE PROC[EDURE] <procedure_name>    [@<parameter_name> <datatype> [ = <default>] 
[OUTPUT] ] ,...
AS
   <procedure_body>
```

```
CREATE PROCEDURE sp_productadd
/* This procedure adds new product to PRODUCT table */
  @v_prodid              INTEGER,
  @v_prodprice           MONEY,
  @v_prodnum             VARCHAR (10),
  @v_proddesc            VARCHAR (44),
  @v_prodstatus          CHAR,
  @v_prodbrand           VARCHAR (20),
  @v_prodpltwid          DECIMAL(5, 2),
  @v_prodpltlen          DECIMAL(5, 2),
  @v_prodnetwgt          DECIMAL(10, 3),
  @v_prodshipwgt         DECIMAL(10, 3)
AS
  -- Local variable declaration and preassignment
  declare @v_prodcount INTEGER
  select @v_prodcount = 0
  declare @v_prodid_existing INTEGER
BEGIN
 -- Begin transaction
 BEGIN TRANSACTION
 -- Check if product with this name already exists
 SELECT @v_prodcount=COUNT(*)
 FROM   product
 WHERE  UPPER(prod_description_s) = UPPER(@v_proddesc)
   
 -- Check for errors
 IF @@error <> 0 GOTO E_General_Error
   
 -- Product does not exist
 IF @v_prodcount = 0
  -- Insert row into PRODUCT based on arguments passed
  INSERT INTO product
  VALUES
  (
          @v_prodid,
          @v_prodprice,
          @v_prodnum,
          @v_proddesc,
          @v_prodstatus,
          @v_prodbrand,
          @v_prodpltwid,
          @v_prodpltlen,
          @v_prodnetwgt,
          @v_prodshipwgt
  )
   
 -- Check for errors
 IF @@error <> 0 GOTO E_General_Error
   
 -- Product with this name already exists
 ELSE IF @v_prodcount = 1
  -- Find the product's primary key number
  SELECT @v_prodid_existing = PROD_ID_N
  FROM   product
  WHERE  UPPER(prod_description_s) = UPPER(@v_proddesc)
   
  -- Check for errors
  IF @@error <> 0 GOTO E_General_Error
 
  -- Update the existing product with
  -- values passed as arguments
  UPDATE product
  SET    prod_price_n = @v_prodprice,
         prod_description_s = @v_proddesc,
         prod_status_s = @v_prodstatus,
         prod_brand_s = @v_prodbrand,
         prod_pltwid_n = @v_prodpltwid,
         prod_pltlen_n = @v_prodpltlen,
         prod_netwght_n = @v_prodnetwgt,
         prod_shipweight_n = @v_prodshipwgt
  WHERE  prod_id_n = @v_prodid_existing
   
  -- Check for errors
  IF @@error <> 0 GOTO E_General_Error
   
 -- No errors; perform COMMIT and exit
 COMMIT TRANSACTION
 RETURN
   
 -- If an error occurs, rollback and exit
 E_General_Error:
    PRINT 'Error'
    ROLLBACK TRANSACTION
    RETURN
END
```

###Removing a stored procedure

```
DROP PROCEDURE [qualifier.]<procedure_name>
```

--------------------------

###User-Defined Functions

User-defined functions combine the advantages of stored procedures with the capabilities of SQL predefined functions. They can accept parameters, perform specific calculations based on data retrieved by one or more SELECT statement, and return results directly to the calling SQL statement

---

####CREATE FUNCTION syntax

```
CREATE FUNCTION <function_name>  ([@<parameter_name> <datatype> [ = <default>]],...)
RETURNS <datatype>
[AS]
BEGIN
   <function_body>
   RETURN <value>
END
```

```
CREATE FUNCTION uf_ordertax
(
   @v_tax    NUMERIC(12,4),
   @v_ordnum VARCHAR(30)
)
RETURNS NUMERIC(12,4)
AS
BEGIN
    -- Declare local variables
    declare @v_result NUMERIC(12,4)
    declare @v_ordamt NUMERIC(12,4)
    -- Assign variable @v_ordamt using SELECT statement
    SELECT @v_ordamt = total_price
    FROM v_customer_totals
    WHERE ORDER_NUMBER = @v_ordnum;
    -- Variable @v_result is @v_ordamt multiplied by tax
    SET @v_result = @v_ordamt * @v_tax
    -- Return result
    RETURN @v_result
END
```

### STORED PROCEDURE VS FUNCTIONS

![ss](http://i.stack.imgur.com/4o6XG.png)

---

###Triggers

A trigger is a special type of stored procedure that fires off automatically whenever a special event in the database occurs. For example, a trigger can be invoked when a row is inserted into a specified table or when certain table columns are being updated.

---

####CREATE TRIGGER syntax

```
CREATE TRIGGER <trigger_name>
ON <table_or_view>
{ FOR | AFTER | INSTEAD OF }
{INSERT | UPDATE | DELETE} 
AS 
[IF UPDATE ( <column_name> )
           [AND | OR UPDATE ( <column_name> ) ],...]
<trigger_body>
```

```
CREATE TRIGGER trbu_product ON product
FOR UPDATE
AS
IF UPDATE (prod_price_n)
    INSERT INTO product_audit
    SELECT  i.prod_id_n,
            d.prod_price_n,
            i.prod_price_n,
            USER,
            GETDATE()
     FROM   inserted i
       JOIN
            deleted d
       ON i.prod_id_n = d.prod_id_n
```

Server provides two special virtual tables, DELETED (stores copies of the affected rows during DELETE and UPDATE operations) and INSERTED (holds copies of the affected rows during INSERT and UPDATE). We can join the two tables as shown above to get the values that have to be inserted into PRODUCT_AUDIT. 
