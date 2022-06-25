using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraits : MonoBehaviour
{
    //GameManager gameManager;
    public GameManager.Tipo TipoEnemigo = GameManager.Tipo.Azul;
    void Awake(){
        changeColor();
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeColor(){
        TipoEnemigo = GameManager.instancia.randomTipoEnemigo();
        if (TipoEnemigo == GameManager.Tipo.Rojo){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

        else if (TipoEnemigo == GameManager.Tipo.Verde){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }

        else if (TipoEnemigo == GameManager.Tipo.Azul){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        
    }
}
