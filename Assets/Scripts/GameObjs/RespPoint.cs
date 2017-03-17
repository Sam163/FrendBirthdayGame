using UnityEngine;
using Units;

public class RespPoint : MonoBehaviour {

    [SerializeField]
    bool destroyable = false;
    BaseLevelManager lvlMngr;

    void OnTriggerEnter2D(Collider2D col)
    {      
        if ((col.gameObject.tag == "Player") && (lvlMngr = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<BaseLevelManager>()))
        {
            lvlMngr.NewRespPoint(transform.position);
            if(destroyable)
                Destroy(this.gameObject);
        }
    }
}
