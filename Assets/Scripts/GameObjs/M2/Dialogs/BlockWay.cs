using UnityEngine;
using System.Collections;

namespace Level2
{
    public class BlockWay : BaseDialog
    {

        void Start()
        {
            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Осторожно, Синий Зверь... Я не самоубийца, и там точно нет лягушки.");

            repeated = true;
            TimeForRepeat = 2f;
        }
    }
}

