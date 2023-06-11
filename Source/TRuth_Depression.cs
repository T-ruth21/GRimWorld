using System;
using Verse;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace TRuth
{
    [StaticConstructorOnStartup]
    public static class TRuth_Depression
    {
        static TRuth_Depression()
        {
            Log.Message("TRuth's depression enabled. Happy ruminating.");
            Harmony harmonyInstance = new Harmony("TRuth.Depression");
            // Log.Message("t-ruth attempting patch");
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            Log.Message("t-ruth succeeded with patch");
        }
    }
    

    // [HarmonyPatch(typeof(WindowStack))]
    // [HarmonyPatch("Add")]
    // [HarmonyPatch(new Type[] { typeof(Window) })]
    // class Patch
    // {
    //     static void Prefix(Window window)
    //     {
    //         Log.Warning("Window: " + window);
    //     }
    // }
    
    //[HarmonyPatch(typeof(JobGiver_Meditate), "GetPriority")]
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
            foreach (var outIndividualThought in outIndividualThoughts)
            {
                Log.Message(outIndividualThought.addTo.relations.OpinionOf(victim).ToString());
                if (outIndividualThought.addTo.relations.OpinionOf(victim) >= 25)
                    DepressionUtility.AddDepression(outIndividualThought.addTo, 0.2f);
                    Log.Message("Depression added person: " + outIndividualThought.addTo.Name + ", cause: " + outIndividualThought.thought);
            }
        }
    }

}