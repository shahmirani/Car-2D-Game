
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class FuelController : MonoBehaviour
{
    public static FuelController instance;
    [SerializeField] private Image _fuelImage;
    [SerializeField , Range(0.1f , 5f)] private float _fuelDrainSpeed = 1f; 
    [SerializeField] private float _maxFuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;
    private float _CurrentFuelAmount;
    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    private void Start(){
        _CurrentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }

    private void Update(){
        _CurrentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        UpdateUI();

        if(_CurrentFuelAmount <= 0f){
            GameManager.instance.GameOver();
        }
    }
    private void UpdateUI(){
        _fuelImage.fillAmount = (_CurrentFuelAmount / _maxFuelAmount);
        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }
    public void FillFuel(string fuelTag)
{
    if (fuelTag == "red_fuel"){
        _CurrentFuelAmount += _maxFuelAmount * 0.1f;
    }
    else if (fuelTag == "blue_fuel"){
        _CurrentFuelAmount += _maxFuelAmount * 0.3f;
    }
    else if (fuelTag == "yellow_fuel"){
        _CurrentFuelAmount += _maxFuelAmount;
    }
    _CurrentFuelAmount = Mathf.Clamp(_CurrentFuelAmount, 0, _maxFuelAmount);
    UpdateUI();
}
}
