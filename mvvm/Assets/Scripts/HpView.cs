using UnityEngine;
using UnityEngine.UI;

public class HpView : MonoBehaviour
{
    [SerializeField] private Text _text;
    private IHpViewModel _hpViewModel;
    public void Initialize(IHpViewModel hpViewModel)
    {
        _hpViewModel = hpViewModel;
        _hpViewModel.OnHpChange += OnHpChange;
        OnHpChange(_hpViewModel.HpModel.CurrentHp);
    }
    private void OnHpChange(float currentHp)
    {
        _text.text = _hpViewModel.IsDead ? "�� �������(" :
        currentHp.ToString();
    }
    ~HpView()
    {
        _hpViewModel.OnHpChange -= OnHpChange;
    }
}
