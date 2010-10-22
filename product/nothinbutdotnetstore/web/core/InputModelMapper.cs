namespace nothinbutdotnetstore.web.core
{
    public interface InputModelMapper
    {
        InputModel map_from<InputModel>(Payload payload);
    }
}