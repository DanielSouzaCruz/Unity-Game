using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinPickUp;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if(player != null)
                {
                    player.hasCoin = true;
                    AudioSource.PlayClipAtPoint(_coinPickUp, transform.position, 1f);
                    UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if(_uiManager != null)
                    {
                        _uiManager.CollectedCoin();
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
