using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float randomVel, randomAngle;

    void Start()
    {
        randomAngle = Random.Range(0f,360f) * Mathf.Deg2Rad;
        randomVel = Random.Range(FpsGameManager.Instance.FpsgambeBalancing.minRandomVel, FpsGameManager.Instance.FpsgambeBalancing.maxRandomVel);
    }
    private bool IsObjectInView(GameObject Object)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes,
            Object.GetComponent<SphereCollider>().bounds);
    }

    private void FixedUpdate()
    {
        var direction = GetVectorDirection();
        transform.Translate(direction * FpsGameManager.Instance.velocityTarget * randomVel * Time.fixedDeltaTime);
        if(transform.position.y <= FpsGameManager.Instance.bottomReference.position.y)
        {
            Vector3 normal = Vector3.up;
            Vector3 newDirection = Vector3.Reflect(GetVectorDirection(), normal);
            randomAngle = Mathf.Atan2(newDirection.y, newDirection.x);
        }
    }

    void Update()
    {
        if (!IsObjectInView(gameObject))
        {
            FpsGameManager.Instance.DecrementMellowsInScene();
            FpsGameManager.Instance.DecrementTime();
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {Debug.Log("Colidiu");
        if (collision.gameObject.tag == "Target")
        {
            
            Vector3 normal = transform.position - collision.gameObject.transform.position;
            Vector3 newDirection = Vector3.Reflect(GetVectorDirection(), normal);
            randomAngle = Mathf.Atan2(newDirection.y, newDirection.x);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Debug.Log("Colidiu");
            Vector3 normal = transform.position - other.gameObject.transform.position;
            Vector3 newDirection = Vector3.Reflect(GetVectorDirection(), normal);
            randomAngle = Mathf.Atan2(newDirection.y, newDirection.x);
        }
    }
    private Vector3 GetVectorDirection()
    {
        return new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0f);
    }
}
