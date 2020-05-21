using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public GameObject groundCheck;
    public LayerMask whatIsGround;
    public bool CanControlThisCharacter;
    public float speed = 30f;               //previously = 0.1f;
    public float groundRadius = 0.2f;
    public float jumpForce = 3500f;  
	bool facingRight = true;
    bool grounded = false;
    public float velocityYTemp;
    //CASHE
    Rigidbody2D rigi;
    Animator anim;

    //COMPONENT CONNECTIONS
	void Awake()
	{
		rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if(rigi == null || anim == null)
        {
            Debug.LogError("SOME TING WONG");
        }
	}
    //PHYSIC REVIEW
	void FixedUpdate()
	{
        float Hmove = Input.GetAxis("Horizontal");
        //Debug.Log(Hmove);
        grounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround);

        if (CanControlThisCharacter)
        {
            if (Hmove < -0.1f)
            {
                // moving Closer
                if (facingRight)
                    Flip();
                //rigi.MovePosition(new Vector2(transform.position.x - speed, transform.position.y));
            }
            else if (Hmove > 0.1f)
            {
                // moving Remote
                if (!facingRight)
                    Flip();
                // rigi.MovePosition(new Vector2(transform.position.x + speed, transform.position.y));
            }
            rigi.velocity = new Vector2(Hmove * speed, rigi.velocity.y);
            anim.SetFloat("move", Mathf.Abs(Hmove));
        }
        //
        velocityYTemp = rigi.velocity.y;
        //
        anim.SetBool("grounded", grounded);
        anim.SetFloat("VSpeed", rigi.velocity.y);
	}
    //
    void Update()
    {
        //Debug.Log(grounded);
        if (grounded && Input.GetKeyDown(KeyCode.Space)&& CanControlThisCharacter)
        {
            //Debug.Log("JUMP MOFO");
            rigi.AddForce(new Vector2(0f, jumpForce));
        }
    }
    //
	void Flip()
	{
            Vector3 temp = transform.localScale;
            transform.localScale = new Vector3(-temp.x, temp.y, temp.z);
            facingRight = !facingRight;
	}
}
