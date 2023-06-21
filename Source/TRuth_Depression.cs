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
            Harmony harmonyInstance = new Harmony("TRuth.Depression");    //Creates Harmony instance
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());      //Patches my code into existing game
            Log.Message("TRuth's depression successfully enabled. Happy ruminating.");
        }
    }
}