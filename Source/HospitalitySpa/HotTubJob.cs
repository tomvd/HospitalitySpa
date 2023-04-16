
using System.Collections.Generic;
using System.Linq;
using DubsBadHygiene;
using Verse.AI;

namespace HospitalitySpa
{

    public class JobDriver_UseHotTubGuest : JobDriver_UseHotTub
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
            toils.Insert(2, toil);
            return toils;
        }
    }

}