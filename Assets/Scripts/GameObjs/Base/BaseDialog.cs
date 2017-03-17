using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssistanObejcts;

public class BaseDialog : MonoBehaviour {

    protected PlayerUIManager pUI;

    private Transform playerT;
    private Collider2D colD;

    protected List<string> dialog =new List<string>();
    protected List<string> talkers = new List<string>();

    protected bool repeated;
    protected bool fstTime =true;
    protected bool started =false;
    protected bool ended =false;
    protected int current = 0;

    protected float TimeForRepeat = 10f;
    private Timer wait = new Timer();

    protected void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject == playerT.gameObject)
        {
            if (fstTime == true) {
                fstTime = false;
                started = true;
                current = 0;
                playerT.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; 
                pUI.DialogEnable();
            }
        }
    }
    protected void Inicialize() {
        pUI = GameObject.Find("PlayerUI").GetComponent<PlayerUIManager>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        colD = GetComponent<Collider2D>();
        colD.isTrigger = true;
        colD.gameObject.layer = 2;
    }

    protected virtual void Update() {
        if (started && !ended && dialog.Count>0) {
            if (current < dialog.Count)
                pUI.SetDialogText(talkers[current]+" :", dialog[current]);
            else
                EndDialog();
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                current++;
            }
        }
        if (repeated && ended) {
            Restarter();
        }
    }
    protected void EndDialog() {
        pUI.DialogDisable();
        playerT.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        ended = true;
        SendEvents();
        if (repeated)
            wait.Reset(TimeForRepeat);
        else
            Destroy(this);
    }

    protected void Restarter() {
        if (wait.Ended) {
            ended = false;
            fstTime = true;
            started = false;
        }
        wait.Ticking_DeltaTime();
    }

    public virtual void SendEvents() { }
}
