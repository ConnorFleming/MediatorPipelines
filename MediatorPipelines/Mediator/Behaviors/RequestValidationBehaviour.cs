using System.ComponentModel.DataAnnotations;
using MediatorPipelines.Models;
using MediatR;

namespace MediatorPipelines.Mediator.Behaviors;

// define a request interface that will be implemented by all requests that need to be validated
public interface IValidatedRequest
{
    // properties used or added by the pipeline behaviour
    public User ValidatedUser { get; set; }
}

// implement a mediatr pipeline behaviour that validates the request
public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IValidatedRequest
{
    private readonly ILogger<RequestValidationBehavior<TRequest, TResponse>> _logger;

    public RequestValidationBehavior(ILogger<RequestValidationBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
        // any other required services i.e. dbcontext
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("validating gm request");
        
        // some actual validation logic
        if (1 == 0)
        {
            _logger.LogInformation("request is invalid");
            throw new ValidationException("request is invalid");
        }

        // add some properties to the request
        request.ValidatedUser = new User
        {
            Username = "i come from pipeline"
        };

        _logger.LogInformation("Request is valid, continuing...");
        
        return await next();
    }
}