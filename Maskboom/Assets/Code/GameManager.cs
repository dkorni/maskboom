using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }
    }

    public float KillCoefficient
    {
        get { return _killCoefficient; }
        set
        {
            _killCoefficient = value;

            // notify all other subscribers that value is changed
            OnKillCoefficientChanged?.Invoke(value);
        }
    }

    public event Action<float> OnKillCoefficientChanged;

    private static GameManager _instance;

    private float _killCoefficient;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
