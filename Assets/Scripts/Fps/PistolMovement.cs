using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PistolMovement : MonoBehaviour
{
    private InputManager inputPlayer;
    private float rotationX = 0;
    private float rotationY = 0;
    private PistolLockRotation pistolL;

    [SerializeField] private Rigidbody waterProjectile;

    [SerializeField] private Transform posFire;
    [SerializeField] private Transform pistol;
    [SerializeField] private bool canFire = true;

    [SerializeField] private float timeOfWait = 0.5f;
    [SerializeField] private float time = 0f;

    [SerializeField] private Slider imgscale;
    void Start()
    {
        pistolL = FindObjectOfType<PistolLockRotation>();
        inputPlayer = FindObjectOfType<InputManager>();
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if(time > timeOfWait)
        {
            canFire = true;
        }
        imgscale.value = Mathf.Clamp(time / timeOfWait, 0f, 1f);
        if (inputPlayer.IsShooting() && canFire)
        {
            time = 0f;
            canFire = false;
            inputPlayer.SetIsShooting(false);
            SoundManager.Instance.PlayShoot();
            ShootWater();
            //StartCoroutine(Shoot());

        }
        else
        {
            inputPlayer.SetIsShooting(false);
        }

        Vector2 mousePosition = inputPlayer.GetDeltaCordinates() * inputPlayer.GetMouseSensitivy();
        //if(rotationX > -pistolL.GetMaxAngles().x && rotationX < pistolL.GetMaxAngles().x )
        rotationX += mousePosition.x;
        //if(-rotationY > -pistolL.GetMaxAngles().y && rotationY < pistolL.GetMaxAngles().z)
        rotationY += mousePosition.y;
        transform.localEulerAngles = new Vector3(Mathf.Clamp(-rotationY, -pistolL.GetMaxAngles().y, pistolL.GetMaxAngles().z), Mathf.Clamp(rotationX, -pistolL.GetMaxAngles().x, pistolL.GetMaxAngles().x));
        rotationX = Mathf.Clamp(rotationX, -pistolL.GetMaxAngles().x, pistolL.GetMaxAngles().x);
        rotationY = Mathf.Clamp(rotationY, -pistolL.GetMaxAngles().z, pistolL.GetMaxAngles().y);
    }


    private void ShootWater()
    {
        Rigidbody tiroInstancia = Instantiate(waterProjectile, posFire.transform.position + posFire.transform.TransformDirection(new Vector3(0, 0,0)), posFire.transform.rotation);

        tiroInstancia.velocity = posFire.transform.TransformDirection(new Vector3(20f, 0, 0));
    }
    IEnumerator Shoot()
    {

        yield return new WaitForSeconds(1f);
        canFire = true;
        
    }
}
