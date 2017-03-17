using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EndGame : MonoBehaviour {
    [SerializeField]
    Image OutImage;

    bool end = false;
    void Start () {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        OutImage.enabled = false;
        AudioListener.volume = 1f;
    }
	
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            end = true;
        }
        if (end)
            EndScene();
    }
    protected void EndScene()
    {
        OutImage.enabled = true;
        OutImage.color = Color.Lerp(OutImage.color, Color.black, 0.4f * Time.deltaTime);
        AudioListener.volume = Mathf.Lerp(AudioListener.volume, 0f, 0.4f * Time.deltaTime);
        if (OutImage.color.a >= 0.95f)
        {
            Cursor.visible = false;
            OutImage.color = Color.black;
            Application.LoadLevel("MainMenu");
        }
    }
}
