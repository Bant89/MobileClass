using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Practicas.Models;
using Refit;
using Newtonsoft.Json;

namespace Practicas.Services
{
    public class ApiService : IApiService
    {
        public async Task<Comment> GetGomments()
        {
            var nsAPI = RestService.For<IApiService>("https://www.googleapis.com/youtube/v3");
            var result = await nsAPI.GetGomments();
            
            return result;
        }

    }
}
