using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripDoDestrutivel : MonoBehaviour
{
    [SerializeField] GameObject explosionParticula;
    [SerializeField] GameObject mallow;
    

    public void ExplodirBolha()
    {
        Instantiate(explosionParticula, transform.position, transform.rotation);
        GameObject mallowInstantiated = Instantiate(mallow, transform.position, transform.rotation) as GameObject;
        mallowInstantiated.GetComponent<MellowFollowWater>().StartMovement();
        Destroy(gameObject);
    }
}
