using UnityEngine;
using System.Collections;
using Units;

namespace Level4 {
    public class Ctulhu : PersonBaseCharacter
    {
        Animator anim;
        bool battle=false;

        bool toBattlePos = false;
        Vector3 startPos = new Vector3(0f, -35f, 0f);
        Vector3 battlePos = Vector3.zero;

        AudioSource auSource;
        public AudioClip dm1;
        public AudioClip dm2;
        public AudioClip dm3;

        PersonBaseCharacter player;

        [SerializeField ]GameObject sk1, sk2, sk3, sk4;

        void OnEnable() {
            EventorL4.OnStartDialog += BeginMoveToBattlePos;
            EventorL4.OnCtulhuDialog += BeginBattle;
        }
        void OnDisable() {
            EventorL4.OnStartDialog -= BeginMoveToBattlePos;
            EventorL4.OnCtulhuDialog -= BeginBattle;
        }

        public void BeginMoveToBattlePos() {
            toBattlePos = true;
        }

        void BeginBattle() {
            battle = true;
            anim.SetBool("Battle",true);
            sk1.GetComponent<Collider2D>().enabled = true;
            sk2.GetComponent<Collider2D>().enabled = true;
            sk3.GetComponent<Collider2D>().enabled = true;
            sk4.GetComponent<Collider2D>().enabled = true;
        }

        void Start() {          

            anim = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PersonBaseCharacter>();
            auSource = GetComponent<AudioSource>();

            this.transform.position = startPos;
            sk1.GetComponent<Collider2D>().enabled = false;
            sk2.GetComponent<Collider2D>().enabled = false;
            sk3.GetComponent<Collider2D>().enabled = false;
            sk4.GetComponent<Collider2D>().enabled = false;
        }

        void Update()
        {
            if (CheckAlive())
            {
                if (player.Health < 10f)
                    anim.SetBool("Happy", true);
                else
                    anim.SetBool("Happy", false);
                if (toBattlePos)
                    ToBattlePosition();
            }

        }

        public override void SetDamage(float damage, TypeDAMAGE type, bool b)
        {
            if (CheckAlive() && (type == TypeDAMAGE.WEAPON) && battle)
            {
                m_Health -= damage;
                switch (Random.Range(1, 4))
                {
                    case 1:
                        {
                            auSource.PlayOneShot(dm1);
                        }
                        break;
                    case 2:
                        {
                            auSource.PlayOneShot(dm2);
                        }
                        break;
                    default:
                        auSource.PlayOneShot(dm3);
                        break;
                }

            }
            if (CheckDead())
            {
                Die();
            }
            else
                if (damage != 0)
            { } //m_Anim.Play("Damage");
        }

        public override float Damage()
        {
            m_Hit = false;
                return 0f;

        }
        private void Die()
        {
            sk1.GetComponent<Collider2D>().enabled = false;
            sk2.GetComponent<Collider2D>().enabled = false;
            sk3.GetComponent<Collider2D>().enabled = false;
            sk4.GetComponent<Collider2D>().enabled = false;
            battle = false;
            anim.SetBool("Battle", false);
            anim.SetBool("Happy", false);
            anim.SetBool("Dead", true);
        }

        void ToBattlePosition() {
            if ((transform.position - battlePos).magnitude >= 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, battlePos, 2f*Time.fixedDeltaTime);
            }
            else
            {
                transform.position = battlePos;
                toBattlePos = false;
                EventorL4 e4 = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL4>();
                e4.EventOnReadyCtulhuDialog();
            }
        }

        void SetDieEvent() {
            EventorL4 e4 = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL4>();
            e4.EventOnCtulhuDie();
        }
    }
}

