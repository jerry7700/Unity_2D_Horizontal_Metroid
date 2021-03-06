﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Boss : MonoBehaviour
{
    #region 欄位
    [Header("移動速度")]
    [Range(0, 1000)]
    public float Speed = 10.5f;
    [Header("攻擊範圍")]
    [Range(0, 100)]
    public float rangeattack = 10;
    [Header("攻擊力")]
    [Range(0, 1000)]
    public float attack = 100;
    [Header("攻擊時間")]
    [Range(0, 10)]
    public float attackCD = 3.5f;
    [Header("攻擊延遲")]
    [Range(0, 10)]
    public float attackDelay = 0.7f;
    [Header("攻擊範圍位移")]
    public Vector3 offsetAttack;
    [Header("攻擊範圍大小")]
    public Vector3 sizeAttack;
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
    private CameraControl2D cam;
    private float timer;
    public UnityEvent onDeath;
    private bool isSecond;
    private ParticleSystem psSecond;
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack);

        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, rangeattack);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        HPMax = HP;
        player = FindObjectOfType<Player>();
        cam = FindObjectOfType<CameraControl2D>();
        psSecond = GameObject.Find("骷髏第二段攻擊特效").GetComponent<ParticleSystem>();
        HPText.text = HP.ToString();
    }

    private void Update()
    {
        if (anim.GetBool("死亡開關")) return; 
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
        if (HP <= HPMax * 0.8f)
        {
            isSecond = true;
            rangeattack = 80;
        }
        if (HP <= 0) Death();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Death()
    {
        onDeath.Invoke();
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
        //如果動畫是 骷髏攻擊 或 骷髏受傷 就跳出
        //GetCurrentAnimatorStateInfo是取得目前動畫的狀態資料
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("骷髏_攻擊") || info.IsName("骷髏_受傷")) return;
        
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

        float dis = Vector2.Distance(transform.position, player.transform.position);

        if (dis > rangeattack)
        {
            rb.MovePosition(transform.position + transform.right * Time.deltaTime * Speed);
        }
        else
        {
            Attack();
        }
        anim.SetBool("走路開關", rb.velocity.magnitude > 0);
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    public void Attack()
    {
        rb.velocity = Vector3.zero;
        if (timer < attackCD)
        {
            timer += Time.deltaTime;
        }
        else
        {
            anim.SetTrigger("攻擊觸發");
            timer = 0;
            StartCoroutine(DelaySendDamage());
        }
    }

    public IEnumerator DelaySendDamage()
    {
        yield return new WaitForSeconds(attackDelay);
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack, 0, 1 << 9);
        if (hit) player.Hurt(attack);
        StartCoroutine(cam.ShakeCamera());

        if (isSecond) psSecond.Play();
    }
}
