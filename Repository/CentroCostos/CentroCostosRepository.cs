using System.Collections;
using System.Data;
using newcontableapi.Entities;
using newcontableapi.Utils;

namespace newcontableapi.Repository
{
    public class CentroCostosRepository : ICentroCostosRepository
    {
        private readonly CustomDataTable dbCon;
        private DataTable? dt;
        private readonly Hashtable Params;

        public CentroCostosRepository()
        {
            dt = new DataTable();
            dbCon = new CustomDataTable();
            Params = new Hashtable();
        }

        public async Task<List<CentroCostos>> SelectCentroCostosRepository(int IdCentroCosto)
        {
            Params.Clear();
            Params.Add("@IdCentroCosto", IdCentroCosto);
            List<CentroCostos> centroCostosList = new();
            dt = await dbCon.ExecuteAsync("SP_CentroCostos_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        centroCostosList.Add(new CentroCostos{
                            IdCentroCosto = Convert.ToInt32(dt.Rows[i]["IdCentroCosto"]),
                            Descripcion = Convert.ToString(dt.Rows[i]["Descripcion"]),
                            FechaSistema = Convert.ToDateTime(dt.Rows[i]["FechaSistema"]),
                            Activo = Convert.ToByte(dt.Rows[i]["Activo"]),
                        });
                    }
                }
            }
            return centroCostosList;
        }

        public async Task<int> InsertCentroCostosRepository(CentroCostos centroCostos)
        {
            int IdCentroCosto = 0;
            Params.Clear();
            Params.Add("@Descripcion", centroCostos.Descripcion);

            dt = await dbCon.ExecuteAsync("SP_CentroCostos_Insert", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdCentroCosto = Convert.ToInt16(dt.Rows[i]["IdCentroCosto"]);
                    }
                }
            }
            return IdCentroCosto;
        }

        public async Task<int> UpdateCentroCostosRepository(int IdCentroCosto, CentroCostos centroCostos)
        {
            Params.Clear();
            Params.Add("@IdCentroCosto", IdCentroCosto);
            Params.Add("@Descripcion", centroCostos.Descripcion);
            Params.Add("@Activo", centroCostos.Activo);

            dt = await dbCon.ExecuteAsync("SP_CentroCostos_Edit", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdCentroCosto = Convert.ToInt16(dt.Rows[i]["IdCentroCosto"]);
                    }
                }
            }
            return IdCentroCosto;
        }
    }
}