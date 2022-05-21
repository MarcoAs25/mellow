using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canvasManager : MonoBehaviour
{
    public GameObject transparentBlack,popUp,background, backgroundOne,textField,btnPlay, gameOneInstructions, gameTwoInstructions;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void OnPlay()
    {
        UiBgSoundManager.Instance.audBtn1.Play();
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
        UiBgSoundManager.Instance.audBtn2.Play();
        transparentBlack.SetActive(false);
        popUp.SetActive(false);
    }

    public void OnClickGameOne()
    {
        UiBgSoundManager.Instance.audBtn3.Play();
        gameOneInstructions.SetActive(true);
        //SceneManager.LoadScene("FpsScene");
    }
    public void OnClickGameOnee()
    {
        UiBgSoundManager.Instance.audBtn1.Play();
        SceneManager.LoadScene("FpsScene");
    }
    public void OnClickGameTwo()
    {
        UiBgSoundManager.Instance.audBtn3.Play();
        gameTwoInstructions.SetActive(true);
        //SceneManager.LoadScene("PuzzleGame");
    }
    public void OnClickGametwoo()
    {
        UiBgSoundManager.Instance.audBtn1.Play();
        SceneManager.LoadScene("1");
        //gameTwoInstructions.SetActive(true);
    }
    public void OnclickReturnMenu()
    {
        UiBgSoundManager.Instance.audBtn2.Play();
        gameTwoInstructions.SetActive(false);
        gameOneInstructions.SetActive(false);
        textField.SetActive(true);
        btnPlay.GetComponent<Button>().enabled = true;
        transparentBlack.SetActive(false);
        popUp.SetActive(false);
    }
    public void OnClickMainMenu()
    {
        UiBgSoundManager.Instance.audBtn2.Play();
        SceneManager.LoadScene("mainMenu");
    }

}
