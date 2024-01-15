﻿using ModdingAPI.Items;
using UnityEngine;

namespace LostDreams.HealthRegen;

class HealthRegenHeart : ModSwordHeart
{
    protected override string Id => "HE501";

    protected override string Name => Main.LostDreams.Localize("hrname");

    protected override string Description => Main.LostDreams.Localize("hrdesc");

    protected override string Lore => Main.LostDreams.Localize("hrlore");

    protected override bool CarryOnStart => false;

    protected override bool PreserveInNGPlus => true;

    protected override bool AddToPercentCompletion => true;

    protected override bool AddInventorySlot => true;

    protected override void LoadImages(out Sprite picture)
    {
        picture = Main.LostDreams.FileUtil.loadDataImages("health-regen.png", new Vector2Int(30, 30), Vector2Int.zero, 32, 0, true, out Sprite[] images) ? images[0] : null;
    }
}

class HealthRegenEffect : ModItemEffectOnEquip
{
    protected override void ApplyEffect() => Main.LostDreams.EffectHandler.Activate("health-regen");

    protected override void RemoveEffect() => Main.LostDreams.EffectHandler.Deactivate("health-regen");
}
