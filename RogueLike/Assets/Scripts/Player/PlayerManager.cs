using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private static float _health;
    private static bool _gameOver;
    public static float _energy { get; private set; }
    [SerializeField] private float _damage;
    [SerializeField] private float _speedAttack;
    [SerializeField] private TextMeshProUGUI _playerHealthText;
    [SerializeField] private TextMeshProUGUI _playerEnergyText;
    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        _gameOver = false;
        _energy = 100;
    }

    // Update is called once per frame
    void Update()
    {
        ShowHealthText();
        GameOver();
        ShowEnergyText();
    }

    public static void GetDamege(float damage)
    {
        Debug.Log("getDamage");
        _health -= damage;
        if (_health < 0)
        {
            _gameOver = true;
        }
    }
    public static void LostEnergy(float energy)
    {
        _energy -= energy;
        if (_energy < 0)
        {
            _energy = 0;
        }
    }
    public static void GainEnergy(float energy)
    {
        _energy += energy;
        if (_energy > 100) 
        {
            _energy = 100;
        }
    }

    private void ShowHealthText()
    {
        _playerHealthText.text = "" + _health;
    }
    private void ShowEnergyText()
    {
        _playerEnergyText.text = "" + _energy;
    }

    public void GameOver()
    {
        if (_gameOver)
        {
            Debug.Log("GameOver");
        }
    }

}
