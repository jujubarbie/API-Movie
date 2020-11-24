using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesRental.DAL.Models;
using MoviesRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly FilmService _service;

        public FilmController(FilmService service)
        {
            _service = service;
        }

        /*
         * Get :
         * - Get all
         * - Get all films Short Info
         * - get all Films Full Info
         * - get all films by categorie id
         * - get all films by actor id
         * - get all films by keywords
         */
        //todo : get by words

        [HttpGet]
        public IEnumerable<Film> GetAll() {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("FilmShort")]
        public IEnumerable<FilmShort> GetAllShort() {
            return _service.GetAllFilmShort();
        }

        [HttpGet]
        [Route("FilmFull")]
        public IEnumerable<FilmFull> GetAllFull()
        {
            return _service.GetAllFilmFull();
        }

        [HttpGet("Category/{CategorieId}")]
        public IEnumerable<FilmShort> GetAllFSByCatId(int CategorieId) {
            return _service.GetAllFSByCategoryId(CategorieId);
        }

        [HttpGet("Title/{Title}")]
        public IEnumerable<FilmShort> GetAllFSByTitle(string Title)
        {
            return _service.GetAllFSByTitle(Title);
        }

        [HttpGet("Langue/{LanguageId}")]
        public IEnumerable<FilmShort> GetAllFSByLanguageId(int LanguageId)
        {
            return _service.GetAllFSByLanguageId(LanguageId);
        }

        [HttpGet("ByActor/{ActorId}")]
        public IEnumerable<FilmShort> GetAllFSByActorId(int ActorId) {
            return _service.GetAllFSByActorId(ActorId);
        }


        [HttpGet("ByKeywords/{KeyWords}")] 

        public IEnumerable<FilmShort> GetAllFSByKeyWords(string KeyWords)
        {
            return _service.GetAllFSByKeyWords(KeyWords);
        }

        [HttpGet("{Id}")]
        public FilmFull GetById(int Id) {
            return _service.GetFilmById(Id);
        }

    }
}
