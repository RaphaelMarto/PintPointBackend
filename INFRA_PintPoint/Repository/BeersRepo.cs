using CORE_PintPoint.Abstraction.IRepo;
using Dapper;
using Domain_PintPoint.Entities;
using Microsoft.Data.SqlClient;

namespace INFRA_PintPoint.Service
{
    public class BeersRepo : IBeersRepo
    {
        private readonly SqlConnection _connection;
        public BeersRepo(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Beers> Get()
        {
            string storedProcedure = "SP_List_Beers";
            return _connection.Query<Beers>(storedProcedure);
        }

        public Beers Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
