using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MellowFollowWater : MonoBehaviour
{
    [SerializeField] private BanheiraMovement water;
    [SerializeField] private float speed = 10f;
    [SerializeField] private bool start = false;
    [SerializeField] public float randomXaxis;
    Vector3 oldPosition;
    Vector3 newPosMovement;
    [SerializeField] public ParticleSystem part;
    private void Start()
    {
        part = GetComponentInChildren<ParticleSystem>();
        randomXaxis = Random.Range(-0.9f, 0.9f);
        water = FindObjectOfType<BanheiraMovement>(); ;
    }
    public void StartMovement()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<SphereCollider>().isTrigger = true;
        start = true;
    }
    void Update()
    {
        
        if (start)
        {
            oldPosition = transform.position;
            newPosMovement = Vector3.MoveTowards(transform.position, new Vector3(water.gameObject.transform.position.x + randomXaxis, water.gameObject.transform.position.y, water.gameObject.transform.position.z), speed * Time.deltaTime);
            transform.position = newPosMovement;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "water")
        {
            part.gameObject.transform.position = transform.position;
            part.Play();
            SoundManager.Instance.PlaySplash();
            Destroy(gameObject, 2f);
        }
    }
}
