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

         public ModExtension_DepressiveThoughts me_depressiveThoughts => 
             base.def.GetModExtension<ModExtension_DepressiveThoughts>();

         //public override string LabelCap => (string) this.CurStage.label.Formatted(this.depression.pawn.Named("HARMONIZER")).CapitalizeFirst();
        
         // public override void ExposeData()
         // {
         //     base.ExposeData();
         //     Scribe_References.Look<Hediff_Depression>(ref this.depression, "depression");
         // }
        
         public override float MoodOffset()
         {
             if (ThoughtUtility.ThoughtNullified(pawn, def) || pawn.Dead || pawn.needs?.mood == null || depression == null)
                 return 0.0f;
             
             this.SetForcedStage(depression.CurStageIndex);
             
             float sumOfPositiveThoughts = 0;
             float sumOfNegativeThoughts = 0;
             
             //pawn.needs.mood.thoughts.GetAllMoodThoughts(thoughts);
             
             List<Thought_Memory> memories = pawn.needs.mood.thoughts.memories.Memories;
             foreach (var thoughtMemory in memories)
             {
                 if (thoughtMemory == this) continue;
                 if (thoughtMemory.MoodOffset() > 0)
                     sumOfPositiveThoughts += thoughtMemory.MoodOffset();
                 else
                     sumOfNegativeThoughts += thoughtMemory.MoodOffset();
             }
             
             List<Thought> thoughts = new List<Thought>();
             pawn.needs.mood.thoughts.situational.AppendMoodThoughts(thoughts);
             foreach (var thought in thoughts)
             {
                 if (thought.MoodOffset() > 0)
                     sumOfPositiveThoughts += thought.MoodOffset();
                 else
                     sumOfNegativeThoughts += thought.MoodOffset();
             }
             
             
             // float depressedthoughtsgood = -1f * (sumOfPositiveThoughts 
             //                                      - sumOfPositiveThoughts * me_depressiveThoughts.goodThoughtsMultiplier[CurStageIndex]);
             // float depressedthoughtsbad = (-1f * sumOfNegativeThoughts)
             //                              + sumOfNegativeThoughts * me_depressiveThoughts.badThoughtsMultiplier[CurStageIndex];
             float depressedthoughtsgood = -1f * (1 - me_depressiveThoughts.goodThoughtsMultiplier[CurStageIndex]) * sumOfPositiveThoughts;
             float depressedthoughtsbad = sumOfNegativeThoughts * me_depressiveThoughts.badThoughtsMultiplier[CurStageIndex] - sumOfNegativeThoughts;
             
             return depressedthoughtsgood + depressedthoughtsbad;
             
         }
    }
}