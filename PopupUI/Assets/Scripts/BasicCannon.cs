using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicCannon : MonoBehaviour
{
    /* * * * * * * * * * �⺻ �Ѿ� �ӵ� * * * * * * * * * */
    float bulletSpeed = 0.5f;


    /* * * * * * * * * * �⺻ �Ѿ� ���� �ð� * * * * * * * * * */
    float bulletTime = 5f;

    /* * * * * * * * * * �⺻ �Ѿ� ���ݷ� * * * * * * * * * */
    float bulletPower = 5f;


    /* * * * * * * * * * �⺻ �Ѿ� ���� * * * * * * * * * */
    ParticleSystem explosionPrefab;

    void Start()
    {
        explosionPrefab = transform.GetChild(0).GetComponent<ParticleSystem>();
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
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<BasicEnemy>().GetDamage(bulletPower);
            Extinction();
        }
        else if(other.CompareTag("Ground"))
        {
            Extinction();
        }
    }


    /* * * * * * * * * * �⺻ �Ѿ� �ı� * * * * * * * * * */
    private void Extinction()
    {
       explosionPrefab.Play();
       Destroy(gameObject, 1f);
    }
}
