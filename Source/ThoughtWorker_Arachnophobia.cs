using RimWorld;
using Verse;

namespace Grimworld
{
    public class ThoughtWorker_Arachnophobia : ThoughtWorker
    {
        public const float InsectRadius = 19.9f;

        protected override ThoughtState CurrentStateInternal(Pawn pawn) => 
            !ModsConfig.BiotechActive
            || !NearInsect(pawn) ? ThoughtState.Inactive : ThoughtState.ActiveAtStage(0);

        public static bool NearInsect(Pawn pawn)
        {
            Map mapHeld = pawn.MapHeld;
            if (mapHeld == null)
                return false;
            IntVec3 positionHeld = pawn.PositionHeld;
            int num = GenRadial.NumCellsInRadius(InsectRadius);
            for (int index = 0; index < num; ++index)
            {
                IntVec3 intVec3 = pawn.Position + GenRadial.RadialPattern[index];
                if (intVec3.InBounds(mapHeld) && !intVec3.Fogged(mapHeld) && GenSight.LineOfSight(positionHeld, intVec3, mapHeld, true) && intVec3.ContainsStaticFire(mapHeld))
                    return true;
            }
            return false;
        }
    }
}