using System.Data;

namespace EP_Planning_BackMicroservice.Repository
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
