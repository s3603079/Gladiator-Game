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

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
        var mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (transform.position.x <= mPos.x)
        //{
        //    transform.localScale = new Vector2(+1F, transform.localScale.y);
        //}
        //else if (transform.position.x >= mPos.x)
        //{
        //    transform.localScale = new Vector2(-1F, transform.localScale.y);
        //}
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

    public void Attack() {
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
