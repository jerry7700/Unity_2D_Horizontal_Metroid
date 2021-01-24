using UnityEngine;
using System.Collections;
public class CameraControl2D : MonoBehaviour
{
    [Header("追蹤目標")]
    public Transform target;
    [Header("追蹤速度")]
    [Range(0, 100)]
    public float speed;
    [Header("晃動間隔")]
    [Range(0, 1)]
    public float shakeInterval = 0.05f;
    [Header("晃動值")]
    [Range(0, 5)]
    public float shakeValue = 0.5f;
    [Header("晃動次數")]
    [Range(0, 10)]
    public int shake = 3;
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

    public IEnumerator ShakeCamera()
    {
        for (int i = 0; i < shake; i++)
        {
            transform.position += Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
            transform.position -= Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
        }
    }
}
