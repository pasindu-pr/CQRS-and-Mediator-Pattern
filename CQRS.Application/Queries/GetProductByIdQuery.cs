

using CQRS.Data.Entities;
using MediatR;

namespace CQRS.Application.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
