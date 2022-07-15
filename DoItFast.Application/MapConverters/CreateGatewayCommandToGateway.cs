using AutoMapper;
using DoItFast.Application.Command.Gateway;
using DoItFast.Domain.Models.GatewayAggregate;

namespace DoItFast.Application.MapConverters
{
    public class CreateGatewayCommandToGateway : ITypeConverter<GatewayCreateCommand, Gateway>
    {
        public Gateway Convert(GatewayCreateCommand source, Gateway destination, ResolutionContext context)
        {
            

            return destination;
        }
    }
}
