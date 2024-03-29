﻿using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetOperationTypeByIdQuery : IRequest<OperationTypesViewModel>
    {
        public GetOperationTypeByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
