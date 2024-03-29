﻿using CQRS.Application.Commands;
using CQRS.Data.Contracts;
using MediatR; 

namespace CQRS.Application.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           return await _productRepository.DeleteProduct(request.productId);
        }
    }
}
