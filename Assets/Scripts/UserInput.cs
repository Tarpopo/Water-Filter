using System;
using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{
   [SerializeField] private UnityEvent _onTouchDown;
   public event UnityAction OnTouchDown
   {
      add => _onTouchDown.AddListener(value);
      remove => _onTouchDown.RemoveListener(value);
   }
   [SerializeField] private UnityEvent _onTouchUp;
   public event UnityAction OnTouchUp
   {
      add => _onTouchUp.AddListener(value);
      remove => _onTouchUp.RemoveListener(value);
   }

   private Camera _camera;
   public Vector2 TouchPosition => Input.mousePosition;
   public Vector2 TouchOnScreen => _camera.ScreenToViewportPoint(TouchPosition);

   private void Start()
   {
      Application.targetFrameRate = 60;
      _camera = Camera.main;
   }

   public Vector3 GetTouchOnWorld(float Zposition)
   {
      var touchPosition = TouchPosition;
      var position=new Vector3(touchPosition.x,touchPosition.y,Zposition);
      return _camera.ScreenToWorldPoint(position);
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         _onTouchDown?.Invoke();
      }
      if (Input.GetMouseButtonUp(0))
      {
         _onTouchUp?.Invoke();
      }
   }
}
