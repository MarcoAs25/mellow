using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimFollow : MonoBehaviour
{
    private float distance = 100f;
    [SerializeField] private Transform posFire;
    [SerializeField] private Transform aimSprite;
    [SerializeField] private LayerMask lm;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(posFire.position, posFire.right, out hit, distance, lm))
        {
            aimSprite.position = new Vector3(hit.point.x, hit.point.y, 4.205f);
            Debug.DrawLine(posFire.position, hit.point);
        }
    }
}
