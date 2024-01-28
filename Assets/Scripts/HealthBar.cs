using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private const int Threshold = 10;

    public int value;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    /// <summary>
    /// </summary>
    /// <param name="playerIndex"></param>
    /// <returns>The winner, if decided, otherwise null</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public PlayerIndex? Hit(PlayerIndex playerIndex)
    {
        switch (playerIndex)
        {
            case PlayerIndex.Player1:
                value++;
                break;
            case PlayerIndex.Player2:
                value--;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(playerIndex), playerIndex, null);
        }

        if (value > Threshold)
            return PlayerIndex.Player1;
        if (value < -Threshold)
            return PlayerIndex.Player2;
        return null;
    }
}