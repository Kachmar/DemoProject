using System;

namespace CSTournaments.Extensibility.Exceptions
{
    public class CSTournamentDomainException : Exception
    {
        public CSTournamentDomainException(string message) : base(message)
        {
        }
    }
}