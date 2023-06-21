using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace TRuth
{
    public class Hediff_Depression : HediffWithComps
    {
        public ModExtension_Hediff_Depression ModExtensionHediffDepression =>
            base.def.GetModExtension<ModExtension_Hediff_Depression>();
        
        
        public override void Tick() 
        {
            base.Tick(); // Execute base functionality
            
            HaveThought(); // Adds additional functionality by me
        }

        private void HaveThought()
        {
            //Only successfully instantiated pawns can have depressed thoughts
            if (pawn.IsHashIntervalTick(1500) || pawn.needs?.mood == null || pawn.Faction == null)
                return;
            
            if (!pawn.RaceProps.Humanlike || pawn.needs?.mood?.thoughts == null) return;

            //Tests if pawn already has the thought
            foreach (Thought_Memory memory in pawn.needs.mood.thoughts.memories.Memories)
            {
                if (memory is Thought_Depressed depressed)
                {
                    return;
                }
            }
            
            //If not, add depressed thoughts to them
            Thought_Depressed newThought = (Thought_Depressed) ThoughtMaker.MakeThought(this.ModExtensionHediffDepression.ThoughtDef);
            
            pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory) newThought);
            newThought.depression = this; // Link depression hediff and thought
        }
        
    }
}