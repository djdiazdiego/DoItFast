using AutoMapper;
using DoItFast.Application.Command.Product;
using DoItFast.Application.Dtos.Product;
using DoItFast.Application.Queries.Product;
using DoItFast.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoItFast.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Response<ProductDto>), StatusCodes.Status200OK)]
    public class ProductController : ApiControllerBase<Guid, ProductDto, CreateProductDto, UpdateProductDto>
    {
        public ProductController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Get product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult<Response<ProductDto>>> Get(Guid id, CancellationToken cancellationToken) => base.Get(id, cancellationToken);

        /// <summary>
        /// Get all product.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<ProductDto>[]), StatusCodes.Status200OK)]
        public override Task<ActionResult<Response<ProductDto[]>>> Get(CancellationToken cancellationToken) => base.Get(cancellationToken);

        /// <summary>
        /// Create product.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult<Response<ProductDto>>> Post([FromBody] CreateProductDto dto, CancellationToken cancellationToken) => base.Post(dto, cancellationToken);

        /// <summary>
        /// Update product.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult<Response<ProductDto>>> Put([FromBody] UpdateProductDto dto, CancellationToken cancellationToken) => base.Put(dto, cancellationToken);

        /// <summary>
        /// Delete product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult<Response<ProductDto>>> Delete([FromBody] Guid id, CancellationToken cancellationToken)=> base.Delete(id, cancellationToken);
    }
}
