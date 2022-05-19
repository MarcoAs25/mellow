using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _MyPlayerShooter : MonoBehaviour
{
    [Header("Corpo")]
    public GameObject cabeca;
    public GameObject braco;
    public Image img;
    public Image weaponImg;

    public Sprite[] imgsW;

    [Header("Configurações")]
    public float velAvanco = 2;
    public float velRotacao = 2;
    
    public float minY = -45;
    public float maxY = 45;

    public float jumpSpeed = 5;

    public float gravidade = 10;


    [Header("Tiro")]
    public GameObject tiroSpawner;
    public Rigidbody tiro;
    public float velTiro;
    float deltaX;
    float mouseAnteriorX;
    float rotationY = 0;
    CharacterController cController;
    private Vector3 moveDirection =  Vector3.zero;
    private Vector3 rotationDirection = Vector3.zero;

    //Configs de armas e tempo de recarga 

    private int weapon = 1;
    float rechargeTime;
    private float timerAux = 0;
    bool isRecharging  = false;
    bool canRecharge =  false;

    bool gunslinger = false;

    void Start()
    {
        cController = GetComponent<CharacterController>();
        mouseAnteriorX = Input.mousePosition.x;
        Cursor.visible = false;
        weaponImg.sprite = imgsW[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        Screen.lockCursor = true;
        if (cController.isGrounded)
        {
            //Rotação da cabeca para cima - para baixo
            rotationY += Input.GetAxis ("Mouse Y") * velRotacao * Time.deltaTime * 50;
            rotationY = Mathf.Clamp (rotationY, minY, maxY);

            cabeca.transform.localEulerAngles = new Vector3 (-rotationY, 0, 0);
            braco.transform.localEulerAngles = new Vector3 (-rotationY, 0, 0);

            //Rotação do Corpo
            rotationDirection = new Vector3(0, Input.GetAxisRaw("Mouse X") * velRotacao * Time.deltaTime, 0);
            
            deltaX = Input.mousePosition.x - mouseAnteriorX;
            
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= velAvanco;

            rotationDirection = new Vector3(0, Input.GetAxis("Mouse X") * velRotacao * Time.deltaTime * 30, 0);

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= velAvanco;
            moveDirection = transform.TransformDirection(moveDirection);

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravidade * Time.deltaTime;
        

        mouseAnteriorX = Input.mousePosition.x;
        cController.Move(moveDirection * Time.deltaTime);
        transform.Rotate(rotationDirection);


        if (Input.GetButtonDown("Fire1"))
        {
            Tiro(0.5f, 60);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Tiro(2, 20);
        }   

    }

    private void Tiro(float projectSize, float projectVel)
    {
        Rigidbody tiroInstancia = Instantiate(tiro, tiroSpawner.transform.position + tiroSpawner.transform.TransformDirection(new Vector3 (0,0, projectSize * 2)), tiroSpawner.transform.rotation);

        tiroInstancia.gameObject.transform.SendMessage("Tamanho", projectSize, SendMessageOptions.DontRequireReceiver);

        tiroInstancia.velocity = tiroSpawner.transform.TransformDirection(new Vector3(0,0, projectVel));
    }
}
