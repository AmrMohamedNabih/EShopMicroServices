

using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommendHandler<in TCommand> : ICommendHandler<TCommand, Unit> where TCommand : ICommend<Unit>
    {
    }
    public interface ICommendHandler<in TCommand, TReasponse> : IRequestHandler<TCommand, TReasponse> where TCommand : ICommend<TReasponse> where TReasponse : notnull 
    {
    }
}
