namespace kpmg.Core.Helpers.Models.Dtos
{
    public class ErrorDto
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}