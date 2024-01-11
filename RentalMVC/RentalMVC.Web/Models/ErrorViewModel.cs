namespace RentalMVC.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? ExceptionPath { get; set; }
        public string? ExceptionMessage { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public bool ShowExceptionPath => !string.IsNullOrEmpty(ExceptionPath);
        public bool ShowExceptionMessage => !string.IsNullOrEmpty(ExceptionMessage);
    }
}