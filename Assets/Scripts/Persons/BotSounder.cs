using UnityEngine;
using System.Collections;

public class BotSounder : MonoBehaviour {

    [SerializeField]
    private AudioClip step1;
    [SerializeField]
    private AudioClip step2;
    [SerializeField]
    private AudioClip stepground;

    public AudioClip damage;

    AudioSource auSource;

    void Start()
    {
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

}
