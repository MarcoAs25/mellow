using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{
    public static PuzzleGameManager instance;
    [SerializeField] private GameObject[] foodObjects;
    [SerializeField] public GameObject gmMenu;
    [SerializeField] public Button btn1, btn2, btn3;
    [SerializeField] public bool rolling = false;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void Win()
    {
        gmMenu.SetActive(true);
        btn1.enabled = false;
        btn2.enabled = false;
        btn3.enabled = false;
    }
    public void StartFoodMovement()
    {
        foreach (GameObject foodObj in foodObjects)
        {
            foodObj.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
