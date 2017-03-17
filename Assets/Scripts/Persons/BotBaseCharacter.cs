using UnityEngine;
using System.Collections;

namespace Units
{
    public class BotBaseCharacter : PersonBaseCharacter
    {
        BotSounder m_Sounder;
        [SerializeField] protected float AtackPow = 20f;

        [SerializeField]
        protected float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField]
        protected LayerMask m_WhatIsGround;

        protected const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
        protected bool m_Grounded;            // Whether or not the player is grounded.
        protected Animator m_Anim;            // Reference to the player's animator component.
        protected Rigidbody2D m_Rigidbody2D;
        protected Weapon m_Weapon;

        public Animator AnimatorControl
        {
            get { return m_Anim; }
        }

        void Awake()
        {
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Sounder = GetComponent<BotSounder>();
        }

        public void Move(float move)
        {
            if (m_Grounded && CheckAlive())
            {
                m_Anim.SetFloat("Speed", Mathf.Abs(move));
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                if (move > 0 && !m_FacingRight)
                {
                    Flip();
                }
                else if (move < 0 && m_FacingRight)
                {
                    Flip();
                }
            }
        }

        public void Attack(bool a)
        {
            //m_Hit = a;
            if(!a)
                m_Hit = false;
            if (CheckAlive())
                m_Anim.SetBool("Attack", a);
        }
        public void Attack()
        {
            //m_Hit = true;
            if (CheckAlive())
                m_Anim.SetBool("Attack", true);
        }
        public void StopAttack()
        {
            m_Hit = false;
            m_Anim.SetBool("Attack", m_Hit);
        }

        public void LookAtTarget(Vector3 target)
        {
            if (CheckAlive())
            {
                if ((target - this.transform.position).x > 0 && !m_FacingRight)
                {
                    Flip();
                }
                else
                if ((target - this.transform.position).x < 0 && m_FacingRight)
                {
                    Flip();
                }
            }

        }

        public override void SetDamage(float damage, TypeDAMAGE t, bool b)
        {
            if (CheckAlive())
            {
                m_Sounder.Damage();
                m_Health -= damage;
               // Debug.Log("Bot take damage"+damage+ "  hp="+m_Health);
            }          
        }

        public override float Damage()
        {
            m_Hit=false;
            if (m_Weapon != null)
            {
                return m_Weapon.CurrentDamage();
            }
            else
            {
                return 0;
            }

        }

        public virtual void Die() {
            m_Hit = false;
            m_Anim.SetBool("Attack", false);
            m_Anim.SetFloat("Speed", 0f);
            m_Anim.SetBool("Dead", true);
            m_Rigidbody2D.isKinematic = true;
        }
    }

}