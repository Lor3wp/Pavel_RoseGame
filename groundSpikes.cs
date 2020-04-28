using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class groundSpikes : MonoBehaviour
{
    public Transform tpPoint;
    public int damage;
    public Animator anim;
    public Image black;
    public bool needCD;

    private void Start()
    {
        needCD = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealtManager.instance.modifyPlayerHealth(damage,needCD);
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        PlayerMovement.instance.canMove = false;
        anim.SetBool("FadeIn", false);
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        PlayerMovement.instance.r2.transform.position = new Vector2(tpPoint.transform.position.x, tpPoint.transform.position.y);
        PlayerMovement.instance.canMove = true;
        anim.SetBool("Fade", false);
        anim.SetBool("FadeIn", true);
    }
}
