using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRight : MonoBehaviour
{
    Vector3 _deltaPos = new Vector3();
    Vector3 moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = GameManager.instancia.globalSpeed;
        _deltaPos.x = (float)1.0 * moveSpeed.x;
        _deltaPos *= Time.deltaTime;
        gameObject.transform.Translate(_deltaPos);
    }
}
