using System;
using Harmony;
using System.Reflection;

namespace HarmonyPatches
{
  [HarmonyPatch(typeof(ConsoleCmdHelp))]
  [HarmonyPatch("Execute")]
  class Patch
  {
    static void Prefix()
    {
      Log.Warning("Harmony Prefix Executed!!");
    }
  }
}
