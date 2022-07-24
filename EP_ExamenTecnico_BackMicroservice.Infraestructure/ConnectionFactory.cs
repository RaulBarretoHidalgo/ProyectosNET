using System.Data;
using System.Data.Common;
using EP_Planning_BackMicroservice.Repository;
using Microsoft.Extensions.Configuration;
using System.Composition;
using Util;

namespace EP_Planning_BackMicroservice.Infraestructure
{
    [Export(typeof(IConnectionFactory))]
    public class ConnectionFactory : IConnectionFactory
    {              
        public IDbConnection GetConnection
        {
            get
            {               
                DbProviderFactory dbProvider = DbProviderFactories.GetFactory(TrackerConfig.databaseProvider);
                DbConnection cn = dbProvider.CreateConnection();
                cn.ConnectionString = TrackerConfig.connectionString ;
                return cn;
            }
        }        
    }
}
