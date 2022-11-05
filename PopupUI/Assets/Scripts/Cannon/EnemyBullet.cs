using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    /* * * * * * * * * * 기본 총알 속도 * * * * * * * * * */
    float bulletSpeed = 0.1f;


    /* * * * * * * * * * 기본 총알 유지 시간 * * * * * * * * * */
    float bulletTime = 5f;

    /* * * * * * * * * * 기본 총알 공격력 * * * * * * * * * */
    float bulletPower = 1f;

    void Start()
    {
        Invoke("Extinction", bulletTime);
    }

    /* * * * * * * * * * 기본 총알 방향 * * * * * * * * * */
    void Update()
    {
        transform.Translate(bulletSpeed * Vector3.forward);
    }


    /* * * * * * * * * * 기본 총알 피격 * * * * * * * * * */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().GetDamage(bulletPower);
            Extinction();
        }
        else if (other.CompareTag("Ground"))
        {
            Extinction();
        }
    }


    /* * * * * * * * * * 기본 총알 파괴 * * * * * * * * * */
    private void Extinction()
    {
        Destroy(gameObject);
    }
}
