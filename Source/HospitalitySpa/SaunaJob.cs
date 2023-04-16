
using System.Collections.Generic;
using System.Linq;
using DubsBadHygiene;
using Verse.AI;

namespace HospitalitySpa
{

    public class JobDriver_UseSaunaGuest : JobDriver_UseSauna
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
            toils.Insert(1, toil);
            return toils;
        }
    }

}