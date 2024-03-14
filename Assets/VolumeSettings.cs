using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    public void SetVolume()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volumeSlider.value) * 20);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
    
    public void MuteVolume(bool isMuted)
    {
        if (isMuted)
        {
            audioMixer.SetFloat("Volume", -80);
            volumeSlider.value = 0;
        }
        else
        {
            audioMixer.SetFloat("Volume", Mathf.Log10(volumeSlider.value) * 20);
        }
    }
}
