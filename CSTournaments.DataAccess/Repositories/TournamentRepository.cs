using System;
using System.Collections.Generic;
using CSTournaments.Extensibility.DataAccess.Repositories;
using CSTournaments.Extensibility.Entities;

namespace CSTournaments.DataAccess.Repositories
{
    internal class TournamentRepository : ITournamentRepository
    {
        public List<Tournament> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(string tournamentName)
        {
            throw new NotImplementedException();
        }

        public Tournament Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}