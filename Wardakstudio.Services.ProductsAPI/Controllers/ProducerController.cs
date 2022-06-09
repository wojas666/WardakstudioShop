using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Responses;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands;

namespace Wardakstudio.Services.ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProducerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProducerDto>>> Get()
        {
            var producers = await _mediator.Send(new GetProducersListRequest());
            return Ok(producers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProducerDto>> Get(int id)
        {
            var producer = await _mediator.Send(new GetProducerDetailsRequest() { Id = id });
            return Ok(producer);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody]CreateProducerDto producer)
        {
            var command = new CreateProducerCommand() { ProducerDto = producer };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT: api/<ProducerController>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody]UpdateProducerDto producer)
        {
            var command = new UpdateProducerCommand() { ProducerToUpdate = producer };
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProducerCommand() { ProducerId = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
