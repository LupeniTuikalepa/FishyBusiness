using UnityEngine;
using UnityEngine.UI;

namespace FishyBusiness.MenuSystem.MenuData
{
    public class SettingsMenu : BaseMenu
    {
        public Slider musicSlider;
        public Slider sfxSlider;
        public AudioSource musicSource;
        public AudioSource sfxSource;

        void Start()
        {
            
            if (musicSource != null)
                musicSlider.value = musicSource.volume;

            if (sfxSource != null)
                sfxSlider.value = sfxSource.volume;
        }
        
        public void SetMusicVolume(float volume)
        {
            if (musicSource != null)
            {
                musicSource.volume = volume;
            }
        }
        
        public void SetSFXVolume(float volume)
        {
            if (sfxSource != null)
            {
                sfxSource.volume = volume;
            }
        }
    }
}