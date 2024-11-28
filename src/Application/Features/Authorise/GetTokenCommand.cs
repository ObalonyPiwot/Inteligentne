﻿using Domain.Authorization;
using MediatR;
using MyProject.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorise
{
    public class GetTokenCommand: IRequest<BaseResponse<TokenViewModel>>
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

}
