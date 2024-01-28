using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandomizer : MonoBehaviour
{
    public GameObject[] backgrounds;
    
    void Start()
    {
        foreach (var background in backgrounds)
        {
            background.SetActive(false);
        }

        var index = Random.Range(0, backgrounds.Length);
        backgrounds[index].SetActive(true);
    }
}
