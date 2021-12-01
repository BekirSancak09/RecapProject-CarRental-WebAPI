using Castle.DynamicProxy;
using Core.Ioc;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Extensions;

namespace Business.BusinessAspects.Autofac
{
    /// <summary>
    /// Jwt için
    /// </summary>
    public class SecuredOperation : MethodInterception
    {

        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        /// <summary>
        /// User'ın claim rollerini bulur.
        /// User'ın rollerini gez. 
        /// İlgili kullanıcının Claim rolleri varsa return et.
        /// Eğer Claim rolleri yoksa hata mesajı gönder.
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("You are not authorized");

        }
    }
}
