using UnityEngine;
using UnityEngine.UI;

public class CountFoods : MonoBehaviour
{
    public float foodQt = 0;
    public float qtdWin = 3;
    public bool flag = false;
    public Slider sl;
    private void Update()
    {
        sl.value = foodQt / qtdWin;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UiBgSoundManager.Instance.FoodFall();
            foodQt++;
            
            if(foodQt >= qtdWin && !flag)
            {
                UiBgSoundManager.Instance.PlayVitoryPuzzle();
                flag = true;
                PuzzleGameManager.instance.Win();
            }
        }
    }
}
