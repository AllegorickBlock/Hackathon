using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {

    public GameObject person01;
    public GameObject person02;
    public GameObject person03;
    public GameObject person04;
    public GameObject person05;
    public GameObject person06;

    public GameObject GO_PauseMenu;
    private bool Affichage_PauseMenu = false;

    void Start()
    {
        person01.SetActive(false);
        person02.SetActive(false);
        person03.SetActive(false);
        person04.SetActive(false);
        person05.SetActive(false);
        person06.SetActive(false);

        GO_PauseMenu.SetActive(false);

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
                throw new System.Exception("Error");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("Escape"))
        {
            PauseManager();
        }
    }

    #region private void PauseManager()
    private void PauseManager()
    {
        Affichage_PauseMenu = !Affichage_PauseMenu;
        if (Affichage_PauseMenu)
        {
            GO_PauseMenu.SetActive(false);
        }
        else
        {
            GO_PauseMenu.SetActive(true);
        }
    }
    #endregion
}