using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2_MovementController : MonoBehaviour
{
    Vector3 _deltaPos = new Vector3();
    Vector3 moveSpeed = new Vector3(20,20);
    const float MIN_LIMIT_Y = -4.30f, MAX_LIMIT_Y = 4.30f;
    const float MIN_LIMIT_X = -8.18f, MAX_LIMIT_X = 8.18f;

    void Update() //called once per frame.
    {
        _deltaPos.x = Input.GetAxis("Horizontal") * moveSpeed.x;
        _deltaPos.y = Input.GetAxis("Vertical") * moveSpeed.y;
        _deltaPos *= Time.deltaTime;

        gameObject.transform.Translate(_deltaPos);
        gameObject.transform.position = new Vector3(
            Mathf.Clamp(gameObject.transform.position.x, MIN_LIMIT_X, MAX_LIMIT_X), 
            Mathf.Clamp(gameObject.transform.position.y, MIN_LIMIT_Y, MAX_LIMIT_Y), 
            gameObject.transform.position.z
        );
    }

}
