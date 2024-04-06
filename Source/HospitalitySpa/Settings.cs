using UnityEngine;
using Verse;

namespace HospitalitySpa;

public class Settings : ModSettings
{
    public float EmptyAfterHours = 4f;
    public override void ExposeData()
    {
        Scribe_Values.Look(ref EmptyAfterHours, "emptyAfterHours", 4f);
        base.ExposeData();
    }

    public void DoWindowContents(Rect inRect)
    {
        Listing_Standard listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.SliderLabeled("HospitalitySpa_EmptyAfterHours".Translate(), ref EmptyAfterHours, EmptyAfterHours.ToString("0"), 0f, 24f,
            "HospitalitySpa_EmptyAfterHoursTooltip".Translate());
        listingStandard.End();
    }
}