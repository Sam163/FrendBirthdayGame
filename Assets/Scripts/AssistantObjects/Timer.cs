using UnityEngine;
using System.Collections;

namespace AssistanObejcts {

    //с точностью 0,05
    public class Timer 
    {
        public Timer()
        {
            timer_lim = 1f;
            run = false;
            end = false;
            timing = 0;
        }
        public Timer(float t)
        {
            timer_lim = t;
            run = false;
            end = false;
            timing = 0;
        }

        private bool run = false;
        private bool end = false;
        private float timing;
        private float timer_lim;

        public bool End
        {
            get { return end; }
        }
        public bool Run
        {
            get { return run; }
        }

        public bool Ended
        {
            get { return end&&run; }
        }

        public float Timing
        {
            get { return timing; }
        }
        public float Timer_lim
        {
            get { return timer_lim; }
        }

        public void Begin(float t)
        {
            if (!run)
            {
                timer_lim = t;
                run = true;
                end = false;
                timing = 0f;
            }
        }

        public void Begin()
        {
            if (!run)
            {
                run = true;
                end = false;
                timing = 0f;
            }
        }

        public bool Ticking_fixedDeltaTime()
        {
            if (run && !end)
            {
                timing += Time.fixedDeltaTime;
                if (timing >= timer_lim)
                {
                    end = true;
                }
            }
            return end;
        }

        public bool Ticking_DeltaTime()
        {
            if (run && !end)
            {
                timing += Time.deltaTime;
                if (timing >= timer_lim)
                {
                    end = true;
                }
            }
            return end;
        }

        public void Reset()
        {
            end = false;
            timing = 0f;
        }

        public void Reset(float t)
        {
            timer_lim = t;
            run = true;
            end = false;
            timing = 0f;
        }

        public void Off()
        {
            run = false;
            end = false;
        }

        public void PauseTurn()
        {
            if (run)
                run = false;
            else
                run = true;
        }

    }
}
