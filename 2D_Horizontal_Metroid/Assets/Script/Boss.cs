using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Boss : MonoBehaviour
{
    [Header("移動速度")]
    [Range(0, 1000)]
    public float Speed = 10.5f;
    [Header("攻擊範圍")]
    [Range(0, 100)]
    public float rangestr = 100;
    [Header("攻擊力")]
    [Range(0, 1000)]
    public float str = 100;
    [Header("血量")]
    [Range(0, 5000)]
    public float HP = 2500;
    [Header("最大血量")]
    [Range(0, 5000)]
    public float HPMax = 2500;
    [Header("血量文字")]
    public Text HPText;
    [Header("血量圖片")]
    public Image HPImage;
    [Header("音效來源")]
    private AudioSource aud;
    [Header("2D 剛體")]
    private Rigidbody2D rb;
    [Header("動畫控制")]
    private Animator anim;
    private Player player;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        HPMax = HP;
        player = FindObjectOfType<Player>();
        HPText.text = HP.ToString();
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        HP -= damage;                   //遞減
        anim.SetTrigger("受傷觸發");    //受傷動畫
        HPText.text = HP.ToString();
        HPImage.fillAmount = HP / HPMax;
        if (HP <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        HP = 0;
        HPText.text = HP.ToString();
        anim.SetBool("死亡開關", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.Sleep();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    /// <summary>
    /// 移動
    /// </summary>
    public void Move()
    {
        /** 判斷式寫法
        if (transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        */
        
        //縮減程式碼
        float y = transform.position.x > player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);

        float dis= Vector2.Distance(transform.position, player.transform.position);

        if (dis > rangestr)
        {
           rb.MovePosition(transform.position + transform.right * Time.deltaTime * Speed);
        }
        else
        {
            Attack();
        }
        anim.SetBool("走路開關", rb.velocity.magnitude > 0);
    }

    public void Attack()
    {
        rb.velocity = Vector3.zero;
        anim.SetTrigger("攻擊觸發");
    }
}
