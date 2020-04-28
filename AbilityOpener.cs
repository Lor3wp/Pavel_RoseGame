using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityOpener : MonoBehaviour
{
    public bool jumpAbility;
    public bool wallAbilities;
    public bool dashAbilities;
    public bool attackaAbilities;

    public bool diasble;

    public Transform activator;
    public Transform hint;

    private void FixedUpdate()
    {
        if (jumpAbility)
        {
            if (GameManager.instance.JumpAbility)
            {
                gameObject.SetActive(false);
            }
        }
         if (wallAbilities)
        {
            if (GameManager.instance.wallAbility)
            {
                gameObject.SetActive(false);
            }
        }
         if (dashAbilities)
        {
            if (GameManager.instance.dashAbility)
            {
                gameObject.SetActive(false);
            }
        }
         if (attackaAbilities)
        {
            if (GameManager.instance.attackAbility)
            {
                gameObject.SetActive(false);
            }
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)){
                if (jumpAbility)
                {

                    GameManager.instance.JumpAbility= true;
                    visualTutoManager.instance.showTutoriall(0);
                }
                if (wallAbilities)
                {
                    GameManager.instance.wallAbility = true;
                    visualTutoManager.instance.showTutoriall(1);

                }
                if (dashAbilities)
                {
                    GameManager.instance.dashAbility = true;
                    visualTutoManager.instance.showTutoriall(3);

                }
                if (attackaAbilities)
                {
                    GameManager.instance.attackAbility = true;
                    visualTutoManager.instance.showTutoriall(2);

                }
                if (diasble)
                {
                    gameObject.SetActive(false);

                }
                if(activator != null)
                {
                activator.gameObject.SetActive(true);

                }
                if(hint != null)
                {
                Destroy(hint.gameObject);

                }

            }
            if(hint != null)
            {
            hint.gameObject.SetActive(true);

            }
        }
    }

}
