using RimWorld;
using Verse;

namespace TRuth
{
    public static class DepressionUtility
    {
        public static void AddDepression(Pawn pawn, float chance, float initSeverity = 0.2f)
        {
            Hediff_Depression depression = pawn.health.hediffSet.GetFirstHediff<Hediff_Depression>();

            if (depression == null)
            {
                if (Rand.Value <= chance)
                {
                    depression = (Hediff_Depression)pawn.health.AddHediff(HediffDefOfTRuth.TRuth_DepressiveEpisode, pawn.health.hediffSet.GetBrain());
                    depression.Severity = initSeverity;
                }
            }
            else
            {
                HealthUtility.AdjustSeverity(pawn, depression.def, 0.2f);
            }
        }
    }
}