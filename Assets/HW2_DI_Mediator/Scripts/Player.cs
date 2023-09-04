using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Mediator.Scripts
{
    public class Player:MonoBehaviour 
    {
        public event Action<int> OnLevelChanged;
        public event Action<int> OnHealthChanged;

        [SerializeField] private int _level;
        [SerializeField] private int _health;

        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
            }
        }

        public int Health
        {
            get { return _health; }
            set
            {                
                _health = value;
            }
        }

        private void OnEnable()
        {
            OnLevelChanged += OnAddHealth;
        }

        private void OnDisable()
        {
            OnLevelChanged -= OnAddHealth;
        }

        [ContextMenu("Add Level Method")]
        public void AddLevel()
        {
            _level++;
            Debug.Log($"Level up! Current level: {_level}");
            OnLevelChanged?.Invoke(_level);
        }

        private void OnAddHealth(int health)
        {
            _health += 2 * health;
            Debug.Log($"Level up! Current health: {_health}");
            OnHealthChanged?.Invoke(_health);
        }
    }
}