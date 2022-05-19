using UnityEngine;

public class ObjectRotateInput : MonoBehaviour
{
    private Vector3 clickpos;
   // public AudioSource aud;
    private void OnMouseUpAsButton()
    {
        //   aud.Play();
        UiBgSoundManager.Instance.RotatePipes();
        transform.Rotate(0, 0, 90);
    }
}
