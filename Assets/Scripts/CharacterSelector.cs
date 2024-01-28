using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PlayerCharacter
{
    Jokachu,
    Jokemander,
    Willie,
    Troll,
    ComicSans,
}

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private PlayerIndex playerIndex;
    [SerializeField] private PlayerCharacter playerCharacter;
    [SerializeField] private CharacterConfig characterConfig;

    private GameObject _character;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Start()
    {
        characterConfig.SetPlayerCharacter(playerIndex, playerCharacter);
        var list = characterConfig.CharacterInfos.ToList();
        var index = list.FindIndex((characterInfo) => characterInfo.playerCharacter == playerCharacter);
        var characterInfo = list[index];
        SetCharacterInfo(characterInfo);
    }

    void SetCharacterInfo(CharacterInfo characterInfo)
    {
        playerCharacter = characterInfo.playerCharacter;
        var prefab = characterInfo.prefab;
        if (_character)
        {
            Destroy(_character);
        }

        _character = Instantiate(prefab, gameObject.transform);
    }

    private void OnMouseDown()
    {
        var list = characterConfig.CharacterInfos.ToList();
        var index = list.FindIndex((characterInfo) => characterInfo.playerCharacter == playerCharacter);
        var nextIndex = (index + 1) % list.Count;
        var nextCharacterInfo = list[nextIndex];
        SetCharacterInfo(nextCharacterInfo);

        characterConfig.SetPlayerCharacter(playerIndex, nextCharacterInfo.playerCharacter);
    }
}
