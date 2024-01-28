using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public enum PlayerIndex
{
    Player1,
    Player2
}

public class Fighter : MonoBehaviour
{
    public PlayerIndex player;
    public Fighter opponent;
    private AttackTarget[] _attackTargets;
    private AttackType? _blocking;
    private bool _coolingDown;
    private Mouth _mouth;

    // Start is called before the first frame update
    private void Start()
    {
        _mouth = GetComponentInChildren<Mouth>();
        _attackTargets = GetComponentsInChildren<AttackTarget>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleKeyboardInput();
    }

    private void HandleKeyboardInput()
    {
        PlayerInput playerInput;
        switch (player)
        {
            case PlayerIndex.Player1:
                playerInput = KeyboardInputManager.Player1Input;
                break;
            case PlayerIndex.Player2:
                playerInput = KeyboardInputManager.Player2Input;
                break;
            default:
                throw new Exception("Oopsie daisie :)");
        }

        var attack = playerInput.Attack;
        if (attack == null) return;

        if (playerInput.Blocking)
            OnBlock(attack.Value);
        else
            OnAttack(attack.Value);
    }

    private void OnBlock(AttackType attackType)
    {
        if (_coolingDown) return;
        StartCoroutine(Cooldown());

        StartCoroutine(Block(attackType));
    }

    private void OnAttack(AttackType attackType)
    {
        if (_coolingDown) return;
        StartCoroutine(Cooldown());

        Debug.unityLogger.Log($"Attack {attackType}");

        StartCoroutine(OpenMouth());

        var origin = _attackTargets.First(target => target.attackType == attackType);
        var target = opponent._attackTargets.First(target => target.attackType == attackType);
        FightManager.Instance.SpawnAttackProjectile(attackType, origin.transform, target);
    }

    private IEnumerator Cooldown()
    {
        _coolingDown = true;
        yield return new WaitForSeconds(0.5f);
        _coolingDown = false;
    }

    private IEnumerator Block(AttackType attackType)
    {
        _blocking = attackType;
        _attackTargets.First(target => target.attackType == attackType).SetBlocking(true);
        yield return new WaitForSeconds(0.16f);
        _attackTargets.First(target => target.attackType == attackType).SetBlocking(false);
        _blocking = null;
    }

    private IEnumerator OpenMouth()
    {
        _mouth.SetOpen(true);
        yield return new WaitForSeconds(0.16f);
        _mouth.SetOpen(false);
    }

    public void Hit(AttackType attackType)
    {
        if (_blocking == attackType)
            Debug.unityLogger.Log($"Blocked {attackType}");
        else
            Debug.unityLogger.Log($"Hit by {attackType}");
    }

    private void OnHiAttack()
    {
        OnAttack(AttackType.Hi);
    }

    private void OnHaAttack()
    {
        OnAttack(AttackType.Ha);
    }

    private void OnHoAttack()
    {
        OnAttack(AttackType.Ho);
    }

    private void OnHeAttack()
    {
        OnAttack(AttackType.He);
    }
}