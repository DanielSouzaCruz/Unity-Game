using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ammoText;
    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo:" + count;
    }
}
