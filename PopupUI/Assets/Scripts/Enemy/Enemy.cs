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

    /* * * * * * * * * * ����ġ * * * * * * * * * */
    float score = 1f;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        Pos = transform.position;
        nvAgent = GetComponent<NavMeshAgent>();
        hp = 10 * GameManager.Instance.gameRound;
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

    public void StopAttack()
    {
        CancelInvoke("FireBullet");
    }

    /* * * * * * * * * * �ǰ� �ż��� * * * * * * * * * */
    float hp = 0;
    public float HP => hp;

    public void GetDamage(float damage)
    {
        hp -= damage;
        Dead(hp);
    }

    /* * * * * * * * * * ���� �ż��� * * * * * * * * * */
    public void Dead(float damage)
    {
        if(hp <= 0)
        {
            GameManager.Instance.playTime += score;
            GameManager.Instance.Player.Hp += 1f;
            transform.tag = "Ground";
            nvAgent.isStopped = true;
        }
    }
}
