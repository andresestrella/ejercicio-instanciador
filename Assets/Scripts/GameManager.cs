using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshPro ScoreText;
    public TextMeshPro hpText;
    int _currentScore = 0;
    int _currentHP = 3;
    public static GameManager instancia;

    public Vector3 globalSpeed;
    public const float POWERUP_TIMER = 4;

    public enum Tipo{
        Rojo,Verde,Azul
    }

    public enum TipoPowerUp{
        HP,Speed,Change
    }

    void Awake(){
        if (instancia != null && instancia != this)
        {
            Destroy(this);
            return;
        }
        globalSpeed = new Vector3(10,10);
        instancia  = this;
    }

    public void IncrementScore()
    {
        _currentScore++;
        ScoreText.text = _currentScore.ToString();
    }

    public void DecreaseHP(){
        _currentHP--;
        hpText.text = _currentHP.ToString();
        if (_currentHP == 0){
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    public void IncrementHP(){
        _currentHP++;
        hpText.text = _currentHP.ToString();
    }

    public void SpeedUp(){
        globalSpeed = new Vector3(20,20);
        Invoke(nameof(ResetSpeed), 4);
    }

    private void ResetSpeed(){
        globalSpeed = new Vector3(10,10);
    }

    public Tipo randomTipoEnemigo(){
        int random = Random.Range(0,3);
        switch (random){
            case 0:
                return Tipo.Azul;
            case 1:
                return Tipo.Rojo;
            case 2:
                return Tipo.Verde;
            default:
                return Tipo.Rojo;
        }
            
    }
    public TipoPowerUp randomTipoPowerUp(){
        int random = Random.Range(0,3);
        switch (random){
            case 0:
                return TipoPowerUp.HP;
            case 1:
                return TipoPowerUp.Speed;
            case 2:
                return TipoPowerUp.Change;
            default:
                return TipoPowerUp.Change;
        }
            
    }

    

    
}
