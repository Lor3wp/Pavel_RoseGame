using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class lookDown : MonoBehaviour
{
    public Transform m_Follow;
    private Transform Original_m_Follow;

    private CinemachineVirtualCamera vcam;

    public float timer;
    public float time;

    void Start()
    {
        time = timer;
        
        vcam = GetComponent<CinemachineVirtualCamera>();
        Original_m_Follow = vcam.Follow;
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            time = timer;
            vcam.Follow = Original_m_Follow;
        }
        if (Input.GetKey(KeyCode.S))
        {
          
                if (time <= 0)
                {
                vcam.Follow = m_Follow;
                time = timer;
                }
                else
                {
                    time -= Time.deltaTime;
                }
            
        }
    }

}
