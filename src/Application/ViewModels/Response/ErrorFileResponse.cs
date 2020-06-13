using System;

namespace Application.ViewModels.Response
{
    public class ErrorFileResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
