using HarmonyLib;
using Verse;

namespace HospitalitySpa
{

	[StaticConstructorOnStartup]
	public class HospitalitySpaMod : Mod
	{
		public HospitalitySpaMod(ModContentPack content) : base(content)
		{
            harmonyInstance = new Harmony("Adamas.HospitalitySpa");
            harmonyInstance.PatchAll();
        }

        public static Harmony harmonyInstance;			
	}
}