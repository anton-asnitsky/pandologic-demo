using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GraphData.Data.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionTypes connectionName);
    }
}
