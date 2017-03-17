using UnityEngine;
using System.Collections;
using Units;

namespace Level3
{
    public class Level3Manager : BaseLevelManager
    {

        [SerializeField]
        GameObject Kazah;

        AudioSource mainsong;
        [SerializeField]
        AudioClip epic;

        bool endLevel = false;
        void OnEnable()
        {
            EventorL3.OnKazahDialog += KazahAttack;
            EventorL3.OnAnanasDialog += NextLevel;

            EventorL3.OnPlayerDied += PlayerDied;
            EventorL3.OnPlayerReviveChoose += RestartScene;
            EventorL3.OnPlayerExitChoose += ExitToMainMenu;
        }

        void OnDisable()
        {
            EventorL3.OnKazahDialog -= KazahAttack;
            EventorL3.OnAnanasDialog -= NextLevel;

            EventorL3.OnPlayerDied -= PlayerDied;
            EventorL3.OnPlayerReviveChoose -= RestartScene;
            EventorL3.OnPlayerExitChoose -= ExitToMainMenu;
        }
        void Start()
        {
            mainsong = GetComponent<AudioSource>();
            nextLevel = Application.loadedLevel + 1;
            StartPlayerSetting();
            Kazah.GetComponent<BotBaseAIControl>().Inicialize();
            Kazah.SetActive(false);
        }

        void KazahAttack()
        {
            Kazah.SetActive(true);
            mainsong.Stop();
            mainsong.PlayOneShot(epic);
        }

        void NextLevel()
        {
            sceneEnd = true;
        }
    }
}

