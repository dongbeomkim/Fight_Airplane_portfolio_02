using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class Enemy : MonoBehaviour
{

    /* * * * * * * * * * ū ���� ���� ���� * * * * * * * * * */
    public NavMeshAgent nvAgent;
    public GameObject player;

    public float speed = 2f;

    public Vector3 Pos;

    /* * * * * * * * * * ���� * * * * * * * * * */
    int Score = 1;

    void Start()
    {
        Pos = transform.position;
        nvAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
    }

    /* * * * * * * * * * ���� �ż��� * * * * * * * * * */
    public GameObject bullet;
    public Transform firePos;

    public void Attack()
    {
        InvokeRepeating("FireBullet", 1f, 1f);
    }

    void FireBullet()
    {
        GameObject bulletcopy = Instantiate(bullet, firePos.position, firePos.transform.rotation);
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
