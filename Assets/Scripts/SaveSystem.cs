using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //Function that save the score
    public void saveBestScore(string key, float bestScore)
    {
        PlayerPrefs.SetFloat("Best Score", bestScore);
    }

    //Function that load the score
    public float loadBestScore()
    {
        return PlayerPrefs.GetFloat("Best Score");
    }
}
