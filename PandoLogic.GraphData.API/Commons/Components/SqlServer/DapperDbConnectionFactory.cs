using Commons.Enums;
using GraphData.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Commons.Components.SqlServer
{ 
    public class DapperDbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<DatabaseConnectionTypes, string> _connectionsDictionary;

        public DapperDbConnectionFactory(IDictionary<DatabaseConnectionTypes, string> connectionDict)
        {
            _connectionsDictionary = connectionDict;
        }

        public IDbConnection CreateDbConnection(DatabaseConnectionTypes connectionType)
        {
            if (_connectionsDictionary.TryGetValue(connectionType, out string connectionString))
            {
                return new SqlConnection(connectionString);
            }

            throw new ArgumentNullException();
        }
    }
}
