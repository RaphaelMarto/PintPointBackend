using CORE_PintPoint.Abstraction.IRepo;
using Dapper;
using Domain_PintPoint.Entities;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace INFRA_PintPoint.Repository
{
    public class CountriesRepo : ICountriesRepo
    {
        private readonly SqlConnection _connection;
        private readonly IHttpClientFactory _httpClientFactory;
        public CountriesRepo(SqlConnection connection, IHttpClientFactory httpClientFactory)
        {
            _connection = connection;
            _httpClientFactory = httpClientFactory;
        }
        public IEnumerable<Countries> Get()
        {
            string storedProcedure = "SP_List_Countries";
            return _connection.Query<Countries>(storedProcedure);
        }

        public Countries Get(int id)
        {
            string storedProcedure = "SP_GetOne_Countries";
            return _connection.QuerySingle<Countries>(storedProcedure, new { Id = id });
        }

        public IEnumerable<Cities> GetCities()
        {
            string storedProcedure = "SP_List_City";
            return _connection.Query<Cities>(storedProcedure);
        }

        //public async Task<string> GetFlag(string name)
        //{
        //    var httpClient = _httpClientFactory.CreateClient();
        //    httpClient.BaseAddress = new Uri("https://restcountries.com/v3.1/");

        //    string url = $"name/{name}";

        //    HttpResponseMessage httpResponse = await httpClient.GetAsync(url);

        //    if (httpResponse.IsSuccessStatusCode)
        //    {
        //        string responseContent = await httpResponse.Content.ReadAsStringAsync();

        //        List<CountryFlag>? countries = JsonSerializer.Deserialize<List<CountryFlag>>(responseContent);


        //        return countries[0].flags.svg;
        //    }
        //    throw new Exception();
        //}
    }
}
