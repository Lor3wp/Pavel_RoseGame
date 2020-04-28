using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class fungusObject : MonoBehaviour
{
    public Flowchart dialogi;

    public bool canActive;

    private void FixedUpdate()
    {
        if (dialogi == null)
        {
            return;
        }
        if (dialogi.GetBooleanVariable("DialogStop"))
        {
            Destroy(gameObject);
            dialogi.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        if (canActive)
        {
            dialogi.gameObject.SetActive(true);

            canActive = false;
        }
    }

    private void Awake()
    {
        canActive = true;
    }
    public void show()
    {
        gameObject.SetActive(true);
    }
}
