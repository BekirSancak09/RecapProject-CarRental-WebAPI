using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
 public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult UpdateUserInfos(ChangeUserInfoDto changeUserInfo);
        IResult ChangeUserPassword(ChangeUserPasswordDto changePasswordDto);
    }
}
