using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ammoText;
    [SerializeField]
    private GameObject _coin;
    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo:" + count;
    }

    public void CollectedCoin()
    {
        _coin.SetActive(true);
    }

    public void RemoveCoin()
    {
        _coin.SetActive(false);
    }
}
