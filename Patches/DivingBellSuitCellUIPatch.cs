using HarmonyLib;
using UnityEngine;

namespace BetterDivingBellUI.Patches {
    [HarmonyPatch(typeof(DivingBellSuitCellUI))]
    public static class DivingBellSuitCellUIPatch {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(DivingBellSuitCellUI.Set))]
        public static void Set(Player player, float dst, DivingBellSuitCellUI __instance) {
            if (player.data.dead) {
                __instance.m_oxygenText.text = "DECEASED";
                __instance.m_oxygenText.color = UnityEngine.Color.red;
            }
            else {
                float oxyAmt = player.data.OxygenPercentage();
                float greenAmt = oxyAmt;
                float redAmt = 1f - greenAmt;
                __instance.m_oxygenText.color = new Color(redAmt, greenAmt, 0);
            }
        }
    }
}
