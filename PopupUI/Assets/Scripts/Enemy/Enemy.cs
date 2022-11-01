using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    /* * * * * * * * * * 큰 범위 변수 선언 * * * * * * * * * */
    public NavMeshAgent nvAgent;
    public GameObject player;

    public float speed = 2f;

    /* * * * * * * * * * 점수 * * * * * * * * * */
    float thisEnemyScore = 0.1f;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
    }

    /* * * * * * * * * * 피격 매서드 * * * * * * * * * */
    float hp = 10f;

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
            //player.Score += thisEnemyScore;
            Destroy(gameObject);
        }
    }
}
