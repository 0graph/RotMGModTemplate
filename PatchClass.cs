using Il2Cpp;

namespace BasicMelonMod.Patches
{
    // This is the class that HarmonyX is patching - in this case ALCOHEIDGKL is the Tile class for RotMG.
    [HarmonyLib.HarmonyPatch(typeof(ALCOHEIDGKL))]
    // This is the method that will be patched. Every time it is called in-game it will run through the patch below.
    // Prefix() runs the patch before the method call and Postfix() runs it after. Check MelonLoader documentation for more info.
    [HarmonyLib.HarmonyPatch("HILBBBOHAAH")]
    public static class FogPatch
    {

        [HarmonyLib.HarmonyPrefix]
        public static bool Prefix(ALCOHEIDGKL __instance, int __0)
        {
            return false;
        }
    }

    // Add more Harmony patches here or expand the mod!
}
