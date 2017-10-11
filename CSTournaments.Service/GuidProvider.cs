using System;
using CSTournament.Extensibility.DataAccess;

namespace CSTournaments.Service
{
    internal class GuidProvider : IGuidProvider
    {
        public Guid GetGuid()
        {
            return new Guid();
        }
    }
}