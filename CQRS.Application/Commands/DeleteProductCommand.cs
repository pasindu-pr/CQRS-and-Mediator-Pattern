using MediatR; 

namespace CQRS.Application.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int productId { get; set; }
    }
}
