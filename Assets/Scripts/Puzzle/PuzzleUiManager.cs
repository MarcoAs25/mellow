using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleUiManager : MonoBehaviour
{
    [SerializeField] public SpawnFoods spwn;
    public void RestartLevel(int i)
    {
        if(i == 1)
        {
            UiBgSoundManager.Instance.playaud3();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartBallsMovement()
    {
        UiBgSoundManager.Instance.playaud2();
        spwn.StartSpawnFood();
        //PuzzleGameManager.instance.StartFoodMovement();
    }

    public void LoadScene(string nameScene)
    {
        if(nameScene != "mainMenu")
            UiBgSoundManager.Instance.PlaybgPuzzle2();
        if (nameScene == "mainMenu")
            UiBgSoundManager.Instance.playaud1();
        SceneManager.LoadScene(nameScene);
    }
}
