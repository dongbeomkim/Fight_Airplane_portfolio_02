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
        Attack();
    }

    /* * * * * * * * * * �÷��̾� �����̴� ��� * * * * * * * * * */
    float playerMoveSpeed = 0.15f;

    public void Move(Vector2 inputDirection)
    {
        transform.Translate(new Vector3(inputDirection.x, 0, inputDirection.y) * playerMoveSpeed);
    }

    /* * * * * * * * * * �÷��̾� ���� * * * * * * * * * */
    bool canAttack = true;
    public GameObject bullet;
    public GameObject firePos;
    float attackcooltime = 0f;
    float currenttime = 1f;


    void Attack()
    {
        if(canAttack)
        {
            if(Input.GetKey(KeyCode.M) && attackcooltime <= 0f)
            {
                GameObject bulletcopy = Instantiate(bullet, firePos.transform.position, transform.rotation);
                attackcooltime = currenttime;
            }
            else
            {
                
            }
            attackcooltime -= Time.deltaTime;
        }
    }

    /* * * * * * * * * * �÷��̾� �ǰ� * * * * * * * * * */

    float hp = 10f;

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
