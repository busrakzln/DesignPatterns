﻿using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using System.Reflection.Metadata.Ecma335;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIDQueryResult Handle(GetProductByIDQuery query)
        {
            var values=_context.Set<Product>().Find(query.Id);

            return new GetProductByIDQueryResult
            {
                Name=values.Name,
                ProductID=values.ProductID,
                Price=values.Price,
                Stock=values.Stock
            };
        } 
    }
}
