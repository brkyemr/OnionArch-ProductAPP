using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.Application.Bases
{
    public class BaseException : ApplicationException
    {
        public BaseException()
        {
            
        }
        public BaseException(string message) : base(message)
        {
            
        }
    }
}