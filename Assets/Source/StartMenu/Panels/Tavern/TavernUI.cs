using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernUI : RenderUI
{
    [SerializeField] private List<GameObject> _characters;
    [SerializeField] private List<HeroNamesCreater> _heroNamesCreater;
    [SerializeField] private List<HeroStatsCreater> _heroStatsCreater;
    [SerializeField] private List<HeroAppearanceCreater> _heroAppearanceCreater;

    private void Start()
    {
        AddGraphics();
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            AddButton(i);
        }
    }

    private void AddButton(int id)
    {
        GameObject newSaler = Instantiate(Ñontainer, Content.transform) as GameObject;
        newSaler.name = (Content.transform.childCount - 1).ToString();
        CharacterStats characterStats = newSaler.GetComponentInChildren<TavernCharactersUI>().ShowCharacter(_characters[id], _heroAppearanceCreater[id]);
        _heroStatsCreater[id].CreateStats(characterStats);
        _heroNamesCreater[id].SetName(characterStats);
        StatsUI statsUI = newSaler.GetComponentInChildren<StatsUI>();
        statsUI.UpdateName(characterStats.Name);
        statsUI.UpdateAllStats(characterStats.Attack, characterStats.Defense, characterStats.Health, characterStats.Magic);
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AddGraphics();
    }
}
