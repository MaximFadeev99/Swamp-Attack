using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _captionField;
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private ParticleSystem _victoryFirework;

    private PlayerDieState _dieState;

    private void OnEnable()
    {
        _dieState = _player.GetComponent<PlayerDieState>();
        _dieState.Died += OnPlayerDefeat;
        _spawner.LastWaveKilled += OnPlayerVictory;
        _exitButton.onClick.AddListener(Quit);
        _restartButton.onClick.AddListener(RestartScene);
    }

    private void OnDisable()
    {
        _dieState.Died -= OnPlayerDefeat;
        _spawner.LastWaveKilled -= OnPlayerVictory;
        _exitButton.onClick.RemoveListener(Quit);
        _restartButton.onClick.RemoveListener(RestartScene);
    }

    private void Start()
    {
        _panel.gameObject.SetActive(false);
    }

    private void OnPlayerDefeat() 
    {
        string defeatCaption = "Defeated!";

        ShowPanel(defeatCaption);             
    }

    private void OnPlayerVictory() 
    {
        string victoryCaption = "Victorious!";

        ShowPanel(victoryCaption);
        _victoryFirework.Play();
    }

    private void ShowPanel(string caption) 
    {
        Time.timeScale = 0f;
        _captionField.text = caption;
        _panel.gameObject.SetActive(true);
    }

    private void Quit() 
    {
        Application.Quit();
    }

    private void RestartScene() 
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}