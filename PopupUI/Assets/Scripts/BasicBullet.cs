using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    /* * * * * * * * * * 기본 총알 속도 * * * * * * * * * */
    float bulletSpeed = 100f;


    /* * * * * * * * * * 기본 총알 유지 시간 * * * * * * * * * */
    float bulletTime = 5f;

    /* * * * * * * * * * 기본 총알 유지 시간 * * * * * * * * * */
    float bulletPower = 5f;

    void Start()
    {
        Invoke("Extinction", bulletTime);
    }

    /* * * * * * * * * * 기본 총알 방향 * * * * * * * * * */
    void Update()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
    }


    /* * * * * * * * * * 기본 총알 피격 * * * * * * * * * */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<BasicEnemy>().GetDamage(bulletPower);
            Extinction();
        }
    }


    /* * * * * * * * * * 기본 총알 파괴 * * * * * * * * * */
    private void Extinction()
    {
       Destroy(gameObject);
    }
}
