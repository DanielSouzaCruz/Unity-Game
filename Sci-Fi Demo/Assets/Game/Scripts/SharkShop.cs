using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if(player != null)
                {
                    if(player.hasCoin == true)
                    {
                        player.hasCoin = false;
                        UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if(uiManager != null)
                        {
                            uiManager.RemoveCoin();
                        }
                        AudioSource sharkAudio = GetComponent<AudioSource>();
                        sharkAudio.Play();
                        player.EnableWeapons();
                    }
                    else
                    {
                        Debug.Log("Pague o Aluguel!");
                    }
                }
            }
        }
    }
}
