using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Services
{
    public interface IApiService
    {
        Task<HttpResponseMessage?> GetResponse(string url);
    }
}
