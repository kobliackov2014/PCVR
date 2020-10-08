using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BenchmarckTextManager : MonoBehaviour
{
    [SerializeField]
    ChecTrigerManager _checTrigerManager;
    public Text _text;
    public Text _textCPU;
    public Text _textGPU;
    public Text _textRAM;
    public Text _textROM;


    void OnEnable ()
    {
        //_text = GetComponent<Text>();
        _checTrigerManager.EvaluatingComponentPerformance();
        _text.text = $"Количество баллов набранных системой: {_checTrigerManager._perfomanceSystem}";
        _textCPU.text = $"Количество боллов набранных CPU: {_checTrigerManager._performanceCPU}";
        _textGPU.text = $"Количество боллов набранных GPU: {_checTrigerManager._performanceGPU}";
        _textRAM.text = $"Количество боллов набранных RAM: {_checTrigerManager._performanceRAM}";
        _textROM.text = $"Количество боллов набранных ROM: {_checTrigerManager._performanceROM}";

    }
}
