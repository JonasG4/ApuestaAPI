using Domain.Primitives;

namespace Domain.Usuarios;

public interface IUsuarioRepository{
    Task<Usuario?> GetByIdAsync(UsuarioId id);
    Task Add(Usuario usuario);

}