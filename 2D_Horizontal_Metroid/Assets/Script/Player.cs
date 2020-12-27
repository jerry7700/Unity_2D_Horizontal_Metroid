using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    public Rigidbody rb;
    [Header("動畫控制")]
    public Animator anim;
    //移動
    private void Move()
    {
        
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
}
