using UnityEngine;
using System.Collections;

namespace Level1
{
    public class EventorL1: Eventor
    {
        public static event LevelEvent OnFindVeip;
        public static event LevelEvent OnEndKeyDialog;
        public static event LevelEvent OnArmed;
        public static event LevelEvent OnLastDialog;
        public static event LevelEvent OnEndLevel;

        public void EventOnArmed() {
            if (OnArmed != null)
                OnArmed();        
        }

        public void EventFindVeip()
        {
            if (OnFindVeip != null)
                OnFindVeip();
        }

        public void EventKeyDialog() {
            if (OnEndKeyDialog != null)
                OnEndKeyDialog();
        }

        public void EventLastDialog() {
            if (OnLastDialog != null)
                OnLastDialog();
        }
        public void EventEndLevel()
        {
            if (OnEndLevel != null)
                OnEndLevel();
        }
    }
}
