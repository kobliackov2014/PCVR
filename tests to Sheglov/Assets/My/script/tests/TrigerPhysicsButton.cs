using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class TrigerPhysicsButton : MonoBehaviour
{
    public GameObject _physicsPusher;
    //public AudioSource _audioSourceButtonUp;
    //public AudioSource _audioSourceButtonDown;
    AudioSource _audioSource;
    public AudioClip _buttonUp;
    public AudioClip _buttonDown;
    public GameObject _video_On_Load_System;
    public GameObject _desctop;
    public GameObject _benchmark_Video;
    bool _stay = true;
    [SerializeField]
    ChecTrigerManager _checTrigerManager;


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

            _checTrigerManager.CheckingTheSystemStatus();
            

            if (_stay)
            {
                if (_checTrigerManager._systemStatus == true)
                {
                    _video_On_Load_System.SetActive(true);
                }
            }
            else
            {
                _video_On_Load_System.SetActive(false);
                _desctop.SetActive(false);
                _benchmark_Video.SetActive(false);
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
}
