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
             base.def.GetModExtension<ModExtension_DepressiveThoughts>(); //Gets the mod extension from the Def
         
         public override float MoodOffset()
         {
             if (ThoughtUtility.ThoughtNullified(pawn, def) || pawn.Dead || pawn.needs?.mood == null || depression == null)
                 return 0.0f;
             
             this.SetForcedStage(depression.CurStageIndex);
             
             float sumOfPositiveThoughts = 0; //Total sum of positive mood offset
             float sumOfNegativeThoughts = 0; //Total sum of negative mood offset

             // Memory thoughts and Mood thoughts work slightly differently but are both relevant for this calculation
             List<Thought_Memory> memories = pawn.needs.mood.thoughts.memories.Memories;
             foreach (var thoughtMemory in memories)
             {
                 if (thoughtMemory == this) continue; // avoid recursion, the game breaks when this check is not there
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
             
             // calculates a the amount of negative mood from being unable to enjoy good things
             float depressedthoughtsgood = -1f * (1 - me_depressiveThoughts.goodThoughtsMultiplier[CurStageIndex]) * sumOfPositiveThoughts;
             // calculates the amount of negative mood from seeing bad events as more dire than they are
             float depressedthoughtsbad = sumOfNegativeThoughts * me_depressiveThoughts.badThoughtsMultiplier[CurStageIndex] - sumOfNegativeThoughts;
             
             //Total mood offset is a sum of both
             return depressedthoughtsgood + depressedthoughtsbad;
         }
    }
}