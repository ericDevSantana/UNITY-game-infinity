using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBestScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveBestScore(string key, float bestScore)
    {
        PlayerPrefs.SetFloat("Best Score", bestScore);
    }

    public float loadBestScore()
    {
        return PlayerPrefs.GetFloat("Best Score");
    }
}
