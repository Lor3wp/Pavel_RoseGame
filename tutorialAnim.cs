using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialAnim : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void show()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("show");
    }
    public void pauseWorld()
    {
        PlayerMovement.instance.canMove = false;
        PlayerMovement.instance.flipAcces = false;
        PlayerMovement.instance.myAnimator.SetFloat("speed", 0);
        GameManager.instance.JumpAbility = false;

    }
    public void resumeWorld()
    {
        PlayerMovement.instance.canMove = true;
        PlayerMovement.instance.flipAcces = true;
        GameManager.instance.JumpAbility = true;
    }
}
