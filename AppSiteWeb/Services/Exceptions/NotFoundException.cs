using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException (string message): base(message)
        {

        }
    }
}
