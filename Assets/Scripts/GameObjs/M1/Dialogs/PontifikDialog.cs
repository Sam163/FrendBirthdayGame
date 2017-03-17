using UnityEngine;
using System.Collections;

namespace Level1
{
    public class PontifikDialog : BaseDialog
    {

        void Start()
        {
            Inicialize();

            talkers.Add("Диакон");
            dialog.Add("Ты ещё не навестил отца?");

            talkers.Add("Диакон");
            dialog.Add("Если так, то тебе следует это сделать.");

            talkers.Add("Диакон");
            dialog.Add("А если ты заблудился, то его дворцовая палата в другой стороне.");

            repeated = true;
        }
    }
}
