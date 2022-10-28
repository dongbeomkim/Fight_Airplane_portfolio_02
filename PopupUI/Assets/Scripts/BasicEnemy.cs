using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.LightProbeProxyVolume;

public class BasicEnemy : MonoBehaviour
{
    /* * * * * * * * * * 큰 범위 변수 선언 * * * * * * * * * */
    float hp = 10f;
    PlayerController playerController;


    /* * * * * * * * * * 점수 * * * * * * * * * */
    float thisEnemyScore = 0.1f;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        
    }

    /* * * * * * * * * * 피격 매서드 * * * * * * * * * */
    public void GetDamage(float damage)
    {
        hp -= damage;
        Dead(hp);
    }

    /* * * * * * * * * * 죽음 매서드 * * * * * * * * * */
    void Dead(float damage)
    {
        if(hp <= 0)
        {
            hp = 0;
            playerController.Score += thisEnemyScore;
            Destroy(gameObject);
        }
    }
}
