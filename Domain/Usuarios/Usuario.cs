using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Primitives;

public sealed class Usuario : AggregateRoot
{
    public Usuario(UsuarioId id, string nombre, string apellido, string correoElectronico, PhoneNumber telefono, Dui dui, DateTime creadoEn, DateTime modificadoEn)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        CorreoElectronico = correoElectronico;
        Telefono = telefono;
        Dui = dui;
        CreadoEn = creadoEn;
        ModificadoEn = modificadoEn;
    }

    private Usuario(){
        
    }

    public UsuarioId Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; private set; } = string.Empty;
    public string CorreoElectronico { get; private set; } = string.Empty;
    public PhoneNumber Telefono { get; private set; }
    public Dui Dui { get; private set; }
    public DateTime CreadoEn { get; private set; }
    public DateTime ModificadoEn { get; private set; }

    public string NombreCompleto => $"{Nombre} {Apellido}";
}