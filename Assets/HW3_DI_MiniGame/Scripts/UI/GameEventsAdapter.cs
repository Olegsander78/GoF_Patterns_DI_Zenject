using UnityEngine;

public class GameEventsAdapter : MonoBehaviour
{
    [SerializeField] private GameEventsView _eventsView;
    [SerializeField] private GameController _gameController;
    [SerializeField] private string _endGametext = "You win again!";    

    private void Start()
    {
        _eventsView.SetupOneColorButtonText($"Pop all balls of color - {_gameController.ColorToPop.ToString()} to win!");

        _gameController.OnEndedGame += OnShowEndGameText;
        _gameController.OnSelectedCondition += OnShowConditionWinText;
    }

    private void OnShowConditionWinText(string conditionWinText)
    {
        _eventsView.SetupConditionWinText(conditionWinText);
    }

    private void OnShowEndGameText()
    {
        _eventsView.SetupEndGameText(_endGametext);
    }    

    private void OnDisable()
    {
        _gameController.OnEndedGame -= OnShowEndGameText;
        _gameController.OnSelectedCondition -= OnShowConditionWinText;
    }

}
