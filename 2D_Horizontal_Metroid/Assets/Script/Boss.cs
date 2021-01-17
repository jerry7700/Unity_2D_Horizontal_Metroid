using UnityEngine;


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
    public float HP = 100;
    [Header("音效來源")]
    private AudioSource aud;
    [Header("2D 剛體")]
    private Rigidbody2D rb;
    [Header("動畫控制")]
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    public void Damage(float damage)
    {
        HP -= damage;
        anim.SetTrigger("受傷觸發");
    }
}
