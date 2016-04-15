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
using ThePeopleSearchApplication.JSON;

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
        private JSON_Parser _jp = new JSON_Parser();
        private List<Entity> _people;

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

               


                //var person = new Person("Corey", "Neal", "123 hi st.", "23", "lots");
                //TODO: check if the database already exists or not, if not create db and populate with data.
                //else run query
                //resource for todo: http://stackoverflow.com/questions/1802286/best-way-to-check-if-object-exists-in-entity-framework
                //resource for property chagned in search box: http://stackoverflow.com/questions/3491510/how-to-hookup-textboxs-textchanged-event-and-command-in-order-to-use-mvvm-patte
                //resource: https://msdn.microsoft.com/en-us/data/jj193542.aspx
                //
                
                //
                //

                //get all people from the json file
                _people = _jp.LoadJson();
                //for each person in the list returned, try to load
                foreach(Entity pers in _people)
                {
                    if (db.People2.Any(o => o.uid == pers.uid))
                    {
                        // Match!
                    }
                    else
                    {
                        db.People2.Add(pers);
                    }

                }
                db.SaveChanges();

                var result = db.People2;
                dt = result.ToDataTable();



            }


        }

    }
}
