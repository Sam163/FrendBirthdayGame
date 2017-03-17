using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Level2
{
    public class Level2Manager : BaseLevelManager
    {

        [SerializeField]
        GameObject FrogDialog;
        [SerializeField]
        GameObject FrogQuestDialog;
        [SerializeField]
        GameObject BlockWay;

        bool endLevel = false;
        void OnEnable()
        {
            EventorL2.OnFrogDialog += StartFrogQuestDialog;
            EventorL2.OnFrogDied += EndFrogQuest;
            EventorL2.OnBeastDialog += NextLevel;
            EventorL2.OnPlayerDied += PlayerDied;
            EventorL2.OnPlayerReviveChoose += RestartScene;
            EventorL2.OnPlayerExitChoose += ExitToMainMenu;
        }

        void OnDisable()
        {
            EventorL2.OnFrogDialog -= StartFrogQuestDialog;
            EventorL2.OnFrogDied -= EndFrogQuest;
            EventorL2.OnBeastDialog -= NextLevel;
            EventorL2.OnPlayerDied -= PlayerDied;
            EventorL2.OnPlayerReviveChoose -= RestartScene;
            EventorL2.OnPlayerExitChoose -= ExitToMainMenu;
        }
        void Start()
        {
            FrogQuestDialog.SetActive(false);
            nextLevel = Application.loadedLevel+1;
            StartPlayerSetting();
        }

        void StartFrogQuestDialog() {
            FrogQuestDialog.SetActive(true);
        }

        void EndFrogQuest()
        {
            Destroy(BlockWay);
        }

        void NextLevel()
        {
            sceneEnd = true;
        }

    }
}
