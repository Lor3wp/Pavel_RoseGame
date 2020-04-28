using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public static tutorialManager instance;
    public tutorialObject[] tutorials;

    public fungusObject[] fungus;


    void Start()
    {
        MakeSingleton();
    }
    private void MakeSingleton()
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

    public void showtutorial(int questnumber)
    {
        tutorials[questnumber].show();
    }

    public void hideTutorial(int questnumber)
    {
        tutorials[questnumber].hide();
    }

    public void showFungus(int number)
    {
        if(fungus[number] != null)
        {
        fungus[number].show();
        }
    }
    public void hideFungus(int number)
    {
        if(fungus[number] != null)
        {
            print("toka osa");
            fungus[number].gameObject.SetActive(false);

        }
    }
}
