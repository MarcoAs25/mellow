using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolLockRotation : MonoBehaviour
{

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector3 maxViewPort;
    [SerializeField] private Transform posFire;
    [SerializeField] private Transform bottomReference;

    [SerializeField] private Vector3 maxAngles;
    [SerializeField] private Vector3 maxPoints;
    [Range(0.1f, 1f)]
    [SerializeField] private float percentScreenAim;
    [Range(0.1f, 1f)]
    [SerializeField] private float percentScreenTargetSpawn;

    void Start()
    {
        maxAngles = new Vector3(GetHorizontalAngle(), GetVerticalAngle(), GetBottomReference());
    }
    public float GetBottomReference()
    {
        RaycastHit hit;
        if (Physics.Raycast(bottomReference.position, bottomReference.forward, out hit, 100, layerMask))
        {
            maxViewPort = hit.point;
            maxPoints.z = hit.point.y * percentScreenTargetSpawn;
        }
        Vector3 targetDir = maxViewPort - transform.position;
        float angle = Vector3.Angle(targetDir, posFire.right);
        return angle * percentScreenAim;
    }
    public float GetVerticalAngle()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            maxViewPort = hit.point;
            maxPoints.y = hit.point.y;
        }
        Vector3 targetDir = maxViewPort - transform.position;
        float angle = Vector3.Angle(targetDir, posFire.right);
        return angle * percentScreenAim;
    }
    private float GetHorizontalAngle()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            maxViewPort = hit.point;
            maxPoints.x = hit.point.x * percentScreenTargetSpawn;
        }
        Vector3 targetDir = maxViewPort - transform.position;
        float angle = Vector3.Angle(targetDir, posFire.right);
        return angle * percentScreenAim;
    }
    public Vector3 GetMaxAngles()
    {
        return maxAngles;
    }
    public Vector3 GetMaxPoints()
    {
        return maxPoints;
    }
}
