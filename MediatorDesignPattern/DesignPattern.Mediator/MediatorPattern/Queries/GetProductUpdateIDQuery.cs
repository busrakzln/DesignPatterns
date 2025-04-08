
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Queries
{
    public class GetProductUpdateIDQuery:IRequest<UpdateProductByIDQueryResult>
    {
        public GetProductUpdateIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
