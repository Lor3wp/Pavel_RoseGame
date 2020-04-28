using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startFungus : MonoBehaviour
{
    public int startTutoNumber;
    public int endTutoNumber;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            tutorialManager.instance.showFungus(startTutoNumber);
            if(endTutoNumber != null)
            {
                tutorialManager.instance.hideFungus(endTutoNumber);
            }
        }
    }
}
