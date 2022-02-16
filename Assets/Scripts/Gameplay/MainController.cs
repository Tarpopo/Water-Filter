using MoreMountains.NiceVibrations;
using SquareDino;
using UnityEngine;
using SquareDino.Scripts.MyAds;
#if !UNITY_EDITOR
using MoreMountains.NiceVibrations;
#endif

public class MainController : MonoBehaviour
{
    [SerializeField] private SceneUI sceneUI;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private ParticleSystem fireworksParticleSystem;
    //private MazeManager _mazeManager;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        sceneUI.GameWindow.RestartButton.OnClick += RestartGame;
        sceneUI.VictoryWindow.ContinueButton.OnClick += NextLevel;
        sceneUI.LosingWindow.RestartButton.OnClick += RestartGame;
        // sceneUI.StartWindow.StartButton.OnClick += () =>
        // {
        //     sceneUI.GameWindow.Enable(true);
        //     _mazeManager.gameObject.SetActive(true);
        //     //sceneUI.StartWindow.Enable(false);
        //     FindObjectOfType<Rotator>().Rotate();
        // };
        levelManager.OnLevelLoaded += LevelManager_OnLevelLoaded;
        levelManager.OnLevelCompleted += LevelManager_OnLevelCompleted;
        levelManager.OnLevelNotPassed += LevelManager_OnLevelNotPassed;

        StartGame();
    }

    private void StartGame()
    {
        levelManager.LoadLevel();
    }

    private void NextLevel()
    {
        MoneyHandler.SaveMoneyData();
        MyAdsManager.InterstitialShow(InterstitialClosed);
    }

    private void RestartGame()
    {
        levelManager.CurrentLevel.OnProgressUpdated -= CurrentLevel_OnProgressUpdated;
        sceneUI.LosingWindow.Enable(false);

        MyAdsManager.InterstitialShow(InterstitialClosed);
    }

    private void InterstitialClosed()
    {    
        levelManager.LoadLevel();
    }

    private void LevelManager_OnLevelLoaded()
    {
        fireworksParticleSystem.Stop();
        fireworksParticleSystem.gameObject.SetActive(false);

        levelManager.CurrentLevel.OnProgressUpdated += CurrentLevel_OnProgressUpdated;
        // _mazeManager = FindObjectOfType<MazeManager>();
        // _mazeManager.gameObject.SetActive(false);
        sceneUI.GameWindow.Enable(true);
        sceneUI.VictoryWindow.Enable(false);
        //sceneUI.StartWindow.Enable(true);
    }

    private void CurrentLevel_OnProgressUpdated(LevelProgress levelProgress)
    {
        sceneUI.GameWindow.UpdateProgressBar(levelProgress);
    }

    private void LevelManager_OnLevelCompleted()
    {
        levelManager.CurrentLevel.OnProgressUpdated -= CurrentLevel_OnProgressUpdated;

        fireworksParticleSystem.gameObject.SetActive(true);
        if (!fireworksParticleSystem.isPlaying) fireworksParticleSystem.Play();

        sceneUI.GameWindow.Enable(false);
        sceneUI.VictoryWindow.Enable(true);

        MyVibration.Haptic(MyHapticTypes.Selection);
    }

    private void LevelManager_OnLevelNotPassed()
    {
        levelManager.CurrentLevel.OnProgressUpdated -= CurrentLevel_OnProgressUpdated;

        sceneUI.GameWindow.Enable(false);
        sceneUI.LosingWindow.Enable(true);

        MyVibration.Haptic(MyHapticTypes.Selection);
    }
}