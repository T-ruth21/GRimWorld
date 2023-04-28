using System.Collections.Generic;
using RimWorld;
using Verse;

namespace Grimworld
{
    public static class SpiderUtility
    {
        public static bool ContainsStaticInsect(this IntVec3 position, Map map)
        {
            List<Thing> thingList = map.thingGrid.ThingsListAt(position);
            foreach (var thing in thingList)
            {
                if (thing is Pawn spider && spider.RaceProps.Insect)
                    return true;
            }
            return false;
        }

        public static bool ContainsStaticCampfire(this IntVec3 position, Map map)
        {
            List<Thing> thingList = map.thingGrid.ThingsListAt(position);
            foreach (var thing in thingList)
            {
                if (thing.def == ThingDefOf.Campfire)
                    return true;
            }
            return false;
        }
    }
}