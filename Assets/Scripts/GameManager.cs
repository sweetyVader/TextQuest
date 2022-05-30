using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    #region Variables

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _headerLabel;
    [SerializeField] private TextMeshProUGUI _locationLabel;
    [SerializeField] private TextMeshProUGUI _descriptionLabel;
    [SerializeField] private TextMeshProUGUI _choicesLabel;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Image _spriteImage;

    [Header("Initial Setup")]
    [SerializeField] private Step _startStep;

    [Header("External Components")]
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _menuSceneName;
    [SerializeField] private string _gameOverSceneName;
    [SerializeField] private string _gameWinSceneName;

    private Step _currentStep;
    private int _i;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _menuButton.onClick.AddListener(MenuButtonClicked);
        SetCurrentStep(_startStep);
    }

    private void Update()
    {
        CheckGameOver();
        CheckGameWin();
        int choiceIndex = GetPressedButtonIndex();

        if (!IsIndexValid(choiceIndex))
            return;
        SetCurrentStep(choiceIndex);
    }

    #endregion


    #region Private metods

    private bool IsIndexValid(int choiceIndex) =>
        choiceIndex >= 0;

    private int GetPressedButtonIndex()
    {
        int pressedButtonIndex = NumButtonHelper.GetPressedButtonIndex();
        return pressedButtonIndex - 1;
    }

    private void SetCurrentStep(int choiceIndex)
    {
        if (_currentStep.Choices.Length <= choiceIndex)
            return;
        Step nextStep = _currentStep.Choices[choiceIndex];
        SetCurrentStep(nextStep);
    }

    private void SetCurrentStep(Step step)
    {
        if (step == null)
            return;

        _currentStep = step;

        _headerLabel.text = step.DebugHeaderText;
        _locationLabel.text = step.LocationText;

        if (step.LocationImage != null)
        {
            _spriteImage.color = Color.white;
            _spriteImage.sprite = step.LocationImage;
        }
        else
            _spriteImage.color = new Color(0, 0, 0, 0);

        _descriptionLabel.text = step.DescriptionText;
        _choicesLabel.text = step.ChoicesText;
    }

    private void MenuButtonClicked()
    {
        _sceneLoader.LoadScene(_menuSceneName);
    }

    private void CheckGameOver()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            return;
        if (_currentStep.Choices.Length == 0)
        {
            _sceneLoader.LoadScene(_gameOverSceneName);
        }
    }

    private void CheckGameWin()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return;
        if (_currentStep.Choices.Length == 10)
        {
            _sceneLoader.LoadScene(_gameWinSceneName);
        }
    }

    #endregion
}