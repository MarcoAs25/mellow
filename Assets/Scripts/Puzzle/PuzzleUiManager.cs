using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleUiManager : MonoBehaviour
{
    [SerializeField] public SpawnFoods spwn;
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartBallsMovement()
    {
        spwn.StartSpawnFood();
        //PuzzleGameManager.instance.StartFoodMovement();
    }

    public void LoadScene(string nameScene)
    {
        if(nameScene != "mainMenu")
            UiBgSoundManager.Instance.PlaybgPuzzle2();
        SceneManager.LoadScene(nameScene);
    }
}
