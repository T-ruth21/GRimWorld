using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace TRuth
{
    public class Thought_Depressed : Thought_Memory
    {
         public Hediff_Depression depression;

         //public override string LabelCap => (string) this.CurStage.label.Formatted(this.depression.pawn.Named("HARMONIZER")).CapitalizeFirst();
        
         // public override void ExposeData()
         // {
         //     base.ExposeData();
         //     Scribe_References.Look<Hediff_Depression>(ref this.depression, "depression");
         // }
        
         public override float MoodOffset()
         {
             if (ThoughtUtility.ThoughtNullified(pawn, def) || pawn.Dead || pawn.needs?.mood == null || depression?.depressiveThoughts == null)
                 return 0.0f;
             
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
        
             float depressedthoughtsgood = -1f * (sumOfPositiveThoughts - sumOfPositiveThoughts * depression.depressiveThoughts.goodThoughtsMultiplier); //depression.CurStage.goodThoughtsMultiplier);
             float depressedthoughtsbad = sumOfNegativeThoughts + sumOfNegativeThoughts * depression.depressiveThoughts.badThoughtsMultiplier;//depression.CurStage.badThoughtsMultiplier;
        
             
             Messages.Message("Depressed thoughts is: " + (depressedthoughtsbad + depressedthoughtsgood), MessageTypeDefOf.NeutralEvent);
             return (float)depressedthoughtsgood + depressedthoughtsbad;
             
             // double baseMoodOffset = (double) base.MoodOffset();
             // double otherMood = (double)Mathf.Lerp(-1f, 1f, this.depression.pawn.needs.mood.CurLevel);
             // float sensitivity = this.depression.pawn.GetStatValue(StatDefOf.PsychicSensitivity, cacheStaleAfterTicks: 1);
             //return (float) (baseMoodOffset * otherMood) * sensitivity;
         }
        
         // public override bool ShouldDiscard
         // {
         //     get
         //     {
         //         //Pawn pawn = depression.pawn;
         //         return pawn.health.Dead 
         //                || pawn.needs?.mood == null 
         //                || !this.pawn.health.hediffSet.HasHediff(HediffDefOfTRuth.TRuth_DepressiveEpisode);
         //     }
         // }
    }
}