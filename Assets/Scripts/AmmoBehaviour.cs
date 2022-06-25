using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehaviour : MonoBehaviour
{
    Vector3 currentSpeed = new Vector3();
    Vector3 deltaPos = new Vector3();
    bool isShot;

    void Update()
    {
        if (!isShot)
            return;

        deltaPos = currentSpeed * Time.deltaTime + Physics.gravity * Mathf.Pow(Time.deltaTime, 2) / 2;
        gameObject.transform.Translate(deltaPos);
        currentSpeed += Physics.gravity * Time.deltaTime;
    }

    public void Shoot(Vector3 startingSpeed)
    {
        currentSpeed = new Vector3
        (0, startingSpeed.y); 
        isShot = true;
    }

    private void OnTriggerEnter(Collider other){
        if(other is CapsuleCollider){
            ej2_GameController.instancia.IncrementScore();
        }else if (other is BoxCollider){
            ej2_GameController.instancia.DecreaseHP();
        }
        Destroy(this.gameObject);
    }

}
