using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour {

    public GameObject person01;
    public GameObject person02;
    public GameObject person03;
    public GameObject person04;
    public GameObject person05;
    public GameObject person06;

    public GameObject GO_PauseMenu;
    private bool Affichage_PauseMenu = false;

    public static InputField phraseToSay;
    public InputField PhraseToSay;

    void Start()
    {
        person01.SetActive(false);
        person02.SetActive(false);
        person03.SetActive(false);
        person04.SetActive(false);
        person05.SetActive(false);
        person06.SetActive(false);

        GO_PauseMenu.SetActive(false);

        phraseToSay = PhraseToSay;

        switch (MainMenu.characNmb)
        {
            case 1:
                person01.SetActive(true);
                break;
            case 2:
                person02.SetActive(true);
                break;
            case 3:
                person03.SetActive(true);
                break;
            case 4:
                person04.SetActive(true);
                break;
            case 5:
                person05.SetActive(true);
                break;
            case 6:
                person06.SetActive(true);
                break;
            default:
                break;
        }
    }

    void Update()
    {
        //if call pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseManager();
        }
    }

    #region private void PauseManager()
    private void PauseManager()
    {
        if (Affichage_PauseMenu)
        {
            Affichage_PauseMenu = !Affichage_PauseMenu;
            GO_PauseMenu.SetActive(false);
        }
        else
        {
            Affichage_PauseMenu = !Affichage_PauseMenu;
            GO_PauseMenu.SetActive(true);
        }
    }
    #endregion

    #region public void LoadMainMenu()
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region public void OptionWindow()
    public void OptionWindow()
    {

    }
    #endregion

    #region public void QuitApp()
    public void QuitApp()
    {
        Application.Quit();
    }
    #endregion
}