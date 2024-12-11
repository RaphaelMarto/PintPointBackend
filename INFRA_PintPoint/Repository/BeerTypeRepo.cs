using CORE_PintPoint.Abstraction.IRepo;
using Dapper;
using Domain_PintPoint.Entities;
using Microsoft.Data.SqlClient;

namespace INFRA_PintPoint.Repository
{
    public class BeerTypeRepo : IBeerTypeRepo
    {
        private readonly SqlConnection _connection;
        public BeerTypeRepo(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<BeerType> Get()
        {
            string storedProcedure = "SP_List_BeerType";
            return _connection.Query<BeerType>(storedProcedure);
        }

        public BeerType Get(int id)
        {
            string storedProcedure = "SP_GetOne_BeerType";
            return _connection.QuerySingle<BeerType>(storedProcedure, new { Id = id });
        }
    }
}
