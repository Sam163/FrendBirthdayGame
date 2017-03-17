using UnityEngine;
using System.Collections;

namespace Level2
{
    public class FrogQuestDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Что это было?!");

            talkers.Add("Буздя");
            dialog.Add("Твою ж медь! Мои уши!");

            talkers.Add("Буздя");
            dialog.Add("Надо найти её, пока я не загнулся!");

            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL2 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL2>();
            e.EventOnFrogQuestBegin();
        }
    }
}

