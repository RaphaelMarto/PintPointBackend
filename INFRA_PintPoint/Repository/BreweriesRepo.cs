using CORE_PintPoint.Abstraction.IRepo;
using Dapper;
using Domain_PintPoint.Entities;
using Microsoft.Data.SqlClient;

namespace INFRA_PintPoint.Repository
{
    public class BreweriesRepo : IBreweriesRepo
    {
        private readonly SqlConnection _connection;
        public BreweriesRepo(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Breweries> Get()
        {
            string storedProcedure = "SP_List_Breweries";
            return _connection.Query<Breweries>(storedProcedure);
        }

        public Breweries Get(int id)
        {
            string storedProcedure = "SP_GetOne_Breweries";
            return _connection.QuerySingle<Breweries>(storedProcedure, new { Id = id });
        }
    }
}
