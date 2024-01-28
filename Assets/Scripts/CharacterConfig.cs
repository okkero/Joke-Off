using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterInfo
{
    public PlayerCharacter playerCharacter;
    public GameObject prefab;
}

public class CharacterConfig : MonoBehaviour
{
    public CharacterInfo[] CharacterInfos;

    private Dictionary<PlayerIndex, PlayerCharacter> _playerCharacters;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _playerCharacters = new Dictionary<PlayerIndex, PlayerCharacter>
        {
            { PlayerIndex.Player1, PlayerCharacter.Jokachu },
            { PlayerIndex.Player2, PlayerCharacter.Jokemander }
        };
    }

    public CharacterInfo GetCharacterInfo(PlayerCharacter playerCharacter)
    {
        foreach (var characterInfo in CharacterInfos)
            if (characterInfo.playerCharacter == playerCharacter)
                return characterInfo;

        return null;
    }

    public CharacterInfo GetCharacterInfoForPlayer(PlayerIndex playerIndex)
    {
        return GetCharacterInfo(_playerCharacters[playerIndex]);
    }

    public void SetPlayerCharacter(PlayerIndex playerIndex, PlayerCharacter playerCharacter)
    {
        _playerCharacters[playerIndex] = playerCharacter;
    }
}