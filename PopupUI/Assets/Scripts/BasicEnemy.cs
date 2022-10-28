using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.LightProbeProxyVolume;

public class BasicEnemy : MonoBehaviour
{
    /* * * * * * * * * * ū ���� ���� ���� * * * * * * * * * */
    float hp = 10f;
    PlayerController playerController;


    /* * * * * * * * * * ���� * * * * * * * * * */
    float thisEnemyScore = 0.1f;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        
    }

    /* * * * * * * * * * �ǰ� �ż��� * * * * * * * * * */
    public void GetDamage(float damage)
    {
        hp -= damage;
        Dead(hp);
    }

    /* * * * * * * * * * ���� �ż��� * * * * * * * * * */
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
