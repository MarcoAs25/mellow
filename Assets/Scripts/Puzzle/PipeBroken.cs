using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBroken : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<PuzzleUiManager>().RestartLevel(2);
        }
    }
}
