using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class doorManager : MonoBehaviour
{
    private Animator anim;

    public Transform text;

    public string soundToStop;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance.pHasKey)
            {
                anim.SetBool("open", true);
                keyManager.instance.enterKey();
            } else
            {
                text.gameObject.SetActive(true);
            }
        }
    }

    public void exit()
    {
        mainFolder.instance.destroyObject();
        AudioManager.instance.StopAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
