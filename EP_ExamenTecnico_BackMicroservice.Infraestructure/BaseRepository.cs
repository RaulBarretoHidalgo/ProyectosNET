using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;
using EP_Planning_BackMicroservice.Repository;

namespace EP_Planning_BackMicroservice.Infraestructure
{    
    public abstract class BaseRepository 
    {
        #region IoC
        [Import]
        public IConnectionFactory _connectionFactory { get; set; }
        
        [ImportingConstructor]
        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #endregion
    }
}
