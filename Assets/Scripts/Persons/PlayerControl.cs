using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Units
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerControl : MonoBehaviour
    {

        private PlayerCharacter m_Character;
        private bool m_Jump;

        private void Awake()
        {
            m_Character = GetComponent<PlayerCharacter>();
        }
        void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }
        private void FixedUpdate()
        {
            bool crouch = Input.GetKey(KeyCode.S);
            bool upmod = Input.GetKey(KeyCode.W);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");

            m_Character.Move(h, crouch, upmod, m_Jump);
            m_Character.Attack(CrossPlatformInputManager.GetButton("Fire1"), CrossPlatformInputManager.GetButton("Fire2"), Input.GetKey(KeyCode.LeftShift));
            m_Jump = false;

        }
    }
}