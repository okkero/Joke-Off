using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

[System.Serializable]
public class CharacterInfo
{
    public PlayerCharacter playerCharacter;
    public GameObject prefab;
}

public class CharacterConfig : MonoBehaviour
{
    public CharacterInfo[] CharacterInfos;
    
    private Dictionary<PlayerIndex, PlayerCharacter> _playerCharacters;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _playerCharacters = new Dictionary<PlayerIndex, PlayerCharacter>
        {
            { PlayerIndex.Player1, PlayerCharacter.Jokachu },
            { PlayerIndex.Player2, PlayerCharacter.Jokemander }
        };
    }

    CharacterInfo GetCharacterInfo(PlayerCharacter playerCharacter)
    {
        foreach (var characterInfo in CharacterInfos)
        {
            if (characterInfo.playerCharacter == playerCharacter)
            {
                return characterInfo;
            }
        }

        return null;
    }

    public void SetPlayerCharacter(PlayerIndex playerIndex, PlayerCharacter playerCharacter)
    {
        _playerCharacters[playerIndex] = playerCharacter;
    }
}
