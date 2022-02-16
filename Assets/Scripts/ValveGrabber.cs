using DefaultNamespace;
using UnityEngine;
[RequireComponent(typeof(UserInput))]
public class ValveGrabber : MonoBehaviour
{
   private UserInput _userInput;
   private Camera _camera;
   private IValve _currentValve;
   
   private void Start()
   {
      _userInput = GetComponent<UserInput>();
      _camera=Camera.main;
      _userInput.OnTouchDown += StartMove;
      _userInput.OnTouchUp += () => _currentValve = null;
   }
   private void StartMove()
   {
      var ray = _camera.ScreenPointToRay (_userInput.TouchPosition);
      _currentValve = null;
      if (Physics.Raycast(ray, out var hit))
      {
         _currentValve= hit.collider.GetComponentInParent<IValve>();
         _currentValve?.OnGrab();
         //_currentValve?.OnGrab();
         print(hit.collider.name);
      }
   }
   private void FixedUpdate()
   {
      // var position = _userInput.TouchPosition;
      // _currentValve.Move(_camera.ScreenToWorldPoint(
      //    new Vector3(position.x,position.y,_currentValve.transform.position.z)));
      _currentValve?.Move(_userInput);
   }
}
