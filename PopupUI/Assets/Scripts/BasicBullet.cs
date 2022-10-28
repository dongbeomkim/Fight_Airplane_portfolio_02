using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    /* * * * * * * * * * �⺻ �Ѿ� �ӵ� * * * * * * * * * */
    float bulletSpeed = 100f;


    /* * * * * * * * * * �⺻ �Ѿ� ���� �ð� * * * * * * * * * */
    float bulletTime = 5f;

    /* * * * * * * * * * �⺻ �Ѿ� ���� �ð� * * * * * * * * * */
    float bulletPower = 5f;

    void Start()
    {
        Invoke("Extinction", bulletTime);
    }

    /* * * * * * * * * * �⺻ �Ѿ� ���� * * * * * * * * * */
    void Update()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
    }


    /* * * * * * * * * * �⺻ �Ѿ� �ǰ� * * * * * * * * * */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<BasicEnemy>().GetDamage(bulletPower);
            Extinction();
        }
    }


    /* * * * * * * * * * �⺻ �Ѿ� �ı� * * * * * * * * * */
    private void Extinction()
    {
       Destroy(gameObject);
    }
}
