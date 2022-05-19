using UnityEngine;

public class SpawnFoods : MonoBehaviour
{
    public int Quantity;
    public GameObject[] foods;
    public float timeOfSpawn = .1f;
    public float time = -0.1f;
    public bool spawn = false;
    public bool flag = false;
    void Update()
    {
        if (spawn)
        {
            if (!flag)
            {
                flag = true;
                Quantity--;
                GameObject objInstantitated = Instantiate(foods[2], transform) as GameObject;
                objInstantitated.transform.position = transform.position;
                time = 0f;
            }
            time += Time.deltaTime;
            if (time > timeOfSpawn && Quantity > 0)
            {
                Quantity--;
                GameObject objInstantitated = Instantiate(foods[Random.Range(0, 2)], transform) as GameObject;
                objInstantitated.transform.position = transform.position;
                time = 0f;
            }
        }
    }
    public void StartSpawnFood()
    {
        spawn = true;
    }
}
