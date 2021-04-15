using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRoomSystem : MonoBehaviour
{
    private CinemachineVirtualCamera cm = null;

    private void Awake()
    {
        cm = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cm.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cm.enabled = false;
    }
}
