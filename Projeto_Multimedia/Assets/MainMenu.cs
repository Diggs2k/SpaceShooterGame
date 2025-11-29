using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; 

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void setQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;
    public void setMusic(float musicVolume){
        musicMixer.SetFloat("music", musicVolume);
    }
        public void setSFX(float sfxVolume){
        sfxMixer.SetFloat("sfx", sfxVolume);
    }


}
