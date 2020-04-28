using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSFX : MonoBehaviour
{
    public float stepDelay;
    public float stTimer;


    private void FixedUpdate()
    {
        if (PlayerMovement.instance.horizontal != 0 && PlayerMovement.instance.isGrounded == true)
        {
                if (stepDelay >= stTimer)
                {
                stTimer += Time.deltaTime;

                }
                else
                {
                AudioManager.instance.Play("step");
                stTimer = 0;
                }
        }


        if (PlayerMovement.instance.attack == true && GameManager.instance.attackAbility == true)
        {
            AudioManager.instance.Play("attack");
        }

        if(PlayerMovement.instance.pressedJump == true && GameManager.instance.JumpAbility == true)
        {
            AudioManager.instance.Play("jump");
        }

    }
}
