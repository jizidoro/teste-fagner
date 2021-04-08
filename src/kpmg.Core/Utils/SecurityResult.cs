namespace kpmg.Core.Utils
{
    public class SecurityResult
    {
        public SecurityResult(User user)
        {
            User = user;
            Success = true;
        }

        public SecurityResult(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Success = false;
        }

        public User User { get; set; }
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Mensagem { get; set; }
    }
}