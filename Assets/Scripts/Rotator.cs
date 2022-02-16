using DefaultNamespace;
using SquareDino;
using UnityEngine;
using UnityEngine.Events;
public class Rotator: MonoBehaviour,IValve
{
    [SerializeField] private Vector3 rotateTo;
    [SerializeField] private int _frames;
    [SerializeField] private UnityEvent _onRotationEnd;
    [SerializeField] private UnityEvent _onRotationStart;
    private bool _isActive;
    private MazeManager _mazeManager;
    public void Move(UserInput userInput) { }
    public void OnGrab()
    {
        if (_isActive) return;
        _onRotationStart?.Invoke();
        StartCoroutine(CoroutinesKid.EulerRotate(transform, rotateTo, _frames,()=>_onRotationEnd?.Invoke()));
        _mazeManager.gameObject.SetActive(true);
        _isActive = true;
        for (int i = 0; i < 4; i++)
        {
            MyVibration.Haptic(MyHapticTypes.LightImpact);
        }
    }
    private void Start()
    {
        _mazeManager = FindObjectOfType<MazeManager>();
        _mazeManager.gameObject.SetActive(false);
    }
}
