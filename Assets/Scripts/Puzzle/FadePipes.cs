using UnityEngine;
[RequireComponent(typeof(Animator))]
public class FadePipes : MonoBehaviour
{
    #region Variables of Animator

    [Header("Animator of Pipe")]
    //[SerializeField] private Animator anim;
    private Material material;
    private int ballsAux = 0;
    public MeshRenderer gm;
    #endregion
    private void FixedUpdate()
    {
        if(ballsAux > 0)
        {
            gm.enabled = false;
        }
        else
        {
            gm.enabled = true;

        }
    }
    private void Start()
    {
    //    anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ballsAux++;
          //  anim.SetInteger("foodQuantity", ballsAux);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ballsAux--;
        //    anim.SetInteger("foodQuantity", ballsAux);
        }
    }
}
