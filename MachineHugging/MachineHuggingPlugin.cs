using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using EquinoxsModUtils;
using HarmonyLib;
using UnityEngine;

namespace MachineHugging
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class MachineHuggingPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.equinox.MachineHugging";
        private const string PluginName = "MachineHugging";
        private const string VersionString = "2.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake() {
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();

            EMU.Events.GameDefinesLoaded += OnGameDefinesLoaded;

            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
            Log = Logger;
        }

        // Events

        private void OnGameDefinesLoaded() { 
            foreach(ResourceInfo resource in GameDefines.instance.resources) {
                if(resource is BuilderInfo builderInfo) {
                    builderInfo.gridClearance = 0;
                }
            }
        }
    }
}
