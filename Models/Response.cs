using System.Runtime.CompilerServices;

public class Response<T>
{
    public int Code { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public static Response<T> DoMethod(Action<Response<T>> action)
    {
        Response<T> response = new Response<T>();
        try
        {
            action.Invoke(response);
        }
        catch (ResponseException ex)
        {
            response.Code = ex.Code;
            response.Message = ex.Message;
            System.IO.File.AppendAllLines("logs.txt", new[] { ex.Message });
        }
        catch (Exception ex)
        {
            response.Code = -1;
            response.Message = ex.Message;
            System.IO.File.AppendAllLines("logs.txt", new[] { ex.Message });
        }
        return response;
    }

    public void Throw(string message) =>
        Throw(1, message);

    public void Throw(int code, string message) =>
        throw new ResponseException(code, message);

    public void ThrowIf(bool condition, string message) =>
        ThrowIf(condition, message);

    public void ThrowIf(bool condition, int code, string message)
    {
        if (condition)
            Throw(code, message);
    }


    public T GetResultIfNotError()
    {
        if (Code < 0)
            throw new Exception(Message);
        else if (Code > 0)
            Throw(Code, Message);

        return Data;
    }
}

public class ResponseException : Exception
{
    public int Code { get; set; }
    public ResponseException(int code, string message)
        : base(message)
    {
        Code = code;
    }
}
