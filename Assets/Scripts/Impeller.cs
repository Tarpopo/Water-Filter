using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Impeller : MonoBehaviour
{
   [SerializeField] private Rigidbody2D _rigidbody;
   [SerializeField] private float _rotationSpeed;
   private bool _isRotate => Mathf.Abs(_rigidbody.angularVelocity)>0;
   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      print("rotate");
      if (_isRotate) return;
      _rigidbody.AddTorque(Mathf.Sign((other.transform.position-transform.position).x)*_rotationSpeed);
   }
}
