# JsonApp

This is a C# application written using Visual Studio 2015 Community Edition. Its intent is to demonstrate how to download some JSON data and parse it using the Json.NET library from Newtonsoft (http://www.newtonsoft.com/json) which can be added on using the NuGet package manager and demonstrate how to use some LINQ queries. The JSON data was provided by http://jsonplaceholder.typicode.com. Big thanks to both groups for their awesome tools and data!

The data is basically for a simple social network. As of October 30, 2016, not all of the data is being used, but it is all being downloaded and deserialized. Once this is complete it will show different tabs for users, albums, posts, and To-Dos. 

Weird thing about that data: the comments don't have users that are in the users data! It just shows e-mails. That's why there is only an e-mail associated with a comment.
