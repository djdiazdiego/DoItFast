using AutoMapper;
using DoItFast.Application.Dtos;
using DoItFast.Domain.Core.Abstractions.Entities.Interfaces;

namespace DoItFast.Application.MapConverters
{
    public class EnumerationDtoToEnumeration : ITypeConverter<IEnumeration, EnumerationDto>
    {
        public EnumerationDto Convert(IEnumeration source, EnumerationDto destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new EnumerationDto();
            }

            destination.Id = (int)source.Id;
            destination.Name = source.Name;

            return destination;
        }
    }
}
