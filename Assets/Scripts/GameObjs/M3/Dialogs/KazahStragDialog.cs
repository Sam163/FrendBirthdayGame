using UnityEngine;
using System.Collections;

namespace Level3
{
    public class KazahStragDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Казах");
            dialog.Add("Проход 10 тенге.");

            talkers.Add("Буздя");
            dialog.Add("Это за что?");

            talkers.Add("Казах");
            dialog.Add("20 тенге.");

            talkers.Add("Буздя");
            dialog.Add("Ты чего борзеешь?");

            talkers.Add("Казах");
            dialog.Add("30 тенге.");

            talkers.Add("Буздя");
            dialog.Add("Может остановишся?");

            talkers.Add("Казах");
            dialog.Add("40 тенге.");

            talkers.Add("Буздя");
            dialog.Add("Слыщь, татаро-монгольское иго, харе!");

            talkers.Add("Казах");
            dialog.Add("Не хочешь по хорошему, будет по плохому.");
            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL3 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL3>();
            e.EventOnKazahDialog();
            Destroy(this.gameObject);
        }
    }
}

