using System.Collections.Generic;
using System.Text;
using RimWorld;
using Verse;

namespace TRuth
{
    public static class DepressionUtility
    {
        public static void AddDepression(Pawn pawn, float chance, float initSeverity = 0.2f, string reason = "No Reason Given")
        {
            Hediff_Depression depression = pawn.health.hediffSet.GetFirstHediff<Hediff_Depression>();
            var letterText = (string) null;
            var letterLabel = (string) null;
            var letterDef = (LetterDef) null;
            var lookTargets = (LookTargets) null;
            var randValue = Rand.Value;

            if (!(randValue <= chance))
            {
                Log.Message("No depression added for: " + pawn.Name + " Rand: " + randValue + " Chance: " + chance + " Reason: " + reason);
                return;
            }
                
            if (depression == null)
            {
                depression = (Hediff_Depression)pawn.health.AddHediff(HediffDefOfTRuth.TRuth_DepressiveEpisode, pawn.health.hediffSet.GetBrain());
                depression.Severity = initSeverity;
                LetterAboutDepression(pawn, " has caught depression.",out letterText, out letterLabel, out letterDef, out lookTargets, reason);
            }
            else
            {
                HealthUtility.AdjustSeverity(pawn, depression.def, initSeverity);
                LetterAboutDepression(pawn, " has gained additional depression.",out letterText, out letterLabel, out letterDef, out lookTargets, reason);
            }
            
            if (letterDef != null && (pawn.IsColonist || pawn.IsPrisonerOfColony))
            {
                // PlayLogEntry_Interaction entry = new PlayLogEntry_Interaction(intDef, this.pawn, recipient, extraSentencePacks);
                // Find.PlayLog.Add((LogEntry) entry);
                // string text = entry.ToGameStringFromPOV((Thing) pawn);
                // if (!letterText.NullOrEmpty())
                //     text = text + "\n\n" + letterText;
                Find.LetterStack.ReceiveLetter((TaggedString) letterLabel, (TaggedString) letterText, letterDef, lookTargets ?? (LookTargets) (Thing) pawn);
            }
        }
        
        public static void LetterAboutDepression(Pawn pawn,
            string addedText,
            out string letterText,
            out string letterLabel,
            out LetterDef letterDef,
            out LookTargets lookTargets,
            string reason)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(pawn.LabelShort + addedText);

            if (reason != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine((string) "The Reason was: " + reason);
            }
            letterLabel = (string) "Depression";
            letterText = stringBuilder.ToString().TrimEndNewlines();
            letterDef = LetterDefOf.NegativeEvent;
            lookTargets = new LookTargets(new TargetInfo[1]
            {
                (TargetInfo) (Thing) pawn,
            });
        }
    }
}