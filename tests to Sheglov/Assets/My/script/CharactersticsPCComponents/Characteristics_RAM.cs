using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics_RAM : MonoBehaviour
{
    [Header("Характеристики RAM")]
    public int _RAM_frequency;//частота
    public int _RAM_amount_of_memory; // объем памяти 
    public int Cl; //RAM timings

    double _performanceRAM;
    public double PerfomanceRAM()
    {
        _performanceRAM = 1 * Cl * 100000 / _RAM_frequency / 2;
        Debug.Log($"_performanceRAM {_performanceRAM}");
        
        return _performanceRAM;

    }
}
