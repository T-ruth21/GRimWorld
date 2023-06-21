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
            Harmony harmonyInstance = new Harmony("TRuth.Depression");
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            Log.Message("TRuth's depression successfully enabled. Happy ruminating.");
        }
    }
}