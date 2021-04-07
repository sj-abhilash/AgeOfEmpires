using AgeOfEmpires.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeOfEmpires.Services
{
    public class BattleService : IBattleService
    {
        private readonly IUnitService _unitservice;

        public BattleService(IUnitService unitservice)
        {
            _unitservice = unitservice;
        }

        /// <summary>
        /// This method returns the Battle result of two random Units.
        /// </summary>
        /// <returns></returns>
        public async Task<Battle> GetUnitsBattle()
        {
            Battle battle = null;
            try
            {
                battle = new Battle();
                List<Unit> Unit = await _unitservice.GetUnits();
                if (Unit != null)
                    battle.Units = Unit;
                else
                    return null;

                if ((Unit[0].hit_points / Unit[1].attack) < (Unit[1].hit_points / Unit[0].attack))
                    battle.superior = Unit[0].name;
                else
                    battle.superior = Unit[1].name;
            }
            catch (Exception ex)
            {
                return null;
            }
            return battle;
        }
    }
}
