using UnityEngine;
using System.Collections;

namespace Level4
{
    public class ShipControl : MonoBehaviour
    {
        Animator anim;
        void OnEnable()
        {
            EventorL4.OnReadyCtulhuDialog += BrokenBeatAndScared;
        }
        void OnDisable()
        {
            EventorL4.OnReadyCtulhuDialog -= BrokenBeatAndScared;
        }

        void Awake() {
            anim = GetComponent<Animator>();
            anim.SetBool("break",false);
        }
        void BrokenBeatAndScared() {
            anim.SetBool("break", true);
        }

        void SetEventStartCtulhuDialog() {

            EventorL4 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL4>();
            e.EventOnStartCtulhuDialog();
        }
    }
}

