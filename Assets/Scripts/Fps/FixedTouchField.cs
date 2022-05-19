using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 TouchDist;
    private Vector2 PointerOld;
    private int PointerId;
    private bool Pressed;
    private InputManager inpManager;

    [SerializeField] private ParticleSystem ps;

    private void Start()
    {
        inpManager = FindObjectOfType<InputManager>();
    }
    void Update()
    {
        if (Pressed)
        {
            
            TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
            PointerOld = Input.mousePosition;
            
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }

    public Vector2 GetTouchDist()
    {
        return TouchDist;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        inpManager.SetIsShooting(true);
    }

}
