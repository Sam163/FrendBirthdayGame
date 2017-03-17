using UnityEngine;
using System.Collections;

namespace Level1
{
    public class KeyDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Настоятель");
            dialog.Add("Погоди. Прежде, чем отправиться в путь, я тебе настоятельно рекомендую посетить оружейную");

            talkers.Add("Настоятель");
            dialog.Add("Тебя ждет опасное путешествие, и хороший меч тебе пригодится! И ещё кое-что.");

            talkers.Add("Настоятель");
            dialog.Add("Будь аккуратен. Не попади в торопях в ловушки замка!");

            talkers.Add("Буздя");
            dialog.Add("(про себя)\nМне бы свой вейп найти!");

            repeated = false;
        }


        public override void SendEvents()
        {
            EventorL1 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL1>();
            e.EventKeyDialog();
        }
    }
}

