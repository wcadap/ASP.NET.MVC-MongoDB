using MongoDB.Driver;
using System;

namespace mvcMongoDB.Models
{
    public class CountryDB
    {
        //For Best practice, Please put this in the web.config. This is only for demo purpose.
        //====================================================
        public String connectionString = "mongodb://localhost";
        public String DataBaseName = "CountryDB";
        //====================================================

        public MongoDatabase Database;
        
        public CountryDB ()
	    {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            Database = server.GetDatabase(DataBaseName);
	    }

        public MongoCollection<Country> Countries
        {
            get
            {
                var Countries = Database.GetCollection<Country>("Countries");
                
                return Countries;
            }
        }
    }
}