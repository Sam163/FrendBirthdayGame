using UnityEngine;
using System.Collections;

namespace Level3
{
    public class StartDialog :BaseDialog
    {
        void Start()
        {

            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Нацонец-то добрался. Курить хочется...");

            repeated = false;
        }
    }
}

