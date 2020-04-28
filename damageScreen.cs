using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageScreen : MonoBehaviour
{
    public static damageScreen instance;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        MakeSingleton();
    }
    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void FixedUpdate()
    {
        anim.ResetTrigger("fade");
    }
    public void startFading()
    {
        print("red");
        anim.SetTrigger("fade");
    }

}
