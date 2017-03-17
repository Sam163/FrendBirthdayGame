using UnityEngine;
using System.Collections;
using AssistanObejcts;
using Units;

namespace Level2
{
    public class FrogSinger : PersonBaseCharacter
    {
        [SerializeField] Vector3 frogPos1;
        [SerializeField] Vector3 frogPos2;
        [SerializeField] Vector3 frogPos3;
        Animator anim;
        [SerializeField]
        AudioClip diefrog;

        bool QuestStarted = false;
        bool QuestEnd = false;
        Timer damageTimer;
        [SerializeField] float damageTimeLim = 1f;
        [SerializeField] float damage = 1f;

        [SerializeField]
        GameObject Deniels;

        PersonBaseCharacter player;

        void OnEnable()
        {
            EventorL2.OnFrogDialog += ReadyQuest;
            EventorL2.OnFrogQuestBegin += StartQuest;
        }


        void OnDisable()
        {
            EventorL2.OnFrogDialog -= ReadyQuest;
            EventorL2.OnFrogQuestBegin -= StartQuest;
        }

        AudioSource song;

        void Start()
        {

            song = GetComponent<AudioSource>();
            anim = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PersonBaseCharacter>();
            damageTimer = new Timer(damageTimeLim);
            Deniels.SetActive(false);
        }

        void PlaySong() {
            song.Play();
        }

        void ReadyQuest() {
            anim.SetBool("Sing",true);
            int i;
            switch (i=Random.Range(1,4))
            {
                case 1:
                    this.transform.position = frogPos1;
                    break;
                case 2:
                    this.transform.position = frogPos2;
                    break;
                default:
                    this.transform.position = frogPos3;
                    break;
            }
        Debug.Log(i);
        }

        void StartQuest()
        {
            QuestStarted = true;
            QuestEnd = false;
            damageTimer.Begin();
        }

        void FixedUpdate() {
            damageTimer.Ticking_fixedDeltaTime();
        }
        void Update()
        {           
            if (QuestStarted && !QuestEnd)
            {
                if (damageTimer.Ended)
                {
                    player.SetDamage(damage, TypeDAMAGE.REGULAR, true);
                    damageTimer.Reset();
                }
            }

        }

        public override void SetDamage(float damage, TypeDAMAGE t, bool b)
        {
            if (t == TypeDAMAGE.WEAPON && QuestStarted && !QuestEnd)
            {
                m_Health = 0f;
                EventorL2 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL2>();
                anim.SetBool("Sing", false);
                song.Stop();
                song.PlayOneShot(diefrog);
                anim.SetBool("Die", true);
                Deniels.SetActive(true);
                QuestEnd = true;
                e.EventOnFrogDied();
            }
        }

        public override float Damage()
        {
            return 0;
        }
    }
}

