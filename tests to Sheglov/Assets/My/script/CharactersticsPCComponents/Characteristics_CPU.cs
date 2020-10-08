using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics_CPU : MonoBehaviour
{
    [Header("Характеристики CPU")]
    public float _CPU_frequency; //частота
    public float _CPU_frequency_TB; //частота
    public int _CPU_number_of_cores;
    public bool _hiperThreading;
    public int _CPU_TDP; // В Вт 
    public float _CPU_temperature;
}
