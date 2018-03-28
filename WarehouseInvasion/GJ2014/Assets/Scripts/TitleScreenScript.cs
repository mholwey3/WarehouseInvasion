using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour
{
    public GameObject titleScreenPanel;
    public GameObject howToPlayPanel;
    public GameObject createdByPanel;

    void Start()
    {
        titleScreenPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        createdByPanel.SetActive(false);
    }

    public void EnterGame()
    {
        Application.LoadLevel(1);
    }

    public void DisplayTitleScreen()
    {
        howToPlayPanel.SetActive(false);
        createdByPanel.SetActive(false);
        titleScreenPanel.SetActive(true);
    }

    public void DisplayHowToPlay()
    {
        titleScreenPanel.SetActive(false);
        createdByPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
    }

    public void DisplayCreatedBy()
    {
        titleScreenPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        createdByPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
