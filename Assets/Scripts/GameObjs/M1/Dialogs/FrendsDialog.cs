using UnityEngine;
using System.Collections;

namespace Level1 {
    public class FrendsDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Здарова.");

            talkers.Add("Марчела, Илюха");
            dialog.Add("Привет!");

            talkers.Add("Марчела");
            dialog.Add("Чего у тебя башка такая здоровая?");

            talkers.Add("Буздя");
            dialog.Add("Латы жмут.");

            talkers.Add("Марчела, Илюха");
            dialog.Add("аххах");

            talkers.Add("Буздя");
            dialog.Add("Меня в рейс опять отправляют.");

            talkers.Add("Илюха");
            dialog.Add("Да мы уже в курсе.");

            talkers.Add("Марчела");
            dialog.Add("Опять твою днюху пропустим?");

            talkers.Add("Буздя");
            dialog.Add("Твою ж медь... Нет! На этот раз я сделаю всё, чтоб не пропустить!");

            talkers.Add("Буздя");
            dialog.Add("А где Дэн?");

            talkers.Add("Илюха");
            dialog.Add("До него не достучались. И кстати, сегодня полнолуние.");

            talkers.Add("Марчела");
            dialog.Add("...А дорога через лес. Посторайся в порт до полуночи добраться.");

            talkers.Add("Буздя");
            dialog.Add("Ладно, я погнал.");

            talkers.Add("Марчела, Илюха");
            dialog.Add("Ага!");
            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL1 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL1>();
            e.EventLastDialog();
        }
    }

}

