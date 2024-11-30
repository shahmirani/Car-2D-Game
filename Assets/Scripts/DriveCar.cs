using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
   [SerializeField] private Rigidbody2D _frontTireRB;
   [SerializeField] private Rigidbody2D _backTireRB;
   [SerializeField] private Rigidbody2D _CarRB;
   [SerializeField] private float _speed=150f;
   [SerializeField] private float _rotationSpeed=300f;
   [SerializeField] private AudioSource hornSound;
   private float _moveInput;



   private void Update(){
    _moveInput= Input.GetAxisRaw("Horizontal");

    if(Input.GetKeyDown(KeyCode.H)){
      hornSound.Play();

    }
   }

   private void FixedUpdate(){
    _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
    _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
    _CarRB.AddTorque(-_moveInput * _rotationSpeed * Time.fixedDeltaTime);
   }

}
