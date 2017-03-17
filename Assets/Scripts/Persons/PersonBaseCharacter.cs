using UnityEngine;
using System.Collections;

namespace Units
{
    public abstract class PersonBaseCharacter : MonoBehaviour
    {
        protected Eventor e;
        [SerializeField]
        protected float m_Health = 100f;
        [SerializeField]
        protected float m_MaxHealth = 100f;
        public float MaxHealth
        {
            get { return m_MaxHealth; }
        }
        [SerializeField]
        protected GameObject DamageBody;
        public GameObject GetDamageBody {
            get { return DamageBody; }
        }
        public float Health { get { return m_Health; } }
        public float hp
        {
            get
            {
                if (m_Health <= 0) return 0;
                return m_Health / m_MaxHealth;
            }
        }

        [SerializeField]
        protected bool m_FacingRight = true;  // For determining which way the player is currently facing.
        protected bool m_Hit;
        public bool Hit
        {
            get { return m_Hit; }
        }

        protected void Set_BeginHitEvent() {
            m_Hit = true;
        }
        protected void Set_EndHitEvent()
        {
            m_Hit = false;
        }

        public bool FacingRight
        {
            get
            {
                return m_FacingRight;
            }
        }

        protected void Flip()
        {
            m_FacingRight = !m_FacingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public bool CheckAlive()
        {
            if (m_Health > 0)
                return true;
            else return false;
        }

        public bool CheckDead()
        {
            if (m_Health <= 0)
                return true;
            else return false;
        }

        public abstract void SetDamage(float damage, TypeDAMAGE t, bool b);

        public abstract float Damage();
    }

}