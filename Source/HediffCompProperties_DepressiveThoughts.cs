using Verse;
using RimWorld;

namespace TRuth
{
    public class HediffCompProperties_DepressiveThoughts : HediffCompProperties
    {
        public ThoughtDef thought;

        public HediffCompProperties_DepressiveThoughts()
        {
            this.compClass = typeof(HediffCompProperties_DepressiveThoughts);
        }
    }
}