using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Common
{
    public class DbContext
    {        
        protected DbContext()
        {}
        public static dynamic Instance(string tenant)
        {
            var objectType = System.Type.GetType("DynamicObjects.Models.Context.HMSContext" + tenant + ", DynamicObjects");
            dynamic dbContext = System.Activator.CreateInstance(objectType);


            return dbContext;
        }
    }
}
