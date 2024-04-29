using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;
using csharp_quickstart;

var conn = "mongodb+srv://tiger:i3M6H44HOvBy@freecodecamp.eyzbpli.mongodb.net/?retryWrites=true&w=majority&appName=freecodecamp";
var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI") ?? conn;

if(connectionString is null)
{
    System.Console.WriteLine("You must set your 'MONGDB_URI' environment variable");
    Environment.Exit(0);
}

var client = new MongoClient(connectionString);

//var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");

//var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");

//var document = collection.Find(filter).First();

//Console.WriteLine(document);

var db = MflixDbContext.Create(client.GetDatabase("sample_mflix"));

var movie = db.Movies.First(m => m.title == "Back to the Future");
Console.WriteLine(movie.plot);