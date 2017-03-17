using UnityEngine;
using System.Collections;
using Units;

public class Kolya : MonoBehaviour {

    Collider2D col;
    [SerializeField] float Damage = 10f;
	void Start () {
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
                    victim.SetDamage(Damage, TypeDAMAGE.REGULAR, true);

                }
            }
    }

    void Update () {
	
	}
}
