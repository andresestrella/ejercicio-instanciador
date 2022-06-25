using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTraits : MonoBehaviour
{
    public GameManager.TipoPowerUp tipoPowerUp;
    void Start()
    {
        changePowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changePowerUp(){
        tipoPowerUp = GameManager.instancia.randomTipoPowerUp();
        if (tipoPowerUp == GameManager.TipoPowerUp.Change){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        }

        else if (tipoPowerUp == GameManager.TipoPowerUp.HP){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

        else if (tipoPowerUp == GameManager.TipoPowerUp.Speed){
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        
    }
}
