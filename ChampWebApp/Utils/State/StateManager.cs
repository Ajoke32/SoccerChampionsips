using System.Reflection;


namespace ChampWebApp.Utils;

public class StateManager
{

    private Dictionary<Type, StateContainerBase?> _states = new();

    public void AddState<T>() where T:StateContainerBase
    {
        var type = typeof(T);
        var pramsLessCtor = type.GetConstructor(Type.EmptyTypes);
        if (pramsLessCtor == null)
        {
            throw new MissingMethodException("Constructor without parameters must be specified");
        }
        if (_states.ContainsKey(type)) { return; }
        
        var obj = (T)Activator.CreateInstance(type)!;
         
        _states[typeof(T)] = obj;
    }

    public T? GetState<T>() where T:StateContainerBase
    {
        return (T?)_states[typeof(T)];
    }
}
