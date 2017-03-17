using UnityEngine;
using System.Collections;

namespace Units
{
    public class RobinCharacter : BotBaseCharacter
    {
        private void Start()
        {
            m_Weapon = GetComponentInChildren<Weapon>();
        }

        private void FixedUpdate()
        {
            m_Grounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);
        }
    }
}
