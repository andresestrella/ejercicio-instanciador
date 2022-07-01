using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ej3_CharacterController : MonoBehaviour
{
    public GameManager.Tipo tipo = GameManager.Tipo.Azul;
    //public GameManager.TipoPowerUp tipo = GameManager.Tipo.Azul;

    Vector3 _deltaPos = new Vector3();
    private Vector3 moveSpeed = new Vector3();
    const float MIN_LIMIT_Y = -4.30f, MAX_LIMIT_Y = 4.30f;
    const float MIN_LIMIT_X = -8.18f, MAX_LIMIT_X = 8.18f;

    void Start(){
        changeColor();
        moveSpeed = GameManager.instancia.globalSpeed;
    }

    void Update() //called once per frame.
    {
        moveSpeed = GameManager.instancia.globalSpeed;

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

    

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.GetComponent<EnemyTraits>()){
            if (other.gameObject.GetComponent<EnemyTraits>().TipoEnemigo == tipo){
                GameManager.instancia.IncrementScore();
            }else{
                GameManager.instancia.DecreaseHP();
            }
            
        }else if(other.gameObject.GetComponent<PowerTraits>()){
            GameManager.TipoPowerUp pTrait = other.gameObject.GetComponent<PowerTraits>().tipoPowerUp;
                
            if (pTrait == GameManager.TipoPowerUp.Change){
                changeColor();
            }else if (pTrait == GameManager.TipoPowerUp.HP){
                GameManager.instancia.IncrementHP();
            }else if(pTrait == GameManager.TipoPowerUp.Speed){
                GameManager.instancia.SpeedUp();
            }
        }
        Destroy(other.gameObject);
    }
    

    private void changeColor(){
        tipo = GameManager.instancia.randomTipoEnemigo();
        if (tipo == GameManager.Tipo.Rojo){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

        else if (tipo == GameManager.Tipo.Verde){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }

        else if (tipo == GameManager.Tipo.Azul){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        
    }
}
