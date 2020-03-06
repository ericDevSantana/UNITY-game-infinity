using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackController : MonoBehaviour
{
    public AudioClip soundTrack;
    public AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {
        soundSource.clip = soundTrack;
        soundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
