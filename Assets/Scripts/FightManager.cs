using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public GameObject projectilePrefabHi;
    public GameObject projectilePrefabHa;
    public GameObject projectilePrefabHo;
    public GameObject projectilePrefabHe;

    public HealthBar healthBar;

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
        var originScale = origin.lossyScale;
        projectile.transform.localScale = new Vector3(
            Math.Sign(originScale.x),
            Math.Sign(originScale.y),
            Math.Sign(originScale.z));

        var projectileComponent = projectile.GetComponent<AttackProjectile>();
        projectileComponent.target = target;

        return projectileComponent;
    }

    public void Hit(PlayerIndex playerIndex, Fighter opponent)
    {
        var winner = healthBar.Hit(playerIndex);
        if (winner != null)
        {
            DontDestroyOnLoad(opponent);

            VictoryData.WinnerPlayer = playerIndex;
            VictoryData.WinnerCharacter = opponent;
            SceneManager.LoadScene("Scenes/Victory");
        }
    }
}