using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace mvcMongoDB.Models
{
    public class Country
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [Required]
        public String CountryCode { get; set; }

        [Required]
        public String CountryName { get; set; }

    }
}