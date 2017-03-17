using UnityEngine;
using System.Collections;
using AssistanObejcts;
namespace Level2 {
    public class LevelManager23 : BaseLevelManager
    {
        Timer tm = new Timer(7f);
       
        bool endLevel = false;
        void Start()
        {
            tm.Begin();
            nextLevel = Application.loadedLevel + 1;
            StartPlayerSetting();
        }

        protected override void Update()
        {
            tm.Ticking_DeltaTime();
            if (sceneStarting) StartScene();
            if (sceneEnd) EndScene();
            if (tm.Ended || Input.GetKeyUp(KeyCode.Escape))
                sceneEnd = true;
        }
    }
}

