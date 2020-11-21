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
    private static extern void AddMetric([MarshalAs(UnmanagedType.LPStr)] string key, int length, float value);

    // edits a metric
    [DllImport(DLL_NAME)]
    private static extern void EditMetric([MarshalAs(UnmanagedType.LPStr)] string key, int length, float newValue);

    // removes a metric based on its key.
    [DllImport(DLL_NAME)]
    private static extern void RemoveMetric([MarshalAs(UnmanagedType.LPStr)] string key, int length);

    // returns a metric based on the provided key
    [DllImport(DLL_NAME)]
    private static extern float GetMetric([MarshalAs(UnmanagedType.LPStr)] string key, int length);

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
    private static extern void SetFile([MarshalAs(UnmanagedType.LPStr)] string key, int length);

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

    // 

    // Start is called before the first frame update
    void Start()
    {
        string file = "Assets/Saves/test.txt";

        SetFile(file, 8);
        bool x = (ImportMetrics() == 0) ? false : true;

        // AddMetric("A", 1, 19.5F);
        // AddMetric("B", 1, -23.2F);
        // AddMetric("C", 1, 50.0F);

        int count = GetMetricCount();

        Debug.Log("Count: " + count);
        Debug.Log("A: " + GetMetric("A", 1));
        Debug.Log("B: " + GetMetric("B", 1));
        Debug.Log("C: " + GetMetric("C", 1));

        // SetFile(file, 8);
        // bool x = (ExportMetrics() == 0) ? false : true;
        Debug.Log("Success: " + x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
