using System.Collections.Generic;
using UnityEngine;

public class AirdropMaterialController : MonoBehaviour
{
    /* ---------- ARMA ---------- */
    [Header("Arma")]
    [SerializeField] Renderer weaponRenderer;         
    [SerializeField] List<Material> weaponMats = new(); 

    /* ---------- ENEMIGOS ---------- */
    [Header("Enemigos")]
    [SerializeField] string enemyTag = "Enemy";         
    [SerializeField] List<Material> enemyMats = new();  

    /* ---------- CARPAS ---------- */
    [Header("Carpas")]
    [SerializeField] string tentTag = "Tent";           
    [SerializeField] List<Material> tentMats = new();   

    /* ---------- Índices para ciclar ---------- */
    int weaponIdx, enemyIdx, tentIdx;

    /* ---------- BOTONES ---------- */
    public void OnWeaponMatButton()
    {
        if (weaponRenderer == null || weaponMats.Count == 0) return;

        weaponRenderer.material = weaponMats[weaponIdx];
        weaponIdx = (weaponIdx + 1) % weaponMats.Count;
    }

    public void OnEnemiesMatButton()
    {
        if (enemyMats.Count == 0) return;

        foreach (Renderer r in GetRenderersByTag(enemyTag))
            r.material = enemyMats[enemyIdx];

        enemyIdx = (enemyIdx + 1) % enemyMats.Count;
    }

    public void OnTentsMatButton()
    {
        if (tentMats.Count == 0) return;

        foreach (Renderer r in GetRenderersByTag(tentTag))
            r.material = tentMats[tentIdx];

        tentIdx = (tentIdx + 1) % tentMats.Count;
    }

    /* ---------- Helper ---------- */
    IEnumerable<Renderer> GetRenderersByTag(string tag)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(tag))
            foreach (Renderer r in go.GetComponentsInChildren<Renderer>())
                yield return r;
    }
}
