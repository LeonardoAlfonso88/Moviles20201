<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Categoria;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Illuminate\Database\QueryException;

class CategoriaController extends Controller
{
    public function create(Request $request)
    {
        try
        {
            $categoria = new Categoria();
            $categoria->categoria = $request->categoria;
            $categoria->save();
            return response(null, 201);
        }
        catch(QueryException $e)
        {
            return response($e->getMessage(), 400);
        }
    }

    public function delete($idCategoria)
    {
        try
        {
            $categoria = Categoria::findOrFail($idCategoria);
            $categoria->delete();
            return response(null, 200);
        }
        catch(QueryException $e)
        {
            return response(null, 400);
        }
        catch(ModelNotFoundException $e)
        {
            return response(null, 404);
        }

    }

    public function getCategoria($idCategoria)
    {
        try
        {
            $categoria = Categoria::findOrFail($idCategoria);
            return response($categoria, 200);
        }
        catch(QueryException $e)
        {
            return response(null, 400);
        }
        catch(ModelNotFoundException $e)
        {
            return response(null, 404);
        }
    }

    public function allCategorias()
    {
        try
        {
            $categorias = Categoria::all();
            return response($categorias, 200);
        }
        catch(QueryException $e)
        {
            return response(null, 400);
        }
    }

    public function update(Request $request, $idCategoria)
    {
        try
        {
            $categoria = Categoria::findOrFail($idCategoria);
            $categoria->categoria = $request->categoria;
            $categoria->save();
            return response(null, 202);
        }
        catch(QueryException $e)
        {
            return response(null, 401);
        }
        catch(ModelNotFoundException $e)
        {
            return response(null, 404);
        }
    }
}
