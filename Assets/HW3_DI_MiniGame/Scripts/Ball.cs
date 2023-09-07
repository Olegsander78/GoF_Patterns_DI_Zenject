using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [field:SerializeField] public bool IsPopped { get; private set; }

    public Action OnPuped;
    public ColorTypes ColorBall { get; private set; }

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetColor(ColorTypes color)
    {
        ColorBall = color;

        switch (color)
        {
            case ColorTypes.Red:
                _renderer.material.color = Color.red;
                break;
            case ColorTypes.White:
                _renderer.material.color = Color.white;
                break;
            case ColorTypes.Green:
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