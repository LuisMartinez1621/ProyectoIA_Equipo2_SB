﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Level1TargetScript : MonoBehaviour, ITrackableEventHandler
{
    // Canasta
    public GameObject basket;

    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            basket.SetActive(true);
        }
    }
}
