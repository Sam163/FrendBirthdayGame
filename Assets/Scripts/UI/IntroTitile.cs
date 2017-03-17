using UnityEngine;
using System.Collections;
using AssistanObejcts;
using UnityEngine.UI;

public class IntroTitile : MonoBehaviour {

    private Timer tm=new Timer();
    [SerializeField] private float tmLim = 9f;

    [SerializeField]
    Text t1;

    [SerializeField]
    Text t2;

    [SerializeField]
    Text t3;

    void Start () {
        tm.Begin(tmLim);
	}
	
	
	void FixedUpdate () {
        tm.Ticking_fixedDeltaTime();
        if (tm.Ended || Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log(tm.Timing);
            Application.LoadLevel("MainMenu");
        }
        if (tm.Timing < 3)
        {
            t1.gameObject.active = true;
            t2.gameObject.active = false;
            t3.gameObject.active = false; 
        }
        else
            if (tm.Timing < 6)
        {
            t1.gameObject.active = false;
            t2.gameObject.active = true;
            t3.gameObject.active = false;
        }
        else
        {
            t1.gameObject.active = false;
            t2.gameObject.active = false;
            t3.gameObject.active = true;
        }

    }
}
