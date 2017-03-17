using UnityEngine;
using System.Collections;

namespace Level4 {
    public class StartDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Ещё немного и дома!");

            talkers.Add("Буздя");
            dialog.Add("Наконец-то день рождения дома отпраздную, а не в море.");

            talkers.Add("Буздя");
            dialog.Add("Только вот погода не очень.");

            talkers.Add("Буздя");
            dialog.Add("И вообще музон чего-то напрягает.");

            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL4 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL4>();
            e.EventOnStartDialog();
            Destroy(this.gameObject);
        }
    }
}

