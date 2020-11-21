using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MetricsLogger : MonoBehaviour
{
    // the DLL
    private const string DLL_NAME = "GED-ASN02-DLL";

    // adds the metric using a key (of length 'length'), and sets to the provided value.
    // [DllImport(DLL_NAME, EntryPoint = "AddMetric")]
    // private static extern void AddMetric(char* key, int length, float value);

    // adds the metric
    [DllImport(DLL_NAME)]
    private static extern void AddMetric([MarshalAs(UnmanagedType.LPStr)] string key, float value);

    // edits a metric
    [DllImport(DLL_NAME)]
    private static extern void EditMetric([MarshalAs(UnmanagedType.LPStr)] string key, float newValue);

    // removes a metric based on its key.
    [DllImport(DLL_NAME)]
    private static extern void RemoveMetric([MarshalAs(UnmanagedType.LPStr)] string key);

    // returns a metric based on the provided key
    [DllImport(DLL_NAME)]
    private static extern float GetMetric([MarshalAs(UnmanagedType.LPStr)] string key);

    // metric count
    [DllImport(DLL_NAME)]
    private static extern int GetMetricCount();

    // checks to see if the metrics list is empty
    [DllImport(DLL_NAME)]
    private static extern int IsEmpty();

    // clears out all metrics
    [DllImport(DLL_NAME)]
    private static extern void Clear();

    // sets the file
    [DllImport(DLL_NAME)]
    private static extern void SetFile([MarshalAs(UnmanagedType.LPStr)] string key);

    // gets the file
    [DllImport(DLL_NAME, EntryPoint = "GetFile")]
    private static extern System.IntPtr GetFile();

    // gets the file name length
    [DllImport(DLL_NAME)]
    private static extern int GetFileNameLength();

    // import metrics (returns bool)
    [DllImport(DLL_NAME)]
    private static extern int ImportMetrics();

    // export metrics (returns bool)
    [DllImport(DLL_NAME)]
    private static extern int ExportMetrics();

    
    // adds a metric to logger
    public void AddMetricToLogger(string key, float value)
    {
        AddMetric(key, value);
    }

    // edits a metric
    public void EditMetricFromLogger(string key, float newValue)
    {
        EditMetric(key, newValue);
    }

    // removes a metric
    public void RemoveMetricFromLogger(string key)
    {
        RemoveMetric(key);
    }

    // gets the metric from the logger.
    public float GetMetricFromLogger(string key)
    {
        return GetMetric(key);
    }

    // gets the number of metrics
    public int GetNumberOfMetrics()
    {
        return GetMetricCount();
    }

    // checks to see if the logger is empty
    public bool LoggerIsEmpty()
    {
        return (IsEmpty() == 0) ? false : true;
    }

    // clears the logger
    public void ClearLogger()
    {
        Clear();
    }

    // sets the file
    public void SetLoggerFile(string file)
    {
        SetFile(file);
    }

    // returns the file name and path
    public string GetLoggerFile()
    {
        return Marshal.PtrToStringAnsi(GetFile());
    }

    // returns the name length of the logger.
    public int GetLoggerFileNameLength()
    {
        return GetFileNameLength();
    }

    // import metrics
    public bool LoadMetrics()
    {
        return (ImportMetrics() == 0) ? false : true;
    }

    // saves metrics
    public bool SaveMetrics()
    {
        return (ExportMetrics() == 0) ? false : true;
    }

    // Start is called before the first frame update
    void Start()
    {
        // string file = "Assets/Saves/test.txt";
        // 
        // SetFile(file);
        // bool check = false;
        // check = (ImportMetrics() == 0) ? false : true;
        // 
        // string getfile = GetLoggerFile();
        // 
        // if (getfile == file)
        //     Debug.Log(getfile + " saved successfully");
        // 
        // // AddMetric("A", 19.5F);
        // // AddMetric("B", -23.2F);
        // // AddMetric("C", 50.0F);
        // // AddMetric("D", -102.0F);
        // // AddMetric("E A", 10.5F);
        // 
        // int count = GetMetricCount();
        // 
        // Debug.Log("Count: " + count);
        // Debug.Log("A: " + GetMetric("A"));
        // Debug.Log("B: " + GetMetric("B"));
        // Debug.Log("C: " + GetMetric("C"));
        // Debug.Log("D: " + GetMetric("D"));
        // Debug.Log("E A: " + GetMetric("E A"));
        // 
        // // check = (ExportMetrics() == 0) ? false : true;
        // Debug.Log("Success: " + check);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
