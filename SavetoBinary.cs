using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SavetoBinary : MonoBehaviour
{
    public SaveData data;
    string DatafilePath;
    BinaryFormatter bf;
    public Text Point;
    public Text Coin;
    public Text Socre;

    private void Awake()
    {
        bf = new BinaryFormatter();
        DatafilePath = Application.persistentDataPath + "/game.dat"; // auto serach data file
        Debug.Log(DatafilePath);
    }

    public void SaveData1()
    {
        FileStream fs = new FileStream(DatafilePath,FileMode.Create); // สร้างไฟล์
        bf.Serialize(fs, data); // แปลงฐาน 10 เป็น ฐาน 2
        fs.Close(); // ปิดข้อมูล fs
    }
    public void Loaddata()
    {
        if (File.Exists(DatafilePath)) // ตรวจสอบว่ามีไฟล์อยู่รึป่าว
        {
            FileStream fs = new FileStream(DatafilePath, FileMode.Open); // เปิดไฟล์
            data = (SaveData)bf.Deserialize(fs); // คืนค่า binary (SaveData) = หลอกว่าเป็นไฟล์เดียวกัน
            fs.Close();
            Debug.Log("Number of coin = " + data.pointCount);
            Debug.Log("Number of coin = " + data.coinCount);
            Point.text = data.pointCount.ToString();
            Coin.text = data.coinCount.ToString();
            Socre.text = data.coinCount.ToString();

        }
    }

    private void OnEnable() //ตอนเปิด
    {
        Debug.Log("Data Loaded");
        Loaddata();
    }
    private void OnDisable() // ตอนปิด
    {
        Debug.Log("Date Saved");
        SaveData1();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdatePoint();
        }
        UpdateCoin();
        UpdateScore();


    }
    public void UpdatePoint()
    {
        data.pointCount += 1;
        Point.text = data.pointCount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            print("A");
            data.coinCount += 1;
            Destroy(other.gameObject);
        }
    }
    public void UpdateCoin()
    {
        Coin.text = data.coinCount.ToString();
    }
    public void UpdateScore()
    {
            data.HighScore1 += Time.deltaTime * 25f;
            Socre.text = ((int)data.HighScore1).ToString("000000");
    }
}
