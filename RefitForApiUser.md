# Refit For API Users

If you are using APIs made by someone else and you want reduce the mistake by providing by all the APIs into an interface. Here by using Refit Library you can do the very simple. 

To Explain the concept I am using the GitHub APIs,
so Let's discuss Step by Step:-

**Step 1:** Create a web application Application 
<img alt="YAP" src="https://i.imgur.com/SEA6KJd.png">
as in this tutorial in this tutorial I have used a web Application you can use any refit in any kind of Application

**Step 2:** Install NuGet package Refit

```xml
  <ItemGroup>
    <PackageReference Include="Refit" Version="4.8.14" />
  </ItemGroup>
```

​	As you can see I have installed Refit version 4.8.14

**step 3:** find the API Link, 

```tex
https://api.github.com/users/{UserName}
```

​		we can put any username at the place of UserName.

**Step 4:** understand the API,
	the above link is a get API so we will try to figure out the object to be made by looking into the responce  which looks 	like the fallowing:-

```json
{
  "login": "NakWarsi",
  "id": 26460282,
  "node_id": "MDQ6VXNlcjI2NDYwMjgy",
  "avatar_url": "https://avatars0.githubusercontent.com/u/26460282?v=4",
  "gravatar_id": "",
  "url": "https://api.github.com/users/NakWarsi",
  "html_url": "https://github.com/NakWarsi",
  "followers_url": "https://api.github.com/users/NakWarsi/followers",
  "following_url": "https://api.github.com/users/NakWarsi/following{/other_user}",
  "gists_url": "https://api.github.com/users/NakWarsi/gists{/gist_id}",
  "starred_url": "https://api.github.com/users/NakWarsi/starred{/owner}{/repo}",
  "subscriptions_url": "https://api.github.com/users/NakWarsi/subscriptions",
  "organizations_url": "https://api.github.com/users/NakWarsi/orgs",
  "repos_url": "https://api.github.com/users/NakWarsi/repos",
  "events_url": "https://api.github.com/users/NakWarsi/events{/privacy}",
  "received_events_url": "https://api.github.com/users/NakWarsi/received_events",
  "type": "User",
  "site_admin": false,
  "name": "Naushad Warsi",
  "company": "@Klingelnberg",
  "blog": "www.linkedin.com/in/naushad-warsi-100ba2114",
  "location": "pune",
  "email": null,
  "hireable": true,
  "bio": "IIoT || ML ",
  "public_repos": 42,
  "public_gists": 15,
  "followers": 14,
  "following": 51,
  "created_at": "2017-03-16T12:28:59Z",
  "updated_at": "2019-11-14T16:15:50Z"
}
```

​	above is the response of my username "NakWarsi" 

**Step 5:** create the Class(object) to deserialize this response,
 	following is the class I have created to deserialize the GitHub User Details Response,

```c#
    public class UserDetails
    {
        public string login { get; set; }
        public string id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; } 
        public string url { get; set; } 
        public string html_url { get; set; } 
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; } 
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; } 
        public string type { get; set; }
        public string site_admin { get; set; } 
        public string name { get; set; }
        public string company { get; set; } 
        public string blog { get; set; } 
        public string location { get; set; } 
        public string email { get; set; } 
        public string hireable { get; set; } 
        public string bio { get; set; }
        public string public_repos { get; set; } 
        public string public_gists { get; set; } 
        public string followers { get; set; } 
        public string following { get; set; }
        public string created_at { get; set; } 
        public string updated_at { get; set; } 
    }
```

now we are all done with .net basics and now we will step towards refit Library use,

**Step 6:** Create interface Using Refit 

```c#
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using WebSamples.Models;

namespace WebSamples.Controllers
{
    internal interface IGitHubApi
    {
        [Get("/users/{user}")]
        Task<UserDetails> GetUser([AliasAs("user")] string user);

        [Get("/users/NakWarsi")]
        Task<UserDetails> GiTHubUserDetails();
    }
}
```

as above you can see by default I am returning my User Details (with user id NakWarsi) and also you can see there in one API I have user an Attribute named **AlieasAs** which Gives us a way to take information from url.
to know more about all the Attribute provided by Refit 

[take a look into the readme at GitHub]: https://github.com/reactiveui/refit

**step 7:** Create Http Client with Base Address.
That's the good thing that user have the freedom to change the base address as in normal scenarios server's machine and base url kept changing but not the relative url of APIs,
so following is the link I have created,

```c#
_client = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com"),
                DefaultRequestHeaders = {UserAgent = { ProductInfoHeaderValue.Parse("NakWarsi")}}
            };
```

Note: the line where I have set the UserAgent in the header is specially for GitHub APIs if you are using some other API it would not be necessary.

**step 8:** Create Instance of the RestService(a service provided by Refit Library) for above created Interface.
(this is the API which creates the Implementation of the defined Interface and provide a way to use those method directly reducing all the complexity)

```c#
 _restApiService = RestService.For<IGitLibApi>(_client);
```

I have defined a field of type IGitLibApi (Defined Interface), following are the all private field I have defined (necessary).

```c#
private readonly HttpClient _client;
private readonly IGitLibApi _restApiService;
```

**step 9:** use the Method defined in the Interface,
we are all done here now we can use all the method defined in the interface, following ae the code where I have use Interface methods,

```c#
            UserDetails userDetails;
            try
            {
                // for By default 
                //userDetails = await _restApiService.GiTHubUserDetails();
                //set the value 
                userDetails = await _restApiService.GetUser("NakWarsi");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
```

fewwww.... all done,
isn't it pretty we aren't just reducing the complexity rest APIs but also reducing the Headache of Deserialization.