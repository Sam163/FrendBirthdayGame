using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Level1
{
    public class StragDialog : BaseDialog
    {

        void Start()
        {
            Inicialize();

            talkers.Add("Стражник");
            dialog.Add("Приветствую тебя, сэр Буздя. С добрым утром!");

            talkers.Add("Буздя");
            dialog.Add("Здарова, и тебе не хворать!");

            talkers.Add("Стражник");
            dialog.Add("Твой отец, Король Ричард, ждет тебя. Он велел передать, что хочет поговорить о чем-то важном!");

            talkers.Add("Буздя");
            dialog.Add("Ладно, понял. Зайду.");

            talkers.Add("Стражник");
            dialog.Add("Удачи тебе!");

            repeated = false;
        }

    }
}
