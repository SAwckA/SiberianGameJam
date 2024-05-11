using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    private AudioSource _audioSource;
    public AudioSource AudioSource => _audioSource;

    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = _sound;
        _audioSource.Play();
    }

    
}
