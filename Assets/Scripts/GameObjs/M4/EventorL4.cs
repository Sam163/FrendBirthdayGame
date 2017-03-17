using UnityEngine;
using System.Collections;

namespace Level4
{
    public class EventorL4 : Eventor
    {
        public static event LevelEvent OnCtulhuDialog;
        public static event LevelEvent OnStartCtulhuDialog;
        public static event LevelEvent OnStartDialog;
        public static event LevelEvent OnReadyCtulhuDialog;
        public static event LevelEvent OnCtulhuDie;

        public void EventOnCtulhuDialog()
        {
            if (OnCtulhuDialog != null)
                OnCtulhuDialog();
        }
        public void EventOnStartDialog()
        {
            if (OnStartDialog != null)
                OnStartDialog();
        }

        public void EventOnReadyCtulhuDialog() {
            if (OnReadyCtulhuDialog != null)
                OnReadyCtulhuDialog();
        }

        public void EventOnStartCtulhuDialog() {
            if (OnStartCtulhuDialog != null)
                OnStartCtulhuDialog();
        }

        public void EventOnCtulhuDie() {
            if (OnCtulhuDie != null)
                OnCtulhuDie();
        }

    }
}

