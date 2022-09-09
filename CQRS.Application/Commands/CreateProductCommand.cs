using CQRS.Data.Entities;
using MediatR;

namespace CQRS.Application.Commands
{
    public class CreateProductCommand: IRequest<Product>
    {        
        public Product Product { get; set; }

    }
}
