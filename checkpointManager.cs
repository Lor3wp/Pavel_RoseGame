using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checkpointManager : MonoBehaviour
{
    public bool isCheckpoint;
    public static checkpointManager instance;

    public GameObject createFolder;

    public Vector3 checkpoint;
    public string checkpointScene;

    private GameObject parentFolder;
    private GameObject playerFolder;

    public GameObject[] disable;

    string prefabPath = "Assets/SavePrefabs/PlayerData.prefab";

    public Image black;
    public Animator anim;

    public bool isPlayerFacingRight;

    private void Awake()
    {
        isCheckpoint = false;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        parentFolder = GameObject.FindGameObjectWithTag("mainFolder");
        playerFolder = GameObject.FindGameObjectWithTag("mainPlayerFolder");
    }
    public void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!PlayerMovement.instance.facingRight)
            {
                Vector3 theScale = PlayerMovement.instance.gameObject.transform.localScale;

                theScale.x *= -1;

                PlayerMovement.instance.gameObject.transform.localScale = theScale;
            }
            respawn();
        }
        
    }

    public void respawn()
    {
        isPlayerFacingRight = PlayerMovement.instance.facingRight;

        fadeOut();
    }
    /*
    private void savePlayer()
    {
        saveSystem.SavePlayer(PlayerMovement.instance);

    }

    private void loadPLayer()
    {
        PlayerData data = saveSystem.LoadPlayer();

    }
    */
    private void fadeOut()
    {

        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        anim.SetBool("Fade", true);
        anim.SetBool("FadeIn", false);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(checkpointScene);

        parentFolder = GameObject.FindGameObjectWithTag("mainFolder");
        playerFolder = GameObject.FindGameObjectWithTag("mainPlayerFolder");
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        Player.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        Destroy(playerFolder.gameObject);
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        yield return new WaitUntil(() => black.color.a == 1);
        var rose = Instantiate(createFolder, new Vector3 (0,0,0), Quaternion.identity);
        rose.transform.parent = parentFolder.transform;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.gameObject.transform.localPosition = checkpoint;
        GameManager.instance.findHeartFolder();
        Parallaxing.instance.retransformCam();

        anim.SetBool("FadeIn", true);
        anim.SetBool("Fade", false);

    }



}
