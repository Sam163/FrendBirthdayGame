using UnityEngine;
using System.Collections;
using Units;

public class Prot : MonoBehaviour {
    [SerializeField]
    float hp = 20;

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerCharacter player;
        if (col.gameObject.tag == "DamageBody")
        {
            if ((col.transform.root.gameObject.tag == "Player") )
            {
                player = col.transform.root.gameObject.GetComponent<PlayerCharacter>();
                player.Revival(hp);
                GetComponent<AudioSource>().Play();
                this.transform.FindChild("Objct").gameObject.SetActive(false);
                Destroy(this);
            }
        }

    }
}
