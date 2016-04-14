using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ThePeopleSearchApplication.Models;
using System.Runtime.CompilerServices;
using System.Data;
using System.Data.Entity.Validation;

namespace ThePeopleSearchApplication.ViewModels
{
    /// <summary>
    /// Person View model will have a database object that it can execute queries on
    /// through those queries, a list of person variables will be added to the people list.
    /// </summary>
    public class PersonsViewModel 
    {

        //data table that will hold values from an SqlDataAdapter using.fill
        //reference:  http://www.codeproject.com/Tips/362436/Data-binding-in-WPF-DataGrid-control
        private DataTable _dt = new DataTable("People");

        public DataTable dt
        {
            get { return _dt; }
            set { _dt = value; }
        }


        //constructor
        public PersonsViewModel()
        {
            using (var db = new DB_Connector())
            {
                try
                {
                    // Create and save a new Blog 
                    Console.Write("Enter a name for a new Blog: ");
                    var name = Console.ReadLine();

                    var person = new Person("Corey", "Neal", "123 hi st.", "23", "lots");
                    //TODO: check if the database already exists or not, if not create db and populate with data.
                    //else run query

                    //resource: https://msdn.microsoft.com/en-us/data/jj193542.aspx
                    //db.People.Add(person);
                    //db.SaveChanges();
                    var result = db.People;
                    dt = result.ToDataTable();
                    

                }


                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }


            }


        }

    }
}
