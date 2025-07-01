using UnityEngine;

public class AirdropController : MonoBehaviour
{
    [Header("Prefabs a instanciar")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject weaponPrefab;

    [Header("Spawn settings")]
    [SerializeField] Transform spawnPoint;          
    [SerializeField] float yOffset = 0.2f;         

    [Header("Score")]
    //[SerializeField] ScoreManager scoreManager;     
    [SerializeField] int scoreReward = 500;

    bool enemySpawned = false;
    bool weaponSpawned = false;
    bool scoreGiven = false;

    public void OnEnemyButton()
    {
        if (enemySpawned) return;
        enemySpawned = true;
        Spawn(enemyPrefab);
    }

    public void OnWeaponButton()
    {
        if (weaponSpawned) return;
        weaponSpawned = true;
        Spawn(weaponPrefab);
    }

    //public void OnScoreButton()
    //{
    //    if (scoreGiven) return;
    //    scoreGiven = true;

    //   // var sm = scoreManager != null ? scoreManager : ScoreManager.Instance;
    //    if (sm != null)
    //        sm.AddScore(scoreReward);     // tu método existente
    //}
    void Spawn(GameObject prefab)
    {
        if (prefab == null) return;

        Vector3 pos = (spawnPoint ? spawnPoint.position : transform.position) +
                      Vector3.up * yOffset;

        Instantiate(prefab, pos, Quaternion.identity);
    }
}
