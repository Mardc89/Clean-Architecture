using App.DTO;
using App.Presenters;
using App.UseCasePorts;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatePersonController:ControllerBase
    {
        private readonly ICreatePersonInputPort InputPort;
        private readonly ICreatePersonOutputPort OutputPort;
        private readonly IValidator<CreatePersonDTO> _validator;

        public CreatePersonController(ICreatePersonInputPort inputPort, ICreatePersonOutputPort outputPort, IValidator<CreatePersonDTO> validator)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody]CreatePersonDTO person)
        {
            var validatorResult= await _validator.ValidateAsync(person);

            if (!validatorResult.IsValid) {
                var errores= validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(new {Errores=errores});
            }


            await InputPort.Handle(person);

            var result= ((IPresenter<PersonDTO>)OutputPort).Content;

            return Ok(result);


        }

    }
}