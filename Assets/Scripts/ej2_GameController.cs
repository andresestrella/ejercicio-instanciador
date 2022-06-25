using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ej2_GameController : MonoBehaviour
{
    public TextMeshPro ScoreText;
    public TextMeshPro hpText;
    int _currentScore = 0;
    int _currentHP = 3;
    public static ej2_GameController instancia;

    void Awake(){
        if (instancia != null && instancia != this)
        {
            Destroy(this);
            return;
        }

        instancia  = this;
    }
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
