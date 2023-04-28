using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace Grimworld
{
    public class ThoughtWorker_DepressedThoughts : Thought_Memory
    {
        // protected override ThoughtState CurrentStateInternal(Pawn pawn)
        // {
        //     return pawn.health.hediffSet.HasHead ? ThoughtState.ActiveAtStage(0) : ThoughtState.Inactive;
        // }
        
        //protected override ThoughtState CurrentStateInternal(Pawn pawn)
        //{
            // Hediff firstHediffOfDef = p.health.hediffSet.GetFirstHediffOfDef(this.def.hediff);
            // if (firstHediffOfDef == null || firstHediffOfDef.def.stages == null)
            //     return ThoughtState.Inactive;
            // return ThoughtState.ActiveAtStage(Mathf.Min(new int[3]
            // {
            //     firstHediffOfDef.CurStageIndex,
            //     firstHediffOfDef.def.stages.Count - 1,
            //     this.def.stages.Count - 1
            // }));
        
            // if (! pawn.GetHediff(HediffDefOf.Depression))
            //     return ThoughtState.Inactive;

        //}
        public Hediff depression;
        
        public override string LabelCap => (string) this.CurStage.label.Formatted(this.depression.pawn.Named("HARMONIZER")).CapitalizeFirst();

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_References.Look<Hediff>(ref this.depression, "depression");
        }
        
        public override float MoodOffset()
        {
            if (ThoughtUtility.ThoughtNullified(this.pawn, this.def) || this.ShouldDiscard)
                return 0.0f;
            
            double baseMoodOffset = (double) base.MoodOffset();
            double otherMood = (double)Mathf.Lerp(-1f, 1f, this.depression.pawn.needs.mood.CurLevel);
            float statValue = this.depression.pawn.GetStatValue(StatDefOf.PsychicSensitivity, cacheStaleAfterTicks: 1);

            //return (float) (baseMoodOffset * otherMood) * statValue;
            
            
            float sumOfPositiveThoughts = 0;
            float sumOfNegativeThoughts = 0;
            

            Thought thought1 = new Thought_KilledInnocentAnimal();
            List<Thought> thoughts = new List<Thought>();
            pawn.needs.mood.thoughts.GetMoodThoughts(thought1, thoughts);
            
            foreach (var thought in thoughts)
            {
                if (thought.CurStage.baseMoodEffect > 0)
                    sumOfPositiveThoughts += thought.CurStage.baseMoodEffect;
                else
                    sumOfNegativeThoughts += thought.CurStage.baseMoodEffect;
            }

            float depressedthoughtsgood = -1f * (sumOfPositiveThoughts - sumOfPositiveThoughts * 0.9f); //depression.CurStage.goodThoughtsMultiplier);
            float depressedthoughtsbad = sumOfNegativeThoughts + sumOfNegativeThoughts * 1;//depression.CurStage.badThoughtsMultiplier;

            return (float)depressedthoughtsgood + depressedthoughtsbad;
        }
        
        public override bool ShouldDiscard
        {
            get
            {
                Pawn pawn = depression.pawn;
                if (pawn.health.Dead ||
                    pawn.needs == null ||
                    pawn.needs.mood == null ||
                    !this.pawn.health.hediffSet.HasHediff(HediffDefOfGRimWorld.Depression))
                    return true;
                return false;
            }
        }
    }
}