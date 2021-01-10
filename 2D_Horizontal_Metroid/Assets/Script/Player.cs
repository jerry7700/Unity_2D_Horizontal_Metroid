using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度")]
    [Range(0, 1000)]
    public float Speed = 10.5f;
    [Header("跳躍高度")]
    [Range(0, 3000)]
    public int jump = 100;
    [Header("是否在地板上")]
    [Tooltip("是否在地板上")]
    public bool grond = false;
    [Header("子彈")]
    [Tooltip("子彈")]
    public GameObject Bullet;
    [Header("子彈生成點")]
    [Tooltip("子彈生成點")]
    public Transform BulletGenrate;
    [Header("子彈速度")]
    [Range(0, 50000)]
    public int BulletSpeed = 800;
    [Header("開槍音效")]
    [Tooltip("開槍音效")]
    public AudioClip BulletAudio;
    [Header("血量")]
    [Range(0, 200)]
    public int HP = 100;
    [Header("音效來源")]
    private AudioSource AS;
    [Header("2D 剛體")]
    private Rigidbody2D rb;
    [Header("動畫控制")]
    private Animator anim;
    [Header("地面判定位移")]
    public Vector3 offset;
    [Header("地面判定半徑")]
    public float Radius;
    #endregion
    public float h;

    private void Start()
    {
        //GetComponent<泛型>()
        //泛型:泛指所有類型
        //GetComponent<Animator>
        //GetComponent<AudioSource>

        //剛體欄位 = 取的元件<剛體>()
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetHorizontal();
        Move();
        Jump();
    }

    //只在 Unity 繪製圖示
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.6f);
        //繪製球體(位置,半徑)
        Gizmos.DrawSphere(transform.position + offset, Radius);
    }

    private void GetHorizontal()
    {
        //輸入取得軸向("水平")
        h = Input.GetAxis("Horizontal");
    }
    #region 方法
    //移動
    private void Move()
    {
        //剛體.加速度 = 二維(水平 * 速度, 原本加速度.y)
        rb.velocity = new Vector2(h * Speed, rb.velocity.y);

        //如果玩家按下D就執行
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform指的此腳本同一層的 transform元件
            // Rotation 角度在程式是 localEulerAngless
            transform.localEulerAngles = Vector3.zero;
        }
        //如果玩家按下A就執行
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        anim.SetBool("跑步開關", h != 0);
    }
    //跳躍
    private void Jump()
    {
        //如果 在地面上 並且 按下空白鍵 才可以 跳躍
        if (grond && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jump));
            grond = false;
        }
        //圓形2D 名稱 = 2D物理.(位置,半徑,1 << 圖層編號)
        Collider2D hit = Physics2D.OverlapCircle(transform.position + offset, Radius, 1 << 8);
        //如果 碰到的物件 存在的 就將是否為地面 設定為 是
        if (hit)
        {
            grond = true;
        }
        //否則 沒碰到 就將是否為地面 設定為 否
        else
        {
            grond = false;
        }
    }
    //傷害
    private void Damage()
    {

    }
    //受傷
    private void Hurt(float damage)
    {

    }
    //死亡
    private void Death()
    {

    }
    #endregion
}
