using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource cardSelectSource;
    AudioSource cardMatchAcceptSource;
    AudioSource cardMatchDeclineSource;
    //AudioSource backgroundSource;

    void Awake()
    {
        AudioSource[] allAudioSources = GetComponents<AudioSource>();
        cardSelectSource = allAudioSources[0];
        cardMatchAcceptSource = allAudioSources[1];
        cardMatchDeclineSource = allAudioSources[2];
        //backgroundSource = allAudioSources[3];
    }

    public void PlayCardSelect() => cardSelectSource.Play(); 
    public void PlayCardAccept() => cardMatchAcceptSource.Play(); 
    public void PlayCardDecline() => cardMatchDeclineSource.Play();
    //public void PlayBackground() => backgroundSource.Play();
}
