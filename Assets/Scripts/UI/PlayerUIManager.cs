using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Units;

public class PlayerUIManager : MonoBehaviour {

    private PlayerCharacter m_Player;
    [SerializeField] private Image bar1;
    [SerializeField] private Image bar2;
    [SerializeField] private Text liveText;
    [SerializeField] private Text elixirText;

    [SerializeField] private GameObject DialogPanel;
    [SerializeField] private Text DialogText;
    [SerializeField] private Text TalkerText;

    [SerializeField] public Image OutImage;

    [SerializeField] GameObject Mess;


    void Start () {
        m_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        bar1.fillAmount = m_Player.hp;

        DialogDisable();
    }
	
	void LateUpdate () {
        liveText.text = "Жизнь : "+ System.Math.Round( m_Player.Health,2);
        elixirText.text = m_Player.Elixir.ToString();
        if (bar1.fillAmount != m_Player.hp)
        {
            bar2.fillAmount = bar1.fillAmount;
            bar1.fillAmount = m_Player.hp;
        }
    }

    public void DialogEnable(){
        DialogPanel.SetActive(true) ;
    }
    public void DialogDisable(){
        DialogPanel.SetActive(false);
    }

    public void SetDialogText(string t, string s) {
        TalkerText.text = t;
        DialogText.text = s;
    }

    public void MessageShow() {
        Cursor.visible = true;
        Mess.SetActive(true);
    }

    public void OnExitChoose() {
        Mess.SetActive(false);
        Cursor.visible = false;
        Eventor e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Eventor>();
        e.EventOnPlayerExitChoose();
    }
    public void OnReviveChoose() {
        Mess.SetActive(false);
        Cursor.visible = false;
        Eventor e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Eventor>();
        e.EventOnPlayerReviveChoose();
    }

}
