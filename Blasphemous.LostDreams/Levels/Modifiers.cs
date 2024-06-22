﻿using Blasphemous.Framework.Levels;
using Blasphemous.Framework.Levels.Modifiers;
using Blasphemous.LostDreams.Animation;
using Framework.Managers;
using Gameplay.GameControllers.Entities;
using UnityEngine;

namespace Blasphemous.LostDreams.Levels;

/// <summary>
/// A modifier that adds a collider to an empty object
/// </summary>
public class ColliderModifier : IModifier
{
    private readonly string _name;
    private readonly Vector2 _size;

    /// <summary>
    /// Specify the name and size of the collider
    /// </summary>
    public ColliderModifier(string name, Vector2 size)
    {
        _name = name;
        _size = size;
    }

    /// <summary>
    /// Adds a collider component and sets the layer to floor
    /// </summary>
    public void Apply(GameObject obj, ObjectData data)
    {
        obj.name = _name;
        obj.layer = LayerMask.NameToLayer("Floor");

        var collider = obj.AddComponent<BoxCollider2D>();
        collider.size = _size;
    }
}


public class NpcModifier : IModifier
{
    public void Apply(GameObject obj, ObjectData data)
    {
        var sr = obj.AddComponent<SpriteRenderer>();
        sr.sortingLayerName = "Player";
        sr.sortingOrder = -1000;

        var anim = obj.AddComponent<ModAnimator>();
        anim.Animation = Main.LostDreams.AnimationLoader[data.properties[0]];

        var animator = obj.AddComponent<Animator>();
        var collider = obj.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(2, 2f);
        collider.offset = new Vector2(0, 1f);
        var damagearea = obj.AddComponent<ModDamageArea>();
        var entity = obj.AddComponent<Entity>();
        entity.Status.CastShadow = true;
        entity.Status.IsGrounded = true;
        var shadow = obj.AddComponent<EntityShadow>();
    }
}

public class ModDamageArea : DamageArea
{
    private void Awake()
    {
        damageAreaCollider = GetComponent<BoxCollider2D>();
    }
}
