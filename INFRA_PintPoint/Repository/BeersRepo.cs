﻿using CORE_PintPoint.Abstraction.IRepo;
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
        public OffsetResult<Beers> Get(int offset, int limit, string order, string type, string search)
        {
            string storedProcedure = "SP_List_Beers";
            var param = new { Offset = offset, Limit = limit, Order = order, Type = type, Search = search };

            using (var multi = _connection.QueryMultiple(storedProcedure, param))
            {
                int total = multi.ReadSingle<int>();
                IEnumerable<Beers> beers = multi.Read<Beers>().ToList();

                return new OffsetResult<Beers>()
                {
                    Results = beers,
                    Total = total,
                };
            }
        }

        public Beers GetOne(int id)
        {
            string storedProcedure = "SP_GetOne_Beers";
            return _connection.QuerySingle<Beers>(storedProcedure, new { Id = id });
        }
    }
}
