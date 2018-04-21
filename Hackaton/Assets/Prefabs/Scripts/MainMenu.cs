using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static int characNmb;

    public void LoadScene (int i)
    {
        characNmb = i;
        SceneManager.LoadScene("FirstScene");
    }
}
