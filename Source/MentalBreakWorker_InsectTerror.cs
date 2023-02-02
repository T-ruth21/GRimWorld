using RimWorld;
using Verse;
using Verse.AI;

namespace Grimworld
{
    public class MentalBreakWorker_InsectTerror : MentalBreakWorker
    {
        public override bool BreakCanOccur(Pawn pawn)
        {
            return pawn.Spawned
                   && base.BreakCanOccur(pawn)
                   && ThoughtWorker_Arachnophobia.NearInsect(pawn);
        }
    }
}