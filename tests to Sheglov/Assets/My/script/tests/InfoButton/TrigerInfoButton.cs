using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerInfoButton : MonoBehaviour
{
    public GameObject _physicsPusher;
    public AudioClip _buttonUp;
    public AudioClip _buttonDown;
    AudioSource _audioSource;
    public PolicyListInfoButton _policyListInfoButton;
    public GameObject _gameObjectInfoPanel;
    bool _stay = true;
    void Start()
    {
        //Fetch the AudioSource from the GameObject
        _audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == _physicsPusher.name)
        {
            _audioSource.PlayOneShot(_buttonUp);
            _stay = !_stay;

            if (_stay)
            {
                //if (_checTrigerManager._systemStatus == true)
                //{
                //    _video_On_Load_System.SetActive(true);
                //}
                Debug.Log("InfoPanel");
                _gameObjectInfoPanel.SetActive(true);
                for (int i = 0; i < _policyListInfoButton._objectList.Count; i ++)
                {
                    _policyListInfoButton._objectList[i].SetActive(false);
                }
            }
            else
            {
                _gameObjectInfoPanel.SetActive(false);
                //_video_On_Load_System.SetActive(false);
                //_desctop.SetActive(false);
                //_benchmark_Video.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == _physicsPusher.name)
        {
            _audioSource.PlayOneShot(_buttonDown);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
