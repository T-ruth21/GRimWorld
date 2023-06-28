using Verse;
using HarmonyLib;
using RimWorld;
using System.Collections.Generic;

namespace TRuth
{
    public class Patch_TreatDepression
    {
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
                out LookTargets lookTargets) // __instance is the currently used instance of interaction worker
            {
                letterText = (string) null;
                letterLabel = (string) null;
                letterDef = (LetterDef) null;
                lookTargets = (LookTargets) null;

                if (recipient == null || __instance == null || initiator == null)
                {
                    Log.Message("parameter is null");
                    return;
                }

                switch (__instance)
                {
                    case InteractionWorker_DeepTalk _:
                        if (initiator.health.hediffSet.HasHediff(HediffDefOfTRuth.TRuth_DepressiveEpisode))
                        {
                            HealthUtility.AdjustSeverity(initiator, HediffDefOfTRuth.TRuth_DepressiveEpisode, -0.005f); // Deep Talk can treat depression in both participants
                            MoteMaker.ThrowText(initiator.Position.ToVector3(), initiator.MapHeld, "Depression treated", 10f); //Feedback is given to the player
                        }
                        if (recipient.health.hediffSet.HasHediff(HediffDefOfTRuth.TRuth_DepressiveEpisode))
                        {
                            HealthUtility.AdjustSeverity(recipient, HediffDefOfTRuth.TRuth_DepressiveEpisode, -0.01f);
                            MoteMaker.ThrowText(recipient.Position.ToVector3(), initiator.MapHeld, "Depression treated", 10f);
                        }
                        return;
                    case InteractionWorker_Insult _:
                        Log.Message(initiator.Name + " insulted " + recipient.Name);
                        if (recipient.health.hediffSet.HasHediff(HediffDefOfTRuth.TRuth_DepressiveEpisode)) //Adjust severity will add a hediff if the pawn doesn't have it, but I don't want that
                            HealthUtility.AdjustSeverity(recipient, HediffDefOfTRuth.TRuth_DepressiveEpisode, 0.01f); 
                        return;
                    case InteractionWorker_Breakup _:
                        DepressionUtility.AddDepression(recipient, 0.4f, 0.3f);
                        return;
                    default:
                        return;
                }
            }
        }
    }
}