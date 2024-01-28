using System.Linq;
using UnityEngine;

public enum PlayerCharacter
{
    Jokachu,
    Jokemander,
    Willie,
    Troll,
    ComicSans
}

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private PlayerIndex playerIndex;
    [SerializeField] private PlayerCharacter playerCharacter;
    private BoxCollider2D _boxCollider2D;

    private GameObject _character;
    private CharacterConfig _characterConfig;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Start()
    {
        _characterConfig = FindObjectOfType<CharacterConfig>();
        _characterConfig.SetPlayerCharacter(playerIndex, playerCharacter);
        var list = _characterConfig.CharacterInfos.ToList();
        var index = list.FindIndex(characterInfo => characterInfo.playerCharacter == playerCharacter);
        var characterInfo = list[index];
        SetCharacterInfo(characterInfo);
    }

    private void OnMouseDown()
    {
        var list = _characterConfig.CharacterInfos.ToList();
        var index = list.FindIndex(characterInfo => characterInfo.playerCharacter == playerCharacter);
        var nextIndex = (index + 1) % list.Count;
        var nextCharacterInfo = list[nextIndex];
        SetCharacterInfo(nextCharacterInfo);

        _characterConfig.SetPlayerCharacter(playerIndex, nextCharacterInfo.playerCharacter);
    }

    private void SetCharacterInfo(CharacterInfo characterInfo)
    {
        playerCharacter = characterInfo.playerCharacter;
        var prefab = characterInfo.prefab;
        if (_character) Destroy(_character);

        _character = Instantiate(prefab, gameObject.transform);
    }
}