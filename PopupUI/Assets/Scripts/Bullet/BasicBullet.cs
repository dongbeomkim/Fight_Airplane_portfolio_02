using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    /* * * * * * * * * * 대포알 속도 * * * * * * * * * */
    protected float bulletSpeed = 0.2f;

    /* * * * * * * * * * 대포알 유지 시간 * * * * * * * * * */
    protected float bulletTime = 5f;

    /* * * * * * * * * * 대포알 중력 * * * * * * * * * */
    Rigidbody rigid;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = true;
        Invoke(nameof(Extinction), bulletTime);
    }

    /* * * * * * * * * * 기본 총알 방향 * * * * * * * * * */
    protected virtual void Update()
    {
        transform.Translate(bulletSpeed * Vector3.forward);
    }


    /* * * * * * * * * * 기본 총알 피격 * * * * * * * * * */
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().GetDamage(GameManager.Instance.Player.Power);
            Extinction();
        }
        else if(other.CompareTag("Ground"))
        {
            Extinction();
        }
    }

    /* * * * * * * * * * 기본 총알 파괴 * * * * * * * * * */

    protected virtual void Extinction()
    {
        ParticleSystem explosionPrefab = transform.GetChild(0).GetComponent<ParticleSystem>();
        explosionPrefab.Play();

        rigid.useGravity = false;

        Destroy(gameObject, 0.5f);
    }
}
