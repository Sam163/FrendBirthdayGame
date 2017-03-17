using UnityEngine;
using System.Collections;

namespace Level2
{
    public class FrogDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Лягуха");
            dialog.Add("Здарова.");

            talkers.Add("Буздя");
            dialog.Add("Чо? Говорящая лягушка? Надеюсь ты не царевна и целовать тебя не надо!");

            talkers.Add("Лягуха");
            dialog.Add("Да нет, что ты! Я лягушка - певица!");

            talkers.Add("Лягуха");
            dialog.Add("Но ты ещё пожалеешь, что не поцеловал меня!");

            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL2 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL2>();
            e.EventOnFrogDialog();
        }
    }
}

