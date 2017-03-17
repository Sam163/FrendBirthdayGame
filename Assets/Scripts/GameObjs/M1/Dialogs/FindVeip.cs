using UnityEngine;
using System.Collections;

namespace Level1
{
    public class FindVeip : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Опа вот он.");

            talkers.Add("Буздя");
            dialog.Add("Твою ж медь! Жидкость закончилась");

            talkers.Add("Буздя");
            dialog.Add("И денег нет...");

            talkers.Add("Буздя");
            dialog.Add("Называется купил, чтобы курить бросить... ");

            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL1 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL1>();
            e.EventFindVeip();
        }
    }
}
