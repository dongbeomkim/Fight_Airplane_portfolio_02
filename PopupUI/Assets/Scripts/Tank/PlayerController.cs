using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    /* * * * * * * * * * ū ���� ���� ���� * * * * * * * * * */
    Rigidbody rigid;
    Inventory inventory;

    /* * * * * * * * * * �÷��̾��� ���� * * * * * * * * * */
    public int level = 1;

    float exp = 0;
    public float Exp
    {
        get => exp;
        set
        {
            if (exp != value)
            {
                exp = value;
            }
        }
    }

    float maxExp = 10;
    public float MaxExp => maxExp;


    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        panelty = GameManager.Instance.gameRound;
    }


    /* * * * * * * * * * �÷��̾��� �������� ������ ��ɸ� * * * * * * * * * */
    int panelty;

    void Update()
    {
        hp -= Time.deltaTime * 0.1f * panelty;
        Dead(hp);
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
    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
        }
    }

    float maxHp = 10f;
    public float MaxHp => maxHp;

    public void GetDamage(float damage)
    {
        hp -= damage;
    }

    /* * * * * * * * * * ���� �ż��� * * * * * * * * * */
    void Dead(float damage)
    {
        if (hp <= 0)
        {
            hp = 0;
            SceneManager.LoadScene("GameOver");
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
