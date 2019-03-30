using System;
using Harmony;
using System.Reflection;

namespace HarmonyPatches
{
  static class PatchGameManager
  {
    public static void RegisterHarmony()
    {
      var harmony = HarmonyInstance.Create("com.7dtd.mods");
      harmony.PatchAll(Assembly.GetExecutingAssembly());

      Log.Out("SDX Patching Harmony.");
    }
  }
}
