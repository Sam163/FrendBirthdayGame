using UnityEngine;
using System.Collections;

namespace Level4 {

    public class CtulhuDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Твою ж медь! Ктулху! Ты чего творишь?");

            talkers.Add("Ктулху");
            dialog.Add("Верни мне мои ананасы!");

            talkers.Add("Буздя");
            dialog.Add("Чего? Я их добыл в честном бою!");

            talkers.Add("Ктулху");
            dialog.Add("Верни мне мои ананасы! Это мои ананасы! Времни мне их!!");

            talkers.Add("Буздя");
            dialog.Add("Губу закатай.");

            talkers.Add("Ктулху");
            dialog.Add("Тогда я заберу их силой и убью тебя!");

            talkers.Add("Буздя");
            dialog.Add("Твою ж медь! Сейчас походу будет битва за ананасы...");
            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL4 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL4>();
            e.EventOnCtulhuDialog();
            Destroy(this.gameObject);
        }
    }
}

