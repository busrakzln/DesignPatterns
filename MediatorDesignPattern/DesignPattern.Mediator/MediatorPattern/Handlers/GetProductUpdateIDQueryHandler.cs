﻿using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Queries;
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
    public class GetProductUpdateIDQueryHandler : IRequestHandler<GetProductUpdateIDQuery, UpdateProductByIDQueryResult>
    {
        private readonly Context _context;

        public GetProductUpdateIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<UpdateProductByIDQueryResult> Handle(GetProductUpdateIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.Id);
            return new UpdateProductByIDQueryResult
            {
                ProductID=values.ProductID,
                ProductName=values.ProductName,
                ProductCategory=values.ProductCategory,
                ProductPrice=values.ProductPrice,
                ProductStock=values.ProductStock,
                ProductStockType=values.ProductStockType
            };
        }
    }
}
