using MoreMountains.NiceVibrations;
using SquareDino;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public event UnityAction OnLevelLoaded
    {
        add => _onLevelLoaded.AddListener(value);
        remove => _onLevelLoaded.RemoveListener(value);
    }
    public event UnityAction OnLevelCompleted
    {
        add => _onLevelCompleted.AddListener(value);
        remove => _onLevelCompleted.RemoveListener(value);
    }
    public event System.Action OnLevelLosing;
    public event System.Action<LevelProgress> OnProgressUpdated;

    [SerializeField] private UnityEvent _onLevelLoaded;
    [SerializeField] private UnityEvent _onLevelCompleted;
    // [SerializeField] private SampleLevelObject winSampleObject;
    // [SerializeField] private SampleLevelObject loseSampleObject;

    private LevelProgress levelProgress;

    private void Start()
    {
        // Сообщает, что уровень загружен
        OnLevelLoaded += () => print("LevelLoaded");
        _onLevelLoaded?.Invoke();
        // Задает начальные значения для прогресса уровня
        levelProgress = new LevelProgress(0, 0, 100);

        // winSampleObject.OnClick += WinSampleObject_OnClick;
        // loseSampleObject.OnClick += LoseSampleObject_OnClick;
    }

    public void CompleteLevel()
    {
        _onLevelCompleted?.Invoke();
    }
    // private void WinSampleObject_OnClick()
    // {
    //     // Победа
    //     winSampleObject.OnClick -= WinSampleObject_OnClick;
    //     loseSampleObject.OnClick -= LoseSampleObject_OnClick;
    //
    //     OnLevelCompleted?.Invoke();
    // }
    //
    // private void LoseSampleObject_OnClick()
    // {
    //     // Проигрыш
    //     winSampleObject.OnClick -= WinSampleObject_OnClick;
    //     loseSampleObject.OnClick -= LoseSampleObject_OnClick;
    //
    //     OnLevelLosing?.Invoke();
    // }

#if UNITY_EDITOR
    private void Update()
    { 
        // Удачно завершаем уровень
        if (Input.GetKeyDown(KeyCode.Space)) _onLevelCompleted?.Invoke();
        // Неудачно завершаем уровень
        if (Input.GetKeyDown(KeyCode.Backspace)) OnLevelLosing?.Invoke();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Изменяет прогресс прохождения уровня
            levelProgress.CurrentValue = 10f;
            // Сообщает, что прогресс обновился
            OnProgressUpdated?.Invoke(levelProgress);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Изменяет прогресс прохождения уровня
            levelProgress.CurrentValue = 20f;
            // Сообщает, что прогресс обновился
            OnProgressUpdated?.Invoke(levelProgress);
        }
    }
#endif
}

public struct LevelProgress
{
    public float CurrentValue;
    private readonly float _minValue;
    private readonly float _maxValue;

    public LevelProgress(float currentValue, float minValue, float maxValue)
    {
        CurrentValue = currentValue;
        _minValue = minValue;
        _maxValue = maxValue;
    }

    public float Progress => (CurrentValue - _minValue) / (_maxValue - _minValue);
}