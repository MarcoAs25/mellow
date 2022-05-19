using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEmission : MonoBehaviour
{
    void Start()
    {
        
    }
    public void twrow()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 20f), ForceMode.Impulse);
    }
}
