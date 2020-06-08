using AppGestionTiendas.Configuracion;
using AppGestionTiendas.Models;
using AppGestionTiendas.Models.ModelosAuxiliares;
using AppGestionTiendas.Servicios.ApiRest;
using AppGestionTiendas.Servicios.Propagacion;
using AppGestionTiendas.Validations.Base;
using AppGestionTiendas.Validations.Rules;
using AppGestionTiendas.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionTiendas.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        #region Properties

        #region Attributes
        public ValidatableObject<string> BusquedaCategoria { get; set; }  //Campo de Busqueda
        public ValidatableObject<string> NombreCategoria { get; set; }

        private CategoriaModel categoria; 

        public MessageViewPop PopUp { get; set; }

        private bool isGuardarEnable;

        private bool isEliminarEnable;

        private bool isGuardarEditar;

        private bool isBuscarEnable;

        private ObservableCollection<CategoriaModel> categorias;
        #endregion Attributes

        #region Requests
        public ElegirRequest<BaseModel> GetCategorias { get; set; }
        public ElegirRequest<BaseModel> GetCategoria { get; set; }
        public ElegirRequest<CategoriaModel> CreateCategoria { get; set; }
        public ElegirRequest<CategoriaModel> EditarCategoria { get; set; }
        public ElegirRequest<BaseModel> EliminarCategoria { get; set; }
        #endregion Requests

        #region Commands
        public ICommand ListaCategoriasCommand { get; set; }
        public ICommand SelectCategoriaCommand { get; set; }
        public ICommand CrearCategoriaCommand { get; set; }
        public ICommand EliminarCategoriaCommand { get; set; }
        public ICommand NuevaCategoriaCommand { get; set; }
        public ICommand ValidateBusquedaCommand { get; set; }
        public ICommand ValidateNombreCategoriaCommand { get; set; }

        #endregion Commands

        #endregion Properties

        #region Getters & Setters

        public CategoriaModel Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                OnPropertyChanged();
            }
        }
        public bool IsGuardarEnable
        {
            get { return isGuardarEnable; }
            set
            {
                isGuardarEnable = value;
                OnPropertyChanged();
            }
        }
        public bool IsEliminarEnable
        {
            get { return isEliminarEnable; }
            set
            {
                isEliminarEnable = value;
                OnPropertyChanged();
            }
        }
        public bool IsGuardarEditar
        {
            get { return isGuardarEditar; }
            set
            {
                isGuardarEditar = value;
                OnPropertyChanged();
            }
        }
        public bool IsBuscarEnable
        {
            get { return isBuscarEnable; }
            set
            {
                isBuscarEnable = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CategoriaModel> Categorias
        {
            get { return categorias; }
            set
            {
                categorias = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters

        #region Initialize
        public CategoryViewModel()
        {
            PopUp = new MessageViewPop();
            Categoria = new CategoriaModel();
            IsGuardarEnable = false;
            IsEliminarEnable = false;
            IsGuardarEditar = false;
            IsBuscarEnable = false;
            Categorias = new ObservableCollection<CategoriaModel>();
            InitializeRequest();
            InitializeCommands();
            InitializeFields();
        }

        public void InitializeRequest()
        {
            string urlCategorias = Endpoints.URL_SERVIDOR + Endpoints.CONSULTAR_ALL_CATEGORIAS;
            string urlCategoria = Endpoints.URL_SERVIDOR + Endpoints.CONSULTAR_CATEGORIA;
            string urlCrearCategoria = Endpoints.URL_SERVIDOR + Endpoints.CREAR_CATEGORIA;
            string urlEditarCategoria = Endpoints.URL_SERVIDOR + Endpoints.EDITAR_CATEGORIA;
            string urlEliminarCategoria = Endpoints.URL_SERVIDOR + Endpoints.ELIMINAR_CATEGORIA;

            GetCategorias = new ElegirRequest<BaseModel>();
            GetCategorias.ElegirEstrategia("GET", urlCategorias);

            GetCategoria = new ElegirRequest<BaseModel>();
            GetCategoria.ElegirEstrategia("GET", urlCategoria);

            CreateCategoria = new ElegirRequest<CategoriaModel>();
            CreateCategoria.ElegirEstrategia("POST", urlCrearCategoria);

            EditarCategoria = new ElegirRequest<CategoriaModel>();
            EditarCategoria.ElegirEstrategia("PUT", urlEditarCategoria);

            EliminarCategoria = new ElegirRequest<BaseModel>();
            EliminarCategoria.ElegirEstrategia("DELETE", urlEliminarCategoria);
        }
        public void InitializeCommands()
        {
            ListaCategoriasCommand = new Command(async () => await ListaCategorias(), () => true);
            SelectCategoriaCommand = new Command(async () => await SelecccionarCategoria(), () => IsBuscarEnable);
            CrearCategoriaCommand = new Command(async () => await GuardarCategoria(), () => IsGuardarEnable);
            EliminarCategoriaCommand = new Command(async () => await DeleteCategoria(), () => IsEliminarEnable);
            NuevaCategoriaCommand = new Command(() => NuevaCategoria(), () => true);
            ValidateBusquedaCommand = new Command(() => ValidateBusquedaForm(), () => true);
            ValidateNombreCategoriaCommand = new Command(() => ValidateNombreCategoriaForm(), () => true);
        }
        public void InitializeFields()
        {
            BusquedaCategoria = new ValidatableObject<string>();
            NombreCategoria = new ValidatableObject<string>();

            BusquedaCategoria.Validations.Add(new RequiredRule<string> { ValidationMessage = "El Id es Obligatorio" });
            NombreCategoria.Validations.Add(new RequiredRule<string> { ValidationMessage = "El nombre de la categoria es Obligatorio" });
        }
        #endregion Initialize

        public async Task ListaCategorias()
        {
            //var navigationStack = App.Current.MainPage.Navigation.NavigationStack;
            //var x = 1;
            //APIResponse response = await GetCategorias.EjecutarEstrategia(null);
            //if(response.IsSuccess)
            //{
            //    List<CategoriaModel> listaCategorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(response.Response);
            //    Categorias = new ObservableCollection<CategoriaModel>(listaCategorias);
            //}
            //else
            //{
            //    ((MessageViewModel)PopUp.BindingContext).Message = "Error al cargar las categorías";
            //    await PopupNavigation.Instance.PushAsync(PopUp);
            //}
            //await NavigationService.RemovePreviousPage();
            //var navigationStack2 = App.Current.MainPage.Navigation.NavigationStack;
            //var y = 3;
            LoginViewModel LoginViewModel = (LoginViewModel)NavigationService.PreviousViewModel;
            LoginViewModel.ContarLogin += 1;
            await NavigationService.PopPage();
        }

        #region Methods
        public async Task SelecccionarCategoria()
        {
            try
            {
                ParametersRequest parametros = new ParametersRequest();
                parametros.Parametros.Add(BusquedaCategoria.Value);
                APIResponse response = await GetCategoria.EjecutarEstrategia(null, parametros);
                if (response.IsSuccess)
                {
                    Categoria = JsonConvert.DeserializeObject<CategoriaModel>(response.Response);
                    NombreCategoria.Value = Categoria.Categoria;
                    IsEliminarEnable = true;
                    IsGuardarEnable = true;
                    IsGuardarEditar = true;
                    ((Command)CrearCategoriaCommand).ChangeCanExecute();
                    ((Command)EliminarCategoriaCommand).ChangeCanExecute();
                }
                else
                {
                    
                    ((MessageViewModel)PopUp.BindingContext).Message = "No se encuentra esa categoría";
                    await PopupNavigation.Instance.PushAsync(PopUp);
                }
            }
            catch (Exception e)
            {

            }
        }

        private async Task GuardarCategoria()
        {
            if(Categoria.IdCategoria == 0)
            {
                await CrearCategoria();
                IsGuardarEnable = false;
                ((Command)CrearCategoriaCommand).ChangeCanExecute();
            }
            else
            {
                await UpdateCategoria();
                IsEliminarEnable = false;
                ((Command)EliminarCategoriaCommand).ChangeCanExecute();
            }
            IsGuardarEditar = false;
            Categoria = new CategoriaModel();
            NombreCategoria.Value = "";
            BusquedaCategoria.Value = "";
        }
        public async Task CrearCategoria()
        {
            try
            {
                CategoriaModel categoria = new CategoriaModel()
                {
                    Categoria = NombreCategoria.Value
                };
                APIResponse response = await CreateCategoria.EjecutarEstrategia(categoria);
                if (response.IsSuccess)
                {
                    ((MessageViewModel)PopUp.BindingContext).Message = "Categoría creada exitosamente";
                    await PopupNavigation.Instance.PushAsync(PopUp);
                }
                else
                {
                    ((MessageViewModel)PopUp.BindingContext).Message = "Error al crear la categoría";
                   await PopupNavigation.Instance.PushAsync(PopUp);
                }
            }
            catch (Exception e)
            {

            }
        }

        public async Task UpdateCategoria()
        {
            try
            {
                CategoriaModel categoria = new CategoriaModel()
                {
                    IdCategoria = Categoria.IdCategoria,
                    Categoria = NombreCategoria.Value
                };
                ParametersRequest parametros = new ParametersRequest();
                parametros.Parametros.Add(categoria.IdCategoria.ToString());
                APIResponse response = await EditarCategoria.EjecutarEstrategia(categoria, parametros);
                if (response.IsSuccess)
                {
                    ((MessageViewModel)PopUp.BindingContext).Message = "Categoría actualizada exitosamente";
                    await PopupNavigation.Instance.PushAsync(PopUp);
                }
                else
                {
                    ((MessageViewModel)PopUp.BindingContext).Message = "Error al actualizar la categoría";
                    await PopupNavigation.Instance.PushAsync(PopUp);
                }
            }
            catch (Exception e)
            {

            }
        }

        public async Task DeleteCategoria()
        {
            try
            {
                ParametersRequest parametros = new ParametersRequest();
                parametros.Parametros.Add(Categoria.IdCategoria.ToString());
                APIResponse response = await EliminarCategoria.EjecutarEstrategia(null, parametros);
                if (response.IsSuccess)
                {
                    ((MessageViewModel)PopUp.BindingContext).Message = "Categoría eliminada exitosamente";
                    await PopupNavigation.Instance.PushAsync(PopUp);
                }
                else
                {
                    ((MessageViewModel)PopUp.BindingContext).Message = "Error al eliminar la categoría";
                    await PopupNavigation.Instance.PushAsync(PopUp);
                }
            }
            catch (Exception e)
            {

            }
        }
        public void NuevaCategoria()
        {
            Categoria = new CategoriaModel();
            NombreCategoria.Value = "";
            BusquedaCategoria.Value = "";
            IsEliminarEnable = false;
            IsGuardarEditar = true;
            ((Command)EliminarCategoriaCommand).ChangeCanExecute();
        }
        private void ValidateBusquedaForm()
        {
            IsBuscarEnable = BusquedaCategoria.Validate();
            ((Command)SelectCategoriaCommand).ChangeCanExecute();
        }

        private void ValidateNombreCategoriaForm()
        {
            IsGuardarEnable = NombreCategoria.Validate();
            ((Command)CrearCategoriaCommand).ChangeCanExecute();
        }
        #endregion Methods
    }
}
