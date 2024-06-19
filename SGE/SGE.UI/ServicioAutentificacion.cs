using System;

namespace SGE.UI;

public class ServicioAutentificacion
{
    private bool _isLoggedIn;

    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        set
        {
            if (_isLoggedIn != value)
            {
                _isLoggedIn = value;
                NotifyAuthenticationStateChanged();
            }
        }
    }

    public event Action OnAuthenticationStateChanged;

    private void NotifyAuthenticationStateChanged() => OnAuthenticationStateChanged?.Invoke();
}
