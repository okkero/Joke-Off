using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public GameObject projectilePrefabHi;
    public GameObject projectilePrefabHa;
    public GameObject projectilePrefabHo;
    public GameObject projectilePrefabHe;
    public AttackTarget attackTargetPrefab;

    public HealthBar healthBar;
    private CharacterConfig _characterConfig;

    public static FightManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _characterConfig = FindObjectOfType<CharacterConfig>();

        var fighter1 = SpawnPlayer(PlayerIndex.Player1);

        var fighter2 = SpawnPlayer(PlayerIndex.Player2);
        var fighter2Transform = fighter2.transform;
        var fighter2Scale = fighter2Transform.localScale;
        fighter2Scale.x *= -1;
        fighter2Transform.localScale = fighter2Scale;

        fighter1.opponent = fighter2;
        fighter2.opponent = fighter1;
    }

    private Fighter SpawnPlayer(PlayerIndex playerIndex)
    {
        Vector3 position;
        switch (playerIndex)
        {
            case PlayerIndex.Player1:
                position = new Vector3(-10, 5, 0);
                break;
            case PlayerIndex.Player2:
                position = new Vector3(10, 5, 0);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(playerIndex), playerIndex, null);
        }

        var characterInfo = _characterConfig.GetCharacterInfoForPlayer(playerIndex);
        var playerObject = Instantiate(characterInfo.prefab, position, Quaternion.identity);
        var playerTransform = playerObject.transform;
        playerObject.AddComponent<CharacterAnimator>();
        var fighter = playerObject.AddComponent<Fighter>();
        fighter.player = playerIndex;
        var attackTypes = new[] { AttackType.Hi, AttackType.Ha, AttackType.Ho, AttackType.He };
        for (var i = 0; i < attackTypes.Length; i++)
        {
            var attackTarget = Instantiate(
                attackTargetPrefab,
                playerTransform.TransformPoint(new Vector3(2, 2 - 1.5f * i)),
                Quaternion.identity, playerTransform);
            attackTarget.attackType = attackTypes[i];
        }

        return fighter;
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