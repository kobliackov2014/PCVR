using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecTrigerManager : MonoBehaviour
{
    //ОЗУ
    [Header("RAM")]
    [SerializeField]
    private List<Characteristics_RAM> _listCharactristicsRAM = new List<Characteristics_RAM>();
    [SerializeField]
    private List<GameObject> _listGameObjectRAM = new List<GameObject>();
    [SerializeField]
    private bool _stayRAM = false;
    [SerializeField]
    private int _numberRAM = 0;
    [SerializeField]
    private int _indexRAM;

    //ПЗУ
    [Header("ROM")]
    [SerializeField]
    private List<Characteristics_ROM> _listCharactristicsROM = new List<Characteristics_ROM>();
    [SerializeField]
    private List<GameObject> _listGameObjectROM = new List<GameObject>();
    [SerializeField]
    private bool _stayROM = false;
    [SerializeField]
    private int _numberROM = 0;
    [SerializeField]
    private int _indexROM;

    //ЦПУ
    [Header("CPU")]
    private Characteristics_CPU _characteristics_CPU;
    [SerializeField]
    private bool _stayCPU;

    //CullerCPU
    private Characteristics_Culler_CPU _characteristics_Culler_CPU;
    [SerializeField]
    private bool _stayCullerCPU;

    //ГПУ
    private Characteristics_GPU _characteristics_GPU;
    [SerializeField]
    private bool _stayGPU;

    //PSU
    private Characteristics_PSU _characteristics_PSU;
    [SerializeField]
    private bool _stayPSU;

    //MB
    private Characteristics_MB _characteristics_MB;
    [SerializeField]
    private bool _stayMB = true;

    //PowerConnectingGPU
    int _numberPowerConnectingGPU = 0;
    [SerializeField]
    bool _stayPowerGPU = false;

    //PowerConnectingCPU
    [SerializeField]
    bool _stayPowerCPU = false;

    //PowerConnectingROM
    int _countPowerROM;
    [SerializeField]
    bool _stayPowerROM = false;

    //PowerConnectingMB
    [SerializeField]
    bool _stayPowerMB = false;

    //Case
    [SerializeField]
    bool _stayCase = false;

    //
    [SerializeField]
    public bool _systemStatus = false;

    public double _performanceRAM;
    public double _performanceROM;
    public double _performanceCPU;
    public double _performanceGPU;
    public double _perfomanceSystem;

    [SerializeField]
    private TaskList _taskList;

    #region RAM
    public void AddStatusRAM(Characteristics_RAM _enteredCharactristics, GameObject _enteredGameObject)
    {
        _listCharactristicsRAM.Add(_enteredCharactristics);
        _listGameObjectRAM.Add(_enteredGameObject);
        _numberRAM = _numberRAM + 1;
        _taskList._checkMarkRAM.SetActive(true);
        _stayRAM = true;
    }

    public void DeteriorationOfStatusRAM(/*Characteristics_RAM _enteredCharacteristics_ROM,*/ GameObject _enteredGameObject)
    {
        _indexRAM = _listGameObjectRAM.IndexOf(_enteredGameObject);
        _listGameObjectRAM.RemoveAt(_indexRAM);
        _listCharactristicsRAM.RemoveAt(_indexRAM);
        _numberRAM = _numberRAM - 1;

        if (_numberRAM == 0)
        {
            _stayRAM = false;
            _taskList._checkMarkRAM.SetActive(false);
        }
    }
    #endregion

    #region ROM
    public void AddStatusROM (Characteristics_ROM _enteredCharacteristics_ROM, GameObject _enteredGameObject)
    {
        _listCharactristicsROM.Add(_enteredCharacteristics_ROM);
        _listGameObjectROM.Add(_enteredGameObject);
        _numberROM = _numberROM + 1;
        _stayROM = true;
        _taskList._checkMarkROM.SetActive(true);
    }

    public void DeteriorationOfStatusROM (/*Characteristics_ROM _enteredCharacteristics_ROM,*/ GameObject _enteredGameObject)
    {
        _indexROM = _listGameObjectROM.IndexOf(_enteredGameObject);
        _listGameObjectROM.RemoveAt(_indexROM);
        _listCharactristicsROM.RemoveAt(_indexROM);
        _numberROM = _numberROM - 1;
        
        if (_numberROM == 0)
        {
            _stayROM = false;
            _taskList._checkMarkROM.SetActive(false);
        }
    }
    #endregion

    #region CPU
    public void AddStatusCPU (Characteristics_CPU _enteredCharacteristics_CPU)
    {
        _characteristics_CPU = _enteredCharacteristics_CPU;
        _stayCPU = true;
        _taskList._checkMarkCPU.SetActive(true);
    }

    public void DeteriorationOfStatusCPU (Characteristics_CPU _enteredCharacteristics_CPU)
    {
        _characteristics_CPU = null;
        _stayCPU = false;
        _taskList._checkMarkCPU.SetActive(false);

    }

    #endregion

    #region CullerCPU
    public void AddStatusCullerCPU(Characteristics_Culler_CPU _enteredCharacteristics_Culler_CPU)
    {
        _characteristics_Culler_CPU = _enteredCharacteristics_Culler_CPU;
        _stayCullerCPU = true;
        _taskList._checkMarkCullerCPU.SetActive(true);

    }

    public void  DeteriorationOfStatusCullerCPU(Characteristics_Culler_CPU _enteredCharacteristics_Culler_CPU)
    {
        _characteristics_Culler_CPU = null;
        _stayCullerCPU = false;
        _taskList._checkMarkCullerCPU.SetActive(false);

    }

    #endregion

    #region GPU
    public void AddStatusGPU(Characteristics_GPU _enteredCharacteristics_GPU)
    {
        _characteristics_GPU = _enteredCharacteristics_GPU;
        _stayGPU = true;
        if (_numberPowerConnectingGPU == _characteristics_GPU._GPUCountPowerConnecting)
        {
            _stayPowerGPU = true;
            _taskList._checkMarkGPU.SetActive(true);

        }
        else
        {
            _stayPowerGPU = false;
            _taskList._checkMarkGPU.SetActive(false);

        }
    }

    public void DeteriorationOfStatusGPU(Characteristics_GPU _enteredCharacteristics_GPU)
    {
        
        _characteristics_GPU = null;
        _stayGPU = false;
        _taskList._checkMarkGPU.SetActive(false);
    }

    #endregion

    #region PSU
    public void AddStatusPSU(Characteristics_PSU _enteredCharacteristics_PSU)
    {
        _characteristics_PSU = _enteredCharacteristics_PSU;
        _stayPSU = true;
        _taskList._checkMarkPSU.SetActive(true);

    }

    public void DeteriorationOfStatusPSU(Characteristics_PSU _enteredCharacteristics_PSU)
    {
        _characteristics_PSU = null;
        _stayPSU = false;
        _taskList._checkMarkPSU.SetActive(false);
    }
    #endregion

    #region MB
    public void AddStatusMB(Characteristics_MB _enteredCharacteristics_MB)
    {
        _characteristics_MB = _enteredCharacteristics_MB;
        _stayMB = true;
        _taskList._checkMarkMB.SetActive(true);

        CheckingTheSystemStatus();

    }

    public void DeteriorationOfStatusMB(Characteristics_MB _enteredCharacteristics_MB)
    {
        _characteristics_MB = null;
        _stayMB = false;
        _taskList._checkMarkMB.SetActive(false);

        CheckingTheSystemStatus();

    }
    #endregion

    #region Case

    public void AddStatusCase()
    {
        _stayCase = true;
        _taskList._checkMarkCase.SetActive(true);
    }

    public void DeteriorationCase()
    {   
        _stayCase = false;
        _taskList._checkMarkCase.SetActive(false);
    }

    #endregion

    #region PowerConnectingGPU
    public void AddPowerConnectingGPU()
    {
        _numberPowerConnectingGPU++;
        if (_characteristics_GPU != null)
        {
            if (_numberPowerConnectingGPU == _characteristics_GPU._GPUCountPowerConnecting)
            {
                _stayPowerGPU = true;
            }
            else
            {
                _stayPowerGPU = false;
            }
        }
    }

    public void DeteriorationPowerConnectingGPU ()
    {
        _numberPowerConnectingGPU--;
        _stayPowerGPU = false;
    }
    #endregion

    #region PowerConnectingCPU
    public void AddPowerConnectingCPU()
    {
        _stayPowerCPU = true;
    }

    public void DeteriorationPowerConnectingCPU()
    {
        _stayPowerCPU = true;
    }
    #endregion

    #region PowerConnectingROM
    public void AddPowerConnectingROM()
    {
        _countPowerROM++;
        _stayPowerROM = true;
    }
    public void DeteriorationPowerConnectingROM()
    {
        _countPowerROM--;
        if (_countPowerROM <=0)
        {
            _stayPowerROM = false;
        }
    }
    #endregion

    #region PowerConnectingMB
    public void AddPowerConnectingMB()
    {
        _stayPowerMB = true;
    }

    public void DeteriorationPowerConnectingMB()
    {
        _stayPowerMB = false;
    }
    #endregion

    public void CheckingTheSystemStatus ()
    {
        Debug.Log("CheckingTheSystemStatus");
        
        if (_stayCPU & _stayCullerCPU & _stayGPU & _stayMB & _stayPSU & _stayRAM & _stayROM /*& _stayPowerGPU & _stayPowerCPU & _stayPowerROM & _stayPowerMB*/)
        {

            _systemStatus = true;
        }
        else
        {
            _systemStatus = false;
        }
    }

    public void EvaluatingComponentPerformance ()
    {
        #region testRAM
        Characteristics_RAM _characteristics_RAM_1 = _listGameObjectRAM[0].GetComponent<Characteristics_RAM>();

        //int _RAMFrequency1 = _listCharactristicsRAM[0]._RAM_frequency;
        //int _RAMFrequency2 = _listCharactristicsRAM[1]._RAM_frequency;

        //_performanceRAM = _listCharactristicsRAM[0].PerfomanceRAM() + 0.25 * _listCharactristicsRAM[1].PerfomanceRAM();

        if (_listGameObjectRAM.Count > 1)
        {
            Debug.Log("RAM 101");
            int i = 0, i1 = 1;

            _performanceRAM = (1 * _listCharactristicsRAM[i].Cl * 100000 / (_listCharactristicsRAM[i]._RAM_frequency / 2)) + (0.25 * (1  * _listCharactristicsRAM[i1].Cl * 100000 / (_listCharactristicsRAM[i1]._RAM_frequency / 2)));
            
        }
        else
        {
            Debug.Log("RAM 202");

            _performanceRAM = 1  * _listCharactristicsRAM[0].Cl * 100000 / (_listCharactristicsRAM[0]._RAM_frequency / 2);
        }
        Debug.Log($"PerfomaceRAM = {_performanceRAM}/n _listCharRAM[0]._ram_Frequency = {_listCharactristicsRAM[0]._RAM_frequency} /n {_listCharactristicsRAM[0].Cl}");

        #endregion

        #region testCPU
        float _measurementError = Random.Range(0.23f, 0.27f);
        if (_characteristics_CPU._hiperThreading)
        {
            _performanceCPU = (/*Производительность без турбо буста*/(_characteristics_CPU._CPU_frequency * _characteristics_CPU._CPU_number_of_cores) + (_measurementError * _characteristics_CPU._CPU_frequency * _characteristics_CPU._CPU_number_of_cores)
                                    /*Производительность в турбобусте*/+ (_characteristics_CPU._CPU_frequency_TB * _characteristics_CPU._CPU_number_of_cores) + (_measurementError * _characteristics_CPU._CPU_frequency_TB * _characteristics_CPU._CPU_number_of_cores)) / 2;
        }
        else
        {

            _performanceCPU = (/*Производительность без турбо буста*/(_characteristics_CPU._CPU_frequency * _characteristics_CPU._CPU_number_of_cores) + (_measurementError * _characteristics_CPU._CPU_frequency * _characteristics_CPU._CPU_number_of_cores));
        }

        #endregion

        #region testROM
        float _currentPerfomance;
        _performanceROM = 0;
        for ( int i = 0; i < _listCharactristicsROM.Count; i++)
        {
            _currentPerfomance = (_listCharactristicsROM[i]._ROM_speed_read * _listCharactristicsROM[i]._ROM_speed_write) / 200;
            if (_currentPerfomance > _performanceROM)
            {
                _performanceROM = _currentPerfomance;
            }
        }

        #endregion

        #region testGPU

        _performanceGPU = (((_characteristics_GPU._GPU_frequency * _characteristics_GPU._GPU_Number_Universal_Core) + (_characteristics_GPU._GPU_frequency_TB * _characteristics_GPU._GPU_Number_Universal_Core)) / 2000);

        #endregion

        _perfomanceSystem = _performanceCPU + _performanceGPU + _performanceRAM + _performanceROM;
    }
}
