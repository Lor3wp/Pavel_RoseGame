using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject pauseCanvas;

    public static bool isPaused;

    private void Awake()
    {
        isPaused = false;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            Pause();
        } 
    }

    public void Pause()
    {
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        Cursor.visible = true;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseCanvas.gameObject.SetActive(false);
        Cursor.visible = false;

    }
    public void Options()
    {

    }
    public void Quit()
    {
        Time.timeScale = 1;

        GameManager.instance.quitLVL();
    }
}
