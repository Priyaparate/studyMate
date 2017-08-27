using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Data.Entity;

namespace StudyMateLibrary.Agent
{
    public class MongoContext<T> where T :class,new()  
    {
        public IMongoClient _client { get; set; }
        public IMongoDatabase _context { get; set; }
        public IMongoCollection<T> Collection { get; set; }
        public MongoContext()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _context = _client.GetDatabase("OnlineTest");
            Collection= _context.GetCollection<T>(nameof(T)); 
        }
        

    }
}
