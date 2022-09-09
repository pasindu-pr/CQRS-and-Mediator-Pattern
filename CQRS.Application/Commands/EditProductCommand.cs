using CQRS.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Commands
{
    public class EditProductCommand: IRequest<Product>
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
