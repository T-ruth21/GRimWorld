using RimWorld;
using Verse;

namespace TRuth
{
    public class ThoughtWorker_CampfireCozyness : ThoughtWorker
    {
        public const float CampfireRadius = 6;
    
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (NearCampfire(p) 
                && !(ModsConfig.BiotechActive 
                     && p.genes != null 
                     && p.genes.HasGene(GeneDefOf.FireTerror)))
                return ThoughtState.ActiveAtStage(0);
            return ThoughtState.Inactive;
        }
    
        public static bool NearCampfire(Pawn pawn)
        {
            Map mapHeld = pawn.MapHeld;
            if (mapHeld == null)
                return false;
            IntVec3 positionHeld = pawn.PositionHeld;
            int num = GenRadial.NumCellsInRadius(CampfireRadius);
            for (int index = 0; index < num; ++index)
            {
                IntVec3 intVec3 = pawn.Position + GenRadial.RadialPattern[index];
                if (intVec3.InBounds(mapHeld) && !intVec3.Fogged(mapHeld) && GenSight.LineOfSight(positionHeld, intVec3, mapHeld, true) 
                    && intVec3.ContainsStaticCampfire(mapHeld))
                    return true;
            }
            return false;
        }
    }
}