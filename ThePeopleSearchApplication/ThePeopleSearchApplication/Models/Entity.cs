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
    public class Entity
    {
        private int _uid;
        private string _first_name;
        private string _last_name;
        private string _address;
        private int _age;
        private string _interests;
        //private Image _picture;

        //default constructor
        public Entity()
        {

        }

        //constructor
        public Entity(int ud,string fname,string lname, string add, int ag, string inters)
        {
            _uid = ud;
            _first_name = fname;
            _last_name = lname;
            _address = add;
            _age = ag;
            _interests = inters;
            
        }
        [Key]
        public int uid
        {
            get { return _uid;}
            set { _uid = value; }
        }
        public string firstName
        {
            get { return _first_name; }
            set
            {
                _first_name = value;

            }
        }
        public string lastName
        {
            get { return _last_name; }
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

        public int age
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
        
        /* commented out for now

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
