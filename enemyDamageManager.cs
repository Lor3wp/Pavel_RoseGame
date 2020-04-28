using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamageManager : MonoBehaviour
{
    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            playerHealtManager PlayerHealthManager = collision.GetComponent<playerHealtManager>();
            PlayerHealthManager.handleDamage(damageToGive);
            GameManager.instance.ModifyHealt(damageToGive);
        }
    }
}
