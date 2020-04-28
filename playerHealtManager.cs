using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerHealtManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static playerHealtManager instance;

    public int maxHP;
    public int currentHP;

    public bool dead;

    public float dmgCD;

    public float waitTime;

    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        waitTime = dmgCD;
        dead = false;
        MakeSingleton();
        GameManager.instance.AddHearts(maxHP);

    }

    private void FixedUpdate()
    {
        GameManager.instance.PlayerCurrentHP = currentHP;
        GameManager.instance.PlayerMaxHp = maxHP;
        if (dead && !checkpointManager.instance.isCheckpoint)
        {
            HandleDeath();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void handleDamage(int damage)
    {
        if (waitTime >= dmgCD)
        {
        StartCoroutine(dmgCooldown(damage));
        }
        
    }
    private IEnumerator dmgCooldown(int dmg)
    {

        currentHP -= dmg;

        while (waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        waitTime = dmgCD;
    }
    public void HandleDeath()
    {
        anim.SetTrigger("dead");

        GameManager.instance.quitLVL();

        

    }

    public void modifyPlayerHealth(int damageToGive, bool needcoldown)
    {
        if (currentHP == 1 && checkpointManager.instance.isCheckpoint)
        {
            if (!PlayerMovement.instance.facingRight)
            {
                Vector3 theScale = PlayerMovement.instance.gameObject.transform.localScale;

                theScale.x *= -1;

                PlayerMovement.instance.gameObject.transform.localScale = theScale;
            }
            checkpointManager.instance.respawn();


        } else
        {
            damageScreen.instance.startFading();
            if (needcoldown)
            {
                handleDamage(damageToGive);
            }
            else
            {
                currentHP -= damageToGive;

            }
            GameManager.instance.ModifyHealt(damageToGive);
        
        }



    }
}
