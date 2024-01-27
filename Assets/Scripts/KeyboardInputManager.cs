using UnityEngine;

public class PlayerInput
{
    internal KeyCode HaKey;
    internal KeyCode HeKey;
    internal KeyCode HiKey;
    internal KeyCode HoKey;

    public AttackType? Attack
    {
        get
        {
            if (Input.GetKeyDown(HiKey)) return AttackType.Hi;
            if (Input.GetKeyDown(HaKey)) return AttackType.Ha;
            if (Input.GetKeyDown(HoKey)) return AttackType.Ho;
            if (Input.GetKeyDown(HeKey)) return AttackType.He;

            return null;
        }
    }
}

public static class KeyboardInputManager
{
    public static PlayerInput Player1Input;
    public static PlayerInput Player2Input;

    static KeyboardInputManager()
    {
        Player1Input = new PlayerInput
        {
            HiKey = KeyCode.Q,
            HaKey = KeyCode.W,
            HoKey = KeyCode.E,
            HeKey = KeyCode.R
        };

        Player2Input = new PlayerInput
        {
            HiKey = KeyCode.H,
            HaKey = KeyCode.J,
            HoKey = KeyCode.K,
            HeKey = KeyCode.L
        };
    }
}