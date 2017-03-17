using UnityEngine;
using System.Collections;
using Units;

public class KillZoneControl : MonoBehaviour {

    private Collider2D m_col;
    private PersonBaseCharacter victim;

    void Start () {
        m_col = GetComponent<Collider2D>();
        m_col.isTrigger = true;
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (victim = col.gameObject.GetComponent<PersonBaseCharacter>())
        {
            victim.SetDamage(1000f, TypeDAMAGE.KILLZONE, false);
        }
    }
}
