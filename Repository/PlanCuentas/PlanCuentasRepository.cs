using System.Collections;
using System.Data;
using newcontableapi.Entities;
using newcontableapi.Utils;

namespace newcontableapi.Repository
{
    public class PlanCuentasRepository : IPlanCuentasRepository
    {
        private readonly CustomDataTable dbCon;
        private DataTable? dt;
        private readonly Hashtable Params;

        public PlanCuentasRepository()
        {
            dt = new DataTable();
            dbCon = new CustomDataTable();
            Params = new Hashtable();
        }

        public async Task<List<PlanCuentas>> SelectPlanCuentasRepository(int IdPlanCuenta)
        {
            Params.Clear();
            Params.Add("@IdPlanCuenta", IdPlanCuenta);
            List<PlanCuentas> planCuentasList = new();
            dt = await dbCon.ExecuteAsync("SP_PlanCuentas_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        planCuentasList.Add(new PlanCuentas{
                            IdPlanCuenta = Convert.ToInt32(dt.Rows[i]["IdPlanCuenta"]),
                            Codigo = Convert.ToString(dt.Rows[i]["Codigo"]),
                            Descripcion = Convert.ToString(dt.Rows[i]["Descripcion"]),
                            FechaSistema = Convert.ToDateTime(dt.Rows[i]["FechaSistema"]),
                            Activo = Convert.ToByte(dt.Rows[i]["Activo"]),
                        });
                    }
                }
            }
            return planCuentasList;
        }

        public async Task<int> InsertPlanCuentasRepository(PlanCuentas planCuentas)
        {
            int IdplanCuenta = 0;
            Params.Clear();
            Params.Add("@Codigo", planCuentas.Codigo);
            Params.Add("@Descripcion", planCuentas.Descripcion);

            dt = await dbCon.ExecuteAsync("SP_PlanCuentas_Insert", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdplanCuenta = Convert.ToInt16(dt.Rows[i]["IdplanCuenta"]);
                    }
                }
            }
            return IdplanCuenta;
        }

        public async Task<int> UpdatePlanCuentasRepository(int IdPlanCuenta, PlanCuentas planCuentas)
        {
            Params.Clear();
            Params.Add("@IdPlanCuenta", IdPlanCuenta);
            Params.Add("@Codigo", planCuentas.Codigo);
            Params.Add("@Descripcion", planCuentas.Descripcion);
            Params.Add("@Activo", planCuentas.Activo);

            dt = await dbCon.ExecuteAsync("SP_PlanCuentas_Edit", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdPlanCuenta = Convert.ToInt16(dt.Rows[i]["IdPlanCuenta"]);
                    }
                }
            }
            return IdPlanCuenta;
        }
    }
}