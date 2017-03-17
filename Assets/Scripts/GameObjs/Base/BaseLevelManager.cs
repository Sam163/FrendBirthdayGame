using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using Units;

public abstract class BaseLevelManager : MonoBehaviour
{
    protected GameObject player;
    protected PlayerCharacter playerChar;

    protected Transform StartPos;
    protected Vector2 RespPos;

    protected static bool sceneEnd;
    protected float fadeSpeed = 1.5f;
    protected static int nextLevel;
    protected bool sceneStarting;
    protected PlayerUIManager UIManager;

    protected void Awake()
    {
        UIManager = GameObject.Find("PlayerUI").GetComponent<PlayerUIManager>();
        UIManager.OutImage.enabled = true;
        sceneStarting = true;
        sceneEnd = false;
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerChar = player.GetComponent<PlayerCharacter>();

        StartPos = GameObject.Find("StartPos").transform;
        RespPos = transform.TransformVector(StartPos.position);

        AudioListener.volume = 1f;
    }

    public virtual void NewRespPoint(Vector2 r) {
        RespPos = r;
    }

    protected virtual void Update()
    {
        if (sceneStarting) StartScene();
        if (sceneEnd) EndScene();
    }

    protected void StartScene()
    {
        UIManager.OutImage.color = Color.Lerp(UIManager.OutImage.color, Color.clear, fadeSpeed * Time.deltaTime);

        if (UIManager.OutImage.color.a <= 0.01f)
        {
            UIManager.OutImage.color = Color.clear;
            UIManager.OutImage.enabled = false;
            sceneStarting = false;
        }
    }

    protected void EndScene()
    {
        sceneStarting = false;
        UIManager.OutImage.enabled = true;
        UIManager.OutImage.color = Color.Lerp(UIManager.OutImage.color, Color.black, fadeSpeed * Time.deltaTime);
        AudioListener.volume = Mathf.Lerp(AudioListener.volume,0f, fadeSpeed * Time.deltaTime);
        if (UIManager.OutImage.color.a >= 0.95f)
        {
            Cursor.visible = false;
            UIManager.OutImage.color = Color.black;
            SceneManager.LoadScene(nextLevel);
        }
    }

    protected virtual void RestartScene() {
        sceneEnd = true;
        nextLevel = Application.loadedLevel;
    }

    protected virtual void PlayerDied()
    {
        Debug.Log("So Sorry!");
        if (playerChar.Elixir > 0)
        {
            player.transform.position = RespPos;
            playerChar.Revival();
        }
        else
        {
            UIManager.MessageShow();
        }
    }

    protected virtual void ExitToMainMenu()
    {
        sceneEnd = true;
        nextLevel = 1;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(nextLevel);
    }

    protected virtual void StartPlayerSetting() {
        playerChar.Rebirth(playerChar.MaxHealth);
        //if (playerChar.CheckDead())
            //playerChar.Revival(playerChar.MaxHealth); //playerChar.TakeElixir();     
    }
}
