using MediatR;

namespace Application.Usuarios.Create;

public record CreateUsuarioCommand(
    string Nombre,
    string Apellido,
    string CorreoElectronico,
    string Telefono,
    string Dui
) : IRequest<Unit>;