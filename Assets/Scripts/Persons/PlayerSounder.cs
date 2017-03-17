using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class PlayerSounder : MonoBehaviour {

    [SerializeField] private AudioClip step1;
    [SerializeField] private AudioClip step2;
    [SerializeField] private AudioClip stepground;

    public AudioClip damage;
    public AudioClip damageOnBlock;
    public AudioClip damageOnContrAttack;

    public AudioClip damageOnTrap;
    public AudioClip damageOnCtulhu;

    public AudioClip damageOnWater;

    AudioSource auSource;

    void Start () {
        auSource = GetComponent<AudioSource>();
    }


    public void Step1()
    {
        auSource.PlayOneShot(step1);
    }
    public void Step2()
    {
        auSource.PlayOneShot(step2);
    }

    public void StepOnGround()
    {
        auSource.PlayOneShot(stepground);
    }

    public void Damage()
    {
        auSource.PlayOneShot(damage);
    }

    public void DamageOnBlock()
    {
        auSource.PlayOneShot(damageOnBlock);
    }
    public void DamageOnContrAttack()
    {
        auSource.PlayOneShot(damageOnContrAttack);
    }

    public void DamageOnTrap()
    {
        auSource.PlayOneShot(damageOnTrap);
    }
    public void DamageOnctulhu()
    {
        auSource.PlayOneShot(damageOnCtulhu);
    }

    public void DamageOnWater() {
        auSource.PlayOneShot(damageOnWater);
    }
}
