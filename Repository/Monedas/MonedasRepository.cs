using System.Collections;
using System.Data;
using newcontableapi.Entities;
using newcontableapi.Utils;

namespace newcontableapi.Repository
{
    public class MonedasRepository : IMonedasRepository
    {
        private readonly CustomDataTable dbCon;
        private DataTable? dt;
        private readonly Hashtable Params;

        public MonedasRepository()
        {
            dt = new DataTable();
            dbCon = new CustomDataTable();
            Params = new Hashtable();
        }

        public async Task<List<Monedas>> SelectMonedasRepository(int IdMoneda)
        {
            Params.Clear();
            Params.Add("@IdMoneda", IdMoneda);
            List<Monedas> monedasList = new();
            dt = await dbCon.ExecuteAsync("SP_Monedas_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        monedasList.Add(new Monedas{
                            IdMoneda = Convert.ToInt32(dt.Rows[i]["IdMoneda"]),
                            Simbolo = Convert.ToString(dt.Rows[i]["Simbolo"]),
                            Descripcion = Convert.ToString(dt.Rows[i]["Descripcion"]),
                            FechaSistema = Convert.ToDateTime(dt.Rows[i]["FechaSistema"]),
                            Activo = Convert.ToByte(dt.Rows[i]["Activo"]),
                        });
                    }
                }
            }
            return monedasList;
        }

        public async Task<int> InsertMonedasRepository(Monedas monedas)
        {
            int IdMoneda = 0;
            Params.Clear();
            Params.Add("@Simbolo", monedas.Simbolo);
            Params.Add("@Descripcion", monedas.Descripcion);

            dt = await dbCon.ExecuteAsync("SP_Monedas_Insert", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdMoneda = Convert.ToInt16(dt.Rows[i]["IdMoneda"]);
                    }
                }
            }
            return IdMoneda;
        }

        public async Task<int> UpdateMonedasRepository(int IdMoneda, Monedas monedas)
        {
            Params.Clear();
            Params.Add("@IdMoneda", IdMoneda);
            Params.Add("@Simbolo", monedas.Simbolo);
            Params.Add("@Descripcion", monedas.Descripcion);
            Params.Add("@Activo", monedas.Activo);

            dt = await dbCon.ExecuteAsync("SP_Monedas_Edit", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdMoneda = Convert.ToInt16(dt.Rows[i]["IdMoneda"]);
                    }
                }
            }
            return IdMoneda;
        }
    }
}