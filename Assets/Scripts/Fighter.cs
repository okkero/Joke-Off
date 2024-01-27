using UnityEngine;
using UnityEngine.InputSystem;

public enum FighterCharacterType
{
    NotSonic,
    NotPikachu,
    NotMario
}

public enum Attack
{
    Hi,
    Ha,
    Ho,
    He
}

public class Fighter : MonoBehaviour
{
    public FighterCharacterType character;

    // Start is called before the first frame update
    private void Start()
    {
        var gameController = FindObjectOfType<GameController>();
        Debug.unityLogger.Log($"State is {gameController.State}");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnAttack(Attack attack)
    {
        Debug.unityLogger.Log($"Attack {attack}");
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