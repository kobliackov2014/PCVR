using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekTrigerZone : MonoBehaviour
{
    public ChecTrigerManager _checTrigerManager;

    public List<GameObject> _listOobjectsToThePoint = new List<GameObject>();
    public GameObject _gameObject;

    private Characteristics_CPU _characteristics_CPU;
    private Characteristics_Culler_CPU _characteristics_Culler_CPU;
    private Characteristics_GPU _characteristics_GPU;
    private Characteristics_PSU _characteristics_PSU;
    private Characteristics_RAM _characteristics_RAM;
    private Characteristics_ROM _characteristics_ROM;
    private Characteristics_MB _characteristics_MB;

    /*ChecingPowerSupplyConnection*/
    //bool _connectingGPUToAPSU;
    [SerializeField]
    private string _tagConnectorGPU = "";
    [SerializeField]
    private string _tagConnectorCPU = "";
    [SerializeField]
    private string _tagConnectorROM = "";
    [SerializeField]
    private string _tagConnectorMB = "";
    [SerializeField]
    private string _tagCase = "";



    private GameObject _exitObject;


    private void OnTriggerEnter(Collider other)
    {

        if (_gameObject.name == other.name)
        {
            if (other.GetComponent<Characteristics_RAM>())
            {
                _characteristics_RAM = other.GetComponent<Characteristics_RAM>();
                _exitObject = other.gameObject;

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.AddStatusRAM(_characteristics_RAM, _exitObject);
                

                Debug.Log($"{_exitObject.name}");
                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(false);
                }
            }
            else if (other.GetComponent<Characteristics_ROM>())
            {
                _characteristics_ROM = other.GetComponent<Characteristics_ROM>();
                _exitObject = other.gameObject;

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.AddStatusROM(_characteristics_ROM, _exitObject);

                if(_characteristics_ROM._ROMCountPowerConnecting == 0)
                {
                    _checTrigerManager.AddPowerConnectingROM();
                }

                //Debug.Log("101");
                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(false);
                }
            }
            else if (other.GetComponent<Characteristics_CPU>())
            {
                _characteristics_CPU = other.GetComponent<Characteristics_CPU>();

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.AddStatusCPU(_characteristics_CPU);

                //Debug.Log("101");
                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(false);
                }
            }
            else if (other.GetComponent<Characteristics_Culler_CPU>())
            {
                _characteristics_Culler_CPU = other.GetComponent<Characteristics_Culler_CPU>();

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.AddStatusCullerCPU(_characteristics_Culler_CPU);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(false);
                }
            }
            else if (other.GetComponent<Characteristics_GPU>())
            {
                _characteristics_GPU = other.GetComponent<Characteristics_GPU>();

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.AddStatusGPU(_characteristics_GPU);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(false);
                }
            }
            else if (other.GetComponent<Characteristics_PSU>())
            {
                _characteristics_PSU = other.GetComponent<Characteristics_PSU>();

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.AddStatusPSU(_characteristics_PSU);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(false);
                }
            }
            else if (other.GetComponent<Characteristics_MB>())
            {
                _characteristics_MB = other.GetComponent<Characteristics_MB>();
                //передача характеристик в менеджер тригер зон
                _checTrigerManager.AddStatusMB(_characteristics_MB);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(false);
                }
            }
            else if ( other.tag == _tagConnectorGPU)
            {
                Debug.Log("AddPowerConnectingGPU");
                _checTrigerManager.AddPowerConnectingGPU();
            }
            else if (other.tag == _tagConnectorCPU)
            {
                Debug.Log("AddPowerConnectingCPU");

                _checTrigerManager.AddPowerConnectingCPU();
            }
            else if (other.tag == _tagConnectorROM)
            {
                _checTrigerManager.AddPowerConnectingROM();
            }
            else if (other.tag == _tagConnectorMB)
            {
                Debug.Log("AddPowerConnectingMB");

                _checTrigerManager.AddPowerConnectingMB();
            }
            else if (other.tag == _tagCase)
            {
                Debug.Log("AddCase");

                _checTrigerManager.AddStatusCase();
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (_gameObject.name == other.name)
        {
            if (other.GetComponent<Characteristics_RAM>())
            {
                _characteristics_RAM = other.GetComponent<Characteristics_RAM>();

                _exitObject = other.gameObject;

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.DeteriorationOfStatusRAM(_exitObject);

                //Debug.Log("202");
                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(true);
                }
            }
            else if (other.GetComponent<Characteristics_ROM>())
            {
                _characteristics_ROM = other.GetComponent<Characteristics_ROM>();

                _exitObject = other.gameObject;

                if (_characteristics_ROM._ROMCountPowerConnecting == 0)
                {
                    _checTrigerManager.DeteriorationPowerConnectingROM();
                }

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.DeteriorationOfStatusROM(_exitObject);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(true);
                }
            }
            else if (other.GetComponent<Characteristics_CPU>())
            {
                _characteristics_CPU = other.GetComponent<Characteristics_CPU>();

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.DeteriorationOfStatusCPU(_characteristics_CPU);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(true);
                }
            }
            else if (other.GetComponent<Characteristics_Culler_CPU>())
            {
                _characteristics_Culler_CPU = other.GetComponent<Characteristics_Culler_CPU>();

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.DeteriorationOfStatusCullerCPU(_characteristics_Culler_CPU);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(true);
                }
            }
            else if (other.GetComponent<Characteristics_GPU>())
            {
                _characteristics_GPU = other.GetComponent<Characteristics_GPU>();

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.DeteriorationOfStatusGPU(_characteristics_GPU);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(true);
                }
            }
            else if (other.GetComponent<Characteristics_PSU>())
            {
                _characteristics_PSU = other.GetComponent<Characteristics_PSU>();

                //передача характеристик в менеджер тригер зон
                _checTrigerManager.DeteriorationOfStatusPSU(_characteristics_PSU);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(true);
                }
            }
            else if (other.GetComponent<Characteristics_MB>())
            {
                _characteristics_MB = other.GetComponent<Characteristics_MB>();
                //передача характеристик в менеджер тригер зон
                _checTrigerManager.DeteriorationOfStatusMB(_characteristics_MB);

                for (int i = 0; i < _listOobjectsToThePoint.Count; i++)
                {
                    _listOobjectsToThePoint[i].SetActive(true);
                }
            }
            else if(other.tag == _tagConnectorGPU)
            {
                _checTrigerManager.DeteriorationPowerConnectingGPU();
            }
            else if (other.tag == _tagConnectorCPU)
            {
                _checTrigerManager.DeteriorationPowerConnectingCPU();
            }
            else if (other.tag == _tagConnectorROM)
            {
                _checTrigerManager.DeteriorationPowerConnectingROM();
            }
            else if (other.tag == _tagConnectorMB)
            {
                _checTrigerManager.DeteriorationPowerConnectingMB();
            }
            else if (other.tag == _tagCase)
            {
                _checTrigerManager.DeteriorationCase();
            }
        }
    }
}
