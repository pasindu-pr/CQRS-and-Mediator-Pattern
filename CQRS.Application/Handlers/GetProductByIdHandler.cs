using CQRS.Application.Queries;
using CQRS.Data.Contracts;
using CQRS.Data.Entities; 
using MediatR; 

namespace CQRS.Application.Handlers
{
    public class GetProductByIdhandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdhandler(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductById(request.Id); 
        }
    }
}
