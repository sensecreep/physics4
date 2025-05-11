using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    public float initialSpeed = 0f; // Начальная скорость
    //public float speed = 0f; // Скорость движения
    public float delayTime = 0f; // Время ожидания перед движением
    public float radius = 2f; // Радиус винтовой линии
    public TMP_InputField speedInput; //Поле ввода скорости
    public TMP_InputField timeInput; //Поле ввода времени
    public TMP_Text distanceText;

    private float distanceTraveled = 0f;
    private float timeElapsed = 0f;
    private Vector3 startPosition;
    private float startTime;
    private bool isMoving = false;

    float time = 0f;

    void Start()
    {
        startTime = Time.time;
        startPosition = transform.position;
        if (speedInput != null)
        {
            speedInput.onEndEdit.AddListener(UpdateSpeed);
        }
        if (timeInput != null)
        {
            timeInput.onEndEdit.AddListener(UpdateTime);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (delayTime <= time)
        {
            float deltaTime = Time.time - startTime - delayTime;
            float angle = deltaTime * initialSpeed; // Угол вращения
            float x = Mathf.Cos(angle) * radius;
            float y = deltaTime * initialSpeed;
            float z = Mathf.Sin(angle) * radius;

            Vector3 newPosition = startPosition + new Vector3(x, y, z);
            //distanceTraveled += Vector3.Distance(transform.position, newPosition);
            distanceTraveled = deltaTime * (Mathf.Sqrt(3 * (initialSpeed * initialSpeed)));
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
            time = 0f;
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
            time = 0f;
        }
    }
}
