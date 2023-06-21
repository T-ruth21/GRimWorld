using Verse;
using HarmonyLib;
using RimWorld;
using System.Collections.Generic;

namespace TRuth
{
    // Patch will be applied to class PawnDiedOrDownedThoughtsUtility in the method AppendThoughts_Relations
    [HarmonyPatch(typeof(PawnDiedOrDownedThoughtsUtility), "AppendThoughts_Relations")]
    internal static class PATCH_PawnDiedOrDownedThoughtsUtility_AppendThoughts_Relations
    {
        //As a postfix this method will be executed after the main method, it can unitlize all the methods parameters
        [HarmonyPostfix]
        public static void Postfix(ref Pawn victim,
            ref DamageInfo? dinfo,
            ref PawnDiedOrDownedThoughtsKind thoughtsKind,
            ref List<IndividualThoughtToAdd> outIndividualThoughts,
            ref List<ThoughtToAddToAll> outAllColonistsThoughts)
        {
            if (thoughtsKind != PawnDiedOrDownedThoughtsKind.Died) //This patch is only applicable for deaths
            {
                Log.Message("Thought kind was: " + thoughtsKind + ", leaving");
                return;
            }

            foreach (var thought in outIndividualThoughts)
            {
                // a lot of different thoughts are handled by the method, it is a bit complicated to differentiate
                if (thought.thought.def == ThoughtDefOf.WitnessedDeathBloodlust)
                    continue;
                if (thought.thought.def == ThoughtDefOf.WitnessedDeathFamily)
                {
                    DepressionUtility.AddDepression(thought.addTo, 0.3f, 0.1f, thought.thought.LabelCap);
                    continue;
                }

                if (thought.thought.def == ThoughtDefOf.PawnWithGoodOpinionDied)
                {
                    DepressionUtility.AddDepression(thought.addTo, 0.1f, 0.1f, thought.thought.LabelCap);
                    continue;
                }

                //Death of Lover/Spouse
                if (thought.thought.def == ThoughtDef.Named("MyLoverDied")
                    || thought.thought.def == ThoughtDef.Named("MyFianceDied")
                    || thought.thought.def == ThoughtDef.Named("MyFianceeDied")
                    || thought.thought.def == ThoughtDef.Named("MyWifeDied")
                    || thought.thought.def == ThoughtDef.Named("MyHusbandDied"))
                {
                    DepressionUtility.AddDepression(thought.addTo, 0.6f, 0.4f, thought.thought.LabelCap);
                    continue;
                }
                //Death of Parent
                if (thought.thought.def == ThoughtDef.Named("MyMotherDied")
                    || thought.thought.def == ThoughtDef.Named("MyFatherDied"))
                {
                    DepressionUtility.AddDepression(thought.addTo, 0.4f, 0.3f, thought.thought.LabelCap);
                    continue;
                }
                //Death of Child
                if (thought.thought.def == ThoughtDef.Named("MySonDied")
                    || thought.thought.def == ThoughtDef.Named("MyDaughterDied"))
                {
                    DepressionUtility.AddDepression(thought.addTo, 0.5f, 0.5f, thought.thought.LabelCap);
                    continue;
                }
                //Death of Sibling
                if (thought.thought.def == ThoughtDef.Named("MyBrotherDied")
                    || thought.thought.def == ThoughtDef.Named("MySisterDied"))
                {
                    DepressionUtility.AddDepression(thought.addTo, 0.4f, 0.3f, thought.thought.LabelCap);
                    continue;
                }
                //Death of Grandparents/Grandchild
                if (thought.thought.def == ThoughtDef.Named("MyGrandchildDied")
                    || thought.thought.def == ThoughtDef.Named("MyGrandparentDied"))
                {
                    DepressionUtility.AddDepression(thought.addTo, 0.2f, 0.3f, thought.thought.LabelCap);
                    continue;
                }
                //Death of all other Family
                if (thought.thought.def == ThoughtDef.Named("MyNieceDied")
                    || thought.thought.def == ThoughtDef.Named("MyNephewDied")
                    || thought.thought.def == ThoughtDef.Named("MyHalfSiblingDied")
                    || thought.thought.def == ThoughtDef.Named("MyAuntDied")
                    || thought.thought.def == ThoughtDef.Named("MyUncleDied")
                    || thought.thought.def == ThoughtDef.Named("MyCousinDied")
                    || thought.thought.def == ThoughtDef.Named("MyKinDied"))
                {
                    DepressionUtility.AddDepression(thought.addTo, 0.1f, 0.2f, thought.thought.LabelCap);
                }
            }
        }
    }
}