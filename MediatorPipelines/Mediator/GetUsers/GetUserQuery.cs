using MediatorPipelines.Mediator.Behaviors;
using MediatorPipelines.Models;
using MediatR;

namespace MediatorPipelines.Mediator.GetUsers;

public class GetUserQuery : IRequest<User>, IValidatedRequest
{
    // normal request properties
    public int Id { get; }

    public GetUserQuery(int id)
    {
        Id = id;
    }

    // properties added by pipeline behaviour
    public User ValidatedUser { get; set; }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    private readonly ILogger<GetUserQueryHandler> _logger;

    public GetUserQueryHandler(ILogger<GetUserQueryHandler> logger)
    {
        _logger = logger;
    }

    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Group manager username is {request.ValidatedUser.Username}");
        
        // some actual implementation
        
        return new User
        {
            Id = request.Id,
            Username = "test",
            Country = "US",
            Email = "test@test.test"
        };
    }
}