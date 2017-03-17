using UnityEngine;
using System.Collections;

public class PlatformControl : MonoBehaviour {

    Rigidbody2D rb;
    [SerializeField] Vector2 p1,p2;
    [SerializeField] float speed;

    Vector2 cur;
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(p1);
        cur = p2;
        rb.gravityScale = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if ((rb.position - cur).magnitude < 0.05)
        {
                if (cur == p1)
                {
                    cur = p2;
                }
                else
                    cur = p1;
        }
        else
            rb.velocity = (cur - rb.position).normalized * speed;
    }

    //void OnCollisionEnter2D(Collision2D col) {
    //    if (col.gameObject.tag == "Player")
    //    {
    //        col.transform.parent = this.transform;
           
    //    }
    //}
    //void OnCollisionStay2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        Debug.Log("qqq" + col.gameObject.GetComponent<Rigidbody2D>().velocity);
    //        col.gameObject.GetComponent<Rigidbody2D>().velocity += rb.velocity;
    //        Debug.Log(rb.velocity);
    //        Debug.Log("hhh"+col.gameObject.GetComponent<Rigidbody2D>().velocity);
    //    }
    //}
    //void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        col.transform.parent = null;

    //    }
    //}
}
