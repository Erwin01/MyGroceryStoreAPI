﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroceryStoreAPI.Models
{
    public class Product
    {

        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public DateTime ExpiryDate { get; set; }   

    }
}
