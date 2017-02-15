using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace MercasuusREST.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        public string Get(int id)
        {
            MySqlConnection con = new MySqlConnection(
                "Server = eu-cdbr-azure-west-d.cloudapp.net;" +
                "Database=mercasuus_db;" +
                "Uid= bdc8fae0451b56;" +
                "Pwd= 94c0cdd0");

            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from beacon;";

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            String result = reader.GetString(0) + reader.GetString(1) + reader.GetString(2) + reader.GetString(3) + reader.GetString(4);
            con.Close();

            return result;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}