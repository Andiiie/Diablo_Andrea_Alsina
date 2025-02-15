using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titulo : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(2);
        Debug.Log("ju");

    }
    public void Exit()
    {
        Application.Quit();

    }
    public void Tutorial()
    {
        SceneManager.LoadScene(1);

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);

    }
}
