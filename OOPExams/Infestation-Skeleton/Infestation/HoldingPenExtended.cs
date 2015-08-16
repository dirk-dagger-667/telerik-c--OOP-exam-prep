using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class HoldingPenExtended: HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            base.ExecuteInsertUnitCommand(commandWords);

            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                default:
                    break;
            }
        }
        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            Unit targetUnit = this.GetUnit(interaction.TargetUnit);

            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
                case InteractionType.Infest:
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    break;
            }
        }
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Weapon":
                    this.GetUnit(commandWords[2]).AddSupplement(new Weapon());
                    break;
                case "AggressionCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new AggressionCatalyst());
                    break;
                case "PowerCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new PowerCatalyst());
                    break;
                case "HealthCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new HealthCatalyst());
                    break;
                default:
                    break;
            }
        }
    }
}
