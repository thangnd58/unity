using Assets.Scripts.Test2;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    string path;

    List<BallObject> listSave = new List<BallObject>();
    List<BallObject> listLoad = new List<BallObject>();
    [SerializeField]
    public GameObject generatorPrefab;

    public UnityEngine.UI.Button saveBtn;

    public UnityEngine.UI.Button loadBtn;

    private void Start()
    {
        path = Application.dataPath + "/save.json";
        saveBtn.interactable = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scence6");
        GeneratorScript.listSaveLoad.Clear();
        listLoad.Clear();
        listSave.Clear();
    }


    private void Update()
    {
        if(GeneratorScript.listSaveLoad.Count > 0)
        {
            saveBtn.interactable = true;
        } else
        {
            saveBtn.interactable = false;
        }
    }

    public void SaveGame()
    {
        loadBtn.interactable = false;

        Dictionary<int, GameObject> list = GeneratorScript.listSaveLoad;

        foreach (GameObject a in list.Values)
        {
            if (!CheckInstanceExist(a))
            {
                BallObject b = new BallObject();
                b.instanceId = a.GetInstanceID();
                b.x = a.transform.position.x;
                b.y = a.transform.position.y;
                b.z = a.transform.position.z;
                b.health = ((int)a.transform.localScale.x);
                listSave.Add(b);
            }
        }
        string json = JsonConvert.SerializeObject(listSave);
        File.WriteAllText(path, json);
        Debug.Log(json);
    }

    public void LoadGame()
    {
        listSave.Clear();
        string jsonData = File.ReadAllText(path);
        listLoad = JsonConvert.DeserializeObject<List<BallObject>>(jsonData);

        foreach (BallObject b in listLoad)
        {
            generatorPrefab.transform.position = new Vector3(b.x, b.y, b.z);
            float scale = (float)b.health;
            generatorPrefab.transform.localScale = new Vector3(scale, scale, 1);
            // Create a new instance of the generatorPrefab GameObject
            GameObject o = Instantiate<GameObject>(generatorPrefab, generatorPrefab.transform.position, Quaternion.identity);
            o.GetInstanceID();
            GeneratorScript.listSaveLoad.Add(o.GetInstanceID(), o);
        }
        listLoad.Clear();
    }

    public bool CheckInstanceExist(GameObject a)
    {
        bool exist = false;
        foreach (BallObject bll in listSave)
        {
            if (a.GetInstanceID() == bll.instanceId)
            {
                exist = true;
                bll.health = ((int)a.transform.localScale.x);
            }
        }
        return exist;
    }
}
