using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ThePeopleSearchApplication.Models
{
    public class DB_Connector:DbContext
    {
        public DbSet<Person> People { get; set; }


    }
}
