using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    /* * * * * * * * * * 큰 범위 변수 선언 * * * * * * * * * */
    Inventory inventory;

    /* * * * * * * * * * 플레이어의 레벨 * * * * * * * * * */
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
        panelty = GameManager.Instance.gameRound;
        GameObject obj = Resources.Load("Bullets/BasicBullet") as GameObject;
        inventory.AddItem(obj.GetComponent<ObjectItem>().item);
    }


    /* * * * * * * * * * 플레이어의 간접적인 움직임 기능만 * * * * * * * * * */
    int panelty;

    void Update()
    {
        hp -= Time.deltaTime * 0.1f * panelty;
        Dead(hp);
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
    GameObject bullet;
    public Transform firePos;

    float power = 0;
    public float Power
    {
        get => power;
        set
        {
            power = value;
        }
    }

    public void OnNewBullet()
    {
        bullet = inventory.equipment[0].itemPrefab;
        Power = inventory.equipment[0].attackPower;
    }

    public void OffNewBullet()
    {
        bullet = null;
        Power = 0;
    }

    public void Attack()
    {
        if(bullet != null)
        {
            GameObject bulletcopy = Instantiate(bullet, firePos.position, firePos.transform.rotation);
        }
        else
        {
            Debug.Log("공격에 필요한 대포알을 장착하십시오.");
        }
    }

    /* * * * * * * * * * 플레이어 피격 * * * * * * * * * */

    float hp = 10f;
    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            if(hp > maxHp)
            {
                hp = maxHp;
            }
        }
    }

    float maxHp = 10f;
    public float MaxHp => maxHp;

    public void GetDamage(float damage)
    {
        hp -= damage;
    }

    /* * * * * * * * * * 죽음 매서드 * * * * * * * * * */
    void Dead(float damage)
    {
        if (hp <= 0)
        {
            hp = 0;
            
            SceneManager.LoadScene("GameOver");
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
            Destroy(other.gameObject);
        }
    }
}
