using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniTaskAssignment.Application.Commands;
using UniTaskAssignment.Application.Queries;

namespace UniTaskAssignment.Api.Controllers
{
    [Route("api/v1/invoices")]
    [ApiController]
    public class InvoiceController: BaseController
	{
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
		{
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> Post([FromBody] CreateOrEditInvoiceCommand command)
        {
            var result = await _mediator.Send(new CreateOrEditInvoiceCommand
            {
                DueDate = command.DueDate,
                InvoiceDate = command.InvoiceDate,
                Status = command.Status,
                Amount = command.Amount,
                CommandId = Guid.NewGuid()
            });

            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> All([FromQuery] GetInvoiceListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var query = new GetInvoiceQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}

