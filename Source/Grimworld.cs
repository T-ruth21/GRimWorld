using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;
using UnityEngine;

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
        public MonoBehaviour monoBehaviour;

        // Exception ticking Froy (at (0, 0, 172)): System.NullReferenceException: Object reference not set to an instance of an object
        //     at TRuth.PATCH_InteractionWorker_Interacted.Postfix (RimWorld.InteractionWorker __instance, Verse.Pawn initiator, Verse.Pawn recipient, System.Collections.Generic.List`1[T] extraSentencePacks, System.String& letterText, System.String& letterLabel, Verse.LetterDef& letterDef, Verse.LookTargets& lookTargets) [0x0005c] in <3cccd65a32ec407a91b52012787b3a97>:0 
        // at (wrapper dynamic-method) RimWorld.InteractionWorker.RimWorld.InteractionWorker.Interacted_Patch1(RimWorld.InteractionWorker,Verse.Pawn,Verse.Pawn,System.Collections.Generic.List`1<Verse.RulePackDef>,string&,string&,Verse.LetterDef&,Verse.LookTargets&)
        // at RimWorld.Pawn_InteractionsTracker.TryInteractWith (Verse.Pawn recipient, RimWorld.InteractionDef intDef) [0x00198] in <95de19971c5d40878d8742747904cdcd>:0 
        // at RimWorld.Pawn_InteractionsTracker.TryInteractRandomly () [0x000d7] in <95de19971c5d40878d8742747904cdcd>:0 
        // at RimWorld.Pawn_InteractionsTracker.InteractionsTrackerTick () [0x0008d] in <95de19971c5d40878d8742747904cdcd>:0 
        // at Verse.Pawn.Tick () [0x00177] in <95de19971c5d40878d8742747904cdcd>:0 
        // at Verse.TickList.Tick () [0x0015c] in <95de19971c5d40878d8742747904cdcd>:0 
        // UnityEngine.StackTraceUtility:ExtractStackTrace ()
        // Verse.Log:Error (string)
        // Verse.TickList:Tick ()
        // Verse.TickManager:DoSingleTick ()
        // Verse.TickManager:TickManagerUpdate ()
        // Verse.Game:UpdatePlay ()
        // Verse.Root_Play:Update ()

    }
}