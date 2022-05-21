using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBgSoundManager : MonoBehaviour

{
    public static UiBgSoundManager Instance;
    public AudioSource bgMenu, bgFps, bgPuzzle,vitorymusic,defeatMusic;
    public AudioSource[] foodfall;
    public AudioSource[] rotatePipes;
    public AudioSource audBtn1, audBtn2, audBtn3;
    public float smooth = 0.4f;
    public bool returnedflag1 = false, returnedflag2 = false, winflag = false, loseflag = false;
    public void playaud1()
    {
        audBtn1.Play();
    }
    public void playaud2()
    {
        audBtn2.Play();
    }

    public void playaud3()
    {
        audBtn3.Play();
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
        vitorymusic.volume = 0f;
        vitorymusic.Play();
        bgPuzzle.Pause();
    }
    public void PlaybgPuzzle2()
    {
        bgPuzzle.volume = 0f;
        vitorymusic.Stop();
        bgPuzzle.UnPause();
    }
    public void PlayDefeat()
    {
        //defeatMusic.volume = 0f;
        defeatMusic.Play();
       // bgMenu.Stop();
        bgFps.Stop();
       // bgPuzzle.Stop();
    }
    public void PlayBgMenu()
    {
        bgMenu.volume = 0f;
        defeatMusic.Stop();
        vitorymusic.Stop();
        bgMenu.Play();
        bgFps.Stop();
        bgPuzzle.Stop();
    }
    public void PlayBgFps()
    {
        bgFps.volume = 0f;
        defeatMusic.Stop();
        vitorymusic.Stop();
        bgMenu.Stop();
        bgFps.Play();
        bgPuzzle.Stop();
    }
    public void PlayBgPuzzle()
    {
        bgPuzzle.volume = 0f;
        vitorymusic.Stop();
        bgMenu.Stop();
        bgFps.Stop();
        bgPuzzle.Play();
    }
    private void Update()
    {
        if (bgPuzzle.volume < 0.8f) {
            bgPuzzle.volume += Time.deltaTime*0.7f;
        }
        if (bgFps.volume < 0.8f)
        {
            bgFps.volume += Time.deltaTime * 0.8f;
        }
        if (vitorymusic.volume < 0.8f)
        {
            vitorymusic.volume += Time.deltaTime * 0.8f;
        }
        if (bgMenu.volume < 0.8f)
        {
            bgMenu.volume += Time.deltaTime * 0.8f;
        }
    }
}
