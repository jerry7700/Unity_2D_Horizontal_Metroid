﻿using UnityEngine;

public class EnemySecondAttack : MonoBehaviour
{
    [Header("第二階段攻擊力")]
    public float attack = 50;

    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Hurt(attack);
        }
    }
}
