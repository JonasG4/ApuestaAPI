using Domain.Primitives;
using Domain.Usuarios;
using Domain.ValueObjects;
using MediatR;

namespace Application.Usuarios.Create;

internal sealed class CreateUsuarioCommandHanlder : IRequestHandler<CreateUsuarioCommand, Unit>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUsuarioCommandHanlder(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateUsuarioCommand command, CancellationToken cancellationToken)
    {
        if (PhoneNumber.Create(command.Telefono) is not PhoneNumber phoneNumber)
        {
            throw new ArgumentException(nameof(phoneNumber));
        }

        if (Dui.Create(command.Dui) is not Dui dui)
        {
            throw new ArgumentException(nameof(dui));
        }

        var usuario = new Usuario(
            new UsuarioId(Guid.NewGuid()),
            command.Nombre,
            command.Apellido,
            command.CorreoElectronico,
            phoneNumber,
            dui,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        await _usuarioRepository.Add(usuario);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
