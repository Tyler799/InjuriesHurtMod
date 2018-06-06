using BattleTech;
using Harmony;
using System.Reflection;

namespace com.Tyler799.Battletech.InjuriesHurtMod
{
    public class InjuriesHurt
    {
        public static void Init()
        {
            // make Harmony call your hooks
            var harmony = HarmonyInstance.Create("com.Tyler799.Battletech.InjuriesHurtMod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    // Modifies tactics value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Tactics", PropertyMethod.Getter)]
    public class TacticsHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * (((0.05 * __instance.Guts - 1) * __instance.Injuries) / (float)__instance.Health + 1));
        }
    }

    // Modifies gunnery value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Gunnery", PropertyMethod.Getter)]
    public class GunneryHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * (((0.05 * __instance.Guts - 1) * __instance.Injuries) / (float)__instance.Health + 1));
        }
    }

    // Modifies piloting value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Piloting", PropertyMethod.Getter)]
    public class PilotingHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * (((0.05 * __instance.Guts - 1) * __instance.Injuries) / (float)__instance.Health + 1));
        }
    }
}