using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDoProojetil : MonoBehaviour
{
    public float lifeTime = 3;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    public void Tamanho(float numero)
    {
        transform.localScale = new Vector3(numero, numero, numero);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.tag == "Target")
        {
            FpsGameManager.Instance.timeElapsed = 0f;
            FpsGameManager.Instance.mellowsInScene--;
            FpsGameManager.Instance.AddTime();
            SoundManager.Instance.PlayBubble();
            //Destroy(other.gameObject);

            FpsGameManager.Instance.SpawnText(transform);
            other.transform.SendMessage("ExplodirBolha", SendMessageOptions.DontRequireReceiver);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {

            Destroy(gameObject);
        }
    }

}
