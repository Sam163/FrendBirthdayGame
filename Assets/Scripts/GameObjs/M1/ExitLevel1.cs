using UnityEngine;
using System.Collections;

namespace Level1
{
    public class ExitLevel1 : MonoBehaviour
    {

        // Use this for initialization
        protected void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                EventorL1 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL1>();
                e.EventEndLevel();
                Debug.Log("Пора закончить уровень!");
            }
        }
    }
}

