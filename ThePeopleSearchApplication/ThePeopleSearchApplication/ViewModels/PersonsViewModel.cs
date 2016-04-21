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
using System.Reflection;

namespace ThePeopleSearchApplication.ViewModels 
{
    /// <summary>
    /// Person View model will have a database object that it can execute queries on
    /// through those queries, a list of person variables will be added to the people list.
    /// </summary>
    public class PersonsViewModel : INotifyPropertyChanged
    {

        //data table that will hold values from an SqlDataAdapter using.fill
        //reference:  http://www.codeproject.com/Tips/362436/Data-binding-in-WPF-DataGrid-control
        private DataTable _dt = new DataTable("People");
        private JSON_Parser _jp = new JSON_Parser();
        private List<Entity> _people;
        private string _query_string;
        private List<string> _auto;

        //add event handling for the databind of tje datatable
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        //gettters and setters for all of my public member variables
        public string query_string
        {
            get { return _query_string; }
            set
            {
                _query_string = value;
                QueryDB();
            }
        }

        public DataTable dt
        {
            get { return _dt; }
            set {
                _dt = value;
                OnPropertyChanged("dt");
            }
        }

        public List<string> auto
        {
            get { return _auto; }
            set { _auto = value; }
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

                QueryDB();
                var result = db.People2;
                dt = result.ToDataTable();



            }
            AutoComplete();

        }

        /// <summary>
        /// queries database for all entries with first or last name equal to the query string
        /// </summary>
        private void QueryDB()
        {
            using (var db = new DB_Connector())
            {
                var result = db.People2.Where(p => p.firstName == query_string || p.lastName == query_string).Select(p => p).ToList();


                var test = result;
                dt = ToDataTable(result);
            }

        }

        /// <summary>
        /// used for autocomplete of the text box
        /// </summary>
        private void AutoComplete()
        {
            using (var db = new DB_Connector())
            {
                var result = db.People2.Select(p => p.firstName).ToList();
                var result2 = db.People2.Select(p => p.lastName).ToList();

                result.AddRange(result2);
                auto = result;
                


            }
        }

        //this is a helper function that takes a list of a templeted type and returns it as a datatable
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }



    }
}
