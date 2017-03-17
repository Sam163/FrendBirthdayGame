using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using Units;


namespace Level1{
    public class Level1Manager : BaseLevelManager
    {

        [SerializeField] GameObject LasDialog;
        [SerializeField] GameObject Frends;
        [SerializeField] GameObject Exit;

        bool armed = false;
        bool fveip = false;
        bool keyDialog = false;
        bool lastDialog = false;
        bool endLevel = false;
        void OnEnable()
        {
            EventorL1.OnArmed += ArmThePlayer;
            EventorL1.OnFindVeip += FindtheVeip;
            EventorL1.OnEndKeyDialog += KeyDialogEnded;
            EventorL1.OnEndLevel += NextLevel;
            EventorL1.OnPlayerDied += PlayerDied;
            EventorL1.OnPlayerReviveChoose += RestartScene;
            EventorL1.OnPlayerExitChoose += ExitToMainMenu;
        }


        void OnDisable()
        {
            EventorL1.OnArmed -= ArmThePlayer;
            EventorL1.OnFindVeip -= FindtheVeip;
            EventorL1.OnEndKeyDialog -= KeyDialogEnded;
            EventorL1.OnEndLevel -= NextLevel;
            EventorL1.OnPlayerDied -= PlayerDied;
            EventorL1.OnPlayerReviveChoose -= RestartScene;
            EventorL1.OnPlayerExitChoose -= ExitToMainMenu;
        }

        void Start()
        {
            Frends.SetActive(false);
            Exit.GetComponent<Collider2D>().isTrigger = false;
            nextLevel = Application.loadedLevel+1;
        }

        void ArmThePlayer() {
            playerChar.Armed();
            armed = true;
            EnableLastdialog();
        }

        void FindtheVeip()
        {
            fveip = true;
            EnableLastdialog();
        }

        void KeyDialogEnded() {
            keyDialog = true;
            EnableLastdialog();
        }

        void EnableLastdialog() {
            if (armed && fveip && keyDialog) {
                LastDialog a = LasDialog.GetComponent<LastDialog>();
                a.RewriteDialog();
                Frends.SetActive(true);
                Exit.GetComponent<Collider2D>().isTrigger = true;
                Exit.transform.FindChild("door").gameObject.active = false;
            }
        }

        void NextLevel() {
            DontDestroyOnLoad(player);
            sceneEnd = true;
        }

    }
}

