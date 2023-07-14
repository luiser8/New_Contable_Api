using System.Collections;
using System.Data;
using newcontableapi.Entities;
using newcontableapi.Utils;

namespace newcontableapi.Repository
{
    public class AsientosContablesRepository : IAsientosContablesRepository
    {
        private readonly CustomDataTable dbCon;
        private DataTable? dt;
        private readonly Hashtable Params;

        public AsientosContablesRepository()
        {
            dt = new DataTable();
            dbCon = new CustomDataTable();
            Params = new Hashtable();
        }

        public async Task<List<AsientoContableDetalleResponse>> SelectAsientosContablesRepository(string FechaDesde, string FechaHasta, int IdPeriodoContable)
        {
            Params.Clear();
            Params.Add("@FechaDesde", FechaDesde);
            Params.Add("@FechaHasta", FechaHasta);
            Params.Add("@IdPeriodoContable", IdPeriodoContable);
            Params.Add("@Tipo", 1);
            List<AsientoContableDetalleResponse> asientoContableDetallesList = new();
            dt = await dbCon.ExecuteAsync("SP_AsientosContables_Select", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        asientoContableDetallesList.Add(new AsientoContableDetalleResponse{
                            IdAsientoDetalle = Convert.ToInt16(dt.Rows[i]["IdAsientoDetalle"]),
                            NroComprobante = Convert.ToInt32(dt.Rows[i]["NroComprobante"]),
                            IdPeriodoContable = Convert.ToInt16(dt.Rows[i]["IdPeriodoContable"]),
                            PeriodoContable = Convert.ToString(dt.Rows[i]["PeriodoContable"]),
                            IdPlanCuenta = Convert.ToInt16(dt.Rows[i]["IdPlanCuenta"]),
                            CodPlanCuenta = Convert.ToString(dt.Rows[i]["CodPlanCuenta"]),
                            PlanCuenta = Convert.ToString(dt.Rows[i]["PlanCuenta"]),
                            IdCentroCosto = Convert.ToInt16(dt.Rows[i]["IdCentroCosto"]),
                            CentroCosto = Convert.ToString(dt.Rows[i]["CentroCosto"]),
                            IdMoneda = Convert.ToInt16(dt.Rows[i]["IdMoneda"]),
                            Moneda = Convert.ToString(dt.Rows[i]["Moneda"]),
                            Descripcion = Convert.ToString(dt.Rows[i]["Descripcion"]),
                            Tipo= Convert.ToByte(dt.Rows[i]["Tipo"]),
                            Debe = Convert.ToDecimal(dt.Rows[i]["Debe"]),
                            Haber = Convert.ToDecimal(dt.Rows[i]["Haber"]),
                            Referencia = Convert.ToString(dt.Rows[i]["Referencia"]),
                            FechaAsiento = Convert.ToDateTime(dt.Rows[i]["FechaAsiento"]),
                            FechaAsientoDetalle = Convert.ToDateTime(dt.Rows[i]["FechaAsientoDetalle"]),
                            FechaSistema = Convert.ToDateTime(dt.Rows[i]["FechaSistema"]),
                            AsientoActivo = Convert.ToBoolean(dt.Rows[i]["AsientoActivo"])
                        });
                    }
                }
            }
            return asientoContableDetallesList;
        }

        public async Task<int> InsertAsientosContablesRepository(AsientosContables asientosContables)
        {
            int IdAsiento = 0;
            Params.Clear();
            Params.Add("@InsertOrder", 1);
            Params.Add("@IdPeriodoContable", asientosContables.IdPeriodoContable);
            Params.Add("@FechaAsiento", asientosContables.FechaAsiento);

            dt = await dbCon.ExecuteAsync("SP_AsientosContables_Insert", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdAsiento = Convert.ToInt16(dt.Rows[i]["IdAsiento"]);
                    }
                }
            }
            return IdAsiento;
        }

        public async Task<int> InsertAsientosContablesDetallesRepository(int IdAsiento, List<AsientosContablesDetalles> asientosContablesDetalles)
        {
            int IdAsientoDetalle = 0;
            if (asientosContablesDetalles.Count > 0)
            {
                foreach (var item in asientosContablesDetalles)
                {
                    Params.Clear();
                    Params.Add("@InsertOrder", 2);
                    Params.Add("@IdAsiento", IdAsiento);
                    Params.Add("@IdPlanCuenta", item.IdPlanCuenta);
                    Params.Add("@IdCentroCosto", item.IdCentroCosto);
                    Params.Add("@IdMoneda", item.IdMoneda);
                    Params.Add("@Descripcion", item.Descripcion);
                    Params.Add("@Tipo", item.Tipo);
                    Params.Add("@Debe", item.Debe);
                    Params.Add("@Haber", item.Haber);
                    Params.Add("@Referencia", item.Referencia);
                    Params.Add("@FechaAsientoDetalle", item.FechaAsientoDetalle);

                    dt = await dbCon.ExecuteAsync("SP_AsientosContables_Insert", Params);

                    if (dbCon.ErrorStatus)
                    {
                        if (dt.Rows.Count != 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                IdAsientoDetalle = Convert.ToInt16(dt.Rows[i]["IdAsientoDetalle"]);
                            }
                        }
                    }
                }
            }
            return IdAsientoDetalle;
        }
        public async Task<int> UpdateAsientosContablesRepository(int IdAsiento, AsientosContables asientosContables)
        {
            Params.Clear();
            Params.Add("@UpdateOrder", 1);
            Params.Add("@IdAsiento", asientosContables.IdAsiento);
            Params.Add("@IdPeriodoContable", asientosContables.IdPeriodoContable);
            Params.Add("@FechaAsiento", asientosContables.FechaAsiento);
            Params.Add("@ActivoAsiento", asientosContables.Activo);

            dt = await dbCon.ExecuteAsync("SP_AsientosContables_Edit", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdAsiento = Convert.ToInt16(dt.Rows[i]["IdAsiento"]);
                    }
                }
            }
            return IdAsiento;
        }

        public async Task<int> UpdateAsientosContablesDetallesRepository(int IdAsientoDetalle, AsientosContablesDetalles asientosContablesDetalles)
        {
            Params.Clear();
            Params.Add("@UpdateOrder", 2);
            Params.Add("@IdAsientoDetalle", asientosContablesDetalles.IdAsientoDetalle);
            Params.Add("@IdPlanCuenta", asientosContablesDetalles.IdPlanCuenta);
            Params.Add("@IdCentroCosto", asientosContablesDetalles.IdCentroCosto);
            Params.Add("@IdMoneda", asientosContablesDetalles.IdMoneda);
            Params.Add("@Descripcion", asientosContablesDetalles.Descripcion);
            Params.Add("@Tipo", asientosContablesDetalles.Tipo);
            Params.Add("@Debe", asientosContablesDetalles.Debe);
            Params.Add("@Haber", asientosContablesDetalles.Haber);
            Params.Add("@Referencia", asientosContablesDetalles.Referencia);
            Params.Add("@FechaAsientoDetalle", asientosContablesDetalles.FechaAsientoDetalle);
            Params.Add("@ActivoAsientoDetalle", asientosContablesDetalles.Activo);

            dt = await dbCon.ExecuteAsync("SP_AsientosContables_Edit", Params);

            if (dbCon.ErrorStatus)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdAsientoDetalle = Convert.ToInt16(dt.Rows[i]["IdAsientoDetalle"]);
                    }
                }
            }
            return IdAsientoDetalle;
        }
    }
}