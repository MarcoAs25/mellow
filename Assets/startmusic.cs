using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UiBgSoundManager.Instance.PlayBgMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
