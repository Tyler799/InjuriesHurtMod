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

    // Modifies guts value

    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Guts", PropertyMethod.Getter)]
    public class GutsHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * ((__instance.Health - (float)__instance.Injuries) / (float)__instance.Health));
        }
    }

    // Modifies tactics value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Tactics", PropertyMethod.Getter)]
    public class TacticsHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * ((__instance.Health - (float)__instance.Injuries) / (float)__instance.Health));
        }
    }

    // Modifies gunnery value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Gunnery", PropertyMethod.Getter)]
    public class GunneryHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * ((__instance.Health - (float)__instance.Injuries) / (float)__instance.Health));
        }
    }

    // Modifies piloting value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Piloting", PropertyMethod.Getter)]
    public class PilotingHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * ((__instance.Health - (float)__instance.Injuries) / (float)__instance.Health));
        }
    }
}