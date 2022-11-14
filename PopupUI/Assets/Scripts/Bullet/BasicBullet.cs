using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    /* * * * * * * * * * ������ �ӵ� * * * * * * * * * */
    protected float bulletSpeed = 0.2f;

    /* * * * * * * * * * ������ ���� �ð� * * * * * * * * * */
    protected float bulletTime = 5f;

    /* * * * * * * * * * ������ �߷� * * * * * * * * * */
    Rigidbody rigid;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = true;
        Invoke(nameof(Extinction), bulletTime);
    }

    /* * * * * * * * * * �⺻ �Ѿ� ���� * * * * * * * * * */
    protected virtual void Update()
    {
        transform.Translate(bulletSpeed * Vector3.forward);
    }


    /* * * * * * * * * * �⺻ �Ѿ� �ǰ� * * * * * * * * * */
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

    /* * * * * * * * * * �⺻ �Ѿ� �ı� * * * * * * * * * */

    protected virtual void Extinction()
    {
        ParticleSystem explosionPrefab = transform.GetChild(0).GetComponent<ParticleSystem>();
        explosionPrefab.Play();

        rigid.useGravity = false;

        Destroy(gameObject, 0.5f);
    }
}
