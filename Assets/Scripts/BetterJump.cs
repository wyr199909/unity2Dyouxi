using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;         // 上升时的速度变化率
    public float lowJumpMultiplier = 2f;        // 下降时的速度变化率
    private Rigidbody2D _rigidbody2D;           // 人物刚体对象

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         if (_rigidbody2D.velocity.y < 0)    // 在下落
        {
            _rigidbody2D.gravityScale = lowJumpMultiplier;
        }
        else if (_rigidbody2D.velocity.y > 0  &&!Input.GetButton("Jump"))   // 上升
        {
            _rigidbody2D.gravityScale = fallMultiplier;
        }
        else
        {
            _rigidbody2D.gravityScale = 1f;
        }
    }
}
