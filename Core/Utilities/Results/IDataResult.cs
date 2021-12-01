using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  public  interface IDataResult<T>:IResult
    {
         
        // Generic yapılar için 

         T Data { get; }
        
    }
}
