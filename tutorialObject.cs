using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialObject : MonoBehaviour
{
    private Animator anim;
    public bool needStartDelay;
    public float startDelay;

    public bool needEndDelay;
    public float endDelay;
    private void Start()
    {

        anim = GetComponent<Animator>();
    }
    

    public void show()
    {
        gameObject.SetActive(true);

        if (needStartDelay)
        {

            StartCoroutine(delayStartTuto(startDelay));
        }
        else
        {
            anim.SetTrigger("fadeIn");
        }

    }


    IEnumerator delayStartTuto(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetTrigger("fadeIn");
    }

    public void hide()
    {
        if (needEndDelay)
        {
        StartCoroutine(delayEndTuto(endDelay));

        }
        else
        {
            anim.SetTrigger("fadeOut");
        }
    }


    IEnumerator delayEndTuto(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetTrigger("fadeOut");
    }

    public void disableObject()
    {
        gameObject.SetActive(false);
    }

}
