using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlayingObject : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitudeX;
    public float amplitudeY;

    public Vector2 tempPosition;
    public Vector2 currentPosition;


    void Start()
    {
        // Etsi pelihahmon Transformi ja sijoita se muuttujaan
        //player = gameObject.GetComponent<PlayerController4>();
    }
    private void FixedUpdate()
    {
        currentPosition = transform.position;

        tempPosition.x = Mathf.Sin(Time.realtimeSinceStartup * horizontalSpeed) * amplitudeX;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitudeY;
        tempPosition.x += currentPosition.x;
        tempPosition.y += currentPosition.y;


        transform.position = tempPosition;
    }


}

