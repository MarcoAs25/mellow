using UnityEngine;

public class roolSound : MonoBehaviour
{
    
    void Update()
    {
        Debug.Log(transform.position.y);
        if(transform.position.y <0 -2f)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
