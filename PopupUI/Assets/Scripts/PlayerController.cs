using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    /* * * * * * * * * * ū ���� ���� ���� * * * * * * * * * */
    Rigidbody rigid;
    Transform propeller;
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
        propeller = transform.GetChild(4);
    }


    /* * * * * * * * * * �÷��̾��� �������� ������ ��ɸ� * * * * * * * * * */
    void Update()
    {
        PlayerAnimation();
    }

    /* * * * * * * * * * �÷��̾��� �������� ������ ��ɸ� * * * * * * * * * */
    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    /* * * * * * * * * * �÷��̾ WASDQE�� �����̴� ��� * * * * * * * * * */
    bool canWalking = true;
    int playerMoveSpeed = 20;
    Vector3 isMove;

    void Move()
    {
        if(canWalking)
        {
            float frontDir = Input.GetAxisRaw("Vertical");
            float sideDir = Input.GetAxisRaw("Horizontal");

            Vector3 frontMove = frontDir * transform.forward;
            Vector3 sideMove = sideDir * transform.right;

            isMove = (frontMove + sideMove).normalized * playerMoveSpeed;

            rigid.MovePosition(transform.position + isMove * Time.deltaTime);

            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(new Vector3(0, -1, 0) * playerMoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(new Vector3(0, 1, 0) * playerMoveSpeed * Time.deltaTime);
            }
        }
        
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




    /* * * * * * * * * * �����緯 �ִϸ��̼� * * * * * * * * * */
    float propellerspeed = 1000f;

    void PlayerAnimation()
    {
        propeller.Rotate(0, 0, propellerspeed * Time.deltaTime);
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
