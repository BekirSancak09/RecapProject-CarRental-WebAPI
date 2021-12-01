using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
  public class BusinessRules
    {
        /// <summary>
        /// Kurala uymayan iş kodlarını döndürür.
        /// </summary>
        /// <param name="logics"></param>
        /// <returns></returns>
        public static IResult Run(params IResult [] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
