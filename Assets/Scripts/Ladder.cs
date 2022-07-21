using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Colision");
        if (SceneManager.GetActiveScene().name == "Ej5-mapa"){
            SceneManager.LoadScene("Cave");
        }else if (SceneManager.GetActiveScene().name == "Cave"){
            SceneManager.LoadScene("Ej5-mapa");
        }
        
    }
    

     void OnTriggerEnter(Collider other){
         Debug.Log("Colision");
         if (SceneManager.GetActiveScene().name == "Ej5-mapa"){
             SceneManager.LoadScene("Cave");
         }else if (SceneManager.GetActiveScene().name == "Cave"){
             SceneManager.LoadScene("Ej5-mapa");
         }
    }
}
