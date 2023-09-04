using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEventsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _conditionWinText;
    [SerializeField] private TextMeshProUGUI _endGameText;
    [SerializeField] private TextMeshProUGUI _oneColorButtonText;

    [SerializeField] private Button _popAllButton;
    [SerializeField] private Button _popOneColorButton;

    public void SetupConditionWinText(string condition)
    {
        DisableButtons();
        
        _conditionWinText.text = condition;
        AnimateConditionTextMove();
    }

    public void SetupOneColorButtonText(string buttonText)
    {
        _oneColorButtonText.text = buttonText;
    }

    public void SetupEndGameText(string endGameText)
    {
        _endGameText.text = endGameText;
        AnimateTextBounce();
    }

    private void DisableButtons()
    {
        _popAllButton.gameObject.SetActive(false);
        _popOneColorButton.gameObject.SetActive(false);
    }

    private void AnimateTextBounce()
    {        
        DOTween
            .Sequence()
            .AppendCallback(() => _endGameText.gameObject.SetActive(true))
            .Append(_endGameText.transform.DOScale(new Vector3(1.1f, 1.1f, 1.0f), 1f))
            .Append(_endGameText.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 1f));
    }

    private void AnimateConditionTextMove()
    {
        Vector3 startPosition = _conditionWinText.transform.position;
        Vector3 endPosition = new Vector3(Screen.width / 4f, Screen.height / 2f, 0f);
        
        DOTween.Sequence()
            .Append(_conditionWinText.transform.DOMove(startPosition, 0f))
            .AppendCallback(() => _conditionWinText.gameObject.SetActive(false)) 
            .Append(_conditionWinText.transform.DOMove(endPosition, 0.1f))
            .AppendCallback(() => _conditionWinText.gameObject.SetActive(true)) 
            .Append(_conditionWinText.transform.DOMove(startPosition, 1f));
    }
}
