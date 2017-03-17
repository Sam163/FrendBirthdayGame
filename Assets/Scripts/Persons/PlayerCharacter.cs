using UnityEngine;
using System.Collections;

namespace Units
{
    public class PlayerCharacter : PersonBaseCharacter
    {
        PlayerSounder m_Sounder;

        [SerializeField] private uint m_Elixir = 2;
        public uint Elixir { get { return m_Elixir; } }
        [SerializeField] private float m_AtackPow = 15f;
        //damage factors
        [Range(1, 2)] [SerializeField] private float m_FD_AttackedInBack = 1.3f;//множитель при ударе в спину 
        [Range(0, 1)] [SerializeField] private float m_FD_Buckler = 0f;//процент получаемого урона при укрытии щитом
        [Range(0, 1)] [SerializeField] private float m_FD_BucklerAndContrAttack = 0.3f;//процент получаемого урона при укрытии щитом и контратаке
        //attack factors
        [Range(0, 1)] [SerializeField] private float m_FA_BucklerAndContrAttack = 0.5f;//процент урона при укрытии щитом и контратаке
        [Range(1, 2)] [SerializeField] private float m_FA_Attack1InCrouch = 1.1f;//множитель при рубящем ударе снизу
        [Range(1, 2)] [SerializeField] private float m_FA_Attack2InCrouch = 1.3f;//множитель при колящем ударе снизу

        [SerializeField]  private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;

        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private bool m_Grounded;            // на земле или нет.
        private bool m_Buckler;             // укрыт щитом или нет
        private bool m_Attack1;             // анимация атаки
        private bool m_Attack2;             // анимация атаки
        private bool m_PushAttack;          // игрок жемт кнопки атаки

        private Transform m_CeilingCheck;   // A position marking where to check for ceilings 
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private Weapon m_Weapon;

        private GameObject m_WeaponPos;
        private GameObject m_ShildPos;
        private GameObject m_Helmet;

        private void Awake()
        {
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

            m_Sounder = GetComponent<PlayerSounder>();
            e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Eventor>();
        }

        private void Start()
        {
            m_Weapon = GetComponentInChildren<Weapon>();
            m_WeaponPos = transform.FindChild("body").FindChild("l_plecho").FindChild("left_arm").FindChild("WeaponPos").gameObject;
            m_ShildPos = transform.FindChild("body").FindChild("r_plecho").FindChild("right_arm").Find("ShildPos").gameObject;
            m_Helmet = transform.FindChild("body").FindChild("face").FindChild("helmet").gameObject;
        }
        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

        }

        public void Move(float move, bool crouch, bool upmod, bool jump)
        {
            if (CheckAlive())
            {
                /*if (!crouch && m_Anim.GetBool("Crouch"))
                {
                    if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                    {
                        crouch = true;
                    }
                }*/
                m_Anim.SetBool("Crouch", crouch);

                if ((m_Grounded || m_AirControl) && !crouch)
                {
                    // The Speed animator parameter is set to the absolute value of the horizontal input.
                    m_Anim.SetFloat("Speed", Mathf.Abs(move));

                    // Move the character
                    
                    m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
                    //m_Rigidbody2D.MovePosition(new Vector2(m_Rigidbody2D.position.x+move * m_MaxSpeed, m_Rigidbody2D.position.y));
                    if (move > 0 && !m_FacingRight)
                    {
                        Flip();
                    }
                    else if (move < 0 && m_FacingRight)
                    {
                        Flip();
                    }
                }
                // If the player should jump...
                if (m_Grounded && jump && m_Anim.GetBool("Ground") && !crouch)
                {
                    m_Grounded = false;
                    m_Anim.SetBool("Ground", false);
                    if(upmod)
                        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce*1.4f));
                    else
                        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                }
            }       
        }

        public void Attack(bool f1, bool f2, bool def)
        {
            m_PushAttack = f1 || f2;
            if (CheckAlive())
            {
                m_Buckler = def;
                m_Anim.SetBool("Attack1", f1);
                m_Anim.SetBool("Attack2", f2);
                m_Anim.SetBool("Def", def);
            }
        }

        public override void SetDamage(float damage, TypeDAMAGE type, bool b)
        {
            if (CheckAlive())
            {
                switch (type)
                {
                    case TypeDAMAGE.WEAPON:
                        {
                            if (b == m_FacingRight)//если удар в спину
                            {
                                damage *= m_FD_AttackedInBack;
                                m_Sounder.Damage();
                                m_Health -= damage;
                                //Debug.Log("Удар в спину");
                            }
                            else
                            if (m_Buckler)
                            {
                                if (m_Hit || m_PushAttack)
                                {
                                    damage *= m_FD_BucklerAndContrAttack;
                                    m_Sounder.DamageOnContrAttack();
                                    m_Health -= damage;
                                    //Debug.Log("Контратака " + m_Hit + " " + m_PushAttack);
                                }
                                else
                                {
                                    damage *= m_FD_Buckler;
                                    m_Sounder.DamageOnBlock();
                                    m_Health -= damage;
                                    //Debug.Log("За щитом");
                                }
                            }
                            else {
                                m_Sounder.Damage();
                                m_Health -= damage;
                            }    
                        }
                        break;
                    case TypeDAMAGE.KILLZONE:
                        {
                            m_Sounder.DamageOnTrap();
                            m_Health = 0;                          
                        }
                        break;
                    case TypeDAMAGE.REGULAR:
                        {
                            m_Sounder.DamageOnTrap();
                            m_Health -= damage;
                        }
                        break;
                    case TypeDAMAGE.SPECIAL:
                        {
                            if(m_Buckler)
                                m_Health -= 0.5f*damage;
                            else
                                m_Health -= damage;
                            m_Sounder.DamageOnctulhu();
                        }
                        break;
                    case TypeDAMAGE.WATER:
                        {
                            m_Sounder.DamageOnWater();
                            m_Health = 0;
                        }
                        break;
                }

                if (CheckDead())
                {
                    Die();
                }
                else
                    if (damage != 0)
                        m_Anim.Play("Damage");

            }
        }

        public override float Damage()
        {
            m_Hit = false;
            if (m_Weapon != null)
            {
                float d = m_Weapon.CurrentDamage();
                if (m_Buckler)
                    d *= m_FA_BucklerAndContrAttack;
                if (m_Anim.GetBool("Crouch"))
                {
                    if (m_Attack1)
                        d *= m_FA_Attack1InCrouch;
                    else//иначе это m_Attack2
                        d *= m_FA_Attack2InCrouch;
                }
                return d;
            }
            else
            {
                return m_AtackPow;
            }

        }

        private void Die() {
            m_Anim.SetBool("Attack1", false);
            m_Anim.SetBool("Attack2", false);
            m_Anim.SetBool("Def", false);
            m_Anim.SetFloat("Speed", 0f);
            m_Anim.SetBool("Dead", true);
        }

        private void SendDieEvent()
        {
            e.EventOnPlayerDied();
        }

        public bool Revival()
        {
            if (m_Elixir > 0)
            {
                m_Elixir--;
                m_Health = m_MaxHealth;
                m_Anim.SetBool("Dead", false);
                return true;
            }
            else
                return false;
        }

        public void Revival(float hp)
        {
            m_Health += hp;
            m_Anim.SetBool("Dead", false);
            if (m_Health > m_MaxHealth)
                m_Health = m_MaxHealth;
            Debug.Log(hp+"-hp  "+m_Health);
        }

        public void Rebirth(float hp)
        {
            m_Health = hp;
            m_Anim.SetBool("Dead", false);
        }
        public void Rebirth()
        {
            m_Health = m_MaxHealth;
            m_Anim.SetBool("Dead", false);
        }

        public void TakeElixir() {
            m_Elixir++;
        }

        public void Armed() {
            m_WeaponPos.SetActive(true) ;
            m_Weapon = GetComponentInChildren<Weapon>();
            m_ShildPos.SetActive(true);
            m_Helmet.SetActive(true);
        }
        public void DisArmed() {
            m_WeaponPos.SetActive(false);
            m_ShildPos.SetActive(false);
            m_Helmet.SetActive(false);
        }

        protected void Set_BeginHit_1_Event()
        {
            Set_BeginHitEvent();
            //Debug.Log("1 B - "+m_Hit);
            m_Attack1 = true;
        }
        protected void Set_EndHit_1_Event()
        {
            Set_EndHitEvent();
           // Debug.Log("1 E - " + m_Hit);
            m_Attack1 = false;
        }
        protected void Set_BeginHit_2_Event()
        {
            Set_BeginHitEvent();
           // Debug.Log("2 B - " + m_Hit);
            m_Attack2 = true;
        }
        protected void Set_EndHit_2_Event()
        {
            Set_EndHitEvent();
            //Debug.Log("2 E - " + m_Hit);
            m_Attack2 = false;
        }
    }
}
