using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace FishyBusiness.Sounds
{
    public class SoundsManager : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup master;
        [SerializeField] private AudioMixerGroup sfx;
        public Slider musicVolumeSlider;
        public Slider sfxVolumeSlider;

        private float currentVolume = 0f;

        public void Start()
        {
            SetMusicVolume(musicVolumeSlider.value);
            SetSfxVolume(sfxVolumeSlider.value);
            float currentVolume = 0f;
        }

        public void SetMusicVolume(float sliderValue)
        {
            if (sliderValue <= 0.0001f)
            {
                master.audioMixer.SetFloat("Music", -80);
                return;
            }
            master.audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
            
        }
        
        public void SetSfxVolume(float sliderValue)
        {
            master.audioMixer.SetFloat("Sfx", Mathf.Log10(sliderValue) * 20);
        }
    }
}