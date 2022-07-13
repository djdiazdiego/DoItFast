using AutoMapper;
using DoItFast.Application.Dtos.Admission;
using DoItFast.Application.Wrappers;
using DoItFast.Domain.Core.Abstractions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Response<ISearchDto<AdmissionDto>>), StatusCodes.Status200OK)]
    public class AdmissionController : ApiSearchFilterControllerBase<AdmissionFilterRequestDto, AdmissionFilterResponseDto>
    {
        public AdmissionController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

    }
}
