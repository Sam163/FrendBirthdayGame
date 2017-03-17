using UnityEngine;
using System.Collections;

public class KPlatform : MonoBehaviour {

    Vector3 startpos;
    [SerializeField]
    Vector3 endPos = Vector3.zero;

    Transform playerT;
	void Start () {
        startpos = transform.position;
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && this.transform.position == startpos)
        {
                if (endPos == Vector3.zero)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z);
                }
                else
                {
                    transform.position = endPos;
                }
        }

    }
    void Update() {
        if (playerT.position.x < this.transform.position.x)
            this.transform.position = startpos;
    }
}
