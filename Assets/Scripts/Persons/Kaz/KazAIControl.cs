using UnityEngine;
using System.Collections;
using AssistanObejcts;

namespace Units
{
    [RequireComponent(typeof(KazCharacter))]

    public class KazAIControl : BotBaseAIControl
    {
        private void Awake()
        {
            m_Character = GetComponent<KazCharacter>();
        }
    }
}