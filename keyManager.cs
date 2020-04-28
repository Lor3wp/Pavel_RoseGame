using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keyManager : MonoBehaviour
{
    public static keyManager instance;

    private Transform destination;

    private Vector3 Destination;
    public FlayingObject FlyingObject;
    private bool picked;
    public float step;
    public Transform key;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        FlyingObject = GetComponent<FlayingObject>();
        picked = false;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            destination = collision.gameObject.transform;
            picked = true;
            GameManager.instance.pHasKey = true;
        }
    }
    private void FixedUpdate()
    {
        if (picked)
        {
            moveKey();
        }
    }
    public void moveKey()
    {
        Destination = new Vector3(destination.localPosition.x, destination.localPosition.y + 3f, destination.localPosition.z);

        Vector3 Traveller = gameObject.transform.localPosition;
        step = 10 * Time.deltaTime;

           // FlyingObject.enabled = false;
        transform.position = Vector3.Lerp(Traveller, Destination, step);   
    }

    public void enterKey()
    {
        anim.SetBool("used", true);
    }

    public void end()
    {
        Destroy(gameObject);
    }


}
