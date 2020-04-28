using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    private Scene scene;
    private string sceneName;
    private Animator anim;

    public Transform hint;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        if (checkpointManager.instance.isCheckpoint)
        {
            anim.SetBool("checkpoint", true);
            hint.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.W))
        {
            if (hint != null)
            {
                hint.gameObject.SetActive(false);

            }
            anim.SetBool("checkpoint", true);
            checkpointManager.instance.checkpoint = gameObject.transform.localPosition;
            checkpointManager.instance.checkpointScene = sceneName;
            checkpointManager.instance.isCheckpoint = true;

            print(gameObject.transform.localPosition);
        }
    }

}