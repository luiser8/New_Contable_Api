using newcontableapi.Entities;

namespace newcontableapi.Services
{
    public interface IUsuariosService
    {
        Task<List<Usuarios>> SelectUsuariosService(int IdUsuario);
        Task<UsuariosRolPoliticas> SelectDetallesUsuariosService(int IdUsuario);
        Task<UsuariosAcceso> LoginUsuariosService(LoginUsuarios loginUsuarios);
        Task<int> InsertUsuariosService(UsuariosDto usuariosDto);
        Task<int> UpdateUsuariosService(int IdUsuario, Usuarios usuarios);
    }
}