using System;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public GameObject projectilePrefabHi;
    public GameObject projectilePrefabHa;
    public GameObject projectilePrefabHo;
    public GameObject projectilePrefabHe;
    public static FightManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public AttackProjectile SpawnAttackProjectile(AttackType attackType, Transform origin, AttackTarget target)
    {
        GameObject prefab;
        switch (attackType)
        {
            case AttackType.Hi:
                prefab = projectilePrefabHi;
                break;
            case AttackType.Ha:
                prefab = projectilePrefabHa;
                break;
            case AttackType.Ho:
                prefab = projectilePrefabHo;
                break;
            case AttackType.He:
                prefab = projectilePrefabHe;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null);
        }

        var projectile = Instantiate(prefab, origin.position, Quaternion.identity);
        projectile.transform.localScale = new Vector3(
            Math.Sign(origin.lossyScale.x),
            Math.Sign(origin.lossyScale.y),
            Math.Sign(origin.lossyScale.z));

        var projectileComponent = projectile.GetComponent<AttackProjectile>();
        projectileComponent.target = target;

        return projectileComponent;
    }
}