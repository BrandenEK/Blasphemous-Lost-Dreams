﻿using Blasphemous.Framework.Levels;
using Blasphemous.Framework.Levels.Modifiers;
using Blasphemous.LostDreams.Components;
using Blasphemous.LostDreams.Npc;
using Framework.FrameworkCore;
using Gameplay.GameControllers.Entities;
using Tools.Level.Interactables;
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
        NpcInfo info = Main.LostDreams.NpcStorage[data.id];

        obj.name = info.Id;

        // Modify body properties (Animator, hitbox, etc)
        GameObject body = obj.transform.GetChild(1).gameObject;

        var anim = body.GetComponent<ModAnimator>();
        anim.Animation = Main.LostDreams.AnimationStorage[info.Animation];

        var collider = body.GetComponent<BoxCollider2D>();
        collider.size = new Vector2(info.ColliderWidth, info.ColliderHeight);
        collider.offset = new Vector2(0, info.ColliderHeight / 2);

        var entity = body.AddComponent<Entity>();
        entity.Status.CastShadow = true;
        entity.Status.IsGrounded = true;
        body.AddComponent<EntityShadow>();

        // Modify function properties (Dialog, etc)
        GameObject function = obj.transform.GetChild(0).gameObject;

        var interactable = function.GetComponent<ModInteractable>();
        interactable.Dialogs = data.properties;
    }
}

public class DoorModifier : IModifier
{
    public void Apply(GameObject obj, ObjectData data)
    {
        obj.name = $"Door[{data.id}]";

        Door door = obj.GetComponent<Door>();
        door.identificativeName = data.id;
        door.targetScene = data.properties[0];
        door.targetDoor = data.properties[1];
        door.exitOrientation = data.properties[2] switch
        {
            "left" => EntityOrientation.Left,
            "right" => EntityOrientation.Right,
            _ => throw new System.Exception("Invalid door orientation")
        };
        door.spawnPoint.transform.position = new()
        {
            x = float.Parse(data.properties[3]),
            y = float.Parse(data.properties[4]),
        };
    }
}
