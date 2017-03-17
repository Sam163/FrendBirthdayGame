using UnityEngine;
using System.Collections;

namespace Level3
{
    public class AnanasDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Сундук с ананасами?");

            talkers.Add("Буздя");
            dialog.Add("Зашибись, вкусненького поем!");

            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL3 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL3>();
            e.EventOnAnanasDialog();
        }
    }
}

