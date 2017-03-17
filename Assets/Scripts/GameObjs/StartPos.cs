using UnityEngine;
using System.Collections;

public class StartPos : MonoBehaviour {


	void Start () {
        SetPlayerPositionOnStart();
    }
    public void SetPlayerPositionOnStart() {
        GameObject.FindGameObjectWithTag("Player").transform.position = this.transform.position;
    }
}
