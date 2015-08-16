namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;
    public class Queen: Unit
    {
        public Queen(string id)
            :base(id, UnitClassification.Psionic, 30, 1, 1)
        {

        }
        //public void Infest(Unit unitToInfest)
        //{
        //    if (this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(unitToInfest.UnitClassification))
        //    {
        //        unitToInfest.AddSupplement(new InfestationSpores());
        //    }
        //}
        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }
        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;

            if (this.Id != unit.Id && this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification))
            {
                attackUnit = true;
            }

            return attackUnit;
        }
        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //This method finds the unit with the least power and attacks it
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 10000, int.MaxValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
