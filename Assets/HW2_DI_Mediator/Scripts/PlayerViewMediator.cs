using System;
using UnityEngine;

namespace Assets.Mediator.Scripts
{
    public class PlayerViewMediator:MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerView _playerView;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            _player.OnLevelChanged += OnLevelChanged;
            _player.OnHealthChanged += OnHealthChanged;
        }        

        private void OnDisable()
        {
            _player.OnLevelChanged -= OnLevelChanged;
            _player.OnHealthChanged -= OnHealthChanged;
        }

        private void OnLevelChanged(int level)
        {
            //Some additional logic
            UpdateLevelUI(level);
        }

        private void UpdateLevelUI(int level)
        {
            _playerView.SetLevel(level);
        }

        private void OnHealthChanged(int health)
        {
            //Some additional logic
            UpdateHealthUI(health);
        }

        private void UpdateHealthUI(int health)
        {
            _playerView.SetHealth(health);
        }

        private void Init()
        {
            _playerView.SetLevel(_player.Level);
            _playerView.SetHealth(_player.Health);
        }
    }
}