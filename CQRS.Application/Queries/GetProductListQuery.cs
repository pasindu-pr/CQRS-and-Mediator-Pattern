using CQRS.Data.Entities;
using MediatR;

namespace CQRS.Application.Queries
{
    public class GetProductListQuery: IRequest<List<Product>>
    {
    }
}
