using DefaultNamespace;
using MoreMountains.NiceVibrations;
using SquareDino;
using UnityEngine;
using UnityEngine.Events;

public class Valve : MonoBehaviour,IValve
{
    [SerializeField] private Transform _lowBorder;
    [SerializeField] private Transform _highBorder;
    [SerializeField] private Transform _valve;
    [SerializeField] private float _step;
    [SerializeField] private GameObject _manual;
    [SerializeField] private UnityEvent _onStartGrab;
    public void OnGrab()
    {
        if(_manual!=null)_manual.SetActive(false);
        _onStartGrab?.Invoke();
        MyVibration.Haptic(MyHapticTypes.LightImpact);
    }

    public void Move(UserInput userInput)
    {
        var worldTouch = userInput.GetTouchOnWorld(transform.position.z);
        // var position = new Vector3(Mathf.Clamp(worldTouch.x, _lowBorder.position.x, _highBorder.position.x), 
        //     Mathf.Clamp(worldTouch.y, _lowBorder.position.y, _highBorder.position.y),_valve.transform.position.z);
        _valve.position = Vector3.MoveTowards(_valve.position,BoardPoint(worldTouch),_step);
    }
    private Vector3 BoardPoint(Vector2 touchPosition)
    {
        var x = Mathf.Clamp(touchPosition.x, _lowBorder.position.x, _highBorder.position.x);
        var y = Mathf.Clamp(touchPosition.y, _lowBorder.position.y, _highBorder.position.y);
        return new Vector3(x, y, _valve.position.z);
    }
}
