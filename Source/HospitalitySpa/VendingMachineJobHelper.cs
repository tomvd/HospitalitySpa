using System.Linq;
using Hospitality;
using RimWorld;
using Verse;

namespace HospitalitySpa
{
    public class VendingMachineJobHelper
	{

		public static bool CheckIfShouldPay(Pawn pawn, Thing slotMachine)
		{
			// only guests pay
			return (pawn.Faction != slotMachine.Faction);
		}
		public static int CountSilver(Pawn pawn)
		{
            if (pawn?.inventory?.innerContainer == null) return 0;
            return pawn.inventory.innerContainer.Where(s => s.def == ThingDefOf.Silver).Sum(s => s.stackCount);
		}

        public static bool CanPawnAffordThis(Pawn pawn, Thing vendingMachine)
        {
	        CompVendingMachine compVendingMachine = vendingMachine.TryGetComp<CompVendingMachine>();
	        if (compVendingMachine != null)
	        {
		        if (CheckIfShouldPay(pawn, vendingMachine))
		        {
			        // caravan pawns spent only 50% of their budget on hyhdrotherapy/ 50% on food/bed
			        if (CountSilver(pawn) < compVendingMachine.CurrentPrice * 2) 
			        {
				        Log.Message(pawn.NameShortColored + " wanted hyhdrotherapy, but could not afford it");
				        return false;
			        }
		        }
	        }

	        return true;
        }

		public static bool InsertCoin(Pawn pawn, Thing vendingMachineParent)
		{
			CompVendingMachine vendingMachine = vendingMachineParent.TryGetComp<CompVendingMachine>();
			if (vendingMachine != null && CheckIfShouldPay(pawn, vendingMachineParent))
			{
				var cash = pawn.inventory.innerContainer?.FirstOrDefault(t => t?.def == ThingDefOf.Silver);
				if (cash != null && cash.stackCount >= vendingMachine.CurrentPrice){
					//comp.TotalRevenue += vendingMachine.CurrentPrice;
					vendingMachine.ReceivePayment(pawn.inventory.innerContainer, cash);
				}
				else
				{
					return false;
				}
			}
			return true;
		}
	}
}