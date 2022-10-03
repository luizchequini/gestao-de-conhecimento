namespace BaseDeConhecimento.Application.DTOS.Response;

public class ApiResult<T> where T : class
{
    public ApiResult() { }

    public ApiResult(bool sucesso, List<string> notifications = null)
    {
        Success = sucesso; Notification = notifications;
    }

    public ApiResult(bool sucesso, T data = null, List<string> notifications = null)
    {
        Success = sucesso; Data = data; Notification = notifications;
    }

    public bool Success { get; set; }
    public T Data { get; set; }
    public List<string> Notification { get; set; }

}
