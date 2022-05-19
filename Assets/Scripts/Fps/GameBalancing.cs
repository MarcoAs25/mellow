using UnityEngine;
[CreateAssetMenu(fileName = "GameBalancing", menuName = "ScriptableObjects/GameBalancing", order = 1)]
public class GameBalancing : ScriptableObject
{
    public float maxTime = 60f;
    public float incrementTimeValue = 1f;
    public float decrementTimeValue = 1f;
    public int maxmellowsInScene = 5;
    public float timeSpawn = 0.5f;
    [Range(0.1f, 10f)]
    public float maxRandomVel = 1f;
    [Range(0.1f, 10f)]
    public float minRandomVel = 1.5f;
}
