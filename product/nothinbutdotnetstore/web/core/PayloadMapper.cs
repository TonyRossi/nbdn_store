namespace nothinbutdotnetstore.web.core
{
    public internal interface PayloadMapper
    {
        InputModel map_payload_to_input_model<InputModel>(Payload payload);
    }
}