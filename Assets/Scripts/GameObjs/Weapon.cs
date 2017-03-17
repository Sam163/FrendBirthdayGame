using UnityEngine;
using System.Collections;
using Units;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour {

    [SerializeField] private float Damage = 40;
    [SerializeField] private float Crit = 80;
    [Range(0, 1)] [SerializeField] private float Speed = 1;
    [Range(0, 100)] [SerializeField] private int CritChance = 10;
    private Collider2D bladeCol;

    private GameObject ownerDB;
    private PersonBaseCharacter ownerC;
    PersonBaseCharacter victim;

    private bool swing=false;

    void Start()
    {
        bladeCol = GetComponent< Collider2D>();
        bladeCol.isTrigger = true;
     
        ownerC = transform.root.gameObject.GetComponentInParent<PersonBaseCharacter>();
        ownerDB = ownerC.GetDamageBody;

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (ownerC.Hit) {
            if (col.gameObject.tag=="DamageBody") {
                if (col.gameObject != ownerDB)
                {
                    if (victim = col.gameObject.GetComponentInParent<PersonBaseCharacter>())
                    {
                        victim.SetDamage(ownerC.Damage(), TypeDAMAGE.WEAPON, ownerC.FacingRight);
                        //Debug.Log(ownerC+" нанес " + victim + " урон " + ownerC.Damage());
                    }
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {

    }
    void OnTriggerExit2D(Collider2D col)
    {
    }
    void Update() {
        if (ownerC.Hit)
        {
            if (swing == false)
            {
                GetComponent<AudioSource>().Play();
                swing = true;
            }
        }
        else {
            swing = false;
        }

    }
    public float CurrentDamage()
    {
        if (Random.Range(0, 100) > CritChance)
        {
            return Damage;           
        }
        else
        {
            return Crit;
        }
    }

    
}
