
using newcontableapi.Entities;

namespace newcontableapi.Repository
{
    public interface IUsuariosRepository
    {
        Task<List<Usuarios>> SelectUsuariosRepository(int IdUsuario);
        Task<UsuariosRolPoliticas> SelectRolUsuariosRepository(int IdUsuario);
        Task<List<PoliticasUsuario>> SelectPoliticasUsuariosRepository(int IdUsuario);
        Task<UsuariosAcceso> LoginUsuariosRepository(LoginUsuarios loginUsuarios);
        Task<int> InsertUsuariosRepository(UsuariosDto usuariosDto);
        Task<int> UpdateUsuariosRepository(int IdUsuario, Usuarios usuarios);
    }
}