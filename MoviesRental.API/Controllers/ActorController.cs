using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesRental.API.Infrastructure;
using MoviesRental.DAL.Models;
using MoviesRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AuthRequired]
    public class ActorController : ControllerBase
    {
        private readonly ActorService _service;
        private readonly ILogger _logger;           // mise en place pour le log 

        public ActorController(ILogger<ActorController> logger, ActorService service)
        {
            _service = service;
            _logger = logger;
        }


        /*
         * Get :
         * - Get all
         * - get all initials of actor
         * - Get all actors by initial
         * - Get all actor by film id
         */

        /*=======================================================================================================*/
        //[HttpGet]
        //public IEnumerable<Actor> GetAll()
        //{
        //    _logger.LogInformation("Get all du controlleur Actor appelé...");
        //    return _service.GetAll();
        //}

        /* Get ALL avec gestion erreur badrequest 
         * -> implique un retour IActionResult
         * -> a la consommation : gerer le code de retour (todo ?? bien mettre les code erreor dans la web api)
         */
        [HttpGet]
        public IActionResult GetAll() {
            try {
                _logger.LogInformation("### Controller Actor : Get all Actors called ...");
                // ne pas lancer directement le service.getall() 
                // dans le OK --> yield return , il faut consommer avec le ToList() pour declencher l'erreur ici
                IEnumerable<Actor> actors = _service.GetAll().ToList();
                return Ok(actors);

            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        /*=======================================================================================================*/
        [HttpGet]
        [Route("Initials")]
        public IEnumerable<ActorInitials> GetAllInitials()
        {
            return _service.GetAllInitials();
        }

        /*=======================================================================================================*/
        [HttpGet("ByInitials/{initialFN}")]
        public IActionResult GetAllByInitial(char initialFN)
        {
            try
            {
                _logger.LogInformation("### Controller Actor : Get all Actors by Initial called ...");
                IEnumerable<Actor> actors = _service.GetAllByInitial(initialFN).ToList();
                return Ok(actors);
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        /*=======================================================================================================*/
        [HttpGet("ByFilms/{IdFilm}")]
        public IActionResult GetAllByFilmId(int IdFilm) {
            try {
                _logger.LogInformation("### Controller Actor : Get all Actors by Film called ...");
                IEnumerable<Actor> actors = _service.GetAllByFilmId(IdFilm).ToList();
                return Ok(actors);
            } 
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
