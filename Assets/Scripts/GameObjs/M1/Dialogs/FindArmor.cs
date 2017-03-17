using UnityEngine;
using System.Collections;

namespace Level1{

    public class FindArmor : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Неплохой арсенальчик.");

            talkers.Add("Буздя");
            dialog.Add("Что бы себе взять?...");

            talkers.Add("Буздя");
            dialog.Add("Во! Отлично!");

            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL1 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL1>();
            gameObject.GetComponent<AudioSource>().Play();
            e.EventOnArmed();
        }
    }
}

