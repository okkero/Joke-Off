using System.Linq;
using UnityEngine;

public enum FighterCharacterType
{
    NotSonic,
    NotPikachu,
    NotMario
}

public class Fighter : MonoBehaviour
{
    public FighterCharacterType character;
    public Fighter opponent;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnAttack(Attack attackType)
    {
        Debug.unityLogger.Log($"Attack {attackType}");
        var origin = GetComponentsInChildren<AttackTarget>().First(target => target.attackType == attackType);
        var target = opponent.GetComponentsInChildren<AttackTarget>().First(target => target.attackType == attackType);
        FightManager.Instance.SpawnAttackProjectile(origin.transform.position, target);
    }

    private void OnHiAttack()
    {
        OnAttack(Attack.Hi);
    }

    private void OnHaAttack()
    {
        OnAttack(Attack.Ha);
    }

    private void OnHoAttack()
    {
        OnAttack(Attack.Ho);
    }

    private void OnHeAttack()
    {
        OnAttack(Attack.He);
    }
}