<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Producto;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Illuminate\Database\QueryException;

class ProductoController extends Controller
{
    public function create(Request $request)
    {
        try
        {
            $producto = new Producto();
            $producto->precio = $request->precio;
            $producto->tamaño = $request->tamaño;
            $producto->referencia = $request->referencia;
            $producto->unidad = $request->unidad;
            $producto->idCategoria = $request->idCategoria;
            $producto->save();
            return response(null, 201);
        }
        catch(QueryException $e)
        {
            return response($e->getMessage(), 400);
        }
    }

    public function consultaProducto($idProducto)
    {
        try
        {
            $producto = Producto::with('categoria')->findOrFail($idProducto);
            return response($producto, 200);
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
}
