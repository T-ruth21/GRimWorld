using System;
using Verse;
using Verse.AI;
using RimWorld;

namespace TRuth
{
    public class TRuth
    {
        public Hediff_Addiction requiredMentalIllness;
        public Hediff_Alcohol Alcohol;
        public MentalState mBreak;
        public ThinkNode_ConditionalMentalState state;
        public MentalState_WanderOwnRoom room;
        public JobGiver_WanderOwnRoom jroom;
        public ThoughtHandler Handler;
        public HediffStage stage;
        public HediffCompProperties_PsychicHarmonizer HediffCompPropertiesPsychicHarmonizer;
        public Thought_PsychicHarmonizer ThoughtPsychicHarmonizer;
        public HediffComp_PsychicHarmonizer PsychicHarmonizer;
        public HediffWithComps HediffWithComps;
        public Thought_OpinionOfMyLover op;
    }
}