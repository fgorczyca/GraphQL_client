using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace graphqlclient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var graphQLClient = new GraphQLHttpClient("exampleurl.com", new NewtonsoftJsonSerializer());

            var personAndFilmsRequest = new GraphQLRequest {
                Query =@"
                query PersonAndFilms($id: ID) {
                    person(id: $id) {
                        name
                        filmConnection {
                            films {
                                title
                            }
                        }
                    }
                }",
                OperationName = "PersonAndFilms",
                Variables = new {
                    id = "cGVvcGxlOjE="
                }
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<ResponseType>(personAndFilmsRequest);
            var personName = graphQLResponse.Data.Person.Name;
            return personName;
        }
    }
}
