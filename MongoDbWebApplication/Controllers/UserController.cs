using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;
using MongoDB.Driver;

using MongoDbWebApplication.ModelBinders;
using MongoDbWebApplication.Models;

namespace MongoDbWebApplication.Controllers
{
    
    [ApiController]
    [Route("api/user")]
    [EnableCors("__VadimPolicy__")]
    public class UserController : ControllerBase
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<User> _usersCollection;

        public UserController()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _usersCollection  = _mongoClient.GetDatabase("TestDb").GetCollection<User>("TestCollection");
        }

        [HttpGet]
        public User? Get([ModelBinder(typeof(ObjectIdModelBinder))] ObjectId id)
        {
            if (ModelState.IsValid)
            {
                return _usersCollection.AsQueryable().SingleOrDefault(u => u.Id == id);
            }

            return null;
        }

        [HttpPost]
        public HttpResponseMessage Add(User user)
        {
            _usersCollection.InsertOne(user);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [HttpDelete("{id:objectid}")]
        public HttpResponseMessage Delete(ObjectId id)
        {
            _usersCollection.DeleteOne(u => u.Id == id);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
