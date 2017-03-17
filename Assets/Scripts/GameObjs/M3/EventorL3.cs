using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Level3
{
    public class EventorL3: Eventor
    {
        public static event LevelEvent OnKazahDialog;
        public static event LevelEvent OnAnanasDialog;

        public void EventOnKazahDialog()
        {
            if (OnKazahDialog != null)
                OnKazahDialog();
        }
        public void EventOnAnanasDialog()
        {
            if (OnAnanasDialog != null)
                OnAnanasDialog();
        }

    }
}
