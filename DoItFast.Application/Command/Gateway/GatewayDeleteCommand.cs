using DoItFast.Application.Dtos.Gateway;

namespace DoItFast.Application.Command.Gateway
{
    public class GatewayDeleteCommand : Command<string, GatewayResponseDto>
    {
        public GatewayDeleteCommand(string id) : base(id)
        {
        }
    }
}
