using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    /* * * * * * * * * * ū ���� ���� ���� * * * * * * * * * */
    public NavMeshAgent nvAgent;
    public GameObject player;

    public float speed = 2f;

    /* * * * * * * * * * ���� * * * * * * * * * */
    float thisEnemyScore = 0.1f;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
    }

    /* * * * * * * * * * �ǰ� �ż��� * * * * * * * * * */
    float hp = 10f;

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
            //player.Score += thisEnemyScore;
            Destroy(gameObject);
        }
    }
}
