using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Units;

    public class KazHealthBarControl : MonoBehaviour
    {
        private KazCharacter person;
        [SerializeField] Image back;
        [SerializeField] Image bar;

        void Start()
        {
            person = GetComponentInParent<KazCharacter>();
        }
        void LateUpdate()
        {
            bar.fillAmount = person.hp;
            if (person.CheckDead()) {
            bar.enabled = false;
                back.enabled = false;
            }
        }
    }
