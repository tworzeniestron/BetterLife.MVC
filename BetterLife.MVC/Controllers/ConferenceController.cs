using AutoMapper;
using BetterLife.Application.Conference;
using BetterLife.Application.Conference.Commands.CreateConference;
using BetterLife.Application.Conference.Commands.EditConference;
using BetterLife.Application.Conference.Commands.Queries.GetAll;
using BetterLife.Application.Conference.Commands.Queries.GetConferenceByEncodedType;
using BetterLife.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetterLife.MVC.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ConferenceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var Conferences = await _mediator.Send(new GetAllQuery());
            return View(Conferences);
        }

        [Route("Conference/{encodedType}/Details")]
        
        public async Task<ActionResult> Details(string encodedType)
        {
            var dto = await _mediator.Send(new GetConferenceByEncodedType(encodedType));
            return View(dto);
        }
        [Route("Conference/{encodedType}/Edit")]
        public async Task<ActionResult> Edit(string encodedType)
        {
            var dto = await _mediator.Send(new GetConferenceByEncodedType(encodedType));

            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditConferenceCommand model = _mapper.Map<EditConferenceCommand>(dto);

            return View(model);
        }
        [HttpPost]
        [Route("Conference/{encodedType}/Edit")]
        public async Task<IActionResult> Edit(string encodedType, EditConferenceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles ="Organizer")]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Create(CreateConferenceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
