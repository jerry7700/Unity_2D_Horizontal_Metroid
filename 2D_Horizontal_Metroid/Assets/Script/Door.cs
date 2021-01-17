using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("鑰匙")]
    public GameObject key;
    public Animator anim;

    public AudioSource aud;
    public AudioClip door;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "戰士" && key == null)
        {
            anim.SetTrigger("開門");
            aud.PlayOneShot(door, Random.Range(1.2f, 1.5f));
        }
    }
}
