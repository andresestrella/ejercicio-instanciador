using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    const float MAX_X = 8f;
    Vector3 currentPosition = new Vector3();
    const float SPEED_X = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        currentPosition.x = -4 + Mathf.PingPong(Time.time * SPEED_X, MAX_X);
        gameObject.transform.position = currentPosition;
    }
}
