using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBgSoundManager : MonoBehaviour

{
    public static UiBgSoundManager Instance;
    public AudioSource bgMenu, bgFps, bgPuzzle,vitorymusic,defeatMusic;
    public AudioSource[] foodfall;
    public AudioSource[] rotatePipes;
    public AudioSource audroll;
    public void PlayRoll()
    {
        audroll.Play();
    }
    public void PauseRoll()
    {
        audroll.Stop();
    }
    public void FoodFall()
    {
        foodfall[Random.Range(0, foodfall.Length)].Play();
    }
    public void RotatePipes()
    {
        rotatePipes[Random.Range(0, rotatePipes.Length)].Play();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void PlayVitoryPuzzle()
    {
        vitorymusic.Play();
        bgPuzzle.Pause();
    }
    public void PlaybgPuzzle2()
    {
        vitorymusic.Stop();
        bgPuzzle.UnPause();
    }
    public void PlayDefeat()
    {
        defeatMusic.Play();
       // bgMenu.Stop();
        bgFps.Stop();
       // bgPuzzle.Stop();
    }
    public void PlayBgMenu()
    {
        defeatMusic.Stop();
        vitorymusic.Stop();
        bgMenu.Play();
        bgFps.Stop();
        bgPuzzle.Stop();
    }
    public void PlayBgFps()
    {
        defeatMusic.Stop();
        vitorymusic.Stop();
        bgMenu.Stop();
        bgFps.Play();
        bgPuzzle.Stop();
    }
    public void PlayBgPuzzle()
    {
        vitorymusic.Stop();
        bgMenu.Stop();
        bgFps.Stop();
        bgPuzzle.Play();
    }
}
