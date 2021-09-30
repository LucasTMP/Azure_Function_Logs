using Microsoft.AspNetCore.Mvc;
using Observabilidade.Api.Controllers.Shared;
using System;

namespace Observabilidade.Api.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomResponseAttribute : ProducesResponseTypeAttribute
    {
        public CustomResponseAttribute(int statusCode) : base(typeof(CustomResult), statusCode)
        {
        }
    }
}