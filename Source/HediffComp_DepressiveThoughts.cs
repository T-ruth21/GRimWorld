using Verse;
using RimWorld;
using System.Collections.Generic;

namespace TRuth
{
    public class HediffComp_DepressiveThoughts : HediffComp
  {
    //public HediffCompProperties_DepressiveThoughts Props => (HediffCompProperties_DepressiveThoughts) this.props;

    public override void CompPostTick(ref float severityAdjustment)
    {
      base.CompPostTick(ref severityAdjustment);
      
      Pawn pawn = this.parent.pawn;
      if (pawn.IsHashIntervalTick(150) || pawn.needs?.mood == null || pawn.Faction == null)
        return;
      
      //HaveThought(pawn);
      
      // if (pawn.Spawned)
      // {
      //   List<Pawn> pawns = pawn.Map.mapPawns.SpawnedPawnsInFaction(pawn.Faction);
      //   this.AffectPawns(pawn, pawns);
      // }
      // else
      // {
      //   Caravan caravan = pawn.GetCaravan();
      //   if (caravan == null)
      //     return;
      //   this.AffectPawns(pawn, caravan.pawns.InnerListForReading);
      // }
    }

    private void HaveThought(Pawn pawn)
    {
      if (!pawn.RaceProps.Humanlike || pawn.needs?.mood?.thoughts == null) return;
      
      foreach (Thought_Memory memory in pawn.needs.mood.thoughts.memories.Memories)
      {
        if (memory is Thought_Depressed depressed)
        {
          return;
        }
      }
      //Thought_Depressed newThought = (Thought_Depressed) ThoughtMaker.MakeThought(this.Props.thought);
      //newThought.depression = (Hediff_Depression) this.parent;
      //pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory) newThought);
    }
    
    // private void AffectPawns(Pawn p, List<Pawn> pawns)
    // {
    //   for (int index = 0; index < pawns.Count; ++index)
    //   {
    //     Pawn pawn = pawns[index];
    //     if (p != pawn && p.RaceProps.Humanlike && pawn != null && pawn.needs != null && pawn.needs.mood != null && pawn.needs.mood.thoughts != null && (double) pawn.Position.DistanceTo(p.Position) <= (double) this.Props.range && !pawn.health.hediffSet.HasHediff(HediffDefOf.PsychicHarmonizer))
    //     {
    //       bool flag = false;
    //       foreach (Thought_Memory memory in pawn.needs.mood.thoughts.memories.Memories)
    //       {
    //         if (memory is Thought_PsychicHarmonizer psychicHarmonizer && psychicHarmonizer.harmonizer == this.parent)
    //         {
    //           flag = true;
    //           break;
    //         }
    //       }
    //       if (!flag)
    //       {
    //         Thought_PsychicHarmonizer newThought = (Thought_PsychicHarmonizer) ThoughtMaker.MakeThought(this.Props.thought);
    //         newThought.harmonizer = (Hediff) this.parent;
    //         newThought.otherPawn = this.parent.pawn;
    //         pawn.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory) newThought);
    //       }
    //     }
    //   }
    // }
    }
}