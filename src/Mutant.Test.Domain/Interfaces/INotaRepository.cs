using PlaySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Interfaces
{
    public interface INotaRepository
    {
        void Add(Nota nota);
    }
}
