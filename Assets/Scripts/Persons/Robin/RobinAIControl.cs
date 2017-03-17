using UnityEngine;
using System.Collections;
using AssistanObejcts;

namespace Units
{
    [RequireComponent(typeof(RobinCharacter))]

    public class RobinAIControl : BotBaseAIControl
    {
        private void Awake()
        {
            m_Character = GetComponent<RobinCharacter>();
        }
    }
}