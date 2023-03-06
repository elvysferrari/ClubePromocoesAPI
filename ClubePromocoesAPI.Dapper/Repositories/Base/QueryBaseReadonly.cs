using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubePromocoesAPI.Dapper.Repositories.Base
{
    public class QueryBaseReadonly
    {
        private readonly IConfiguration _config;
        public QueryBaseReadonly(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("connection"));
            }
        }

    }
}
