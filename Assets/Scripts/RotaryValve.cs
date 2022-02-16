using DefaultNamespace;
using Sirenix.OdinInspector;
using SquareDino;
using UnityEngine;
public class RotaryValve : MonoBehaviour,IValve
{
    [SerializeField] private Vector2 _angleLimit = new Vector2(-90, 90);
    [SerializeField] [OnValueChanged(nameof(InverseValve))] private bool _inverse;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private GameObject _manual;
    private Camera _camera;
    private float _angle;
    private float _angleOffset=180;
    private void Start()
    {
        _camera=Camera.main;
    }
    public void OnGrab()
    {
        if(_manual!=null)_manual.SetActive(false);
        MyVibration.Haptic(MyHapticTypes.LightImpact);
    }
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    private void InverseValve()
    {
        var child = transform.GetChild(0);
        var position = child.localPosition;
        position.x *= -1;
        _angleOffset = _inverse ? 0 : 180;
        child.transform.localPosition = position;
    }
    public void Move(UserInput userInput)
    {
        var positionOnScreen = _camera.WorldToViewportPoint(transform.position);
        _angle = AngleBetweenTwoPoints(positionOnScreen, userInput.TouchOnScreen)+_angleOffset;
        if (_angle > 180) _angle -= 360;
        _angle = Mathf.Clamp(_angle,_angleLimit.x,_angleLimit.y);
        transform.rotation=Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,0,_angle), _rotateSpeed);
        //transform.eulerAngles=Vector3.MoveTowards(transform.eulerAngles,new Vector3(0,0,_angle),_rotateSpeed);
    }
}
