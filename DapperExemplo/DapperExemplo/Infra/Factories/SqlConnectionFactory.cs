using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DapperExemplo.Infra.Contracts;
using Microsoft.Data.SqlClient;

namespace DapperExemplo.Infra.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public IDbConnection Connection() => new SqlConnection("Data Source=DESKTOP-A59Q46N\\SQLEXPRESS;Initial Catalog=DapperExemplo;Integrated Security=True;");
    }
}
