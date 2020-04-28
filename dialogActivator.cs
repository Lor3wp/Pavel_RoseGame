using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class dialogActivator : MonoBehaviour
{
    public Flowchart dialogi;

    public bool canActive;

    private void FixedUpdate()
    {
        if(dialogi == null)
        {
            return;
        }
        if (dialogi.GetBooleanVariable("DialogStop"))
        {
            dialogi.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        if (canActive)
        {
            dialogi.gameObject.SetActive(true);

            canActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActive = true;
        }
    }


}
