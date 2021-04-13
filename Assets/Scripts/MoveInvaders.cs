﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInvaders : MonoBehaviour
{
    [SerializeField]
    float velocity = 0.1f;

    [SerializeField]
    float minX = -0.7f;

    [SerializeField]
    float maxX = 0.7f;

    [SerializeField]
    float moveTime = 1f;

    Vector3 direction = Vector3.right;
    float tempoQuePassou = 0f;


   

    // Update is called once per frame
    void Update()
    {
        tempoQuePassou += Time.deltaTime;
        if(tempoQuePassou >= moveTime)
        {
            transform.position += velocity * direction;
            tempoQuePassou = 0f;
            if(transform.position.x <= minX || transform.position.x >= maxX)
            {
                direction *= -1f;
                transform.position += velocity * Vector3.down;
            }
        }
    }
}
