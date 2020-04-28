using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainFolder : MonoBehaviour
{

    public static mainFolder instance;


    // Start is called before the first frame update
    void Awake()
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

    private void FixedUpdate()
    {
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            destroyObject();
        }
        */
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }

}
