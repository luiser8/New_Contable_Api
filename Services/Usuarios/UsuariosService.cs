
using newcontableapi.Entities;
using newcontableapi.Repository;

namespace newcontableapi.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<List<Usuarios>> SelectUsuariosService(int IdUsuario)
        {
            try
            {
                return await _usuariosRepository.SelectUsuariosRepository(IdUsuario);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<UsuariosRolPoliticas> SelectDetallesUsuariosService(int IdUsuario)
        {
            try
            {
                var rolesUsuario = await _usuariosRepository.SelectRolUsuariosRepository(IdUsuario);
                var politicasUsuario = await _usuariosRepository.SelectPoliticasUsuariosRepository(IdUsuario);
                rolesUsuario.PoliticasUsuarios = politicasUsuario;
                return rolesUsuario;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<UsuariosAcceso> LoginUsuariosService(LoginUsuarios loginUsuarios)
        {
            try
            {
                var usuarioAcceso = await _usuariosRepository.LoginUsuariosRepository(loginUsuarios);
                var politicasUsuario = await _usuariosRepository.SelectPoliticasUsuariosRepository(usuarioAcceso.IdUsuario);
                usuarioAcceso.PoliticasUsuarios = politicasUsuario;
                return usuarioAcceso;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> InsertUsuariosService(UsuariosDto usuariosDto)
        {
            try
            {
                return await _usuariosRepository.InsertUsuariosRepository(usuariosDto);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> UpdateUsuariosService(int IdUsuario, Usuarios usuarios)
        {
            try
            {
                return await _usuariosRepository.UpdateUsuariosRepository(IdUsuario, usuarios);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}