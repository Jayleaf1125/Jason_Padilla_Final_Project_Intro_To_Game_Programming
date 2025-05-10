using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource cardSelectSource;
    AudioSource cardMatchAcceptSource;
    AudioSource cardMatchDeclineSource;

    void Awake()
    {
        AudioSource[] allAudioSources = GetComponents<AudioSource>();
        cardSelectSource = allAudioSources[0];
        cardMatchAcceptSource = allAudioSources[1];
        cardMatchDeclineSource = allAudioSources[2];
    }

    public void PlayCardSelect() => cardSelectSource.Play(); 
    public void PlayCardAccept() => cardMatchAcceptSource.Play(); 
    public void PlayCardDecline() => cardMatchDeclineSource.Play();
}
