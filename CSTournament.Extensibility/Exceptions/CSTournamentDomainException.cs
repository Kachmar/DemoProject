using System;

namespace CSTournament.Extensibility.Exceptions
{
    public class CSTournamentDomainException : Exception
    {
        public CSTournamentDomainException(string message) : base(message)
        {
        }
    }
}