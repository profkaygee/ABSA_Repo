using System;

namespace ABSA_Assessment
{
    public class MessageResponse
    {
        public Guid NewId { get; set; }
        public bool SuccessResponse { get; set; }
        public string ErrorMessage { get; set; }
    }
}