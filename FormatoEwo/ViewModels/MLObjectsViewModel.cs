using FormatoEwo.DaoEF;
using FormatoEwo.Database;
using FormatoEwo.Objetos;
using FormatoEwo.SubViews;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FormatoEwo.ViewModels
{
    public class MLObjectsViewModel: BindableBase,INotifyPropertyChanged
    {
        #region Data

        bool? _isChecked = false;
        MLObjectsViewModel _parent;
        static DaoML daoMl = new DaoML();
        private BackgroundWorker _worker;
        private BackgroundWorker _worker_dup;
        Splash splash = new Splash();
        
        private int _sisCount;

        public ICommand CmdDuplicate { get; private set; }

      
        private List<MLObjectsViewModel> _list;
        public List<MLObjectsViewModel> List
        {
            get { return _list; }
            set
            {
                _list = value;
                onPropertyChanged("List");
            }
        }
        
        #endregion

        #region CreateRows
        void Initialize()
        {
            foreach (MLObjectsViewModel item in Children)
            {
                item._parent = this;
                item.Initialize();
            }
        }

        public MLObjectsViewModel()
        {
            
        }

        private string CreateTag()
        {
            return "" +DateTime.Now.Hour  + DateTime.Now.Minute + DateTime.Now.Second;
        }

        private void Duplicar()
        {
            foreach (var maq in List)
            {
                //INSERTAR MAQUINA                
                //OBTENER LA INFORMACIÓN COMPLETA DE LA MAQUINA
                maquinas mCon = daoMl.GetMachineById(maq.Id); 

                //CREAR MAQUINA DUPLICADA CON EL TAG EN EL NOMBRE
                string tag_maq = mCon.nombre + "-" + CreateTag();
                daoMl.AddMachine(new Machines() { nombre = tag_maq, foto = mCon.foto_path, id_planta = (int)mCon.id_planta,id_linea = (int)mCon.id_linea });
                Console.WriteLine("Maquina: " + maq.Name);

                //CONSULTAR ID ED RECIÉN INSERTADO
                maquinas mConAdded = daoMl.GetMachineByName(tag_maq);

                foreach (var sis in maq.Children)
                {
                    sistemas sConAdded = null;
                    if (sis.IsChecked == true || sis.IsChecked == null)
                    {
                        //OBTENER LA INFORMACIÓN COMPLETA DEL SISTEMA
                        sistemas sCon = daoMl.GetSystemById(sis.Id);

                        //CREAR SISTEMA DUPLICADO CON EL TAG EN EL NOMBRE
                        string tag_sis = sCon.Nombre + "-" + CreateTag();
                        daoMl.AddSistema(new Sistemas() { id_machine = (int)mConAdded.Id,image_path = sCon.image_path, nombre = tag_sis });
                        
                        //CONSULTAR ID ED RECIÉN INSERTADO
                        sConAdded = daoMl.GetSystemByName(tag_sis);

                        Console.WriteLine("Sistema: " + sConAdded.Nombre);
                    }

                    foreach (var con in sis.Children)
                    {
                        conjuntos cConAdded = null;
                        if (con.IsChecked == true || con.IsChecked == null)
                        {
                            //OBTENER LA INFORMACIÓN COMPLETA DEL CONJUNTO
                            conjuntos cCon = daoMl.GetConjuntoById(con.Id);

                            //CREAR CONJUNTO DUPLICADO CON EL TAG EN EL NOMBRE
                            string tag_con = cCon.nombre + "-" + CreateTag();
                            daoMl.AddConjunto(new Conjuntos()
                            {
                                nombre = tag_con,
                                id_sistema = (int)sConAdded.Id,
                                image_path = cCon.image_path,
                                id_smp = (int)cCon.id_smp
                            });

                            //CONSULTAR ID ED RECIÉN INSERTADO
                            cConAdded = daoMl.GetConjuntoByName(tag_con);

                            Console.WriteLine("Conjunto: " + cConAdded.nombre);
                        }
                        foreach (var comp in con.Children)
                        {
                            if (comp.IsChecked == true)
                            {
                                //Console.WriteLine("Componente: "+comp.Name);                               
                                //AGREGAR COMPONENTE

                                //OBTENER LA INFORMACIÓN COMPLETA DEL COMPONENTE
                                componentes compCon = daoMl.GetComponentById(comp.Id);

                                //CREAR CONJUNTO DUPLICADO CON EL TAG EN EL NOMBRE
                                //string tag_comp = compCon.descripcion + "-" + CreateTag();
                                daoMl.AddComponente(new Componentes()
                                {
                                    descripcion = compCon.descripcion,
                                    id_conjunto = (int)cConAdded.Id,
                                    image_path = compCon.image_path,
                                    id_smp = (int)compCon.id_smp,
                                    clase = compCon.clase,
                                    codigo_estrategia_mtto = (int)compCon.estrategia_mtto,
                                    codigo_fabricante = compCon.codigo_fabricante,
                                    codigo_sap = compCon.codigo_sap,
                                    duracion_estandar = (int)compCon.duracion_estandar,
                                    estado_equipo = (int)compCon.estado_equipo,
                                    estandar_am = (int)compCon.estandar_am,
                                    frecuencia_am = (int)compCon.frecuencia_am,
                                    frecuencia_pm = (int)compCon.frecuencia_pm,
                                    n_kaizen = (int)compCon.n_kaizen,
                                    n_matriz_qm = compCon.n_matriz_qm,
                                    n_matriz_qp = compCon.n_matriz_qp,
                                    proveedor = compCon.proveedor,
                                    tipo_frecuencia_am = (int)compCon.tipo_frecuencia_am,
                                    tipo_frecuencia_pm = (int)compCon.tipo_frecuencia_pm,
                                    tipo_kaizen = (int)compCon.tipo_kaizen,
                                    ubicacion_almacen = compCon.ubicacion_almacen  
                                });
                                                                 
                                //CONSULTAR ID ED RECIÉN INSERTADO
                                //cConAdded = daoMl.GetConjuntoByName(tag_con);

                                //Console.WriteLine("Componenete: " + cConAdded.nombre);
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Duplicación finalizada correctamente!");
        }

        private void BgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                List = (List<MLObjectsViewModel>)e.Result;
            }

            splash.Hide();
        }

        private void BgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            //OBTENER MAQUINA CON ID INDICADO
            var Ms = daoMl.GetMachineById((int)e.Argument);

            //CREAR NUEVO OBJETO CON DATOS DE LA MAQUINA 
            MLObjectsViewModel root = new MLObjectsViewModel(Ms.Id, Ms.nombre, 1);
            root.IsInitiallySelected = true;

            //OBTENER TODOS LOS SISTEMAS DE LA MAQUINA SELECCIONADA
            var Ss = daoMl.GetSystems(Ms.Id);

            //ITERAR CON CADA SISTEMA DE LA MAQUINA SELECCIONADA
            foreach (var item in Ss)
            {
                //CREAR NUEVO OBJETO CON CADA UNO DE LOS SISTEMAS
                MLObjectsViewModel mv = new MLObjectsViewModel(item.id, item.nombre, 2);
                //RELACIONAR CADA UNO DE LOS SISTEMAS CON EL OBJETO RAIZ
                root.Children.Add(mv);

                //OBTENER TODOS LOS CONJUNTOS DE CADA UNO DE LOS SISTEMAS
                var Cs = daoMl.GetConjuntos(item.id);

                //ITERAR CON CADA CONJUNTO DE CADA SISTEMA SELECCIONADO
                foreach (var itemC in Cs)
                {
                    //CREAR NUEVO OBJETO CON CADA UNO DE LOS CONJUNTOS
                    MLObjectsViewModel mvC = new MLObjectsViewModel(itemC.id, itemC.nombre, 3);
                    //RELACIONAR CADA UNO DE LOS CONJUNTOS CON EL SISTEMA CORRESPONDIENTE
                    mv.Children.Add(mvC);

                    //OBTENER TODOS LOS COMPONENTES DE CADA UNO DE LOS CONJUNTOS
                    var Ccs = daoMl.GetComponentes(itemC.id, 0);
                    //ITERAR CON CADA COMPONENTE DE CADA CONJUNTO SELECCIONADO
                    foreach (var itemCss in Ccs)
                    {
                        //CREAR NUEVO OBJETO CON CADA UNO DE LOS COMPONENTES
                        MLObjectsViewModel mvCc = new MLObjectsViewModel(itemCss.id, itemCss.descripcion, 4);
                        //RELACIONAR CADA UNO DE LOS COMPONENTES CON EL CONJUNTOI CORRESPONDIENTE
                        mvC.Children.Add(mvCc);
                    }
                }
            }

            root.Initialize();
            e.Result = new List<MLObjectsViewModel> { root };
        }

        
        public MLObjectsViewModel(int ms)
        {
            //COMANDO PARA LA ACCIÓN DEL BOTÓN
            CmdDuplicate = new DelegateCommand(this.Duplicar);

            //BWORKER PARA LA CARGA INICIAL
            _worker = new BackgroundWorker();
            _worker.DoWork += BgLoad_DoWork;
            _worker.RunWorkerCompleted += BgLoad_RunWorkerCompleted;

            //BWORKER PARA DUPLICAR OBJETOS
            _worker_dup = new BackgroundWorker();
            _worker_dup.DoWork += _worker_dup_DoWork; ;
            _worker_dup.RunWorkerCompleted += _worker_dup_RunWorkerCompleted; ;

            //INICIAR TRABAJO CON WORKER
            if (!_worker.IsBusy)
            {
                splash.Show();
                _worker.RunWorkerAsync(ms);
            }           
        }

        private void _worker_dup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        private void _worker_dup_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        MLObjectsViewModel(string name)
        {
            Name = name;            
            Children = new List<MLObjectsViewModel>();
        }

        MLObjectsViewModel(int id, string name, int type)
        {
            Id = id;
            Name = name;
            Type = type;
            Children = new List<MLObjectsViewModel>();
        }

        #endregion

        #region Properties              

        private List<MLObjectsViewModel> _children;
        public List<MLObjectsViewModel> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                onPropertyChanged("Children");
            }
        }


        public int Id { get; private set; }
        public bool IsInitiallySelected { get; private set; }

        public string Name { get; private set; }

        public int Type { get; private set; }

        #endregion
        
        #region IsChecked

        public bool? IsChecked
        {
            get => _isChecked;
            set => SetIsChecked(value, true, true);
        }
        public int SisCount
        {
            get => _sisCount;
            set
            {
                _sisCount = value;
                onPropertyChanged("SisCount");
            }
        }

        void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {            

            if (value == _isChecked)
                return;
        
            _isChecked = value;

            if (updateChildren && _isChecked.HasValue)
                this.Children.ForEach(c => c.SetIsChecked(_isChecked, true, false));

            if (updateParent && _parent != null)
                _parent.VerifyCheckState();
                      
            this.onPropertyChanged("IsChecked");            
        }

        void VerifyCheckState()
        {
            bool? state = null;
            for (int i = 0; i < this.Children.Count; ++i)
            {
                bool? current = this.Children[i].IsChecked;
                if (i == 0)
                {
                    state = current;
                }
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }
            this.SetIsChecked(state, false, true);
        }
        #endregion

        #region INotifyPropertyChanged Members

        void onPropertyChanged(string prop)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
