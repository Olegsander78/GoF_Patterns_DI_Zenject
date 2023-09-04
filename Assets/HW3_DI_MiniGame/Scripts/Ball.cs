using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [field:SerializeField] public bool IsPopped { get; private set; }

    public Action OnPuped;
    public ColorType ColorBall { get; private set; }

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetColor(ColorType color)
    {
        ColorBall = color;

        switch (color)
        {
            case ColorType.Red:
                _renderer.material.color = Color.red;
                break;
            case ColorType.White:
                _renderer.material.color = Color.white;
                break;
            case ColorType.Green:
                _renderer.material.color = Color.green;
                break;
        }
    }

    public void Pop()
    {
        if (!IsPopped)
        {
            IsPopped = true;
            this.gameObject.SetActive(false);

            OnPuped?.Invoke();
        }
    }

    private void OnMouseDown()
    {
        Pop();     
    }
}