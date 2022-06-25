using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereInstantiator : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject enemy, powerUp;
    Vector3 _startingPosition = new Vector3(-10f,4f); // o 0 en y
    float nextTime;
    const float MIN_TIME = 1f, MAX_TIME = 3f, MIN_Y = -4.25f, MAX_Y = 4.25f;
    void Start()
    {
        nextTime = getNextTime();
    }

    void Update()
    {
        if (Time.time > nextTime){
            _startingPosition.y = Random.Range(MIN_Y, MAX_Y);
            Instantiate(SpawnSomething(), _startingPosition, Quaternion.identity);
            nextTime = getNextTime();
        }
        
    }

    float getNextTime(){
        return Time.time + (Random.Range(MIN_TIME, MAX_TIME));
    }

    GameObject SpawnSomething(){
        switch(Random.Range(0,2)){
            case 0:
                //enemy.GetComponent<EnemyTraits>().TipoEnemigo = gameManager.randomTipoEnemigo();
                return enemy;
            case 1:
                //powerUp.GetComponent<EnemyTraits>().TipoPowerUp = gameManager.randomTipoPowerUp();
                return powerUp;
            default: 
                //enemy.GetComponent<EnemyTraits>().TipoEnemigo = gameManager.randomTipoEnemigo();
                return enemy; 
        }
    }
}
