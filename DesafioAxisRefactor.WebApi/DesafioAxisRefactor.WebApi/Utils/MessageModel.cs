namespace DesafioAxisRefactor.WebApi.Utils
{
    public class MessageModel
    {
        public Object Data { get; set; }
        public Boolean Success { get; set; }
        public string Message { get; set; }

        public MessageModel(Object data, Boolean success, string message)
        {
                Data = data;
                Success = success;
                Message = message;
        }
    }
}
