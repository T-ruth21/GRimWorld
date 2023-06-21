using Verse;
using HarmonyLib;
using RimWorld;
using System.Collections.Generic;

namespace TRuth
{
    [HarmonyPatch(typeof(PawnDiedOrDownedThoughtsUtility), "AppendThoughts_Relations")]
    internal static class PATCH_PawnDiedOrDownedThoughtsUtility_AppendThoughts_Relations
    {
        [HarmonyPostfix]
        public static void Postfix(ref Pawn victim,
            ref DamageInfo? dinfo,
            ref PawnDiedOrDownedThoughtsKind thoughtsKind,
            ref List<IndividualThoughtToAdd> outIndividualThoughts,
            ref List<ThoughtToAddToAll> outAllColonistsThoughts)
        {
            if (thoughtsKind != PawnDiedOrDownedThoughtsKind.Died)
            {
                Log.Message("Thought kind was: " + thoughtsKind + ", leaving");
                return;
            }

            foreach (var thought in outIndividualThoughts)
            {
                if (thought.thought.def == ThoughtDefOf.WitnessedDeathBloodlust)
                    continue;
                if (thought.thought.def == ThoughtDefOf.WitnessedDeathFamily)
                    DepressionUtility.AddDepression(thought.addTo, 0.3f, 0.1f, thought.thought.LabelCap);
                if (thought.thought.def == ThoughtDefOf.PawnWithGoodOpinionDied)
                    DepressionUtility.AddDepression(thought.addTo, 0.1f, 0.1f, thought.thought.LabelCap);

                //Death of Lover/Spouse
                if (thought.thought.def == ThoughtDef.Named("MyLoverDied")
                    || thought.thought.def == ThoughtDef.Named("MyFianceDied")
                    || thought.thought.def == ThoughtDef.Named("MyFianceeDied")
                    || thought.thought.def == ThoughtDef.Named("MyWifeDied")
                    || thought.thought.def == ThoughtDef.Named("MyHusbandDied"))
                    DepressionUtility.AddDepression(thought.addTo, 0.6f, 0.4f, thought.thought.LabelCap);
                //Death of Parent
                if (thought.thought.def == ThoughtDef.Named("MyMotherDied")
                    || thought.thought.def == ThoughtDef.Named("MyFatherDied"))
                    DepressionUtility.AddDepression(thought.addTo, 0.4f, 0.3f, thought.thought.LabelCap);
                //Death of Child
                if (thought.thought.def == ThoughtDef.Named("MySonDied")
                    || thought.thought.def == ThoughtDef.Named("MyDaughterDied"))
                    DepressionUtility.AddDepression(thought.addTo, 0.5f, 0.5f, thought.thought.LabelCap);
                //Death of Sibling
                if (thought.thought.def == ThoughtDef.Named("MyBrotherDied")
                    || thought.thought.def == ThoughtDef.Named("MySisterDied"))
                    DepressionUtility.AddDepression(thought.addTo, 0.4f, 0.3f, thought.thought.LabelCap);
                //Death of Grandparents/Grandchild
                if (thought.thought.def == ThoughtDef.Named("MyGrandchildDied")
                    || thought.thought.def == ThoughtDef.Named("MyGrandparentDied"))
                    DepressionUtility.AddDepression(thought.addTo, 0.2f, 0.3f, thought.thought.LabelCap);
                //Death of all other Family
                if (thought.thought.def == ThoughtDef.Named("MyNieceDied")
                    || thought.thought.def == ThoughtDef.Named("MyNephewDied")
                    || thought.thought.def == ThoughtDef.Named("MyHalfSiblingDied")
                    || thought.thought.def == ThoughtDef.Named("MyAuntDied")
                    || thought.thought.def == ThoughtDef.Named("MyUncleDied")
                    || thought.thought.def == ThoughtDef.Named("MyCousinDied")
                    || thought.thought.def == ThoughtDef.Named("MyKinDied"))
                    DepressionUtility.AddDepression(thought.addTo, 0.1f, 0.2f, thought.thought.LabelCap);
            }
        }
    }

    [HarmonyPatch(typeof(InteractionWorker), "Interacted")]
    internal static class PATCH_InteractionWorker_Interacted
    {
        [HarmonyPostfix]
        public static void Postfix(
            InteractionWorker __instance,
            Pawn initiator,
            Pawn recipient,
            List<RulePackDef> extraSentencePacks,
            out string letterText,
            out string letterLabel,
            out LetterDef letterDef,
            out LookTargets lookTargets)
        {
            letterText = (string) null;
            letterLabel = (string) null;
            letterDef = (LetterDef) null;
            lookTargets = (LookTargets) null;

            if (recipient == null)
            {
                Log.Message("recipient is null");
                return;
            }
            
            switch (__instance)
            {
                case InteractionWorker_DeepTalk _:
                    Log.Message(recipient.Name + "'s depression is treated by DeepTalk. Severity: " + recipient.health.hediffSet.GetFirstHediffOfDef(HediffDefOfTRuth.TRuth_DepressiveEpisode).Severity);
                    HealthUtility.AdjustSeverity(initiator, HediffDefOfTRuth.TRuth_DepressiveEpisode, -0.005f);
                    HealthUtility.AdjustSeverity(recipient, HediffDefOfTRuth.TRuth_DepressiveEpisode, -0.01f);
                    Log.Message(recipient.Name + "'s depression was treated by DeepTalk with " + initiator.Name + ". Severity: " + recipient.health.hediffSet.GetFirstHediffOfDef(HediffDefOfTRuth.TRuth_DepressiveEpisode).Severity);
                    return;
                case InteractionWorker_Insult _:
                    Log.Message(initiator.Name + " insulted " + recipient.Name);
                    HealthUtility.AdjustSeverity(recipient, HediffDefOfTRuth.TRuth_DepressiveEpisode, 0.01f);
                    return;
                case InteractionWorker_Breakup _:
                    DepressionUtility.AddDepression(recipient, 0.4f, 0.3f);
                    return;
            }
        }
    }
}