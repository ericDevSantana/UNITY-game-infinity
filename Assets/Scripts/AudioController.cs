using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffects
{
    HIT
}

//Singleton of the class that controls the sound effects
public class AudioController : MonoBehaviour
{
    public AudioClip hitEffect;

    public static AudioController audioControllerInstance;

    //Call on Awake because it needs to be available before something called in Start
    private void Awake()
    {
        //instance of this class
        audioControllerInstance = this;
    }

    //function to call with desired soundEffects from the enum SoundEffects
    public static void playSound(SoundEffects sound)
    {
        switch (sound)
        {
            case SoundEffects.HIT:
            {
                audioControllerInstance.GetComponent<AudioSource>().PlayOneShot(audioControllerInstance.hitEffect);
            }
            break;
        }
    }
}
