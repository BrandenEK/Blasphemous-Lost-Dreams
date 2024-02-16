﻿using Blasphemous.ModdingAPI.Items;
using UnityEngine;

namespace Blasphemous.LostDreams.Items;

public class StandardRosaryBead : ModRosaryBead
{
    public StandardRosaryBead(string id, bool useEffect)
    {
        Id = id;
        if (useEffect)
            AddEffect(new StandardEquipEffect(id));
    }

    protected override string Id { get; }

    protected override string Name => Main.LostDreams.LocalizationHandler.Localize(Id + ".n");

    protected override string Description => Main.LostDreams.LocalizationHandler.Localize(Id + ".d");

    protected override string Lore => Main.LostDreams.LocalizationHandler.Localize(Id + ".l");

    protected override Sprite Picture => Main.LostDreams.FileHandler.LoadDataAsSprite(Id + ".png", out Sprite picture) ? picture : null;

    protected override bool CarryOnStart => false;

    protected override bool PreserveInNGPlus => true;

    protected override bool AddToPercentCompletion => true;

    protected override bool AddInventorySlot => true;
}

public class StandardSwordHeart : ModSwordHeart
{
    public StandardSwordHeart(string id, bool useEffect)
    {
        Id = id;
        if (useEffect)
            AddEffect(new StandardEquipEffect(id));
    }

    protected override string Id { get; }

    protected override string Name => Main.LostDreams.LocalizationHandler.Localize(Id + ".n");

    protected override string Description => Main.LostDreams.LocalizationHandler.Localize(Id + ".d");

    protected override string Lore => Main.LostDreams.LocalizationHandler.Localize(Id + ".l");

    protected override Sprite Picture => Main.LostDreams.FileHandler.LoadDataAsSprite(Id + ".png", out Sprite picture) ? picture : null;

    protected override bool CarryOnStart => false;

    protected override bool PreserveInNGPlus => true;

    protected override bool AddToPercentCompletion => true;

    protected override bool AddInventorySlot => true;
}

public class StandardQuestItem : ModQuestItem
{
    public StandardQuestItem(string id, bool activateOnce)
    {
        Id = id;
        AddEffect(new StandardAcquireEffect(id, activateOnce));
    }

    protected override string Id { get; }

    protected override string Name => Main.LostDreams.LocalizationHandler.Localize(Id + ".n");

    protected override string Description => Main.LostDreams.LocalizationHandler.Localize(Id + ".d");

    protected override string Lore => Main.LostDreams.LocalizationHandler.Localize(Id + ".l");

    protected override Sprite Picture => Main.LostDreams.FileHandler.LoadDataAsSprite(Id + ".png", out Sprite picture) ? picture : null;

    protected override bool CarryOnStart => false;

    protected override bool PreserveInNGPlus => true;
}

public class StandardEquipEffect(string effect) : ModItemEffectOnEquip
{
    protected override void ApplyEffect() => Main.LostDreams.ItemHandler.Equip(effect);

    protected override void RemoveEffect() => Main.LostDreams.ItemHandler.Unequip(effect);
}

public class StandardAcquireEffect(string effect, bool activateOnce) : ModItemEffectOnAcquire
{
    protected override bool ActivateOnce => activateOnce;

    protected override void ApplyEffect() => Main.LostDreams.ItemHandler.Equip(effect);

    protected override void RemoveEffect() => Main.LostDreams.ItemHandler.Unequip(effect);
}