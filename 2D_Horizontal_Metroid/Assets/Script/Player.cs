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
    public int Jamp = 100;
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
    }

    private void Update()
    {
        GetHorizontal();
        Move();
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
    }
    //跳躍
    private void Jump()
    {

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
