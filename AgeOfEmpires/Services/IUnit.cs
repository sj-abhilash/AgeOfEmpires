using AgeOfEmpires.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeOfEmpires.Services
{
    public interface IUnitService
    {
        public Task<List<Unit>> GetUnits();        
    }
}
