using Harmony;
using Il2Cpp;

namespace BasicMelonMod.Patches
{
    //
    [HarmonyPatch(typeof(ALCOHEIDGKL))] // This is the Class that 0Harmony is Patching - in this case ALCOHEIDGKL is the Tile Class for RotMG
    [HarmonyPatch("HILBBBOHAAH")] // This is the Method that will be patched - Every time it is called the patch will run, Prefix runs the patch before the method call and postfix runs after the method call
    public static class FogPatch
    {

        [HarmonyPrefix]
        public static bool Prefix(Il2Cpp.ALCOHEIDGKL __instance, int __0)
        {
            return false;
        }
    }
}
