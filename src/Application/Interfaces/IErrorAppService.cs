using Application.ViewModels.Response;
using Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IErrorAppService
    {
        Task<ErrorResponse> GetErrorById(Guid Id);
        Task<IEnumerable<ErrorResponse>> GetErrors();
    }
}
