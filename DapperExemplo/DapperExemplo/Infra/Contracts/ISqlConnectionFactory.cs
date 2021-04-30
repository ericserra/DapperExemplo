using System;
using System.Data;

namespace DapperExemplo.Infra.Contracts
{
    public interface ISqlConnectionFactory
    {
        IDbConnection Connection();
    }
}
