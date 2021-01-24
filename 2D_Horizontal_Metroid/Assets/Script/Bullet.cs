using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int attack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Boss>())
        {
            collision.gameObject.GetComponent<Boss>().Damage(attack);
        }
        
    }
}
