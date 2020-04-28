using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayerAbility : MonoBehaviour
{
    public Transform haveAbility;
    public Transform dontHaveAbility;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(GameManager.instance.wallAbility == true)
            {
                if(haveAbility != null)
                {
                    haveAbility.gameObject.SetActive(true);
                }
            } else if( GameManager.instance.wallAbility == false)
            {
                if(dontHaveAbility != null)
                {
                    dontHaveAbility.gameObject.SetActive(true);
                }
            }
        }
    }

}
