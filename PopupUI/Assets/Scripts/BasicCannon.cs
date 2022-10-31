using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicCannon : MonoBehaviour
{
    /* * * * * * * * * * ±âº» ÃÑ¾Ë ¼Óµµ * * * * * * * * * */
    float bulletSpeed = 0.5f;


    /* * * * * * * * * * ±âº» ÃÑ¾Ë À¯Áö ½Ã°£ * * * * * * * * * */
    float bulletTime = 5f;

    /* * * * * * * * * * ±âº» ÃÑ¾Ë °ø°Ý·Â * * * * * * * * * */
    float bulletPower = 5f;


    /* * * * * * * * * * ±âº» ÃÑ¾Ë Æø¹ß * * * * * * * * * */
    ParticleSystem explosionPrefab;

    void Start()
    {
        explosionPrefab = transform.GetChild(0).GetComponent<ParticleSystem>();
        Invoke("Extinction", bulletTime);
    }

    /* * * * * * * * * * ±âº» ÃÑ¾Ë ¹æÇâ * * * * * * * * * */
    void Update()
    {
        transform.Translate(bulletSpeed * Vector3.forward);
    }


    /* * * * * * * * * * ±âº» ÃÑ¾Ë ÇÇ°Ý * * * * * * * * * */
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


    /* * * * * * * * * * ±âº» ÃÑ¾Ë ÆÄ±« * * * * * * * * * */
    private void Extinction()
    {
       explosionPrefab.Play();
       Destroy(gameObject, 1f);
    }
}
