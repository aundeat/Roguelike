using TMPro;
using UnityEngine;
using MagicPigGames;
public class PlayerManager : MonoBehaviour
{
    private static float _health;
    private static bool _gameOver;
    public static float _energy { get; private set; }
    [SerializeField] private float _damage;
    [SerializeField] private float _speedAttack;
    [SerializeField] private HealthProgressBar _healthProgressBar;
    [SerializeField] private EnergyProgressBar _energyProgressBar;
    [SerializeField] private GameObject _player;
    private PlayerController _playerController;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _health = 100;
        _gameOver = false;
        _energy = 100;
    }
    void Update()
    {
        ShowHealthText();
        GameOver();
        ShowEnergyText();
    }

    public static void GetDamege(float damage)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Animator animator = player.GetComponent<Animator>();
        BlockAction action = player.GetComponent<BlockAction>();

        if (animator.GetBool("block") == true && _energy >= action.EnergyLoseOnHitBlockAction)
        {
            _energy -= action.EnergyLoseOnHitBlockAction;
        }
        else if (animator.GetBool("block") == true && _energy < action.EnergyLoseOnHitBlockAction)
        {
            _energy = 0;
            _health -= damage;
            animator.SetTrigger("breakBlock");
        }
        else
        {
            _health -= damage;
            if (_health < 0)
            {
                _gameOver = true;
            }
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
        _healthProgressBar.UpdateHealth(_health / 100);
    }
    private void ShowEnergyText()
    {
        _energyProgressBar.UpdateEnergy(_energy / 100);
    }

    public void GameOver()
    {
        if (_gameOver)
        {
            Debug.Log("GameOver");
        }
    }

}
