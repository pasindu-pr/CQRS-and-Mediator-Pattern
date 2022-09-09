using CQRS.Application.Commands;
using CQRS.Data.Contracts;
using CQRS.Data.Entities;
using MediatR; 


namespace CQRS.Application.Handlers
{
    internal class EditProductHandler : IRequestHandler<EditProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public EditProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.UpdateProduct(request.ProductId,request.Product);
        }
    }
}
