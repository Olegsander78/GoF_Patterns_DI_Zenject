using UnityEngine;

public class GameEventsAdapter : MonoBehaviour
{
    [SerializeField] private GameEventsView _eventsView;
    [SerializeField] private GameController _gameController;
    [SerializeField] private string _endGametext = "You win again!";    

    private void Start()
    {
        _gameController.OnEndedGame += OnGameEnded;
        _gameController.OnSelectedCondition += OnShowConditionWinText;
    }

    private void OnShowConditionWinText(string conditionWinText)
    {
        _eventsView.SetupConditionWinText(conditionWinText);
    }

    private void OnGameEnded()
    {
        _eventsView.SetupEndGameText(_endGametext);
        _eventsView.EnableButtons();
    }    

    private void OnDisable()
    {
        _gameController.OnEndedGame -= OnGameEnded;
        _gameController.OnSelectedCondition -= OnShowConditionWinText;
    }

}
