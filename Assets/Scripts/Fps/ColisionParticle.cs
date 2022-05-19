using UnityEngine;

public class ColisionParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem splashPart;
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Target")
        {
            
            FpsGameManager.Instance.timeElapsed = 0f;
            FpsGameManager.Instance.mellowsInScene--;
            FpsGameManager.Instance.AddTime();
            SoundManager.Instance.PlaySplash();
            Destroy(other);
            //Add object pooling
        }
        //ParticleSystem a = Instantiate(splashPart) as ParticleSystem;
        //splashPart.transform.position = transform.position;
        //splashPart.Play();
        //Destroy(splashPart, 1);
        Destroy(gameObject);
    }
}
