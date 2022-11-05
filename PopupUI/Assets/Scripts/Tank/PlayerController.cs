using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* * * * * * * * * * ū ���� ���� ���� * * * * * * * * * */
    Rigidbody rigid;
    Inventory inventory;


    /* * * * * * * * * * �÷��̾��� �� ���� * * * * * * * * * */
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

    /* * * * * * * * * * �÷��̾��� ���� * * * * * * * * * */
    int level = 1;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    /* * * * * * * * * * �÷��̾��� �������� ������ ��ɸ� * * * * * * * * * */
    void Update()
    {
        
    }

    /* * * * * * * * * * �÷��̾��� �������� ������ ��ɸ� * * * * * * * * * */
    private void FixedUpdate()
    {
        
    }
    /* * * * * * * * * * �÷��̾� ���� * * * * * * * * * */
    float fuel = 10f;
    public float Fuel => fuel;

    float maxFuel = 10f;
    public float MaxFuel => maxFuel;

    /* * * * * * * * * * �÷��̾� �����̴� ��� * * * * * * * * * */
    float playerMoveSpeed = 0.15f;

    public void Move(Vector2 inputDirection)
    {
        transform.Translate(new Vector3(0, 0, inputDirection.y) * playerMoveSpeed);
        transform.Rotate(new Vector3(0,inputDirection.x,0));
    }

    /* * * * * * * * * * �÷��̾� ���� * * * * * * * * * */
    public GameObject bullet;
    public Transform firePos;


    public void Attack()
    {
        GameObject bulletcopy = Instantiate(bullet, firePos.position, firePos.transform.rotation);
    }

    /* * * * * * * * * * �÷��̾� �ǰ� * * * * * * * * * */

    float hp = 10f;
    public float Hp => hp;

    float maxHp = 10f;
    public float MaxHp => maxHp;

    public void GetDamage(float damage)
    {
        hp -= damage;
        Dead(hp);
    }

    /* * * * * * * * * * ���� �ż��� * * * * * * * * * */
    void Dead(float damage)
    {
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }


    /* * * * * * * * * * ������ ȹ�� * * * * * * * * * */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.GetComponent<ObjectItem>().item;
            inventory.AddItem(item);
            Debug.Log($"{item.itemName}�� �����߽��ϴ�.");
        }
    }
}
