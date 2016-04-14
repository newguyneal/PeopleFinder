using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ThePeopleSearchApplication.Models 
{
    public class Person
    {
        private string _first_name;
        private string _last_name;
        private string _address;
        private string _age;
        private string _interests;
        //private Image _picture;

        //default constructor
        public Person()
        {

        }

        //constructor
        public Person(string fname,string lname, string add, string ag, string inters)
        {
            first_name = fname;
            last_name = lname;
            address = add;
            age = ag;
            interests = inters;
            
        }
        [Key]
        public string first_name
        {
            get { return _first_name; }
            set
            {
                _first_name = value;

            }
        }
        public string last_name
        { get { return _last_name; }
            set { _last_name = value; }
        }

        public string address
        {
            get { return _address; }
            set
            {
                _address = value;

            }
        }

        public string age
        {
            get { return _age; }
            set
            {
                _age = value;

            }
        }

        public string interests
        {
            get { return _interests; }
            set
            {
                _interests = value;

            }
        }
        
        /*

        public Image picture
        {
            get { return _picture; }
            set
            {
                _picture = value;

            }
        }
        */

    }
}
