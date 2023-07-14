using System.Collections;
using System.Data;
using newcontableapi.Entities;
using newcontableapi.Utils;

namespace newcontableapi.Repository
{
    public class PeriodoContableRepostory : IPeriodoContableRepostory
    {
        private readonly CustomDataTable dbCon;
        private DataTable? dt;
        private readonly Hashtable Params;

        public PeriodoContableRepostory()
        {
            dt = new DataTable();
            dbCon = new CustomDataTable();
            Params = new Hashtable();
        }

        public async Task<List<PeriodoContable>> SelectPeriodoContableRepository(int IdPeriodoContable)
        {
            Params.Clear();
            Params.Add("@IdPeriodoContable", IdPeriodoContable);
            List<PeriodoContable> periodoContablesList = new();
            dt = await dbCon.ExecuteAsync("SP_PeriodoContable_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        periodoContablesList.Add(new PeriodoContable{
                            IdPeriodoContable = Convert.ToInt32(dt.Rows[i]["IdPeriodoContable"]),
                            Inicio = Convert.ToDateTime(dt.Rows[i]["Inicio"]),
                            Fin = Convert.ToDateTime(dt.Rows[i]["Fin"]),
                            Descripcion = Convert.ToString(dt.Rows[i]["Descripcion"]),
                            FechaSistema = Convert.ToDateTime(dt.Rows[i]["FechaSistema"]),
                            Activo = Convert.ToByte(dt.Rows[i]["Activo"]),
                        });
                    }
                }
            }
            return periodoContablesList;
        }

        public async Task<int> InsertPeriodoContableRepository(PeriodoContable periodoContable)
        {
            int IdPeriodoContable = 0;
            Params.Clear();
            Params.Add("@Inicio", periodoContable.Inicio);
            Params.Add("@Fin", periodoContable.Fin);
            Params.Add("@Descripcion", periodoContable.Descripcion);

            dt = await dbCon.ExecuteAsync("SP_PeriodoContable_Insert", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdPeriodoContable = Convert.ToInt16(dt.Rows[i]["IdPeriodoContable"]);
                    }
                }
            }
            return IdPeriodoContable;
        }

        public async Task<int> UpdatePeriodoContableRepository(int IdPeriodoContable, PeriodoContable periodoContable)
        {
            Params.Clear();
            Params.Add("@IdPeriodoContable", IdPeriodoContable);
            Params.Add("@Inicio", periodoContable.Inicio);
            Params.Add("@Fin", periodoContable.Fin);
            Params.Add("@Descripcion", periodoContable.Descripcion);
            Params.Add("@Activo", periodoContable.Activo);

            dt = await dbCon.ExecuteAsync("SP_PeriodoContable_Edit", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdPeriodoContable = Convert.ToInt16(dt.Rows[i]["IdPeriodoContable"]);
                    }
                }
            }
            return IdPeriodoContable;
        }
    }
}