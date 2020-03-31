using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public Button butt1;
    public Button butt2;
    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Text dialogueText;
    public GameObject image;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    Unit playerUnit;
    Unit enemyUnit;

    void Start()
    {
        image.SetActive(false);
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "Watch out! " + enemyUnit.unitName + " approaches...";

        playerHUD.SetupHud(playerUnit);
        enemyHUD.SetupHud(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHp);
        dialogueText.text = "The attack is succesful!";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        butt1.interactable = false;
        butt2.interactable = false;
        StartCoroutine(PlayerAttack());
    }

    public void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You lost the war!";
            image.SetActive(true);
            StartCoroutine(WaitAfterLoss());
            Application.Quit();
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHp);

        yield return new WaitForSeconds(1f);
        butt1.interactable = true;
        butt2.interactable = true;
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        butt1.interactable = false;
        butt2.interactable = false;
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.currentHp += 15;
        playerHUD.Heal(15);
        dialogueText.text = "The heal is succesful!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator WaitAfterLoss()
    {
        yield return new WaitForSeconds(10f);
    }
}
