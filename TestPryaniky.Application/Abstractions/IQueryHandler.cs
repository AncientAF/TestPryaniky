using MediatR;

namespace TestPryaniky.Application.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse> 
    where TResponse : notnull;