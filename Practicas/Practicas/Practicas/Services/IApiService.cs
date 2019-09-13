using System;
using System.Collections.Generic;
using System.Text;
using Practicas.Models;
using System.Threading.Tasks;
using Refit;
using Practicas.Configuration;

namespace Practicas.Services
{
    public interface IApiService
    {

        //No funciona asi que pongo el key fijo =( [Get($"/commentThreads?part=snippet&videoId=2j3x0VYnehg&fields=items%2Fsnippet%2FtopLevelComment&key={Constants.key}")]
        [Get("/commentThreads?part=snippet&videoId=2j3x0VYnehg&fields=items%2Fsnippet%2FtopLevelComment&key=AIzaSyCO4bqpLYO0u_vfKOMpvlUgHEHb1Z6GCzs")]
        Task<Comment> GetGomments();
    }
}
