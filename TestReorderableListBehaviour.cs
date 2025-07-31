using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringListWrapper
{
    public List<string> strings = new List<string>();
}

public class TestReorderableListBehaviour : MonoBehaviour
{
    public StringListWrapper testStrings;
}