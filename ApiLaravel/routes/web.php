<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Route::post('/create',"CategoriaController@create");
Route::delete('/delete/{idCategoria}',"CategoriaController@delete");
Route::get('/get/{idCategoria}',"CategoriaController@getCategoria");
Route::get('/all',"CategoriaController@allCategorias");
Route::put('/update/{idCategoria}',"CategoriaController@update");
Route::post('/createProducto',"ProductoController@create");
Route::get('/getProducto/{idProducto}',"ProductoController@consultaProducto");

