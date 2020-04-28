using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    private void Start()
    {
        AudioManager.instance.Play("menuBC");
    }
    public void PlayGame()
    {
        AudioManager.instance.Play("menuSFX");
        AudioManager.instance.StopPlay("menuBC");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;

        AudioManager.instance.Play("backGround");


    }


    public void quitGame()
    {
        AudioManager.instance.Play("menuSFX");

        Application.Quit();
    }

    public void PlaySound()
    {
        AudioManager.instance.Play("menuSFX");
    }
}
