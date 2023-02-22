using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private string _namePath;
    [SerializeField] private string _descriptionPath;

    public string NamePath => _namePath;
    public string DescriptionPath => _descriptionPath;
    public string Name => Lean.Localization.LeanLocalization.GetTranslationText(_namePath);
    public string Description => Lean.Localization.LeanLocalization.GetTranslationText(_descriptionPath);

    protected Fighter Fighter => GetComponent<Fighter>();

    protected Health Health => GetComponent<Health>();

    protected abstract void ActivateAbility();

    protected virtual void Test()
    {

    }

    public abstract void SetAbility(Recruit recruit, string namePath, string desriptionPath);

    protected void SetAbilitiesDescription(string name, string description)
    {
        _namePath = name;
        _descriptionPath = description;
    }
}
