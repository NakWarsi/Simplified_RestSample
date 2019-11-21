# Refit for API Developers

If you are API developer and **If you don't want the API users to struggle**, you should really-really use Refit so you can share a contract having methods wrapping all the APIs you want others to use.
**Following are the steps you need to follow :-**
	Let me explain End to End steps from creating APIs to creating contract to share with the users,

**Step 1:** Create application Exposing APIs
following way I have created one Application exposing bare minimum APIs 
<img alt="YAP" src="https://i.imgur.com/OSfuQoX.png">

following are the APIs Exposed By this Application

```c#
using System.Collections.Generic;
using LibraryWithSDKandRefitService;
using Microsoft.AspNetCore.Mvc;

namespace RestApiforTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Get Api with no argument was Called";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Get Api was called";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] ModelForTest testObject)
        {
            return "Post Api was Called";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] ModelForTest testObject)
        {
            return "Put Api was called";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            return "Delete Api was Called";
        }
    }
}

```

as above we can see we have an object named **ModelForTest** so to keep out application clean we keep the SDK asperate. So in next step we will create a library project to store all the SDKs (well as this is just to explain concept so there will be just one)

**Step 2:** Create a library Project,
<img alt="YAP" src="https://i.imgur.com/uScyoSM.png">

**Step 3:** Create model class used in the API Application,
in my Example Class looks like this,

```c#
namespace LibraryWithSDKandRefitService
{
    public class ModelForTest
    {
        public string TestVariable { get; set; }
    }
}
```

**Step 4:** Install the **Refit NuGet package**
	as we can see I have installed Refit Library 
    <img alt="YAP" src="https://i.imgur.com/RtKFalV.png">

**Step 5:** create Interface using Refit,
this interface could be anywhere but preferably if you put it in the library having SDK than it would get shared with your users with no external dependencies.

```c#
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace LibraryWithSDKandRefitService
{
    public interface IRestService
    {
        [Get("/api/values")]
        Task<string> GetWithNoParameter();

        [Get("/api/values/{id}")]
        Task<string> GetWithParameter([AliasAs("id")] int id);

        [Post("/api/values")]
        Task<string> PostWithTestObject([Body] ModelForTest modelObject);

        [Put("/api/values/{id}")]
        Task<string> PutWithParameters([AliasAs("id")] int id, [Body] ModelForTest modelObject);

        [Delete("/api/values/{id}")]
        Task<string> DeleteWithParameters([AliasAs("id")] int id);
    }
}
```

here you are done with the all the API business, now your contract is ready to share,
now API users don't have to worry about anything related to Rest APIs as relative path, deserializing, object Selection etc, All they have to do is create instance of this interface and call the needed methods.
as we are discussing about the explanation or Refit service End to End so **in next Step we will create a project to use this Interface methods, but for an API developer His work is done**  

**Step 6:** Create a console Application.
this is the project where we will use the APIs but not directly but by using Refit Interface.

**Step 7:** give the reference of contract to the console Application,
here by referencing the Contract (Library Project) we will be able to use the all the services Provided by Library,

**Step 8:** Create Http Client,

```c#
            HttpClient _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:61868")
            };
```

here you need to provide the base address where the server is running as my API application is running at localhost at port "61868" so I have Provided the same.

**Step 9:** create Instance of **RestService**
this is the service which allow us to use interface methods as Rest service,

```c#
IRestService _restApiService = RestService.For<IRestService>(_client);
```

here "IRestService" is the Interface defined in the Library Project. Now we can use all the APIs just by Calling the Method,

```c#
 switch (choice)
                {
                    case 1:
                        var result1 = _restApiService.GetWithNoParameter().Result;
                        Console.WriteLine(result1);
                        break;
                    case 2:
                        var result2 = _restApiService.GetWithParameter(4).Result;
                        Console.WriteLine(result2);
                        break;
                    case 3:
                        var result3 = _restApiService.PostWithTestObject(new ModelForTest()).Result;
                        Console.WriteLine(result3);
                        break;
                    case 4:
                        var result4 = _restApiService.PutWithParameters(4, new 					                             ModelForTest()).Result;
                        Console.WriteLine(result4);
                        break;
                    case 5:
                        var result5 = _restApiService.DeleteWithParameters(5).Result;
                        Console.WriteLine(result5);
                        break;
                    default:
                        Console.WriteLine("Bhai Please Enter valid if you are really serious");
                        break;
                }
```

in above you can see I have Called all the APIs available provided by API application but I am not providing anything like  relative path for different APIs, I am not even deserializing the result this feels exactly like normal method call,

Everything simplified now isn't it, well that was the Goal