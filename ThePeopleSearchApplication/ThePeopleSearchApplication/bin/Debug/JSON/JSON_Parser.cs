using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePeopleSearchApplication.Models;
using System.Web.Script.Serialization;
using System.Resources;


namespace ThePeopleSearchApplication.JSON
{
    public class JSON_Parser
    {

        //list of people to be added to from the json file
        private List<Entity> _people;

        //default constructor
        public JSON_Parser()
        { }

        //load json deserialized a jason file and made a list of people out of it
        public List<Entity> LoadJson()
        {
           
            using (StreamReader r = new StreamReader(@"JSON/file.json"))
            {

                string json = r.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                _people = jss.Deserialize<List<Entity>>(json);

                return _people;
               

            }
        }

    }
}
