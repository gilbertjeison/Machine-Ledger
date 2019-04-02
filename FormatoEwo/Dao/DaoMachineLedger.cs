using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Media.Imaging;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoMachineLedger: IDisposable
    {
        DaoCalendarioPm daoCal = new DaoCalendarioPm();
        DataTable dt = new DataTable();
        EwoDatabaseDataSet.maquinasDataTable dtMaq = new EwoDatabaseDataSet.maquinasDataTable();
        maquinasTableAdapter mta = new maquinasTableAdapter();
        sistemasTableAdapter sta = new sistemasTableAdapter();
        conjuntosTableAdapter cta = new conjuntosTableAdapter();
        componentesTableAdapter comta = new componentesTableAdapter();
        CompCalTableAdapter ccta = new CompCalTableAdapter();

        public int AddMaquina(Machines m)
        {
            int res = 0;
            if (m != null)
            {
                res = mta.Insert(m.nombre,m.foto,m.id_planta);
            }

            return res;
        }

        public int AddSistema(Sistemas s)
        {
            int res = 0;
            if (s != null)
            {
                res = sta.Insert(s.nombre, s.id_machine, s.image_path);
            }

            return res;
        }

        public int AddConjunto(Conjuntos c)
        {
            int res = 0;
            if (c != null)
            {
                res = cta.Insert(c.nombre, c.image_path, c.id_sistema);
            }

            return res;
        }

        public int AddComponente(Componentes com)
        {
            int res = 0;
            if (com != null)
            {
                res = comta.Insert(com.codigo_fabricante,
                                   com.codigo_sap,
                                   com.descripcion,
                                   com.ubicacion_almacen,
                                   com.clase,
                                   com.proveedor,
                                   com.codigo_estrategia_mtto,
                                   com.id_smp,
                                   com.frecuencia_pm,                                   
                                   com.tipo_frecuencia_pm,
                                   com.duracion_estandar,
                                   com.estado_equipo,
                                   com.estandar_am,
                                   com.frecuencia_am,
                                   com.tipo_frecuencia_am,
                                   com.n_matriz_qp,
                                   com.n_matriz_qm,
                                   com.tipo_kaizen,
                                   com.n_kaizen,                                   
                                   com.image_path,
                                   com.id_conjunto);
            }

            return res;
        }

        public int EditMaquina(Machines m)
        {         
            int res = 0;
            if (m != null)
            {
                //SE CREA UN DATATABLE COMUN Y SE ASIGNA 
                //EL RESULTADO DE UNA CONSULTA LINQ
                //CON EL ID DE LA FILA
                DataTable dt =  mta.GetData().
                    Where(x => x.Id == m.id).CopyToDataTable<maquinasRow>();
                
                //SE CREA UN DATATABLE TIPO DE LA TABLA
                maquinasDataTable mdt = new maquinasDataTable();
                //SE COMBINA LOS DATATABLES PARA FACILITAR EL MANEJO
                mdt.Merge(dt);

                //SE CREA UN DATAROW DEL TIPO DE LA TABLA
                EwoDatabaseDataSet.maquinasRow maqRow =
                   mdt.FindById(m.id);

                //SE ASIGNAN LOS VALORES MODIFICADOS
                maqRow.nombre = m.nombre;
                maqRow.foto_path = m.foto;

                //SE EJECUTA LA ACTUALIZACIÓN
                res = mta.Update(maqRow);                
            }

            return res;
        }

        public int EditSistema(Sistemas s)
        {
            int res = 0;
            if (s != null)
            {
                //SE CREA UN DATATABLE COMUN Y SE ASIGNA 
                //EL RESULTADO DE UNA CONSULTA LINQ
                //CON EL ID DE LA FILA
                DataTable dt = sta.GetData().
                    Where(x => x.Id == s.id).CopyToDataTable<sistemasRow>();

                //SE CREA UN DATATABLE TIPO DE LA TABLA
                sistemasDataTable sdt = new sistemasDataTable();
                //SE COMBINA LOS DATATABLES PARA FACILITAR EL MANEJO
                sdt.Merge(dt);

                //SE CREA UN DATAROW DEL TIPO DE LA TABLA
                EwoDatabaseDataSet.sistemasRow sisRow =
                   sdt.FindById(s.id);

                //SE ASIGNAN LOS VALORES MODIFICADOS
                sisRow.Nombre = s.nombre;
                sisRow.image_path = s.image_path;
                sisRow.id_maquina = s.id_machine;

                //SE EJECUTA LA ACTUALIZACIÓN
                res = sta.Update(sisRow);
            }

            return res;
        }

        public int EditConjunto(Conjuntos c)
        {
            int res = 0;
            if (c != null)
            {
                //SE CREA UN DATATABLE COMUN Y SE ASIGNA 
                //EL RESULTADO DE UNA CONSULTA LINQ
                //CON EL ID DE LA FILA
                DataTable dt = cta.GetData().
                    Where(x => x.Id == c.id).CopyToDataTable<conjuntosRow>();

                //SE CREA UN DATATABLE TIPO DE LA TABLA
                conjuntosDataTable cdt = new conjuntosDataTable();
                //SE COMBINA LOS DATATABLES PARA FACILITAR EL MANEJO
                cdt.Merge(dt);

                //SE CREA UN DATAROW DEL TIPO DE LA TABLA
                EwoDatabaseDataSet.conjuntosRow conRow =
                   cdt.FindById(c.id);

                //SE ASIGNAN LOS VALORES MODIFICADOS
                conRow.nombre = c.nombre;
                conRow.image_path = c.image_path;
                conRow.id_sistema = c.id_sistema;

                //SE EJECUTA LA ACTUALIZACIÓN
                res = cta.Update(conRow);
            }

            return res;
        }

        public int EditComponente(Componentes c)
        {
            int res = 0;
            if (c != null)
            {
                //SE CREA UN DATATABLE COMUN Y SE ASIGNA 
                //EL RESULTADO DE UNA CONSULTA LINQ
                //CON EL ID DE LA FILA
                DataTable dt = comta.GetData().
                    Where(x => x.Id == c.id).CopyToDataTable<componentesRow>();

                //SE CREA UN DATATABLE TIPO DE LA TABLA
                componentesDataTable comdt = new componentesDataTable();
                //SE COMBINA LOS DATATABLES PARA FACILITAR EL MANEJO
                comdt.Merge(dt);

                //SE CREA UN DATAROW DEL TIPO DE LA TABLA
                EwoDatabaseDataSet.componentesRow comRow =
                   comdt.FindById(c.id);

                //SE ASIGNAN LOS VALORES MODIFICADOS
                comRow.Id = c.id;
                comRow.codigo_fabricante = c.codigo_fabricante;
                comRow.codigo_sap = c.codigo_sap;
                comRow.descripcion = c.descripcion;
                comRow.ubicacion_almacen = c.ubicacion_almacen;
                comRow.clase = c.clase;
                comRow.proveedor = c.proveedor;
                comRow.estrategia_mtto = c.codigo_estrategia_mtto;
                comRow.id_smp = c.id_smp;
                comRow.frecuencia_pm = c.frecuencia_pm;
                comRow.tipo_frecuencia_pm = c.tipo_frecuencia_pm;
                comRow.duracion_estandar = c.duracion_estandar;
                comRow.estado_equipo = c.estado_equipo;
                comRow.estandar_am = c.estandar_am;
                comRow.frecuencia_am = c.frecuencia_am;
                comRow.tipo_frecuencia_am = c.tipo_frecuencia_am;
                comRow.n_matriz_qp = c.n_matriz_qp;
                comRow.n_matriz_qm = c.n_matriz_qm;
                comRow.tipo_kaizen = c.tipo_kaizen;
                comRow.n_kaizen = c.n_kaizen;
                comRow.image_path = c.image_path;
                comRow.id_conjunto = c.id_conjunto;
                
                //SE EJECUTA LA ACTUALIZACIÓN
                res = comta.Update(comRow);
            }

            return res;
        }
        
        public int DeleteMaquina(Machines m)
        {
            int res = 0;
            if (m.id > 0)
            {
                //SE EJECUTA LA ACTUALIZACIÓN
                res = mta.Delete(m.id,m.nombre,m.id_planta);
            }

            return res;
        }

        public int DeleteSistema(Sistemas s)
        {
            int res = 0;
            if (s.id > 0)
            {
                //SE EJECUTA LA ACTUALIZACIÓN
                res = sta.Delete(s.id, s.id_machine);
            }

            return res;
        }

        public int DeleteConjunto(Conjuntos c)
        {
            int res = 0;
            if (c.id > 0)
            {
                //SE EJECUTA LA ACTUALIZACIÓN
                res = cta.Delete(c.id, c.id_sistema);
            }

            return res;
        }

        public List<Machines> ConsultarMaquinas(int id_planta)
        {
            List<Machines> list = new List<Machines>();            
            maquinasDataTable mdt = new maquinasDataTable();

            mdt = mta.GetDataByIdPlanta(id_planta);

            for (int i = 0; i < mdt.Rows.Count; i++)
            {
                list.Add(new Machines()
                {
                    id = int.Parse(mdt.Rows[i][0].ToString()),
                    nombre = mdt.Rows[i][1].ToString(),
                    foto = mdt.Rows[i][2].ToString()
                });
            }
            
            return list;
        }

        public List<Sistemas> ConsultarSistemas(int id_maquina)
        {
            List<Sistemas> list = new List<Sistemas>();
            sistemasDataTable sdt = new sistemasDataTable();

            sdt = sta.GetDataByIdMaquina(id_maquina);

            for (int i = 0; i < sdt.Rows.Count; i++)
            {
                list.Add(new Sistemas()
                {
                    id = int.Parse(sdt.Rows[i][0].ToString()),
                    nombre = sdt.Rows[i][1].ToString(),
                    id_machine = int.Parse(sdt.Rows[i][2].ToString()),
                    image_path = sdt.Rows[i][3].ToString()
                });
            }

            Dispose(true);
            
            return list;
        }

        public List<Conjuntos> ConsultarConjuntos(int id_sistema)
        {
            List<Conjuntos> list = new List<Conjuntos>();
            conjuntosDataTable cdt = new conjuntosDataTable();

            cdt = cta.GetDataByIdSistema(id_sistema);

            for (int i = 0; i < cdt.Rows.Count; i++)
            {
                list.Add(new Conjuntos()
                {
                    id = int.Parse(cdt.Rows[i][0].ToString()),
                    nombre = cdt.Rows[i][1].ToString(),
                    id_sistema = int.Parse(cdt.Rows[i][3].ToString()),
                    image_path = cdt.Rows[i][2].ToString()
                });
            }

            return list;
        }

        public List<Componentes> ConsultarComponentes(int id_conjunto)
        {
            List<Componentes> list = new List<Componentes>();
            componentesDataTable cdt = new componentesDataTable();

            cdt = comta.GetDataByIdConjunto(id_conjunto);

            for (int i = 0; i < cdt.Rows.Count; i++)
            {
                list.Add(new Componentes()
                {
                    id = int.Parse(cdt.Rows[i]["Id"].ToString()),
                    codigo_fabricante = cdt.Rows[i]["codigo_fabricante"].ToString(),
                    codigo_sap= cdt.Rows[i]["codigo_sap"].ToString(),
                    descripcion = cdt.Rows[i]["descripcion"].ToString(),
                    ubicacion_almacen = cdt.Rows[i]["ubicacion_almacen"].ToString(),
                    clase = cdt.Rows[i]["clase"].ToString(),
                    proveedor = cdt.Rows[i]["proveedor"].ToString(),
                    codigo_estrategia_mtto = int.Parse(cdt.Rows[i]["estrategia_mtto"].ToString()),
                    id_smp = int.Parse(cdt.Rows[i]["id_smp"].ToString()),
                    frecuencia_pm = int.Parse(cdt.Rows[i]["frecuencia_pm"].ToString()),
                    tipo_frecuencia_pm = int.Parse(cdt.Rows[i]["tipo_frecuencia_pm"].ToString()),
                    duracion_estandar = int.Parse(cdt.Rows[i]["duracion_estandar"].ToString()),
                    estado_equipo = int.Parse(cdt.Rows[i]["estado_equipo"].ToString()),
                    estandar_am = int.Parse(cdt.Rows[i]["estandar_am"].ToString()),
                    frecuencia_am = int.Parse(cdt.Rows[i]["frecuencia_am"].ToString()),
                    tipo_frecuencia_am = int.Parse(cdt.Rows[i]["tipo_frecuencia_am"].ToString()),
                    n_matriz_qp = cdt.Rows[i]["n_matriz_qp"].ToString(),
                    n_matriz_qm = cdt.Rows[i]["n_matriz_qm"].ToString(),
                    tipo_kaizen = int.Parse(cdt.Rows[i]["tipo_kaizen"].ToString()),
                    n_kaizen = int.Parse(cdt.Rows[i]["n_kaizen"].ToString()),
                    image_path = cdt.Rows[i]["image_path"].ToString(),
                    id_conjunto = int.Parse(cdt.Rows[i]["id_conjunto"].ToString()),
                    image = new BitmapImage(new Uri(Util.Global.DIRECTORIO_IMAGENES + @"\" + cdt.Rows[i]["image_path"].ToString())),
                    mttos = daoCal.ConsultarCalendario(int.Parse(cdt.Rows[i]["Id"].ToString()))
            });
            }

            return list;
        }

        public List<Componentes> ConsultarComponentesCal(int id_conjunto)
        {
            List<Componentes> list = new List<Componentes>();
            CompCalDataTable ccdt = new CompCalDataTable();

            ccdt = ccta.GetDataCompCal(id_conjunto);

            for (int i = 0; i < ccdt.Rows.Count; i++)
            {
                list.Add(new Componentes()
                {
                    id = int.Parse(ccdt.Rows[i]["Id"].ToString()),
                    codigo_fabricante = ccdt.Rows[i]["codigo_fabricante"].ToString(),
                    codigo_sap = ccdt.Rows[i]["codigo_sap"].ToString(),
                    descripcion = ccdt.Rows[i]["descripcion"].ToString(),
                    ubicacion_almacen = ccdt.Rows[i]["ubicacion_almacen"].ToString(),
                    clase = ccdt.Rows[i]["clase"].ToString(),
                    proveedor = ccdt.Rows[i]["proveedor"].ToString(),
                    codigo_estrategia_mtto = int.Parse(ccdt.Rows[i]["estrategia_mtto"].ToString()),
                    id_smp = int.Parse(ccdt.Rows[i]["id_smp"].ToString()),
                    frecuencia_pm = int.Parse(ccdt.Rows[i]["frecuencia_pm"].ToString()),
                    tipo_frecuencia_pm = int.Parse(ccdt.Rows[i]["tipo_frecuencia_pm"].ToString()),
                    duracion_estandar = int.Parse(ccdt.Rows[i]["duracion_estandar"].ToString()),
                    estado_equipo = int.Parse(ccdt.Rows[i]["estado_equipo"].ToString()),
                    estandar_am = int.Parse(ccdt.Rows[i]["estandar_am"].ToString()),
                    frecuencia_am = int.Parse(ccdt.Rows[i]["frecuencia_am"].ToString()),
                    tipo_frecuencia_am = int.Parse(ccdt.Rows[i]["tipo_frecuencia_am"].ToString()),
                    n_matriz_qp = ccdt.Rows[i]["n_matriz_qp"].ToString(),
                    n_matriz_qm = ccdt.Rows[i]["n_matriz_qm"].ToString(),
                    tipo_kaizen = int.Parse(ccdt.Rows[i]["tipo_kaizen"].ToString()),
                    n_kaizen = int.Parse(ccdt.Rows[i]["n_kaizen"].ToString()),
                    image_path = ccdt.Rows[i]["image_path"].ToString(),
                    id_conjunto = int.Parse(ccdt.Rows[i]["id_conjunto"].ToString()),
                    image = new BitmapImage(new Uri(Util.Global.DIRECTORIO_IMAGENES + @"\" + ccdt.Rows[i]["image_path"].ToString()))
                });
            }

            return list;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~DaoMachineLedger() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
