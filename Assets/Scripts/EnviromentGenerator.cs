using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]

public class EnviromentGenerator : MonoBehaviour
{
[SerializeField] private SpriteShapeController _SpriteShapeController;
[SerializeField, Range(3f,100f)] private int _levelLenght = 50; 
[SerializeField, Range(1f,50f)] private float _xMultiplier = 50; 
[SerializeField, Range(1f,50f)] private float _yMultiplier = 50;
[SerializeField, Range(0f,1f)] private float _curveSmoothness = 0.5f;
[SerializeField] private float _noiseStep = 0.5f;
[SerializeField] private float _bottom = 10f;
private Vector3 _lastPos;
private void OnValidate(){
    _SpriteShapeController.spline.Clear();
    for (int i = 0 ; i < _levelLenght ; i++){
        _lastPos = transform.position + new Vector3(i * _xMultiplier , Mathf.PerlinNoise(0,i* _noiseStep) * _yMultiplier);
        _SpriteShapeController.spline.InsertPointAt(i,_lastPos);
        if(i != 0 && i != _levelLenght - 1){
            _SpriteShapeController.spline.SetTangentMode(i,ShapeTangentMode.Continuous);
            _SpriteShapeController.spline.SetLeftTangent(i , Vector3.left * _xMultiplier * _curveSmoothness);
            _SpriteShapeController.spline.SetRightTangent(i , Vector3.right * _xMultiplier * _curveSmoothness);
        }
    }
        _SpriteShapeController.spline.InsertPointAt(_levelLenght , new Vector3(_lastPos.x , transform.position.y - _bottom));
        _SpriteShapeController.spline.InsertPointAt(_levelLenght +1 , new Vector3(transform.position.x , transform.position.y - _bottom));
    
}
   
    
}
