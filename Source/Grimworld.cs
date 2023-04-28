using System;
using Verse;
using Verse.AI;
using RimWorld;

namespace Grimworld
{
    public class Grimworld
    {
        public Hediff_Addiction requiredMentalIllness;
        public Hediff_Alcohol Alcohol;
        public MentalState mBreak;
        public ThinkNode_ConditionalMentalState state;
        public MentalState_WanderOwnRoom room;
        public JobGiver_WanderOwnRoom jroom;
        public ThoughtHandler Handler;
    }
}