using UnityEngine;

public class CameraControl2D : MonoBehaviour
{
    [Header("追蹤目標")]
    public Transform target;
    [Header("追蹤速度")]
    [Range(0,100)]
    public float speed;
    /// <summary>
    /// 追蹤目標
    /// </summary>
    public void Track()
    {
        Vector3 PosA = target.position;
        Vector3 PosB = transform.position;
        PosA.z = -10;
        PosB = Vector3.Lerp(PosB, PosA, 0.5f * speed * Time.deltaTime);
        transform.position = PosB;
    }

    private void LateUpdate()
    {
        Track();
    }
}
