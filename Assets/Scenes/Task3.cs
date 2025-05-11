using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    public float initialSpeed = 0f; // Начальная скорость по X

    public float A = 0f; // Начальная скорость по X

    public float B = 0f; // Начальная скорость по X
    //public float speed = 0f; // Скорость движения
    public float delayTime = 0f; // Время ожидания перед движением
    public float radius = 2f; // Радиус винтовой линии
    public TMP_InputField speedInput; //Поле ввода скорости

    public TMP_InputField AInput;

    public TMP_InputField BInput;
    public TMP_InputField timeInput; //Поле ввода времени
    public TMP_Text distanceText;

    private float distanceTraveled = 0f;
    private float timeElapsed = 0f;
    private Vector3 startPosition;
    private float startTime;
    private bool isMoving = false;

    void Start()
    {
        startTime = Time.time;
        startPosition = transform.position;
        if (speedInput != null)
        {
            speedInput.onEndEdit.AddListener(UpdateSpeed);
        }

        if (AInput != null)
        {
            AInput.onEndEdit.AddListener(UpdateA);
        }

        if (BInput != null)
        {
            BInput.onEndEdit.AddListener(UpdateB);
        }

        if (timeInput != null)
        {
            timeInput.onEndEdit.AddListener(UpdateTime);
        }
    }

    void Update()
    {
        float deltaTime = Time.time - startTime;
        if (delayTime <= deltaTime)
        {
            float accel = A + deltaTime * B;
            float angle = initialSpeed * deltaTime + deltaTime * deltaTime * accel * 0.5f; // Угол вращения
            float x = Mathf.Cos(angle) * radius;
            float y = initialSpeed * deltaTime + deltaTime * deltaTime * accel * 0.5f;
            float z = Mathf.Sin(angle) * radius;

            Vector3 newPosition = startPosition + new Vector3(x, y, z);
            //distanceTraveled += Vector3.Distance(transform.position, newPosition);
            distanceTraveled = 0.5f * deltaTime * (Mathf.Sqrt(3 * (initialSpeed * initialSpeed) + deltaTime * (3 * accel * initialSpeed) + deltaTime*deltaTime / 3 * (3 * accel * accel)));
            transform.position = newPosition;

            if (distanceText != null)
            {
                distanceText.text = "Пройденный путь: " + (distanceTraveled).ToString("F2") + " м";
                distanceText.text += "\nВремя: " + deltaTime.ToString("F2") + " с";
            }
        }

    }

    void UpdateSpeed(string input)
    {
        if (float.TryParse(input, out float newSpeed))
        {
            initialSpeed = newSpeed;
            startTime = Time.time;
            distanceTraveled = 0f;
            transform.position = startPosition;
        }
    }
    void UpdateA(string input)
    {
        if (float.TryParse(input, out float newA))
        {
            A = newA;
            startTime = Time.time;
            distanceTraveled = 0f;
            transform.position = startPosition;
        }
    }

    void UpdateB(string input)
    {
        if (float.TryParse(input, out float newB))
        {
            B = newB;
            startTime = Time.time;
            distanceTraveled = 0f;
            transform.position = startPosition;
        }
    }
    void UpdateTime(string input)
    {
        if (float.TryParse(input, out float newTime))
        {
            delayTime = newTime;
            startTime = Time.time;
            distanceTraveled = 0f;
            transform.position = startPosition;
        }
    }
}
