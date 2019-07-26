using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vc;

    // Start is called before the first frame update
    private void Start() 
    {
        vc = GetComponent<CinemachineVirtualCamera>();
        Transform player = GameManager.instance.player.transform;
        vc.m_Follow = player;
    }

}
