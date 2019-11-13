using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace LibraryWithSDKandRefitService
{
    interface IRestService
    {
        [Get("/api/values")]
        Task<IEnumerable<string>> GetWithNoParameter();

        [Get("/api/values/{id}")]
        Task<string> GetWithParameter([AliasAs("id")] int id);

        [Post("/api/values")]
        Task PostWithTestObject();

        [Put("/api/values/{id}")]
        Task PutWithParameters([AliasAs("id")] int id);

        [Delete("/api/values/{id}")]
        Task DeleteWithParameters([AliasAs("id")] int id);
    }
}
