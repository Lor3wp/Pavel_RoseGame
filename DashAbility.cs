using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public static DashAbility instance;
    public DashState dashState;
    public float dashTimer;
    public float maxDash = 20f;
    public float DashSpeed;
    //[SerializeField] GameObject particle;

    private Rigidbody2D r2;

    public GameObject dashEffect;

    public Vector2 savedVelocity;




    void Start()
    {
        r2 = GetComponent<Rigidbody2D>();
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


    void FixedUpdate()
    {
        if (GameManager.instance.dashAbility)
        {
              dash();
        }
    }

private void dash()
{
        switch (dashState)
        {
            case DashState.Ready:
                bool isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                if (isDashKeyDown)
                {
                    AudioManager.instance.Play("dash");
                    //Instantiate(particle, transform, false);
                    savedVelocity = r2.velocity;
                    if (PlayerMovement.instance.facingRight)
                    {
                        Instantiate(dashEffect, transform.position, Quaternion.identity);
                        r2.AddForce(Vector2.right * DashSpeed);
                    }
                    else if (!(PlayerMovement.instance.facingRight))
                    {
                        Instantiate(dashEffect, transform.position, Quaternion.identity);
                        r2.AddForce(Vector2.left * DashSpeed);
                    }

                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:

                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:

                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}