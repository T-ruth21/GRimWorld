using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace TRuth
{
    public class Hediff_Depression : HediffWithComps
    {
        public bool Panic = false;

        public ModExtension_Hediff_Depression ModExtensionHediffDepression =>
            base.def.GetModExtension<ModExtension_Hediff_Depression>();
        
        //public virtual HediffStage CurStage => !this.def.stages.NullOrEmpty<HediffStage>() ? this.def.stages[this.CurStageIndex] : (HediffStage) null;
        
        // public Hediff_Depression(float initialSeverity)
        // {
        //     this.Severity = initialSeverity;
        // }
        
        public override void Tick()
        {
            base.Tick();
            
            HaveThought();
            HavePanic();
        }

        private void HaveThought()
        {
            if (pawn.IsHashIntervalTick(1500) || pawn.needs?.mood == null || pawn.Faction == null)
                return;
            
            if (!pawn.RaceProps.Humanlike || pawn.needs?.mood?.thoughts == null) return;
      
            foreach (Thought_Memory memory in pawn.needs.mood.thoughts.memories.Memories)
            {
                if (memory is Thought_Depressed depressed)
                {
                    return;
                }
            }
            
            Thought_Depressed newThought = (Thought_Depressed) ThoughtMaker.MakeThought(this.ModExtensionHediffDepression.ThoughtDef);
            
            pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory) newThought);
            newThought.depression = this;
        }

        private void HavePanic()
        {
            if(!pawn.Downed)
            {
                switch ((pawn.GetHashCode() ^ (GenLocalDate.DayOfYear(pawn) + GenLocalDate.Year(pawn) + (int)(GenLocalDate.DayPercent(pawn) * 5) * 60) * 391) % (50 * (13 - ((this.CurStageIndex + 1) * 2))))
                {
                    case 0:
                        Panic = true;
                        this.Severity += 0.00000002f;
                        if (pawn.Spawned && pawn.RaceProps.Humanlike)
                        {
                            if (pawn.jobs.curJob.def != JobDefOf.FleeAndCower && !pawn.jobs.curDriver.asleep)
                            {
                                pawn.jobs.StartJob(new Job(JobDefOf.FleeAndCower, pawn.Position), JobCondition.InterruptForced, null, false, true, null);
                            }
                            else if (pawn.jobs.curDriver.asleep)
                            {
                                //pawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtDefOfPsychology.DreamNightmare);
                            }
                        }
                        break;
                    default:
                        Panic = false;
                        break;
                }
            }
            else
            {
                Panic = false;
            }
        }
    }
}