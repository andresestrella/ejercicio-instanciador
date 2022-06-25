using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ej2_CharacterController : MonoBehaviour
{
    
    
    public GameObject Ammo;
    Vector3 startingSpeed;
    //const float SCALAR_SPEED = 20f;
    float currentAngle, deltaY, deltaX;
    //Vector3 userInput = new Vector3();

    Vector3 _deltaPos = new Vector3();
    Vector3 moveSpeed = new Vector3(20,20);
    const float MIN_LIMIT_Y = -4.30f, MAX_LIMIT_Y = 4.30f;
    const float MIN_LIMIT_X = -8.18f, MAX_LIMIT_X = 8.18f;
    void Start()
    {
        startingSpeed = new Vector3(0, 11);
    }

    void Update()
    {
        //movimiento
        _deltaPos.x = Input.GetAxis("Horizontal") * moveSpeed.x;
        _deltaPos *= Time.deltaTime;

        gameObject.transform.Translate(_deltaPos);
        gameObject.transform.position = new Vector3(
            Mathf.Clamp(gameObject.transform.position.x, MIN_LIMIT_X, MAX_LIMIT_X), 
            gameObject.transform.position.y, 
            gameObject.transform.position.z
        );

        // //esto podira ser con la posicion del mouse.

        // userInput = Camera.main.ScreenToWorldPoint(Input.touchSupported && Input.touchCount > 0 ? (Vector3)Input.GetTouch(0).position : Input.mousePosition);
        // deltaY =  userInput.y - gameObject.transform.position.y;
        // deltaX =  userInput.x - gameObject.transform.position.x;

        // //Input.GetTouch(0).position.y me da una posicion en pixeles en la pantalla, tengo que convertir esto a unidades 'Unity'
        // currentAngle = Mathf.Atan(deltaY / deltaX);
        
        
        //trigger; disparar un objeto
        if(Input.GetButtonDown("Fire1")){
            Instantiate(Ammo, gameObject.transform.position, Quaternion.identity).GetComponent<AmmoBehaviour>().Shoot(startingSpeed);
        }
    }
}
