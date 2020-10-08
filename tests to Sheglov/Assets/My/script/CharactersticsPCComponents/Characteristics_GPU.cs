using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics_GPU : MonoBehaviour
{
    [Header("Характеристики GPU")]
    public float _GPU_frequency;//частота
    public float _GPU_frequency_TB;//частота
    public int _GPU_Number_Universal_Core;
    public int _GPU_amount_of_memory; // объем памяти 
    public int _GPU_TDP; // В Вт 
    public float _GPU_temperature;
    public int _GPUCountPowerConnecting;
}
