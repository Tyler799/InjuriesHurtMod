using BattleTech;
using Harmony;
using Newtonsoft.Json;
using System;
using System.Reflection;

namespace com.Tyler799.Battletech.InjuriesHurtMod
{
    public class InjuriesHurt
    {
        public static Settings ModSettings;

        public static void Init(string _directory, string settingsJSON)
        {
            try
            {
                ModSettings = JsonConvert.DeserializeObject<Settings>(settingsJSON);
            }
            catch (Exception ex)
            {
                ModSettings = new Settings();
            }

            // make Harmony call your hooks
            var harmony = HarmonyInstance.Create("com.Tyler799.Battletech.InjuriesHurtMod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    public class Settings
    {
        public double gutsEffectPercentage = 0.5;
    }

    // Modifies tactics value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Tactics", PropertyMethod.Getter)]
    public class TacticsHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * ((((InjuriesHurt.ModSettings.gutsEffectPercentage / 10) * __instance.Guts - 1) * __instance.Injuries) / (float)__instance.Health + 1));
        }
    }

    // Modifies piloting value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Piloting", PropertyMethod.Getter)]
    public class PilotingHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * ((((InjuriesHurt.ModSettings.gutsEffectPercentage / 10) * __instance.Guts - 1) * __instance.Injuries) / (float)__instance.Health + 1));
        }
    }

    // Modifies gunnery value
    [HarmonyPatch(typeof(Pilot))]
    [HarmonyPatch("Gunnery", PropertyMethod.Getter)]
    public class GunneryHealthModifier
    {
        public static void Postfix(Pilot __instance, ref int __result)
        {
            __result = (int)(__result * ((((InjuriesHurt.ModSettings.gutsEffectPercentage / 10) * __instance.Guts - 1) * __instance.Injuries) / (float)__instance.Health + 1));
        }
    }
}