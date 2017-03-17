using UnityEngine;
using System.Collections;
using Units;

public class Elixir : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerCharacter player;
        if (col.gameObject.tag == "DamageBody")
        {
            if ((col.transform.root.gameObject.tag == "Player"))
            {
                player = col.transform.root.gameObject.GetComponent<PlayerCharacter>();
                player.TakeElixir();
                GetComponent<AudioSource>().Play();
                this.transform.FindChild("elicsirObjct").gameObject.SetActive(false);
                Destroy(this);
            }
        }
    }
}
