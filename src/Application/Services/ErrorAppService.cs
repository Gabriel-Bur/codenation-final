using Application.Interfaces;
using Application.ViewModels.Response;
using AutoMapper;
using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ErrorAppService : IDisposable, IErrorAppService
    {
        private readonly IMapper _mapper;
        private readonly IErrorRepository _errorRepository;
        public ErrorAppService(IMapper mapper,
            IErrorRepository errorRepository)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _errorRepository = errorRepository ??
                throw new ArgumentNullException(nameof(errorRepository));
        }

        public async Task<ErrorResponse> GetErrorById(Guid Id)
        {
            var error = _mapper.Map<ErrorResponse>(await _errorRepository.SelectById(Id));
            return error;
        }

        public async Task<IEnumerable<ErrorResponse>> GetErrors()
        {
            var errorList = _mapper.Map<IEnumerable<ErrorResponse>>(await _errorRepository.SelectAll());
            return errorList;
        }

        public void Dispose()
        {
            _errorRepository.Dispose();
        }
    }
}
