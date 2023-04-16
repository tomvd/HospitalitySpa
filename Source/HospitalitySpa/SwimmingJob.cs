
using System.Collections.Generic;
using System.Linq;
using DubsBadHygiene;
using Verse.AI;

namespace HospitalitySpa
{

    public class JobDriver_GoSwimmingGuest : JobDriver_GoSwimming
    {
        public override IEnumerable<Toil> MakeNewToils()
        {
            var toils = base.MakeNewToils().ToList();
            Toil toil = new Toil
            {
                initAction = () =>
                {
                    VendingMachineJobHelper.InsertCoin(this.GetActor(), base.TargetA.Thing);
                }
            };
            toils.Insert(3, toil);
            return toils;
        }
    }

}