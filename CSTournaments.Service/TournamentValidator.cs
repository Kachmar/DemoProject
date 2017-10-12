using System;
using CSTournaments.Extensibility.Exceptions;
using CSTournaments.Extensibility.Service;

namespace CSTournaments.Service
{
    internal class TournamentValidator : ITournamentValidator
    {
        public void ValidateName(string tournamentName)
        {
            if (String.IsNullOrEmpty(tournamentName))
            {
                throw new CSTournamentDomainException("Tournament Name cannot be empty.");
            }
        }
    }
}