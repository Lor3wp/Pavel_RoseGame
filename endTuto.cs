using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTuto : MonoBehaviour
{
    public int endTutonumber;

    public Transform startTuto;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tutorialManager.instance.hideTutorial(endTutonumber);
            Destroy(gameObject);
            if(startTuto != null)
            {
                Destroy(startTuto.gameObject);

            }
        }
    }

}
