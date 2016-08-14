Stored Procedures in the Entity Framework
---

###Returning an Entity Collection with Code Second

Create a new public method called GetCustomers in the DbContext subclass that takes two
string parameters and returns a collection of <Type> objects

```
public ICollection<Customer> GetCustomers(string company, string contactTitle)
{
    return Database.SqlQuery<Customer>( "EXEC Chapter10.GetCustomers @Company,
         @ContactTitle"
          , new SqlParameter("Company", company)
          , new SqlParameter("ContactTitle", contactTitle))
      .ToList();
}
```

---

###Returning Output Parameters

```
var totalRentals = new ObjectParameter("TotalRentals", typeof(int));
var totalPayments = new ObjectParameter("TotalPayments", typeof(decimal));
var vehicles = context.GetVehiclesWithRentals(DateTime.Parse(reportDate),totalRentals, totalPayments);
```

---

###Returning a Scalar Value Result Set

```
var forYesterday = context.GetWithdrawals(17, yesterday).FirstOrDefault();
```

###Returning a Complex Type from a Stored Procedure

Right-click the design surface, and select Add ➤ Function Import. Select the
GetEmployeeAddresses stored procedure from the Stored Procedure Name drop-down.
In the Function Import Name text box, enter GetEmployeeAddresses. This will be the
name used for the method in the model. Select the Complex Return Type, and select
EmployeeAddress in the drop-down. Click OK.

---

###Defining a Custom Function in the Storage Model

Right-click the .edmx file, and select Open With ➤ XML (Text) Editor. This will open the
.edmx file in the XML editor.

Add the code element. This defines the custom function.

```
<Function Name="MembersWithTheMostMessages" IsComposable="false">
  <CommandText>
    select m.*
    from chapter10.member m
    join
    (
    select msg.MemberId, count(msg.MessageId) as MessageCount
    from chapter10.message msg where datesent = @datesent
    group by msg.MemberId
    ) temp on m.MemberId = temp.MemberId
    order by temp.MessageCount desc
  </CommandText>
  <Parameter Name="datesent" Type="datetime" />
</Function>
```

Open the .edmx file in the Designer. Right-click the design surface, and select Add ➤ Function
Import. In the dialog box, select the MembersWithTheMostMessages in the Stored Procedure
Name drop-down. Enter MembersWithTheMostMessages in the Function Import Name text
box. Finally, select Entities as the return type and choose Member as the entity type. Click OK.

---

###Populating Entities in a Table per Type Inheritance Model

You want to use a stored procedure to populate entities in a Table per Type inheritance model.

===

The GetAllMedia Stored Procedure That Returns a Rowset with a Discriminator Column

```
create procedure [Chapter10].[GetAllMedia]
as
begin
select m.MediaId,c.Title,m.PublicationDate, null PlayTime,'Magazine' MediaType
from chapter10.Media c join chapter10.Magazine m on c.MediaId = m.MediaId
union
select d.MediaId,c.Title,null,d.PlayTime,'DVD'
from chapter10.Media c join chapter10.DVD d on c.MediaId = d.MediaId
end
```

Right-click the design surface, and select Update Model from Database. Select the
GetAllMedia stored procedure. Click Finish to add the stored procedure to the model.

Right-click the design surface, and select Add ➤ Function Import. In the dialog box, select
the GetAllMedia stored procedure. Enter GetAllMedia in the Function Import Name text
box. Select Entities as the type of collection and Media as the type of entity returned. Click
OK. This will create the skeleton <FunctionImportMapping>.

Right-click the .edmx file, and select Open With ➤ XML Editor. Edit the
<FunctionImportMapping> tag in the mapping section of the .edmx file to match the
code in Listing 10-16. This maps the rows returned by the stored procedure either to the
Magazine or to the DVD entity based on the MediaType column.

```
<FunctionImportMapping FunctionImportName="GetAllMedia" FunctionName="EF6RecipesModel.Store.GetAllMedia">
  <ResultMapping>
    <EntityTypeMapping TypeName="EF6RecipesModel.Magazine">
      <ScalarProperty ColumnName="PublicationDate" Name="PublicationDate"/>
      <Condition ColumnName="MediaType" Value="Magazine"/>
    </EntityTypeMapping>
    <EntityTypeMapping TypeName="EF6RecipesModel.DVD">
        <ScalarProperty ColumnName="PlayTime" Name="PlayTime"/>
        <Condition ColumnName="MediaType" Value="DVD"/>
    </EntityTypeMapping>
  </ResultMapping>
</FunctionImportMapping>
```

###Populating Entities in a Table per Hierarchy Inheritance Model

You want to use a stored procedure to populate entities in a Table per Hierarchy inheritance model.

===

Right-click the design surface, and select Add ➤ Function Import. In the dialog box, select
the GetAllPeople stored procedure. Enter GetAllPeople in the Function Import Name
text box. Select Entities as the type of collection and Person as the type of entity returned.
Click OK. This will create the skeleton <FunctionImportMapping> section.

Right-click the .edmx file, and select Open With ➤ XML Editor. Edit the
<FunctionImportMapping> tag in the mapping section of the .edmx file to match the
code in Listing 10-19. This maps the rows returned by the stored procedure either to the
Instructor or to Student entity based on the PersonType column.

```
<FunctionImportMapping FunctionImportName="GetAllPeople" FunctionName="EF6RecipesModel.Store.GetAllPeople">
  <ResultMapping>
    <EntityTypeMapping TypeName="EFRecipesModel.Student">
      <ScalarProperty Name="Degree" ColumnName="Degree" />
      <Condition ColumnName="PersonType" Value="Student"/>
    </EntityTypeMapping>
    <EntityTypeMapping TypeName="EF6RecipesModel.Instructor">
      <ScalarProperty Name="Salary" ColumnName="Salary"/>
      <Condition ColumnName="PersonType" Value="Instructor"/>
    </EntityTypeMapping>
  </ResultMapping>
</FunctionImportMapping>
```

---


