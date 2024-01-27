using UnityEngine;

public class FightManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public static FightManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public AttackProjectile SpawnAttackProjectile(Vector3 position, AttackTarget target)
    {
        var projectile = Instantiate(projectilePrefab, position, Quaternion.identity);

        var projectileComponent = projectile.GetComponent<AttackProjectile>();
        projectileComponent.target = target;

        return projectileComponent;
    }
}