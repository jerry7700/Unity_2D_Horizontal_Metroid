using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    [Header("另一個傳送門的位置")]
    public Transform otherTeleport;

    private bool playerIn;
    private Transform player;

    private void Teleport()
    {
        if (playerIn && Input.GetKeyDown(KeyCode.W))
        {
            player.position = otherTeleport.position + Vector3.up * 1.5f;
        }
    }

    private void Awake()
    {
        player = GameObject.Find("戰士").transform;
    }

    private void Update()
    {
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "戰士") playerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "戰士") playerIn = false;
    }
}
