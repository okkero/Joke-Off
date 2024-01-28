using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Debug.unityLogger.Log($"Winner is {VictoryData.WinnerPlayer}");

        foreach (var target in VictoryData.WinnerCharacter.AttackTargets) DestroyImmediate(target.gameObject);

        Instantiate(VictoryData.WinnerCharacter.gameObject, transform.TransformPoint(Vector3.up),
            Quaternion.identity);
        Destroy(VictoryData.WinnerCharacter.gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}