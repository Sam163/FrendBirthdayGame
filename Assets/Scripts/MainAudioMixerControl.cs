using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;


public class MainAudioMixerControl:MonoBehaviour
{
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider effectsVolume;

    public AudioMixer mainMixer;

    void Start() {
        masterVolume.value = GetMasterVolume();
        musicVolume.value = GetMusicVolume();
        effectsVolume.value = GetEffectsVolume();
    }

    public void SetMasterVolume(float vol)
    {
        mainMixer.SetFloat("MasterVolumeParam", vol);
    }
    public void SetMusicVolume(float vol)
    {
        mainMixer.SetFloat("MusicVolumeParam", vol);
    }
    public void SetEffectsVolume(float vol)
    {
        mainMixer.SetFloat("SfxParam", vol);
    }

    public float GetMasterVolume()
    {
        float vol;
        mainMixer.GetFloat("MasterVolumeParam",out vol);
        return vol;
    }
    public float GetMusicVolume()
    {
        float vol;
        mainMixer.GetFloat("MusicVolumeParam", out vol);
        return vol;
    }
    public float GetEffectsVolume()
    {
        float vol;
        mainMixer.GetFloat("SfxParam",out vol);
        return vol;
    }
}

