using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeControl : MonoBehaviour
{
    private SoundManager _soundManager;
    private Slider _slider;
    private static float volume = 1;
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _soundManager = FindAnyObjectByType<SoundManager>();
        

        _slider.value = volume;

        _soundManager.AudioSource.volume = volume;
    }
    public void SliderMusic()
    {
        volume = _slider.value;
        _soundManager.AudioSource.volume = volume;
        _slider.value = volume;
    }

}
