using UnityEngine;
using System.Collections;

namespace Level1
{
    public class InMindDialog : BaseDialog
    {

        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Твою ж медь!");

            talkers.Add("Буздя");
            dialog.Add("Такс, надо найти свой вейп!");

            repeated = false;
        }
    }
}

