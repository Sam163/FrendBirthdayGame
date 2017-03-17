using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    private bool m_CursorRef = false;
    private bool m_Paused;
    private GameObject m_UI;
    private GameObject m_playerUI;
    private GameObject m_settingPanel;

    void Start() {
        m_UI = transform.FindChild("MenuUI").gameObject;
        m_playerUI = GameObject.Find("PlayerUI");
        m_settingPanel = m_UI.transform.FindChild("SettingPanel").gameObject;
        MenuOff();
    }

    private void MenuOn()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        m_Paused = true;
        m_UI.SetActive(m_Paused);
        m_playerUI.SetActive(false);
        m_settingPanel.SetActive(false);
        m_CursorRef = Cursor.visible;
        Cursor.visible = m_Paused;
    }

    public void MenuOff()
    {
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        m_Paused = false;
        m_UI.SetActive(m_Paused);
        m_playerUI.SetActive(true);
        Cursor.visible = m_CursorRef;
    }

    public void SettingOn()
    {
        m_settingPanel.SetActive(true);
    }

    public void SettingOff()
    {
        m_settingPanel.SetActive(false);
    }

    public void MainMenuOn()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        Application.LoadLevel("MainMenu");       
    }


    public void OnMenuStatusChange()
    {
        if (!m_Paused)
        {
            MenuOn();
        }
        else if (m_Paused)
        {
            MenuOff();
        }
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OnMenuStatusChange();
        }
    }
}
