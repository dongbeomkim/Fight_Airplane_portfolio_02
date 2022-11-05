using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* * * * * * * * * * 큰 범위 변수 선언 * * * * * * * * * */
    Rigidbody rigid;
    Inventory inventory;


    /* * * * * * * * * * 플레이어의 총 점수 * * * * * * * * * */
    float score = 0;

    public float Score
    {
        get => score;
        set
        {
            if(score != value)
            {
                score = value;
                Debug.Log($"{score}");
            }
        }
    }

    /* * * * * * * * * * 플레이어의 레벨 * * * * * * * * * */
    int level = 1;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    /* * * * * * * * * * 플레이어의 간접적인 움직임 기능만 * * * * * * * * * */
    void Update()
    {
        
    }

    /* * * * * * * * * * 플레이어의 직접적인 움직임 기능만 * * * * * * * * * */
    private void FixedUpdate()
    {
        
    }
    /* * * * * * * * * * 플레이어 연료 * * * * * * * * * */
    float fuel = 10f;
    public float Fuel => fuel;

    float maxFuel = 10f;
    public float MaxFuel => maxFuel;

    /* * * * * * * * * * 플레이어 움직이는 기능 * * * * * * * * * */
    float playerMoveSpeed = 0.15f;

    public void Move(Vector2 inputDirection)
    {
        transform.Translate(new Vector3(0, 0, inputDirection.y) * playerMoveSpeed);
        transform.Rotate(new Vector3(0,inputDirection.x,0));
    }

    /* * * * * * * * * * 플레이어 공격 * * * * * * * * * */
    public GameObject bullet;
    public Transform firePos;


    public void Attack()
    {
        GameObject bulletcopy = Instantiate(bullet, firePos.position, firePos.transform.rotation);
    }

    /* * * * * * * * * * 플레이어 피격 * * * * * * * * * */

    float hp = 10f;
    public float Hp => hp;

    float maxHp = 10f;
    public float MaxHp => maxHp;

    public void GetDamage(float damage)
    {
        hp -= damage;
        Dead(hp);
    }

    /* * * * * * * * * * 죽음 매서드 * * * * * * * * * */
    void Dead(float damage)
    {
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }


    /* * * * * * * * * * 아이템 획득 * * * * * * * * * */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.GetComponent<ObjectItem>().item;
            inventory.AddItem(item);
            Debug.Log($"{item.itemName}을 습득했습니다.");
        }
    }
}
