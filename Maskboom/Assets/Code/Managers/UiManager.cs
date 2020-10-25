using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UiManager>();

            return _instance;
        }
    }

    private static UiManager _instance;

    [SerializeField]
    private Image _healthBar;

    [SerializeField] private Text _ammoText;

    [SerializeField] private Text _killText;

    public void UpdateHealthBar(float health)
    {
        _healthBar.fillAmount = health / 100;
    }

    public void UpdateAmmoText(int ammo)
    {
        _ammoText.text =  "x"+ammo.ToString();
    }

    public void UpdateKillText(int kills)
    {
        _killText.text = kills.ToString();
    }
}
