using Application.Interfaces;
using Application.ViewModels.Request;
using Application.ViewModels.Response;
using AutoMapper;
using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ErrorAppService : IDisposable, IErrorAppService
    {
        private readonly IMapper _mapper;
        private readonly IErrorRepository _errorRepository;
        private readonly IErrorFileRepository _errorFileRepository;
        public ErrorAppService(IMapper mapper,
            IErrorRepository errorRepository,
            IErrorFileRepository errorFileRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _errorRepository = errorRepository ?? throw new ArgumentNullException(nameof(errorRepository));
            _errorFileRepository = errorFileRepository ?? throw new ArgumentNullException(nameof(errorFileRepository));
        }

        public async Task AddError(ErrorRequest errorRequest)
        {
            Error newError = await _errorRepository
                .Insert(new Error(Guid.NewGuid(), errorRequest.Type, errorRequest.Title, errorRequest.Details));

            if (errorRequest.Files.Count > 0)
            {
                List<ErrorFile> errorFiles = ConvertFile(errorRequest.Files);

                errorFiles.ForEach(x => x.ErrorId = newError.Id);

                await _errorFileRepository.InsertRange(errorFiles);
            }
           
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

        private List<ErrorFile> ConvertFile(IList<IFormFile> files)
        {
            List<ErrorFile> errorFilesList = new List<ErrorFile>();

            foreach (var file in files)
            {
                Stream fileStream = file.OpenReadStream();

                using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    errorFilesList.Add(new ErrorFile(Guid.NewGuid(), file.FileName, memoryStream.ToArray()));
                }
            }

            return errorFilesList;
        }

        public void Dispose()
        {
            _errorRepository.Dispose();
        }

    }
}
