using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Audio manager script
public class AudioManager : MonoBehaviour
{
    public GameObject audioObject;
    public AudioEffects[] audioEffects;

    public const float defaultVolume = 0.3f;
    public void PlaySoundEffect_AM(PlaySoundTool.AudioLibrary soundName)
    {
        
        GameObject audioSourceInstance = Instantiate(audioObject);
        AudioSource aS = audioSourceInstance.GetComponent<AudioSource>();
        foreach(AudioEffects audio in audioEffects)
        {
            if(audio.audioName == soundName)
            {
                aS.PlayOneShot(audio.audioClip, PlayerPrefs.GetFloat("volume", defaultVolume));
                break;
            }
        }
        Destroy(audioSourceInstance, 3f);
    }
}
public static class PlaySoundTool
{
    public enum AudioLibrary{example};
    public static void PlaySoundEffect(AudioLibrary audioName)
    {
        AudioManager am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        am.PlaySoundEffect_AM(audioName);
    }
}
[System.Serializable]
public class AudioEffects
{
    public PlaySoundTool.AudioLibrary audioName;
    public AudioClip audioClip;
}
