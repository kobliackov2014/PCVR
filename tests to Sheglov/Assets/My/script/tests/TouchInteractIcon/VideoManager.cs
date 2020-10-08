using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    VideoPlayer _videoPlayer;
    public GameObject _desktop;

    private void OnEnable()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += OnVideoEnd;
        _desktop.SetActive(false);
    }

    private void OnDisable()
    {
        _videoPlayer.loopPointReached -= OnVideoEnd;

    }

    void OnVideoEnd (VideoPlayer causedVideoPlayer)
    {
        _desktop.SetActive(true);
        //Debug.Log("1");

        _videoPlayer.Stop();
    }
}
