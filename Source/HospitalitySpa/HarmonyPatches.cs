using DubsBadHygiene;
using HarmonyLib;
using Verse;
using Verse.AI;

namespace HospitalitySpa
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var method = GenTypes.GetTypeInAnyAssembly("JoyGiver_UseHotTub", "DubsBadHygiene");
            if (method != null)
                HospitalitySpaMod.harmonyInstance.Patch(
                    AccessTools.Method(typeof(JoyGiver_UseHotTub), "TryGivePlayJob"),
                    prefix: new HarmonyMethod(typeof(HarmonyPatches), nameof(TryGivePlayJob_Prefix)));

            method = GenTypes.GetTypeInAnyAssembly("JoyGiver_GoSwimming", "DubsBadHygiene");
            if (method != null)
                HospitalitySpaMod.harmonyInstance.Patch(
                    AccessTools.Method(typeof(JoyGiver_GoSwimming), "TryGivePlayJob"),
                    prefix: new HarmonyMethod(typeof(HarmonyPatches), nameof(TryGivePlayJob_Prefix)));

            method = GenTypes.GetTypeInAnyAssembly("JoyGiver_UseSauna", "DubsBadHygiene");
            if (method != null)
                HospitalitySpaMod.harmonyInstance.Patch(AccessTools.Method(typeof(JoyGiver_UseSauna), "TryGivePlayJob"),
                    prefix: new HarmonyMethod(typeof(HarmonyPatches), nameof(TryGivePlayJob_Prefix)));
        }


        static bool TryGivePlayJob_Prefix(Pawn pawn, Thing t, ref Job __result)
        {
            if (!VendingMachineJobHelper.CanPawnAffordThis(pawn, t))
            {
                __result = null;
                return false;
            }

            return true;
        }
    }
}