using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorello.Services.Exceptions
{
    public class EntityDublicateException:Exception
    {
        public EntityDublicateException(string message):base(message)
        {
            
        }
    }
}
