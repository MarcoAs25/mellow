using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource splash, water, bubble;
    
    public static SoundManager Instance;
    public AudioSource sounDFunny;
    public AudioClip[] audios;
    public float time, TimeSpawn = 5f;
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
        
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time > TimeSpawn)
        {
            time = 0f;
            TimeSpawn = Random.Range(6f, 15f);
            sounDFunny.clip = audios[Random.Range(0, audios.Length)];
            sounDFunny.Play();
        }
    }

    public void PlayShoot()
    {
        if(Time.timeScale >0f)
            water.Play();
    }
    public void PlaySplash()
    {
        if (Time.timeScale > 0f)
            splash.Play();
    }
    public void PlayBubble()
    {
        if (Time.timeScale > 0f)
            bubble.Play();
    }
}
