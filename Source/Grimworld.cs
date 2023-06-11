using System;
using System.Collections.Generic;
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
        public InteractionWorker_DeepTalk deepTalk;
        public InteractionWorker worker;
        public HediffGiver_Random giverRandom;
        public PawnRelationWorker_Lover workerLover;
        public DeathActionWorker deathActionWorker;
        public DeathActionWorker_Simple deathActionWorkerSimple;
        public HediffGiver_Event hediffGiverEvent;
        public HistoryEvent historyEvent;
        public HistoryEventsManager historyEventsManager;
        public ThoughtDef thoughtDef;
        public PawnRelationDef pawnRelationDef;
        public Hediff_PsychicBondTorn hediffPsychicBondTorn;
        public InteractionWorker_DeepTalk interactionWorkerDeepTalk;
        public InteractionWorker_KindWords interactionWorkerKindWords;
        public InteractionWorker_Breakup interactionWorkerBreakup;
        public PawnRelationWorker_Lover pawnRelationWorkerLover;

        // public List<IndividualThoughtToAdd> tmpIndividualThoughtsToAdd = new List<IndividualThoughtToAdd>();
        // public List<ThoughtToAddToAll> tmpAllColonistsThoughts = new List<ThoughtToAddToAll>();
        // public void TryGiveThoughts(
        //   Pawn victim,
        //   DamageInfo? dinfo,
        //   PawnDiedOrDownedThoughtsKind thoughtsKind)
        // {
        //   try
        //   {
        //     // if (PawnGenerator.IsBeingGenerated(victim) 
        //     //     || Current.ProgramState != ProgramState.Playing)
        //     //   return;
        //     //
        //     PawnDiedOrDownedThoughtsUtility.GetThoughts(victim, dinfo, thoughtsKind, PawnDiedOrDownedThoughtsUtility.tmpIndividualThoughtsToAdd, PawnDiedOrDownedThoughtsUtility.tmpAllColonistsThoughts);
        //     for (int index = 0; index < PawnDiedOrDownedThoughtsUtility.tmpIndividualThoughtsToAdd.Count; ++index)
        //       PawnDiedOrDownedThoughtsUtility.tmpIndividualThoughtsToAdd[index].Add();
        //     
        //     if (PawnDiedOrDownedThoughtsUtility.tmpAllColonistsThoughts.Any<ThoughtToAddToAll>())
        //     {
        //       foreach (Pawn podsAliveColonist in PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_Colonists)
        //       {
        //         if (podsAliveColonist != victim)
        //         {
        //           for (int index = 0; index < PawnDiedOrDownedThoughtsUtility.tmpAllColonistsThoughts.Count; ++index)
        //             PawnDiedOrDownedThoughtsUtility.tmpAllColonistsThoughts[index].Add(podsAliveColonist);
        //         }
        //       }
        //     }
        //     
        //     
        //     PawnDiedOrDownedThoughtsUtility.tmpIndividualThoughtsToAdd.Clear();
        //     PawnDiedOrDownedThoughtsUtility.tmpAllColonistsThoughts.Clear();
        //     
        //     // if ((!dinfo.HasValue ? 0 : (dinfo.Value.Def.execution ? 1 : 0)) != 0 || thoughtsKind != PawnDiedOrDownedThoughtsKind.Died || !victim.IsPrisonerOfColony)
        //     //   return;
        //     //
        //     // //if prisoner died
        //     // Pawn responsibleColonist = PawnDiedOrDownedThoughtsUtility.FindResponsibleColonist(victim, dinfo);
        //     // if (!victim.guilt.IsGuilty && !victim.InAggroMentalState)
        //     //   Find.HistoryEventsManager.RecordEvent(new HistoryEvent(HistoryEventDefOf.InnocentPrisonerDied, responsibleColonist.Named(HistoryEventArgsNames.Doer)));
        //     // else
        //     //   Find.HistoryEventsManager.RecordEvent(new HistoryEvent(HistoryEventDefOf.GuiltyPrisonerDied, responsibleColonist.Named(HistoryEventArgsNames.Doer)));
        //     // Find.HistoryEventsManager.RecordEvent(new HistoryEvent(HistoryEventDefOf.PrisonerDied, responsibleColonist.Named(HistoryEventArgsNames.Doer)));
        //   }
        //   catch (Exception ex)
        //   {
        //     Log.Error("Could not give thoughts: " + (object) ex);
        //   }
        // }
    }
}