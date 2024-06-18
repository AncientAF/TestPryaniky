using MediatR;

namespace TestPryaniky.Application.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull;
