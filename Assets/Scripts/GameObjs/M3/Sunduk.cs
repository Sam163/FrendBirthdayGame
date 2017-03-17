using UnityEngine;
using System.Collections;
using Units;

namespace Level3
{

    public class Sunduk : MonoBehaviour
    {
        [SerializeField]
        GameObject LastKazah;
        PersonBaseCharacter k;

        Collider2D col;
        bool b = true;
        void Start()
        {
            col = GetComponent<Collider2D>();
            col.enabled = false;
            k = LastKazah.GetComponent<PersonBaseCharacter>();
        }

        void Update()
        {
            if (k.CheckDead() && b)
            {
                col.enabled = true;
                b = false;
            }
        }
    }
}

