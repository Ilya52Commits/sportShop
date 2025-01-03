using System;
using System.Windows.Input;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

namespace sportShop.MVVM.RelayCommands;

/// <summary>
/// Реализация класса команд
/// </summary>
public class RelayCommand(Action action) : ICommand
{
  public Action Action { get; set; } = action;

  public void Execute(object parameter) => Action?.Invoke();

  public bool CanExecute(object parameter) => IsEnabled;

  private bool _isEnabled = true;

  public bool IsEnabled
  {
    get => _isEnabled;
    set
    {
      _isEnabled = value;
      CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
  }

  public event EventHandler CanExecuteChanged;
}

/// <summary>
/// Реализация обобщённого класса команд 
/// </summary>
/// <param name="action"></param>
/// <typeparam name="T"></typeparam>
public class RelayCommand<T>(Action<T> action) : ICommand
{
  public Action<T> Action { get; set; } = action;

  public void Execute(object parameter)
  {
    if (Action != null && parameter is T parameter1)
      Action(parameter1);
  }

  public bool CanExecute(object parameter) => IsEnabled;

  private bool _isEnabled = true;

  public bool IsEnabled
  {
    get => _isEnabled;
    set
    {
      _isEnabled = value;
      CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
  }

  public event EventHandler CanExecuteChanged;
}