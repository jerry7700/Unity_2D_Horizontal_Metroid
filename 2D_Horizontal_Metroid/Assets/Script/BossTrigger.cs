using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [Header("魔王血量")]
    public GameObject ObjHP;
    [Header("魔王")]
    public GameObject ObjBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "戰士")
        {
            ObjHP.SetActive(true);
            ObjBoss.SetActive(true);
        }
    }
}
