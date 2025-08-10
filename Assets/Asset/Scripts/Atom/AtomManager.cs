using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using System.Collections; // 코루틴용 IEnumerator
using System.Collections.Generic; // List, Dictionary 등

public class AtomManager : MonoBehaviour
{
    public int availableElectrons = 4;
    public List<XRSocketInteractor> electronSockets;
    public Collider atomCollider;
    public Transform core;
    public GameObject clearMessageUI;

    [Header("Atom Info")]
    public string atomName;
    public TextMeshPro label;

    [HideInInspector] public AtomManager root;
    [HideInInspector] public List<AtomManager> bondedAtoms = new();

    void Awake()
    {
        if (label == null)
            label = GetComponentInChildren<TextMeshPro>();

        if (label != null)
        {
            atomName = label.text.Trim();
        }

        root = this;

        //
        // Panel 자동 연결 (씬에서 이름이 "Panel"인 오브젝트 찾아서 연결)
        if (clearMessageUI == null)
        {
            clearMessageUI = GameObject.Find("ClearMessagePanel");
        }
        //
    }

    public void ConsumeElectrons(int amount)
    {
        availableElectrons = Mathf.Max(0, availableElectrons - amount);

        if (availableElectrons == 0)
            DisableElectronSockets();
    }

    void DisableElectronSockets()
    {
        foreach (var socket in electronSockets)
            socket.socketActive = false;
    }

    public XRSocketInteractor GetAvailableSocket()
    {
        return electronSockets.FirstOrDefault(s => !s.hasSelection);
    }

    public Vector3 GetBondDirection(XRSocketInteractor socket)
    {
        return (socket.attachTransform.position - core.position).normalized;
    }

    public void AddBondedAtom(AtomManager other)
    {
        if (bondedAtoms.Contains(other)) return;

        bondedAtoms.Add(other);
        other.root = this.root;
        MergeBondGraph(other);
        root.UpdateFormulaFromRoot();

        if (other.label != null)
            other.label.gameObject.SetActive(false);

        if (SoundManager.Instance != null)
            SoundManager.Instance.PlayBondSound();
    }

    void MergeBondGraph(AtomManager other)
    {
        foreach (var node in other.GetAllConnectedAtoms())
        {
            if (node != this && !root.GetAllConnectedAtoms().Contains(node))
            {
                root.bondedAtoms.Add(node);
                node.root = root;
            }
        }
    }

    public List<AtomManager> GetAllConnectedAtoms(HashSet<AtomManager> visited = null)
    {
        if (visited == null)
            visited = new HashSet<AtomManager>();

        visited.Add(this);

        foreach (var bonded in bondedAtoms)
        {
            if (!visited.Contains(bonded))
                bonded.GetAllConnectedAtoms(visited);
        }

        return visited.ToList();
    }

    public void UpdateFormulaFromRoot()
    {
        var allAtoms = root.GetAllConnectedAtoms();
        

        List<string> expanded = new();
        foreach (var atom in allAtoms)
            expanded.AddRange(Expand(atom.atomName));

        var counts = expanded
            .GroupBy(x => x)
            .OrderBy(g => g.Key == "C" ? 0 : 1)
            .ThenBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Count());

        string formula = "";
        foreach (var kv in counts)
        {
            formula += kv.Key;
            if (kv.Value > 1)
                formula += kv.Value;
        }

        foreach (var atom in allAtoms)
        {
            if (atom.label != null)
            {
                if (atom == root)
                    atom.label.text = formula;
                else
                    atom.label.gameObject.SetActive(false);
            }
        }

        //
        // 정답과 비교하고 Clear 표시
        if (formula == GameStateManager.EnteredDoorLabel)
        {
            Debug.Log("정답입니다: " + formula);
            
            //
            GameStateManager.clearedLabels.Add(formula);
            //

            ShowClearMessage(); // ← 이 함수 따로 만들자
        }
        //
    }

    void ShowClearMessage()
    {
        if (clearMessageUI != null)
        {
            clearMessageUI.SetActive(true);
            StartCoroutine(HideClearMessageAfterDelay(5f)); // 5초 뒤에 숨김
        }
            //clearMessageUI.SetActive(true);

        // SoundManager를 통해 사운드 재생
        if (SoundManager.Instance != null)
            SoundManager.Instance.PlayClearSound();
    }

    private IEnumerator HideClearMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (clearMessageUI != null)
            clearMessageUI.SetActive(false);
    }

    List<string> Expand(string name)
    {
        List<string> result = new();
        string current = "";

        for (int i = 0; i < name.Length; i++)
        {
            char c = name[i];

            if (char.IsLetter(c))
            {
                if (!string.IsNullOrEmpty(current))
                    result.Add(current);

                current = c.ToString();
            }
            else if (char.IsDigit(c))
            {
                int count = (int)char.GetNumericValue(c);
                result.AddRange(Enumerable.Repeat(current, count));
                current = "";
            }
        }

        if (!string.IsNullOrEmpty(current))
            result.Add(current);

        return result;
    }
}
