using UnityEngine;
using System.Collections;

namespace Level2
{
    public class EventorL2 : Eventor
    {

        public static event LevelEvent OnFrogDialog;
        public static event LevelEvent OnFrogQuestBegin;
        public static event LevelEvent OnFrogDied;
        public static event LevelEvent OnBeastDialog;
        public void EventOnFrogDialog()
        {
            if (OnFrogDialog != null)
                OnFrogDialog();
        }
        public void EventOnFrogQuestBegin()
        {
            if (OnFrogQuestBegin != null)
                OnFrogQuestBegin();
        }
        public void EventOnFrogDied()
        {
            if (OnFrogDied != null)
                OnFrogDied();
        }
        public void EventOnBeastDialog()
        {
            if (OnBeastDialog != null)
                OnBeastDialog();
        }
    }
}

