using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace TRuth
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