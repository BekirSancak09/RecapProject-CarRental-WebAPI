using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
 public interface ITokenHelper
    { /// <summary>
    /// İlgili kullanıcı için ilgili kullanıcının claimlerini içerecek bir jwt uretecek...
    /// </summary>
    /// <param name="user"></param>
    /// <param name="operationClaims"></param>
    /// <returns></returns>
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
