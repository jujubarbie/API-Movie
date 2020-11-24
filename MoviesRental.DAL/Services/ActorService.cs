using ADOLibrary;
using MoviesRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MoviesRental.DAL.Services
{
    public class ActorService : BaseService<int, Actor>
    {
        public ActorService(Connection connection) : base(connection)
        {
        }
        /*
         * GET : 
         * - Get all
         * - Get all actors by Film id
         * - Get all Initials of actors
         * - Get all actors by initials
         */
        public override IEnumerable<Actor> GetAll()
        {
            Command cmd = new Command("GetAllActor", true);
            return Connection.ExecuteReader<Actor>(cmd, Converter);
        }

        public IEnumerable<Actor> GetAllByFilmId(int key) {
            Command cmd = new Command("GetAllActorByFilmId", true);
            cmd.AddParameter("IdFilm", key);
            return Connection.ExecuteReader<Actor>(cmd, Converter);
        }

        public IEnumerable<ActorInitials> GetAllInitials() {
            Command cmd = new Command("GetAllActorInitials", true);
            return Connection.ExecuteReader<ActorInitials>(cmd, ConverterInitials);
        }

        public IEnumerable<Actor> GetAllByInitial(char IFN)
        {
            Command cmd = new Command("GetAllActorByInitial", true);
            cmd.AddParameter("initialFN", IFN);
            return Connection.ExecuteReader<Actor>(cmd, Converter);

        }

        /* 
         * Converters :
         * - Actor
         * - ActorInitials
         **/
        private Actor Converter(SqlDataReader reader)
        {
            return new Actor (
                (int)reader["ActorId"],
                reader["FirstName"].ToString(), 
                reader["LastName"].ToString()
            );
        }

        private ActorInitials ConverterInitials(SqlDataReader reader)
        {
            return new ActorInitials(
                Char.Parse(reader["InitialFirstName"].ToString())
            );
        }

    }
}
