using MediatR;

namespace MediatorPipelines.Mediator.OtherRequest;

public class SomeOtherQuery : IRequest<bool>
{
    
}

public class SomeOtherQueryHandler : IRequestHandler<SomeOtherQuery, bool>
{
    public async Task<bool> Handle(SomeOtherQuery request, CancellationToken cancellationToken)
    {
        // the request handler is not aware of the pipeline behaviour
        return true;
    }
}