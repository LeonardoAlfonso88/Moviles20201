<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Producto extends Model
{
    protected $table = 'productos';
    protected $primaryKey = 'idProducto';
    protected $fillable = ['idProducto','precio','tamaño','referencia','unidad','idCategoria'];
    public $timestamps = false;

    public function categoria()
    {
        return $this->belongsTo('App\Models\Categoria','idCategoria');
    }
}
