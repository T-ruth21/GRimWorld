using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace TRuth
{
    public class JobGiver_FleeSpider : ThinkNode_JobGiver
    {
        private const int MinSpidersNearbyRadius = 20;
        private const int MinSpidersNearbyRegionsToScan = 18;
        private const int DistToSpiderToFlee = 20;

        protected override Job TryGiveJob(Pawn pawn)
        {
            // pawn.Map.listerThings.ThingsInGroup(ThingRequestGroup.Pawn);
            // TraverseParms traverseParms = TraverseParms.For(pawn);
            // Thing closestInsect = (Thing) null;
            // float closestDistSq = -1f;
            // RegionTraverser.BreadthFirstTraverse(
            //     pawn.Position, 
            //     pawn.Map, 
            //     (RegionEntryPredicate) ((from, to) => to.Allows(traverseParms, false)), 
            //     (RegionProcessor) (x =>
            //     {
            //         List<Thing> thingList = x.ListerThings.ThingsInGroup(ThingRequestGroup.Pawn);
            //         foreach (var thing in thingList)
            //         {
            //             if (thing is Pawn spider && spider.RaceProps.Insect)
            //                 continue;
            //             
            //             float squared = (float) pawn.Position.DistanceToSquared(thing.Position);
            //             if (!(squared <= Mathf.Pow(MinSpidersNearbyRadius, 2)) || (closestInsect != null && !(squared < closestDistSq))) 
            //                 continue;
            //             
            //             closestDistSq = squared;
            //             closestInsect = thing;
            //         }
            //         return (double) closestDistSq <= MinSpidersNearbyRadius;
            //     }), 
            //     MinSpidersNearbyRegionsToScan);
            //
            // if (closestInsect != null && (double) closestDistSq <= DistToSpiderToFlee)
            // {
            //     Job job = JobGiver_AnimalFlee.FleeJob(pawn, closestInsect);
            //     if (job != null)
            //         return job;
            // }
            return (Job) null;
        }
    }
}