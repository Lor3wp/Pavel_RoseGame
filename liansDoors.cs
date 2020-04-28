using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liansDoors : MonoBehaviour
{
    public int doorHP;
    private Animator anim;
    public float shakeTime;
    private bool Up;
    private bool Side;
    public bool shaking;
    Vector2 currentPos;
    public int damageToGive;
    public float knockPWR;
    public bool needCD;
    private void Start()
    {
        anim = GetComponent<Animator>();
        shaking = false;
        currentPos = transform.localPosition;
        needCD = true;
    }

    private void FixedUpdate()
    {
        anim.ResetTrigger("hit");
        if (doorHP <= 0)
        {
            doorOpen();
        }
        if (shaking)
        {
            if (Up)
            {
                transform.Translate(0, 0.1f, 0);
                Up = false;
            }
            else
            {
                transform.Translate(0, -0.1f, 0);
                Up = true;
            }
            if (Side)
            {
                transform.Translate(0.1f, 0, 0);
                Side = false;
            }
            else
            {
                transform.Translate(-0.1f, 0, 0);
                Side = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon"))
        {
            doorHP--;
            StartCoroutine(Shaking());
            anim.SetTrigger("hit");
        }
        if (collision.CompareTag("Player"))
        {
            if (PlayerMovement.instance.facingRight)
            {
                PlayerMovement.instance.r2.AddForce(Vector2.left * knockPWR);
                playerHealtManager.instance.modifyPlayerHealth(damageToGive,needCD);

            }
            else if (!PlayerMovement.instance.facingRight)
            {
                PlayerMovement.instance.r2.AddForce(Vector2.right * knockPWR);
                playerHealtManager.instance.modifyPlayerHealth(damageToGive,needCD);

            }
        }
    }
  

    IEnumerator Shaking()
    {
        shaking = true;
        transform.localPosition = currentPos;
        yield return new WaitForSeconds(shakeTime);
        shaking = false;
        transform.localPosition = currentPos;
    }

    private void doorOpen()
    {
        anim.SetBool("open", true);
    } 

    public void destroyDoor()
    {
        Destroy(gameObject);
    }
}
