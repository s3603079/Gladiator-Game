using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Gladiator : MonoBehaviour {

    [SerializeField]
    private float walkSpeed = 1F;
    [SerializeField]
    private float jumpPower = 1F;

    private Rigidbody2D rb2d;
    private Vector3 velocity;
    private bool isGrounded;
    private bool attackedReady;
    private Transform shoulder;
    private Transform arm;

    private Vector2 armPos;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;

        shoulder = transform.GetChild(0);
        arm = shoulder.GetChild(0);

        armPos = arm.position;
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void Walk(float inputValue) {
        rb2d.velocity = new Vector2(inputValue * walkSpeed, rb2d.velocity.y);
    }

    public void Jump(bool InputTrigger) {
        if(InputTrigger && isGrounded)
        {
            isGrounded = false;
            rb2d.AddForce(transform.up * jumpPower * 200F);
        }
    }

    public void Attack(float InputValue) {
        //if (InputValue > 0F)
        //{
        //    var armUp = new Vector2(arm.transform.up.x, arm.transform.up.y);
        //    arm.position = Vector2.MoveTowards(armPos - armUp * 0.25F, armPos + armUp * 0.5F, InputValue);
        //}
        if (attackedReady && InputValue < 1F)
        {
            Debug.Log("Attack");
        }
        attackedReady = (InputValue >= 1F) ? true : false;
    }

    public void RotaShoulder(Vector2 InputAxis) {
        // 入力軸の横方向で向きを決定
        if(InputAxis.x <= -0.1F)
        {
            transform.localScale = new Vector3(-1F, transform.localScale.y);
        }
        else if(InputAxis.x >= 0.1f)
        {
            transform.localScale = new Vector3(+1F, transform.localScale.y);
        }

        // 入力軸の縦方向で角度を修正
        //if (Mathf.Abs(InputAxis.y) >= 0.1F)
        {
            shoulder.localEulerAngles = (transform.forward * InputAxis.y * 90F) + transform.forward * 90F;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
