Executing asynchronous queries
---

ADO.NET supports asynchronous (threaded) sql queries.  In some situations and SQL query will take a long time to complete and asynchronous queries allow you to execute other code while you wait for the query to complete.  In this example we’re manually telling the SQL server to wait 10 seconds and executing a console.writeline() call while the query is being executed.

An Asynchronous query is called by first including a “using System.Threading;” reference at the top of your code.  Then you create an IAsyncResult object with the SqlCommand.BeginExecuteReader() function.  You execute your other code, then Create your SqlDataReader object using the SqlCommand.EndExecuteReader(IAsyncResult result) function, passing your IAsyncResult object into the EndExecuteReader function.  Example:

```
//Using Visual Studio Express 2005, Microsoft SQL Express 2005 and Northwind Database
//ensure there's a reference to System.Data.dll assembly
 
using System;
using System.Collections.Generic;
using System.Text;
 
//used for asynchronous querying
using System.Threading;
 
//for database access/manipulation
using System.Data;
using System.Data.SqlClient;
 
namespace chapter01SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            string strSQL;
 
            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = @".\SQLEXPRESS";
            connectionBuilder.InitialCatalog = "Northwind";
 
            //enable asynchronous (threaded) query processing
            connectionBuilder.AsynchronousProcessing = true;
            connectionBuilder.IntegratedSecurity = true;
            strSQL = "WAITFOR DELAY '00:00:10'; SELECT * FROM Customers";
 
            //will close and dispose object when complete. ensures proper garbage collection
            using (SqlConnection cn = new SqlConnection(connectionBuilder.ConnectionString))
            {
                cn.Open();
 
                SqlCommand cmd = new SqlCommand(strSQL, cn);
 
                //create Asynchronous handle and begin the reader
                IAsyncResult iar = cmd.BeginExecuteReader();
 
                //perform other operations
                Console.WriteLine("this line is written while we're waiting for the reader");
 
                //pass the handle to the EndExecuteReader(...) function at the end of our asynchronous operations
                SqlDataReader rdr = cmd.EndExecuteReader(iar);
                while (rdr.Read())
                    Console.WriteLine(rdr["CustomerID"]);
                rdr.Close();
                cn.Close();
 
            }
            pressEnterToExit();
        }
 
        /// <summary>
        /// Prompts user to press Enter before exiting
        /// </summary>
        private static void pressEnterToExit()
        {
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
 
        /// <summary>
        /// Prompts user before exiting
        /// </summary>
        ///
        <param name="message">message prompt for user</param>
        private static void pressEnterToExit(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
```
