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
    private Mouth _mouth;
    private Coroutine _openMouthCoroutine;

    // Start is called before the first frame update
    private void Start()
    {
        _mouth = GetComponentInChildren<Mouth>();
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

        OnAttack(attack.Value);
    }

    private void OnAttack(AttackType attackType)
    {
        Debug.unityLogger.Log($"Attack {attackType}");

        if (_openMouthCoroutine != null) StopCoroutine(_openMouthCoroutine);
        _openMouthCoroutine = StartCoroutine(OpenMouth());

        var origin = GetComponentsInChildren<AttackTarget>().First(target => target.attackType == attackType);
        var target = opponent.GetComponentsInChildren<AttackTarget>()
            .First(target => target.attackType == attackType);
        FightManager.Instance.SpawnAttackProjectile(attackType, origin.transform, target);
    }

    private IEnumerator OpenMouth()
    {
        _mouth.SetOpen(true);
        yield return new WaitForSeconds(0.16f);
        _mouth.SetOpen(false);
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