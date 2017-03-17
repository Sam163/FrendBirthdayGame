using UnityEngine;
using Units;

namespace Level4
{
    public class CtulhuPalp : MonoBehaviour
    {

        Collider2D col;
        [SerializeField]
        float Damage = 4f;
        void Start()
        {
            col = GetComponent<Collider2D>();
            col.isTrigger = true;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "DamageBody")
            {
                PersonBaseCharacter victim;
                if (victim = col.gameObject.GetComponentInParent<PersonBaseCharacter>())
                {
                    victim.SetDamage(Damage, TypeDAMAGE.SPECIAL, true);

                }
            }
        }
    }
}

