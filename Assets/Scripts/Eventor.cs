using UnityEngine;
using System.Collections;

public class Eventor:MonoBehaviour
{
    public delegate void LevelEvent();
    public static event LevelEvent OnPlayerDied;
    public static event LevelEvent OnPlayerReviveChoose;
    public static event LevelEvent OnPlayerExitChoose;

    public void EventOnPlayerDied()
    {
        if (OnPlayerDied != null)
            OnPlayerDied();
    }

    public void EventOnPlayerReviveChoose()
    {
        if (OnPlayerReviveChoose != null)
            OnPlayerReviveChoose();
    }

    public void EventOnPlayerExitChoose()
    {
        if (OnPlayerExitChoose != null)
            OnPlayerExitChoose();
    }
}
