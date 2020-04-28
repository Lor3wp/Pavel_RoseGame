using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualTutoManager : MonoBehaviour
{
    public static visualTutoManager instance;
    public tutorialAnim[] tutorials;
    public Animator anim;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void showTutoriall(int tutorialNumber)
    {
        tutorials[tutorialNumber].show();
    }
}
