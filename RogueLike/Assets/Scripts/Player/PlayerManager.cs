using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static float _health;
    private static bool _gameOver;
    private static float _energy;
    [SerializeField] private float _damage;
    [SerializeField] private float _speedAttack;
    [SerializeField] private TextMeshProUGUI _playerHealthText;
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
    }

    public static void GetDamege(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _gameOver = true;
        }
    }

    private void ShowHealthText()
    {
        _playerHealthText.text = "" + _health;
    }

    public void GameOver()
    {
        if (_gameOver)
        {
            Debug.Log("GameOver");
        }
    }

}
