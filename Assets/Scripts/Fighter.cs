using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public PlayerIndex player;
    public Fighter opponent;
    private CharacterAnimator _animator;
    private bool _attackCooldown;
    private bool _blockCooldown;
    private AttackType? _blocking;
    public AttackTarget[] AttackTargets { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<CharacterAnimator>();
        AttackTargets = GetComponentsInChildren<AttackTarget>();
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
        if (_blockCooldown) return;
        StartCoroutine(BlockCooldown());

        StartCoroutine(Block(attackType));
    }

    private void OnAttack(AttackType attackType)
    {
        if (_attackCooldown) return;
        StartCoroutine(AttackCooldown());

        Debug.unityLogger.Log($"Attack {attackType}");

        _animator.AnimateLaugh(attackType);

        var origin = AttackTargets.First(target => target.attackType == attackType);
        var target = opponent.AttackTargets.First(target => target.attackType == attackType);
        FightManager.Instance.SpawnAttackProjectile(attackType, origin.transform, target);
    }

    private IEnumerator BlockCooldown()
    {
        _blockCooldown = true;
        yield return new WaitForSeconds(0.5f);
        _blockCooldown = false;
    }

    private IEnumerator AttackCooldown()
    {
        _attackCooldown = true;
        yield return new WaitForSeconds(0.5f);
        _attackCooldown = false;
    }

    private IEnumerator Block(AttackType attackType)
    {
        _blocking = attackType;
        AttackTargets.First(target => target.attackType == attackType).SetBlocking(true);
        yield return new WaitForSeconds(0.16f);
        AttackTargets.First(target => target.attackType == attackType).SetBlocking(false);
        _blocking = null;
    }

    public void Hit(AttackType attackType)
    {
        if (_blocking == attackType)
        {
            Debug.unityLogger.Log($"Blocked {attackType}");
            _animator.AnimateBlock(attackType);
        }
        else
        {
            Debug.unityLogger.Log($"Hit by {attackType}");
            FightManager.Instance.Hit(player, opponent);
            _animator.AnimateHit(attackType);
        }
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