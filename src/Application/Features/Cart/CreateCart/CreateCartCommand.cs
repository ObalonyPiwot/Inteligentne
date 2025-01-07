using MyProject.Application.Features.Common;
using MyProject.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cart.CreateCart
{
    public class CreateCartCommand : BaseRequest
    {
        public string ProductIds { get; set; } = null!;
    }
}
