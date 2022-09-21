using FluentValidation;
using GevangenisOef.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GevangenisOef.Controller
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {

        private HttpStatusCode _statusCode = HttpStatusCode.OK;
        private readonly IMediator _mediator;
        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }

        #region Execute requests
        protected Task<IActionResult> ExecutePostRequest<T>(IRequest<T> request)
        {
            _statusCode = HttpStatusCode.Created;
            return ExecuteRequest<T>(request);
        }
        protected Task<IActionResult> ExecutePutRequest<T>(IRequest<T> request)
        {
            _statusCode = HttpStatusCode.OK;
            return ExecuteRequest<T>(request);
        }
        protected Task<IActionResult> ExecuteDeleteRequest<T>(IRequest<T> request)
        {
            _statusCode = HttpStatusCode.OK;
            return ExecuteRequest<T>(request);
        }
        #endregion

        protected async Task<IActionResult> ExecuteRequest<T>(IRequest<T> request)
        {
            var response = new Response<T>();
            try
            {
                if (request == null) throw new NullReferenceException("The received request cannot be null");
                var result = await _mediator.Send(request);
                response = new Response<T>(_statusCode, result);
                return StatusCode((int)_statusCode, response);
            }
            catch (NullReferenceException nex)
            {
                _statusCode = HttpStatusCode.BadRequest;
                response = new Response<T>(_statusCode, "OOps, Gevangenis has the hickups", new string[] { nex.Message });
            }
            catch (ValidationException vex)
            {
                _statusCode = HttpStatusCode.BadRequest;
                response = new Response<T>(_statusCode, "OOps, nice try", new string[] { vex.Message });
            }
            catch (Exception ex)
            {
                _statusCode = HttpStatusCode.InternalServerError;
                response = new Response<T>(_statusCode, "Try later again", new string[] { ex.Message });
            }

            return StatusCode((int)_statusCode, response);
        }
    }
}
