using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {

    public GameObject control_panel;
    Vector3 control_p_ClosePos = new Vector3(10f, 600f,0f);
    Vector3 control_p_OpenPos = new Vector3(10f, 80f, 0f);
    bool controlOpen;
    bool controlClose;

    public GameObject setting_panel;
    public GameObject setting_Buttons;
    float setting_speed = 10f;
    Image fon;
    GameObject p_down;
    float  setting_p_StartFillAmount = 0.12f;
    Vector3 p_down_OpenPos = new Vector3(0f, -227f, 0f);
    Vector3 p_down_ClosePos = new Vector3(0, 177f, 0f);
    bool settingOpen;
    bool settingClose;

    bool sceneEnd = false;
    float sceneEndSpeed = 4f;
    Image OutImage;

    public GameObject main_panel;
    void Start () {
        //control panel
        control_panel.transform.localPosition = control_p_ClosePos;

        //setting panel
        p_down = setting_panel.transform.FindChild("PergamentDown").gameObject;
        p_down.transform.localPosition = p_down_ClosePos;
        fon = setting_panel.GetComponent<Image>();
        setting_panel.SetActive(false);

        //on new game
        OutImage = transform.FindChild("OutImage").GetComponent<Image>();
        OutImage.enabled = false;

        AudioListener.volume = 1f;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (controlOpen) OpenControlPanel();
        if (controlClose) CloseControlPanel();
        if (settingOpen) OpenSettingPanel();
        if (settingClose) CloseSettingPanel();
        if (sceneEnd) EndScene();
    }

    public void OnNewGame() {
        sceneEnd = true;
    }
    public void OnExit() {
        Application.Quit();
    }
    public void OnSetting() {
        setting_panel.SetActive(true);
        setting_Buttons.SetActive(false);
        settingOpen = true;
        settingClose = false;
        setting_panel.GetComponent<AudioSource>().Play();
    }
    public void OnSettingBack()
    {
        setting_Buttons.SetActive(false);
        settingOpen = false;
        settingClose = true;
        setting_panel.GetComponent<AudioSource>().Play();
    }
    public void OnUserControl() {
        controlOpen = true;
        controlClose = false;
        control_panel.GetComponent<AudioSource>().Play();
    }
    public void OnUserControlBack()
    {
        controlOpen = false;
        controlClose = true;
        control_panel.GetComponent<AudioSource>().Play();
    }

    void OpenControlPanel() {
        if ((control_panel.transform.localPosition - control_p_OpenPos).magnitude >= 0.01f)
        {
            control_panel.transform.localPosition = Vector3.MoveTowards(control_panel.transform.localPosition, control_p_OpenPos, 4f );
        }
        else
        {
            control_panel.transform.localPosition = control_p_OpenPos;
            control_panel.GetComponent<AudioSource>().Stop();
            controlOpen = false;
        }
    }
    void CloseControlPanel() {
        if ((control_panel.transform.localPosition - control_p_ClosePos).magnitude >= 0.01f)
        {
            control_panel.transform.localPosition = Vector3.MoveTowards(control_panel.transform.localPosition, control_p_ClosePos, 4f);
        }
        else
        {
            control_panel.transform.localPosition = control_p_ClosePos;
            control_panel.GetComponent<AudioSource>().Stop();
            controlClose = false;
        }
    }
    void OpenSettingPanel()
    {
        if ((p_down.transform.localPosition - p_down_OpenPos).magnitude >= 0.01f)
        {
            p_down.transform.localPosition = Vector3.MoveTowards(p_down.transform.localPosition, p_down_OpenPos, setting_speed);
            fon.fillAmount = PergamentPersent(p_down.transform.localPosition);
        }
        else
        {
            p_down.transform.localPosition = p_down_OpenPos;
            fon.fillAmount = 1f;
            setting_Buttons.SetActive(true);
            settingOpen = false;
        }
    }

    void CloseSettingPanel()
    {
        if ((p_down.transform.localPosition - p_down_ClosePos).magnitude >= 0.01f)
        {
            p_down.transform.localPosition = Vector3.MoveTowards(p_down.transform.localPosition, p_down_ClosePos, setting_speed);
            fon.fillAmount = PergamentPersent(p_down.transform.localPosition);
        }
        else
        {
            p_down.transform.localPosition = p_down_ClosePos;
            fon.fillAmount = setting_p_StartFillAmount;
            setting_panel.SetActive(false);
            settingClose = false;
        }
    }

    float PergamentPersent(Vector3 v) {
        float p = (v - p_down_ClosePos).magnitude / (p_down_OpenPos - p_down_ClosePos).magnitude;
        p = p * (1 - setting_p_StartFillAmount)+ setting_p_StartFillAmount;

        return p;
    }

    protected void EndScene()
    {
        OutImage.enabled = true;
        OutImage.color = Color.Lerp(OutImage.color, Color.black, sceneEndSpeed * Time.deltaTime);
        AudioListener.volume = Mathf.Lerp(AudioListener.volume, 0f, sceneEndSpeed * Time.deltaTime);
        if (OutImage.color.a >= 0.95f)
        {
            Cursor.visible = false;
            OutImage.color = Color.black;
            Application.LoadLevel("M1");
            //Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
