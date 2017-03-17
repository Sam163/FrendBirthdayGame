using UnityEngine;
using System.Collections;
using Units;

public class VisonDetector : MonoBehaviour {

    [SerializeField] private float R_Vision = 10f;
    RaycastHit2D hit;    
    private bool iSee;

    Vector2 dir;
    public bool isISee {
        get{ return iSee; }
    }

    GameObject target;
    PersonBaseCharacter owner;

    public void SetVisionTarget(Transform a)
    {
        target = a.gameObject;
    }

    void Start () {
        iSee = false;
        owner = transform.root.gameObject.GetComponent<PersonBaseCharacter>();
    }
	

	void FixedUpdate () {

        if(owner.FacingRight)
            dir = Vector2.right;
        else dir = Vector2.left;
        hit = Physics2D.Raycast(this.transform.position,dir , R_Vision);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == target)
            {
                iSee = true;
            }
            else iSee = false;
        }
        else iSee = false;

    }
}
