using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyProject.Application.Features.Common;
using MyProject.Application.Features.Common.Commands.Create;
using MyProject.Application.Features.Products.Commands.CreateProduct;
using MyProject.Application.Models.Products;
using MyProject.Persistance.Authorization;
using MyProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cart.CreateCart
{
    public class CreateCartCommandHandler : CreateCommandHandler<CartEntity, CreateCartCommand>
    {
        public ICurrentUser _currentUser;
        public CreateCartCommandHandler(IMyProjectDbContext dbContext, IMapper mapper, ICurrentUser currentUser) : base(dbContext, mapper) {
            _currentUser = currentUser;
        }
        public override async Task<BaseResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<CartEntity>(request);
            entity.UserId = _currentUser.Id;
            await DbSet.AddAsync(entity, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            return new BaseResponse(statusCode: HttpStatusCode.Created);
        }
    }
}
