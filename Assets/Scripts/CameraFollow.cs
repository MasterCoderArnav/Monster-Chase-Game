using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if(player == null)
        {
            return;
        }
        tempPos = transform.position;
        tempPos.x = player.position.x;

        transform.position = tempPos;

        if(transform.position.x < minX)
        {
            tempPos.x = minX;
        }
        if(transform.position.x > maxX)
        {
            tempPos.x = maxX;
        }
        transform.position = tempPos;
    }
}
