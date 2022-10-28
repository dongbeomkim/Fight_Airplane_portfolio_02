using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    /* * * * * * * * * * 큰 범위 변수 선언 * * * * * * * * * */
    Rigidbody rigid;
    Transform propeller;
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
        propeller = transform.GetChild(4);
    }


    /* * * * * * * * * * 플레이어의 간접적인 움직임 기능만 * * * * * * * * * */
    void Update()
    {
        PlayerAnimation();
    }

    /* * * * * * * * * * 플레이어의 직접적인 움직임 기능만 * * * * * * * * * */
    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    /* * * * * * * * * * 플레이어가 WASDQE로 움직이는 기능 * * * * * * * * * */
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

    /* * * * * * * * * * 플레이어 공격 * * * * * * * * * */
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




    /* * * * * * * * * * 프로펠러 애니메이션 * * * * * * * * * */
    float propellerspeed = 1000f;

    void PlayerAnimation()
    {
        propeller.Rotate(0, 0, propellerspeed * Time.deltaTime);
    }

    /* * * * * * * * * * 플레이어 피격 * * * * * * * * * */

    float hp = 10f;

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
