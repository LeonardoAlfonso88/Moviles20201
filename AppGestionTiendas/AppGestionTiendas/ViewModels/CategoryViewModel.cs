using AppGestionTiendas.Configuracion;
using AppGestionTiendas.Models;
using AppGestionTiendas.Models.ModelosAuxiliares;
using AppGestionTiendas.Servicios.ApiRest;
using AppGestionTiendas.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionTiendas.ViewModels
{
    public class CategoryViewModel : NotificationObject
    {
        public ElegirRequest<BaseModel> GetCategorias { get; set; }
        public ElegirRequest<BaseModel> GetCategoria { get; set; }
        public ElegirRequest<CategoriaModel> CreateCategoria { get; set; }
        public ElegirRequest<CategoriaModel> EditarCategoria { get; set; }
        public ElegirRequest<BaseModel> EliminarCategoria { get; set; }

        public ICommand ListaCategoriasCommand { get; set; }
        public ICommand SelectCategoriaCommand { get; set; }
        public ICommand CrearCategoriaCommand { get; set; }
        public ICommand EditarCategoriaCommand { get; set; }
        public ICommand EliminarCategoriaCommand { get; set; }

        

        public CategoryViewModel()
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

            ListaCategoriasCommand = new Command(async () => await ListaCategorias(), () => true);
            SelectCategoriaCommand = new Command(async () => await SelecccionarCategoria(), () => true);
            CrearCategoriaCommand = new Command(async () => await CrearCategoria(), () => true);
            EditarCategoriaCommand = new Command(async () => await UpdateCategoria(), () => true);
            EliminarCategoriaCommand = new Command(async () => await DeleteCategoria(), () => true);
        }

        public async Task ListaCategorias()
        {
            APIResponse response = await GetCategorias.EjecutarEstrategia(null);
            List<CategoriaModel> Categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(response.Response);
        }

        public async Task SelecccionarCategoria()
        {
            ParametersRequest parametros = new ParametersRequest();
            parametros.Parametros.Add("3");
            APIResponse response = await GetCategoria.EjecutarEstrategia(null, parametros);
            CategoriaModel categoria = JsonConvert.DeserializeObject<CategoriaModel>(response.Response);
        }

        public async Task CrearCategoria()
        {
            CategoriaModel categoria = new CategoriaModel()
            {
                Categoria = "Aseo"
            };

            APIResponse response = await CreateCategoria.EjecutarEstrategia(categoria);
        }

        public async Task UpdateCategoria()
        {
            CategoriaModel categoria = new CategoriaModel()
            {
                IdCategoria = 3,
                Categoria = "Hogar" 
            };
            ParametersRequest parametros = new ParametersRequest();
            parametros.Parametros.Add("3");
            APIResponse response = await EditarCategoria.EjecutarEstrategia(categoria, parametros);
        }

        public async Task DeleteCategoria()
        {
            ParametersRequest parametros = new ParametersRequest();
            parametros.Parametros.Add("5");
            APIResponse response = await EliminarCategoria.EjecutarEstrategia(null, parametros);
        }
    }
}
