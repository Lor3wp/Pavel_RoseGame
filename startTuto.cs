using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTuto : MonoBehaviour
{
    public int startTutoNumber;


    public Transform endOfTuto;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tutorialManager.instance.showtutorial(startTutoNumber);
            if(endOfTuto != null)
            {
            endOfTuto.gameObject.SetActive(true);

            }
        }
    }
}
