using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int PlayerCurrentHP;
    public int PlayerMaxHp = 5;
    private int CompareHP;


    public GameObject FullHeart;
    public GameObject EmptyHeart;

    public GameObject heartFolder;
    //kaikki tallennettava tieto
    public float heartSpace;

    public bool pHasKey;

    public float musicVolume;


    //remember abilitys;
    public bool JumpAbility;
    public bool wallAbility;
    public bool attackAbility;
    public bool dashAbility;

    public GameObject screenFader;
    private void Awake()
    {
        pHasKey = false;
        Cursor.visible = false;
        MakeSingleton();
        PlayerCurrentHP = PlayerMaxHp;

        

        
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
            DontDestroyOnLoad(gameObject);
        }
    }


    
    private void FixedUpdate()
    {


    
        if ( Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;


        }


    }


    public void findHeartFolder()
    {
        heartFolder = GameObject.FindGameObjectWithTag("HeartBar");
    }


    public void AddHearts(int n)
    {
        float x = FullHeart.transform.position.x;
        float y = FullHeart.transform.position.y;
        float z = FullHeart.transform.position.z;
        for (int i = 0; i < n; i++)
        {

            GameObject elama = Instantiate(FullHeart, new Vector3(x, y, z), Quaternion.identity);
            elama.transform.SetParent(GameObject.FindWithTag("HeartBar").transform, false);
            x += heartSpace;
        }
    }
    public void ModifyHealt(int amount)
    {
        float x = FullHeart.transform.position.x;
        float y = FullHeart.transform.position.y;
        float z = FullHeart.transform.position.z;
        if (PlayerCurrentHP > 1)
        {
            PlayerCurrentHP -= amount;
            CompareHP = PlayerCurrentHP;
            foreach (Transform child in heartFolder.transform)
            {
                Destroy(child.gameObject);
            }
            for (int maxHP = 0; maxHP < PlayerMaxHp; maxHP++)
            {

                if (CompareHP != 0)
                {
                    GameObject elama = Instantiate(FullHeart, new Vector3(x, y, z), Quaternion.identity);
                    elama.transform.SetParent(GameObject.FindWithTag("HeartBar").transform, false);
                    CompareHP -= amount;
                }
                else if (CompareHP == 0)
                {
                    GameObject elama = Instantiate(EmptyHeart, new Vector3(x, y, z), Quaternion.identity);
                    elama.transform.SetParent(GameObject.FindWithTag("HeartBar").transform, false);
                }

                x += heartSpace;

            }

        }
        else
        {
            foreach (Transform child in heartFolder.transform)
            {
                Destroy(child.gameObject);
            }
            for (int maxHP = 0; maxHP < PlayerMaxHp; maxHP++)
            {

                if (CompareHP != 0)
                {
                    GameObject elama = Instantiate(FullHeart, new Vector3(x, y, z), Quaternion.identity);
                    elama.transform.SetParent(GameObject.FindWithTag("HeartBar").transform, false);
                    CompareHP -= amount;
                }
                else if (CompareHP == 0)
                {
                    GameObject elama = Instantiate(EmptyHeart, new Vector3(x, y,z), Quaternion.identity);
                    elama.transform.SetParent(GameObject.FindWithTag("HeartBar").transform, false);
                }

                x += heartSpace;

            }
            playerHealtManager.instance.HandleDeath();
        }

    }


   public void quitLVL()
    {

        mainFolder.instance.destroyObject();
        AudioManager.instance.StopAll();
        SceneManager.LoadScene(1);
        Cursor.visible = true;
    }

}


/* SceneManager.LoadScene("Menu");
            Destroy(GameObject.Find("GameManager"));
            Destroy(GameObject.Find("Canvas"));
            
*/

