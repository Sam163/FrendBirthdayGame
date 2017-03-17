using UnityEngine;
using System.Collections;

namespace Level3
{
    public class MonahDialog : BaseDialog
    {
        [SerializeField ]GameObject m1;
        [SerializeField ]GameObject m2;

        // Use this for initialization
        void Start()
        {
            m1.SetActive(true);
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Мужчина, у вас сигареты не найдется?");

            talkers.Add("Монах");
            dialog.Add("Ну, я как бы не совсем мужчина...");

            talkers.Add("Буздя");
            dialog.Add("... o_O");

            talkers.Add("Буздя");
            dialog.Add("В смысле?");

            talkers.Add("Монах");
            dialog.Add("... мне ещё 18-ти нет.");

            talkers.Add("Буздя");
            dialog.Add("Пора бросать...");

        }

        protected override void Update()
        {
            if (started && !ended && dialog.Count > 0)
            {
                if (current < dialog.Count)
                    pUI.SetDialogText(talkers[current] + " :", dialog[current]);
                else
                    EndDialog();
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    if(current==3)
                        m1.SetActive(false);
                    current++;
                }
            }
            if (repeated && ended)
            {
                Restarter();
            }
        }
    }

}

