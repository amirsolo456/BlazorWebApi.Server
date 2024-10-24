using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;   
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface IVillaNumberService
    {
        public IEnumerable<VillaNumber> GetAllVillaNumbers(Expression<Func<VillaNumber, bool>>? filter = null, string? PropertuIncludeProps = null);
    }
}
