namespace Organization.Services.Response
{
    public class ResponseService
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }

        public static ResponseService Ok() => new ResponseService();
        public static ResponseService Error(string errorMessage)
            => new ResponseService()
            {
                ErrorMessage = errorMessage,
                IsError = true,
            };
    }
}