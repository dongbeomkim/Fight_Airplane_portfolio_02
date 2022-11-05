using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    /* * * * * * * * * * �⺻ �Ѿ� �ӵ� * * * * * * * * * */
    float bulletSpeed = 0.1f;


    /* * * * * * * * * * �⺻ �Ѿ� ���� �ð� * * * * * * * * * */
    float bulletTime = 5f;

    /* * * * * * * * * * �⺻ �Ѿ� ���ݷ� * * * * * * * * * */
    float bulletPower = 1f;

    void Start()
    {
        Invoke("Extinction", bulletTime);
    }

    /* * * * * * * * * * �⺻ �Ѿ� ���� * * * * * * * * * */
    void Update()
    {
        transform.Translate(bulletSpeed * Vector3.forward);
    }


    /* * * * * * * * * * �⺻ �Ѿ� �ǰ� * * * * * * * * * */
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


    /* * * * * * * * * * �⺻ �Ѿ� �ı� * * * * * * * * * */
    private void Extinction()
    {
        Destroy(gameObject);
    }
}
