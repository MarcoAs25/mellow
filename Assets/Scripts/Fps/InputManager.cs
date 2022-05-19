using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private bool isShooting = false;
    [SerializeField] private Vector2 deltaCord;
    [Range(0.1f,0.8f)]
    [SerializeField] private float mouseSens = 0.1f;
    private FixedTouchField fixedTF;

    private void Start()
    {
        fixedTF = FindObjectOfType<FixedTouchField>();
    }

    public float GetMouseSensitivy()
    {
        return this.mouseSens;
    }

    private void Update()
    {
        deltaCord = fixedTF.GetTouchDist();
    }
    public void Shoot()
    {
        isShooting = true;
    }

    public Vector2 GetDeltaCordinates()
    {
        return this.deltaCord;
    }

    public bool IsShooting()
    {
        return isShooting;
    }

    public void SetIsShooting(bool isShooting)
    {
        this.isShooting = isShooting;
    }
}
