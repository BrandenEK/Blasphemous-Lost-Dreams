﻿using Blasphemous.ModdingAPI;
using CreativeSpore.SmartColliders;
using Framework.Managers;
using Gameplay.GameControllers.Entities;
using System.Linq;
using UnityEngine;

namespace Blasphemous.LostDreams.Items.Prayers;

internal class PR501 : EffectOnPrayerUse
{
    private readonly PR501Config _config;

    public PR501(PR501Config cfg) : base(cfg)
    {
        _config = cfg;
    }

    protected override void OnActivate()
    {
        PerformSwap();
    }

    private void PerformSwap()
    {
        Enemy enemy = FindClosestEnemy();

        if (enemy == null)
        {
            ModLog.Warn("PR501: No enemy was in range");
            return;
        }

        ModLog.Info($"PR501: Swapping places with {enemy.name} ({enemy.Id})");
        Vector3 playerPosition = Core.Logic.Penitent.transform.position;
        Vector3 enemyPosition = enemy.transform.position;

        MoveEntity(enemy, Vector3.zero);
        MoveEntity(Core.Logic.Penitent, enemyPosition);
        MoveEntity(enemy, playerPosition);
    }

    private void MoveEntity(Entity entity, Vector3 position)
    {
        SmartPlatformCollider collider = entity.GetComponentInChildren<SmartPlatformCollider>();

        if (collider != null)
            collider.enabled = false;

        entity.transform.position = position;

        if (collider != null)
            collider.enabled = true;
    }

    private Enemy FindClosestEnemy()
    {
        Vector3 playerPosition = Core.Logic.Penitent.transform.position;

        return Object.FindObjectsOfType<Enemy>()
            .Select(e => new EnemyDistance(e, Vector3.Distance(playerPosition, e.transform.position)))
            .Where(x => x.Distance <= _config.MAX_RANGE && !_bannedEnemyIds.Contains(x.Enemy.Id))
            .OrderBy(x => x.Distance)
            .FirstOrDefault()?.Enemy;
    }

    class EnemyDistance(Enemy e, float d)
    {
        public Enemy Enemy { get; } = e;
        public float Distance { get; } = d;
    }

    private readonly string[] _bannedEnemyIds =
    {
        "BS16"
    };
}

/// <summary> Properties for PR501 </summary>
public class PR501Config : IPrayerConfig
{
    /// <summary> Maximum range for enemies that you can swap with </summary>
    public float MAX_RANGE = 10;
    /// <inheritdoc/>
    public int FervourCost { get; set; } = 20;
    /// <inheritdoc/>
    public float EffectTime { get; set; } = 0;
    /// <inheritdoc/>
    public bool UsePrayerDurationModifier { get; set; } = false;
}
