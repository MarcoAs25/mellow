using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canvasManager : MonoBehaviour
{
    public GameObject transparentBlack,popUp,background, backgroundOne,textField,btnPlay;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void OnPlay()
    {
        textField.SetActive(false);
        btnPlay.GetComponent<Button>().enabled = false;
        transparentBlack.SetActive(true);
        popUp.SetActive(true);
    }
    public void OnReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnReturn()
    {
        transparentBlack.SetActive(false);
        popUp.SetActive(false);
    }
    public void OnClickGameOne()
    {
        SceneManager.LoadScene("FpsScene");
    }
    public void OnClickGameTwo()
    {
        SceneManager.LoadScene("PuzzleGame");
    }
    public void OnclickReturnMenu()
    {
        textField.SetActive(true);
        btnPlay.GetComponent<Button>().enabled = true;
        transparentBlack.SetActive(false);
        popUp.SetActive(false);
    }
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
