using UnityEngine;
using System.Collections;

namespace Level4
{
    public class Level4Manager : BaseLevelManager
    {

        [SerializeField]
        GameObject Ctulhu;

        [SerializeField]
        GameObject CtulhuDialog;

        AudioSource mainsong;

        [SerializeField]
        Transform Resp;

        bool endLevel = false;
        void OnEnable()
        {
            EventorL4.OnStartCtulhuDialog += EnableCtulhuDialog;
            EventorL4.OnCtulhuDie += NextLevel;
            EventorL4.OnPlayerDied += PlayerDied;
            EventorL4.OnPlayerReviveChoose += RestartScene;
            EventorL4.OnPlayerExitChoose += ExitToMainMenu;
        }

        void OnDisable()
        {
            EventorL4.OnStartCtulhuDialog -= EnableCtulhuDialog;
            EventorL4.OnPlayerDied -= PlayerDied;
            EventorL4.OnPlayerReviveChoose -= RestartScene;
            EventorL4.OnPlayerExitChoose -= ExitToMainMenu;
        }
        void Start()
        {
            mainsong = GetComponent<AudioSource>();
            nextLevel = Application.loadedLevel + 1;
            StartPlayerSetting();
            CtulhuDialog.active = false;
        }

        void EnableCtulhuDialog() {
            CtulhuDialog.active = true;
        }

        void NextLevel()
        {
            Debug.Log("hj");
            sceneEnd = true;
        }

        protected override void PlayerDied()
        {
            if (playerChar.Elixir > 0)
            {
                player.transform.position = Resp.position;
                playerChar.Revival();
            }
            else
            {
                UIManager.MessageShow();
            }
        }
    }
}

