using UnityEngine;
using System.Collections.Generic;

public static class GameStateManager
{
    public static string EnteredDoorLabel = "";

    // 클리어한 원소 이름(문 Label)을 저장할 집합
    public static HashSet<string> clearedLabels = new();
}
