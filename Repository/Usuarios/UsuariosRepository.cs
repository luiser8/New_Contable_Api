using System.Collections;
using System.Data;
using newcontableapi.Entities;
using newcontableapi.Utils;

namespace newcontableapi.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly CustomDataTable dbCon;
        private DataTable? dt;
        private readonly Hashtable Params;

        public UsuariosRepository()
        {
            dt = new DataTable();
            dbCon = new CustomDataTable();
            Params = new Hashtable();
        }

        public async Task<List<Usuarios>> SelectUsuariosRepository(int IdUsuario)
        {
            Params.Clear();
            Params.Add("@IdUsuario", IdUsuario);
            Params.Add("@Tipo", IdUsuario == 0 ? 1 : 2);
            List<Usuarios> usuariosList = new();
            dt = await dbCon.ExecuteAsync("SP_Usuarios_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        usuariosList.Add(new Usuarios
                        {
                            IdUsuario = Convert.ToInt32(dt.Rows[i]["IdUsuario"]),
                            Nombres = Convert.ToString(dt.Rows[i]["Nombres"]),
                            Apellidos = Convert.ToString(dt.Rows[i]["Apellidos"]),
                            CuentaLocal = Convert.ToString(dt.Rows[i]["CuentaLocal"]),
                            Correo = Convert.ToString(dt.Rows[i]["Correo"]),
                            FechaSistema = Convert.ToDateTime(dt.Rows[i]["FechaSistema"]),
                            Activo = Convert.ToByte(dt.Rows[i]["Activo"]),
                        });
                    }
                }
            }
            return usuariosList;
        }

        public async Task<UsuariosRolPoliticas> SelectRolUsuariosRepository(int IdUsuario)
        {
            Params.Clear();
            Params.Add("@IdUsuario", IdUsuario);
            Params.Add("@Tipo", 4);
            var usuariosList = new UsuariosRolPoliticas();
            dt = await dbCon.ExecuteAsync("SP_Usuarios_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        usuariosList.IdUsuario = Convert.ToInt32(dt.Rows[i]["IdUsuario"]);
                        usuariosList.RolUsuario = new RolUsuario
                        {
                            IdRol = Convert.ToInt32(dt.Rows[i]["IdRol"]),
                            CodRol = Convert.ToString(dt.Rows[i]["CodRol"]),
                            DesRol = Convert.ToString(dt.Rows[i]["DesRol"]),
                            ActRol = Convert.ToByte(dt.Rows[i]["ActRol"]),
                        };
                    }
                }
            }
            return usuariosList;
        }

        public async Task<List<PoliticasUsuario>> SelectPoliticasUsuariosRepository(int IdUsuario)
        {
            Params.Clear();
            Params.Add("@IdUsuario", IdUsuario);
            Params.Add("@Tipo", 5);
            List<PoliticasUsuario> usuariosList = new();
            dt = await dbCon.ExecuteAsync("SP_Usuarios_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        usuariosList.Add(new PoliticasUsuario
                        {
                            IdPolitica = Convert.ToInt32(dt.Rows[i]["IdPolitica"]),
                            CodPolitica = Convert.ToString(dt.Rows[i]["CodPolitica"]),
                            DesPolitica = Convert.ToString(dt.Rows[i]["DesPolitica"]),
                            RutaPolitica = Convert.ToString(dt.Rows[i]["RutaPolitica"]),
                            ActPolitica = Convert.ToByte(dt.Rows[i]["ActPolitica"])
                        });
                    }
                }
            }
            return usuariosList;
        }

        public async Task<UsuariosAcceso> LoginUsuariosRepository(LoginUsuarios loginUsuarios)
        {
            Params.Clear();
            Params.Add("@CuentaLocal", loginUsuarios.CuentaLocal);
            Params.Add("@Contrasena", loginUsuarios.Contrasena);
            Params.Add("@Tipo", 3);
            var usuariosList = new UsuariosAcceso();
            dt = await dbCon.ExecuteAsync("SP_Usuarios_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        usuariosList.IdUsuario = Convert.ToInt32(dt.Rows[i]["IdUsuario"]);
                        usuariosList.Nombres = Convert.ToString(dt.Rows[i]["Nombres"]);
                        usuariosList.Apellidos = Convert.ToString(dt.Rows[i]["Apellidos"]);
                        usuariosList.CuentaLocal = Convert.ToString(dt.Rows[i]["CuentaLocal"]);
                        usuariosList.Correo = Convert.ToString(dt.Rows[i]["Correo"]);
                        usuariosList.TokenAcceso = Convert.ToString(dt.Rows[i]["TokenAcceso"]);
                        usuariosList.TokenRefresco = Convert.ToString(dt.Rows[i]["TokenRefresco"]);
                        usuariosList.TokenCreado = Convert.ToDateTime(dt.Rows[i]["TokenCreado"]);
                        usuariosList.TokenExpiracion = Convert.ToDateTime(dt.Rows[i]["TokenExpiracion"]);
                        usuariosList.Activo = Convert.ToByte(dt.Rows[i]["Activo"]);
                        usuariosList.RolUsuario = new RolUsuario
                        {
                            IdRol = Convert.ToInt32(dt.Rows[i]["IdRol"]),
                            CodRol = Convert.ToString(dt.Rows[i]["CodRol"]),
                            DesRol = Convert.ToString(dt.Rows[i]["DesRol"]),
                            ActRol = Convert.ToByte(dt.Rows[i]["ActRol"]),
                        };
                    }
                }
            }
            return usuariosList;
        }

        public async Task<int> InsertUsuariosRepository(UsuariosDto usuariosDto)
        {
            int IdUsuario = 0;
            Params.Clear();
            Params.Add("@Nombres", usuariosDto.Nombres);
            Params.Add("@Apellidos", usuariosDto.Apellidos);
            Params.Add("@CuentaLocal", usuariosDto.CuentaLocal);
            Params.Add("@Correo", usuariosDto.Correo);
            Params.Add("@Contrasena", usuariosDto.Contrasena);
            Params.Add("@TokenAcceso", usuariosDto.TokenAcceso);
            Params.Add("@TokenRefresco", usuariosDto.TokenRefresco);
            Params.Add("@TokenCreado", DateTime.Now);
            Params.Add("@TokenExpiracion", DateTime.Now.AddDays(7));
            Params.Add("@IdRol", usuariosDto.IdRol);

            dt = await dbCon.ExecuteAsync("SP_Usuarios_Insert", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdUsuario = Convert.ToInt16(dt.Rows[i]["IdUsuario"]);
                    }
                }
            }
            return IdUsuario;
        }

        public async Task<int> UpdateUsuariosRepository(int IdUsuario, Usuarios usuarios)
        {
            Params.Clear();
            Params.Add("@IdUsuario", IdUsuario);
            Params.Add("@Nombres", usuarios.Nombres);
            Params.Add("@Apellidos", usuarios.Apellidos);
            Params.Add("@CuentaLocal", usuarios.CuentaLocal);
            Params.Add("@Correo", usuarios.Correo);
            Params.Add("@Contrasena", usuarios.Contrasena);
            Params.Add("@TokenAcceso", usuarios.TokenAcceso);
            Params.Add("@TokenRefresco", usuarios.TokenRefresco);
            Params.Add("@TokenCreado", DateTime.Now);
            Params.Add("@TokenExpiracion", DateTime.Now.AddDays(7));

            dt = await dbCon.ExecuteAsync("SP_Usuarios_Edit", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdUsuario = Convert.ToInt16(dt.Rows[i]["IdUsuario"]);
                    }
                }
            }
            return IdUsuario;
        }
    }
}