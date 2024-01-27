using UnityEngine;

public class FightManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public static FightManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public AttackProjectile SpawnAttackProjectile(Transform origin, AttackTarget target)
    {
        var projectile = Instantiate(projectilePrefab, origin.position, Quaternion.identity);
        projectile.transform.localScale = origin.lossyScale;

        var projectileComponent = projectile.GetComponent<AttackProjectile>();
        projectileComponent.target = target;

        return projectileComponent;
    }
}