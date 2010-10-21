namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        InputModel map<InputModel>() where InputModel:new();
        string Url   { get; }
        string[] QueryString { get; }
    }
}