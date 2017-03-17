using UnityEngine;
using System.Collections;
using Units;

public class FlyBulava : MonoBehaviour {

    [SerializeField] SpriteRenderer b1, b2;
    [SerializeField] float damage = 10f;
    [Range(0, 2)][SerializeField] float startPos = 0f;
    Animation anim;
    PersonBaseCharacter victim;

    void Start () {
        anim = GetComponent<Animation>();
        anim["bulava"].time = startPos;
    }

    void SetLayerFar()
    {
        b1.sortingOrder = 11;
        b2.sortingOrder = 11;
        Damage();
    }

    void SetLayerNear()
    {
        b1.sortingOrder = 200;
        b2.sortingOrder = 200;
        Damage();
    }

    void Damage() {
        if (victim) {
            victim.SetDamage(damage, TypeDAMAGE.REGULAR, true);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "DamageBody")
        {
            victim = col.gameObject.GetComponentInParent<PersonBaseCharacter>();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "DamageBody")
            victim = null;
    }
}
