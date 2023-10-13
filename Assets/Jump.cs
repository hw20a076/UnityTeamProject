using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*!
 * 一定時間ごとに繰り返しオブジェクトをジャンプさせます。
 */
public class Jump : MonoBehaviour
{
    [Tooltip("ジャンプのパワー")]
    public float JumpPower = 10f;

    [Tooltip("ジャンプの間隔 (秒)")]
    public float Duration = 2f;

    [Tooltip("重力")]
    public Vector3 gravity = new Vector3(0f, -9.81f, 0f);

    private float time;
    private Rigidbody theRigidbody;

    void Reset()
    {
        JumpPower = 10f;
        Duration = 2f;
        gravity = new Vector3(0f, -9.81f, 0f);
    }

    void Start()
    {
        // Rigidbodyの作成
        theRigidbody = gameObject.GetComponent<Rigidbody>();
        if (theRigidbody == null)
        {
            theRigidbody = gameObject.AddComponent<Rigidbody>();
        }

        // 時間の初期化
        time = 0.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            time = Duration;
            theRigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        theRigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

}
