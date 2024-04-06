using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace HospitalitySpa
{
	public class MyDefs
	{
		static MyDefs()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(MyDefs));
		}

		public static ThoughtDef CheapSpa;
		public static ThoughtDef ExpensiveSpa;
		public static JobDef HospitalitySpa_EmptyVendingMachine;
	}

	[StaticConstructorOnStartup]
	public class HospitalitySpaMod : Mod
	{
		public static Settings Settings;
		
		public HospitalitySpaMod(ModContentPack content) : base(content)
		{
			Settings = GetSettings<Settings>();
            harmonyInstance = new Harmony("Adamas.HospitalitySpa");
            harmonyInstance.PatchAll();
        }

        public static Harmony harmonyInstance;
        
        
        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
	        Settings.DoWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {
	        return "Hospitality: Spa";
        }        
	}
}